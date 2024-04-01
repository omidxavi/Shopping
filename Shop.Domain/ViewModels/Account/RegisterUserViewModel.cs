using System.ComponentModel.DataAnnotations;

namespace Shop.Domain.ViewModels.Account;

public class RegisterUserViewModel
{
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
    
    [Display(Name = "تکرار گذرواژه")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(200, ErrorMessage = "نمیتواند بیشتر از {1} کاراکتر باشد {0}")]
    [Compare("Password",ErrorMessage = "کلمه ی عبور مغایرت دارد")]
    public string confirmPassword { get; set; }
}

public enum RegisterUserResult
{
    MobileExists,
    Success
}