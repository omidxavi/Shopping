﻿using Shop.Domain.Models.Account;

namespace Shop.Domain.Interfaces;

public interface IUserRepository
{
    #region account

    Task<bool> IsUserExistPhoneNumber(string phoneNumber);
    Task CreateUser(User user);
    Task SaveChanges();
    Task<User> GetUserByPhoneNumber(string phoneNumber);

    void UpdateUser(User user);
    Task<User> GetUserById(long userId);

    #endregion

}