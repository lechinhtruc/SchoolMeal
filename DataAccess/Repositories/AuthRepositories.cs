using DataAccess.Data;
using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var user = await _db.Tbl_account.FirstOrDefaultAsync(x => x.Username == Username && x.Password == Password);
            return user ?? new AccountModel();
        }
    }
}
