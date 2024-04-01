using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Shop.Domain.Models.Account;

namespace Shop.Infra.Data.Context;

public class ShopDbContext : DbContext
{
    #region constractor

    public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
    {
    }

    #endregion


    #region User

    public DbSet<User> Users { get; set; }

    #endregion
}