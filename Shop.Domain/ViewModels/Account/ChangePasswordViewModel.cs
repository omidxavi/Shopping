using System.ComponentModel.DataAnnotations;

namespace Shop.Domain.ViewModels.Account;

public class ChangePasswordViewModel
{
    [Display(Name = "نام")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(200, ErrorMessage = "نمیتواند بیشتر از {1} کاراکتر باشد {0}")]
    public string CurrentPassword { get; set; }
    [Display(Name = "نام")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(200, ErrorMessage = "نمیتواند بیشتر از {1} کاراکتر باشد {0}")]
    public string NewPassword { get; set; }
    [Display(Name = "نام")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(200, ErrorMessage = "نمیتواند بیشتر از {1} کاراکتر باشد {0}")]
    [Compare("NewPassword" , ErrorMessage = "کلمه عبور جدید و تکرار آن با هم مغایرت دارند")]
    public string ConfirmNewPassword { get; set; }
}

public enum ChangePasswordResult
{
    NotFound,
    PasswordEqual,
    Success
}