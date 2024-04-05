using Microsoft.AspNetCore.Http;
using Shop.Domain.Models.Account;
using Shop.Domain.ViewModels.Account;

namespace Shop.Application.Interfaces;

public interface IUserService
{
    #region account

    Task<RegisterUserResult> RegisterUser(RegisterUserViewModel register);
    Task<LoginUserResult> LoginUser(LoginUserViewModel login);
    
    Task<User> GetUserByPhoneNumber(string phoneNumber);

    Task<ActiveAccountResult> ActiveAccount(ActiveAccountViewModel activeAccount);
    Task<User> GetUserById(long userId);

    #endregion

    #region profile

    Task<EditUserProfileViewModel> GetEditUserprofile(long userId);
    Task<EditUserProfileResult> EditProfile(long userId, IFormFile userAvatar,
        EditUserProfileViewModel editUserProfile);

    Task<ChangePasswordResult> ChangePassword(long userId, ChangePasswordViewModel changePassword);

    #endregion
}
