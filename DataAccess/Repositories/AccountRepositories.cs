using DataAccess.Data;
using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class AccountRepositories : IAccountRepositories
    {
        private readonly ApplicationDbContext _db;

        public AccountRepositories(ApplicationDbContext db)
        {
            _db = db;
        }

        private bool IsExitsAccount(string Username)
        {
            var account = _db.Tbl_Account.FirstOrDefault(x => x.Username == Username);
            if (account == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> ChangePassword(int Id, string OldPassword, string NewPassword)
        {
            var user = await _db.Tbl_Account.FirstOrDefaultAsync(x => x.Id == Id && x.Password == AccountModel.HashPassword(OldPassword));
            if (user != null)
            {
                user.Password = AccountModel.HashPassword(NewPassword);
                await _db.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public AccountModel CreateAccount(AccountModel account)
        {
            if (!IsExitsAccount(account.Username))
            {
                account.Password = AccountModel.HashPassword(account.Password);
                _db.Tbl_Account.Add(account);
                _db.SaveChanges();
            }
            return account;
        }

        public async Task<AccountModel> GetAccountInfomation(int Id)
        {
            var infomation = await _db.Tbl_Account.FirstOrDefaultAsync(x => x.Id == Id);
            return infomation ?? new AccountModel();
        }

        public async Task<AccountModel> UpdateAccount(AccountModel account)
        {
            if (!IsExitsAccount(account.Username))
            {
                _db.Tbl_Account.Update(account);
                await _db.SaveChangesAsync();
            }
            return account;
        }

        public async Task<IEnumerable<AccountRoles>> GetAccountRoles(int AccountId)
        {
            var accountRoles = await _db.Tbl_AccountRoles.Where(account => account.AccountId == AccountId).ToListAsync();
            return accountRoles;
        }
    }
}
