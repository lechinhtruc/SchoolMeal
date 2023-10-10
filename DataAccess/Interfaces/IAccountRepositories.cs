﻿using DataAccess.Models;

namespace DataAccess.Interfaces
{
    public interface IAccountRepositories
    {
        public AccountModel CreateAccount(AccountModel account);

        public Task<bool> ChangePassword(int Id, string OldPassword, string NewPassword);

        public Task<AccountModel> GetAccountInfomation(int Id);

        public Task<IEnumerable<AccountRoles>> GetAccountRoles(int AccountId);

        public Task<AccountModel> UpdateAccount(AccountModel account);
    }
}
