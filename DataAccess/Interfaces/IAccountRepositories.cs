using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IAccountRepositories
    {
        public Task<bool> ChangePassword(int Id, string OldPassword, string NewPassword);

        public Task<AccountModel> GetAccountInfomation(int Id);
    }
}
