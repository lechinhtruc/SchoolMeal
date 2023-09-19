using DataAccess.Data;
using DataAccess.Interfaces;
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

        public async Task<bool> ChangePassword(int Id, string OldPassword, string NewPassword)
        {
            var user = await _db.Tbl_account.FirstOrDefaultAsync(x => x.Id == Id && x.Password == OldPassword);
            if (user != null)
            {
                user.Password = NewPassword;
                await _db.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
