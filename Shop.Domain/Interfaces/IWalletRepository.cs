using Shop.Domain.Models.Wallet;
using Shop.Domain.ViewModels.Wallet;

namespace Shop.Domain.Interfaces;

public interface IWalletRepository
{
    Task CreateWallet(UserWallet userWallet);
    Task<UserWallet> GetUserWalletById(long walletId);
    void UpdateWallet(UserWallet wallet);
    Task SaveChange();
}