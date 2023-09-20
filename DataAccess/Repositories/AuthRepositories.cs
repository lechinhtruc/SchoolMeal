using DataAccess.Data;
using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class AuthRepositories : IAuthRepositories
    {
        private readonly ApplicationDbContext _db;
        public AuthRepositories(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<AccountModel> Login(string Username, string Password)
        {
            var user = await _db.Tbl_Account.FirstOrDefaultAsync(x => x.Username == Username && x.Password == Password);
            return user ?? new AccountModel();
        }

    }
}
