using Microsoft.Extensions.DependencyInjection;
using Shop.Application.Interfaces;
using Shop.Application.Services;
using Shop.Domain.Interfaces;
using Shop.Infra.Data.Repositories;

namespace Shop.Infra.Ioc;

public class DependencyContainer
{
    public static void RegisterService(IServiceCollection services)
    {
        #region services

        services.AddScoped<IUserService, UserService>();

        #endregion

        #region repositories

        services.AddScoped<IUserRepository, UserRepository>();

        #endregion

        #region tools

        services.AddScoped<IPasswordHelper, PasswordHelper>();

        #endregion
    }
}