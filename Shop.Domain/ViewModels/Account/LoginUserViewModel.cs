using System.ComponentModel.DataAnnotations;

namespace Shop.Domain.ViewModels.Account;

public class LoginUserViewModel
{
    [Display(Name = "شماره تلفن همراه")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(200, ErrorMessage = "نمیتواند بیشتر از {1} کاراکتر باشد {0}")]
    public string PhoneNumber { get; set; }

    [Display(Name = "گذرواژه")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(200, ErrorMessage = "نمیتواند بیشتر از {1} کاراکتر باشد {0}")]
    public string Password { get; set; }

    [Display(Name = "مرا به خاطر بسپار")]
    public bool RememberMe { get; set; }
}

public enum LoginUserResult
{
    NotFound,
    NotActive,
    Success,
    IsBlocked
}