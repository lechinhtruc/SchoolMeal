using DataAccess.Data;
using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class ManageAccountsRepositories : IManageAccountsRepositories
    {
        private readonly ApplicationDbContext _db;
        public ManageAccountsRepositories(ApplicationDbContext db)
        {
            _db = db;
        }

        private bool IsExitsAccount(string Username)
        {
            var account = _db.Tbl_Account.FirstOrDefault(x => x.Username == Username);
            return account != null;
        }

        public async Task<IEnumerable<AccountModel>> GetAllAccount()
        {
            var accounts = await _db.Tbl_Account.ToListAsync();
            return accounts;
        }

        public async Task<AccountModel> CreateAccount(AccountModel account)
        {
            if (!IsExitsAccount(account.Username))
            {
                account.Password = AccountModel.HashPassword(account.Password);
                await _db.Tbl_Account.AddAsync(account);
                await _db.SaveChangesAsync();
            }
            return account;
        }

        public async Task<AccountModel> UpdateAccount(AccountModel account, List<RoleModel> rolesList)
        {
            await _db.Tbl_AccountRoles.Where(x => x.AccountId == account.Id).ExecuteDeleteAsync();
            rolesList.ForEach(async rolesList =>
            {
                if (rolesList.IsChecked) await _db.Tbl_AccountRoles.AddAsync(new AccountRoles()
                {
                    AccountId = account.Id,
                    ActionName = rolesList.ActionName
                });
            });
            _db.Tbl_Account.Update(account);
            await _db.SaveChangesAsync();
            return account;
        }

        public async Task<IEnumerable<AccountRoles>> GetAccountRoles(int AccountId)
        {
            var accountRoles = await _db.Tbl_AccountRoles.Where(account => account.AccountId == AccountId).ToListAsync();
            return accountRoles;
        }

        public async Task DeleteAccount(int Id)
        {
            await _db.Tbl_Account.Where(account => account.Id == Id).ExecuteDeleteAsync();
            await _db.SaveChangesAsync();
        }
    }
}
