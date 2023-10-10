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

        public async Task<IEnumerable<AccountModel>> GetAllAccount()
        {
            var accounts = await _db.Tbl_Account.ToListAsync();
            return accounts;
        }

        public async Task DeleteAccount(int Id)
        {
            var account = await _db.Tbl_Account.FindAsync(Id);
            if (account != null)
            {
                _db.Tbl_Account.Remove(account);
                _db.SaveChanges();
            }
        }
    }
}
