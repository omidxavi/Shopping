using Microsoft.EntityFrameworkCore;
using Shop.Domain.Interfaces;
using Shop.Domain.Models.Account;
using Shop.Infra.Data.Context;

namespace Shop.Infra.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ShopDbContext _context;

    #region constractor

    public UserRepository(ShopDbContext context)
    {
        _context = context;
    }

    #endregion

    #region account

    public async Task<bool> IsUserExistPhoneNumber(string phoneNumber)
    {
        return await _context.Users.AsQueryable().AnyAsync(c => c.PhoneNumber == phoneNumber);
    }

    public async Task CreateUser(User user)
    {
        await _context.Users.AddAsync(user);
    }
    
    public async Task<User> GetUserByPhoneNumber(string phoneNumber)
    {
        return await _context.Users.AsQueryable().SingleOrDefaultAsync(c => c.PhoneNumber == phoneNumber);
    }

    public void UpdateUser(User user)
    {
        _context.Users.Update(user);
    }

    public async Task<User> GetUserById(long userId)
    {
        return await _context.Users.AsQueryable().SingleOrDefaultAsync(c => c.Id == userId);
    }

    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }



    #endregion
}