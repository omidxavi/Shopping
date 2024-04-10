using Microsoft.EntityFrameworkCore;
using Shop.Domain.Interfaces;
using Shop.Domain.Models.Wallet;
using Shop.Domain.ViewModels.Paging;
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

    public async Task<FilterWalletViewModel> FilterWallets(FilterWalletViewModel filter)
    {
        var query = _context.UserWallets.AsQueryable();

        #region filter

        if (filter.UserId !=0 && filter.UserId != null)
        {
            query = query.Where(c => c.UserId == filter.UserId);
        }
        #endregion

        #region paging

        var pager = Pager.Build(filter.PageId, await query.CountAsync(), filter.TakeEntity,
            filter.CountForShowAfterAndBefore);
        var allData = await query.Paging(pager).ToListAsync();
        return filter.SetPaging(pager).SetWallets(allData);

        #endregion
    }


    public async Task SaveChange()
    {
        await _context.SaveChangesAsync();
    }

    #endregion

}