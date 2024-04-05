using Shop.Domain.Models.Account;

namespace Shop.Application.Extensions;

public static class UserExtensions
{
    public static string GetUserName(this User user)
    {
        // if (!string.IsNullOrWhiteSpace(user.FirstName) && !string.IsNullOrWhiteSpace(user.LastName))
        // {
        //     return $"{user.FirstName} {user.LastName}";
        // }
        //
        // return user.PhoneNumber;
        return $"{user.FirstName} {user.LastName}";
    }
}