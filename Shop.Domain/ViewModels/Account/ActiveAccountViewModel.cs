using System.ComponentModel.DataAnnotations;
using Shop.Domain.ViewModels.Site;

namespace Shop.Domain.ViewModels.Account;

public class ActiveAccountViewModel : Recaptcha
{
    [Display(Name = "شماره تلفن همراه")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(200, ErrorMessage = "نمیتواند بیشتر از {1} کاراکتر باشد {0}")]
    public string PhoneNumber { get; set; }
    
    [Display(Name = "کد فعال سازی")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(50, ErrorMessage = "نمیتواند بیشتر از {1} کاراکتر باشد {0}")]
    public string ActiveCode { get; set; }
}

public enum ActiveAccountResult
{
    Error,
    Success,
    NotFound 
}