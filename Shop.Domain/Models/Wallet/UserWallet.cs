using System.ComponentModel.DataAnnotations;
using Shop.Domain.Models.Account;
using Shop.Domain.Models.Account.BaseEntities;

namespace Shop.Domain.Models.Wallet;

public class UserWallet : BaseEntity
{
    #region prperties

    [Display(Name = "کاربر")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public long UserId { get; set; }
    [Display(Name = "نوع تراکنش")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public WalletType WalletType { get; set; }
    [Display(Name = "مبلغ")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public int Amount { get; set; }
    [Display(Name = "شرح")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(500, ErrorMessage = "نمیتواند بیشتر از {1} کاراکتر باشد {0}")]
    public string Description { get; set; }
    [Display(Name = "پرداخت شده/نشده")]
    public bool IsPaid { get; set; }

    #endregion

    #region relations

    public User User { get; set; }
    
    #endregion
}

public enum WalletType
{
    [Display(Name = "واریز")]
    Deposit = 1,
    [Display(Name = "برداشت")]
    Withdraw = 2
}