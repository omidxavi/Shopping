using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Interfaces;
using Shop.Domain.ViewModels.Account;
using Shop.Domain.ViewModels.Wallet;
using Shop.Web.Extensions;
using ZarinpalSandbox;

namespace Shop.Web.Areas.User.Controllers;

public class AccountController : UserBaseController
{
    #region constractor

    private readonly IUserService _userService;
    private readonly IWalletService _walletService;
    private readonly IConfiguration _configuration;

    public AccountController(IUserService userService, IWalletService walletService, IConfiguration configuration)
    {
        _userService = userService;
        _walletService = walletService;
        _configuration = configuration;
    }

    #endregion

    #region edit user profile

    [HttpGet("edit-user-profile")]
    public async Task<IActionResult> EditUserProfile()
    {
        var user = await _userService.GetEditUserprofile(User.GetUserId());
        if (user == null) return NotFound();
        return View(user);
    }

    [HttpPost("edit-user-profile"), ValidateAntiForgeryToken]
    public async Task<IActionResult> EditUserProfile(EditUserProfileViewModel editUserProfile, IFormFile userAvatar)
    {
        if (ModelState.IsValid)
        {
            var result = await _userService.EditProfile(User.GetUserId(), userAvatar, editUserProfile);
            switch (result)
            {
                case EditUserProfileResult.NotFound:
                    TempData[WarningMessage] = "کاربری با مشخصات داده شده یافت نشد";
                    break;
                case EditUserProfileResult.Success:
                    TempData[SuccessMessage] = "عملیات ویرایش حساب کاربری با موفقیت انجام شد";
                    return RedirectToAction("EditUserProfile");
            }
        }

        return View(editUserProfile);
    }

    #endregion

    #region change password

    [HttpGet("change-password")]
    public IActionResult ChangePassword()
    {
        return View();
    }

    [HttpPost("change-password"), ValidateAntiForgeryToken]
    public async Task<IActionResult> ChangePassword(ChangePasswordViewModel changePassword)
    {
        if (!ModelState.IsValid) return View(changePassword);
        var result = await _userService.ChangePassword(User.GetUserId(), changePassword);
        switch (result)
        {
            case ChangePasswordResult.NotFound:
                TempData[WarningMessage] = "کاربری با مشخصات وارد شده یافت نشد";
                break;
            case ChangePasswordResult.PasswordEqual:
                TempData[InfoMessage] = "لطفا از کلمه عبور جدیدی استفاده کنید";
                ModelState.AddModelError("NewPassword", "لطفا از کلمه عبور جدیدی استفاده کنید");
                break;
            case ChangePasswordResult.Success:
                TempData[SuccessMessage] = "کلمه عبور شما با موفقیت تغییر یافت";
                TempData[InfoMessage] = "لطفا جهت تکمیل فرایند تغییر کلمه عبور مجدد وارد سایت شوید";

                await HttpContext.SignOutAsync();
                return RedirectToAction("Login", "Account", new { area = "" });
        }

        return View(changePassword);
    }

    #endregion

    #region charge account

    [HttpGet("charge-wallet")]
    public async Task<IActionResult> ChargeWallet()
    {
        //show transaction list for user 
        return View();
    }

    [HttpPost("charge-wallet"), ValidateAntiForgeryToken]
    public async Task<IActionResult> ChargeWallet(ChargeWalletViewModel chargeWallet)
    {
        if (ModelState.IsValid)
        {
            var walletId = await _walletService.ChargeWallet(User.GetUserId(), chargeWallet,
                $"charge value {chargeWallet.Amount}");

            #region payment

            var payment = new Payment(chargeWallet.Amount);
            var url = _configuration.GetSection("DefaultUrl")["Host"] + "/user/online-payment/" + walletId;
            var result = payment.PaymentRequest("شارژ کیف پول", url);
            if (result.Result.Status == 100)
            {
                return Redirect("https://sandbox.zarinpal.com/pg/StartPay/");
            }
            else
            {
                TempData[ErrorMessage] = "مشکلی پیش امده لطفا مجدد امتحان فرمایید";
            }

            #endregion
        }

        return View();
    }

    #endregion

    #region online paymeny

    [HttpGet("online-payment/{id}")]
    public async Task<IActionResult> OnlinePayment(long id)
    {
        if (HttpContext.Request.Query["Status"] != "" && HttpContext.Request.Query["Status"].ToString().ToLower() ==
                                                      "ok"
                                                      && HttpContext.Request.Query["Authority"] != "")
        {
            string authority = HttpContext.Request.Query["Authority"];
            var wallet = await _walletService.GetUserWalletById(id);
            if (wallet != null)
            {
                var payment = new Payment(wallet.Amount);
                var result = payment.Verification(authority).Result;
                if (result.Status == 100)
                {
                    ViewBag.RefId = result.RefId;
                    ViewBag.Success = true;
                    await _walletService.UpdateWalletForCharge(wallet);
                }

                return View();
            }

            return NotFound();
        }

        return View();
    }

    #endregion
}