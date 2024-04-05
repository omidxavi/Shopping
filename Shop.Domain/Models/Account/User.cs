using System.ComponentModel.DataAnnotations;
using Shop.Domain.Models.Account.BaseEntities;
using Shop.Domain.Models.Wallet;

namespace Shop.Domain.Models.Account;

public class User : BaseEntity
{

    #region properties

    [Display(Name = "نام")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(200, ErrorMessage = "نمیتواند بیشتر از {1} کاراکتر باشد {0}")]
    public string FirstName { get; set; }

    [Display(Name = "نام خانوادگی")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(200, ErrorMessage = "نمیتواند بیشتر از {1} کاراکتر باشد {0}")]
    public string LastName { get; set; }

    [Display(Name = "شماره تلفن همراه")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(200, ErrorMessage = "نمیتواند بیشتر از {1} کاراکتر باشد {0}")]
    public string PhoneNumber { get; set; }

    [Display(Name = "گذرواژه")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(200, ErrorMessage = "نمیتواند بیشتر از {1} کاراکتر باشد {0}")]
    public string Password { get; set; }

    [Display(Name = "آواتار")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(200, ErrorMessage = "نمیتواند بیشتر از {1} کاراکتر باشد {0}")]
    public string Avatar { get; set; }

    [Display(Name = "مسدود شده/ نشده")] 
    public bool IsBlocked { get; set; }

    [Display(Name = "کد احراز هویت")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(50, ErrorMessage = "نمیتواند بیشتر از {1} کاراکتر باشد {0}")]
    public string MobileActiveCode { get; set; }

    [Display(Name = "تایید شده/ نشده")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(200, ErrorMessage = "نمیتواند بیشتر از {1} کاراکتر باشد {0}")]
    public bool IsMobileActive { get; set; }

    [Display(Name = "جنسیت")] 
    public UserGender UserGender { get; set; }

    #endregion

    #region relations

    public ICollection<UserWallet> UserWallets { get; set; }

    #endregion
}

public enum UserGender
{
    [Display(Name = "آقا")] 
    Male,
    [Display(Name = "خانوم")]
    Female,
    [Display(Name = "نامشخص")]
    Unknown
}