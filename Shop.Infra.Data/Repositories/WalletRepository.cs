using Microsoft.EntityFrameworkCore;
using Shop.Domain.Interfaces;
using Shop.Domain.Models.Wallet;
using Shop.Domain.ViewModels.Wallet;
using Shop.Infra.Data.Context;

namespace Shop.Infra.Data.Repositories;

public class WalletRepository : IWalletRepository
{
    private readonly ShopDbContext _context;

    #region constractor

    public WalletRepository(ShopDbContext context)
    {
        _context = context;
    }

    #endregion


    #region wallet

    public async Task CreateWallet(UserWallet userWallet)
    {
        await _context.UserWallets.AddAsync(userWallet);
    }

    public async Task<UserWallet> GetUserWalletById(long walletId)
    {
        return await _context.UserWallets.AsQueryable().SingleOrDefaultAsync(c => c.Id == walletId);
    }

    public void UpdateWallet(UserWallet wallet)
    {
        _context.UserWallets.Update(wallet);
    }


    public async Task SaveChange()
    {
        await _context.SaveChangesAsync();
    }

    #endregion

}