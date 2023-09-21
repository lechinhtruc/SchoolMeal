using DataAccess.Models;

namespace DataAccess.Interfaces
{
    public interface IAccountRepositories
    {
        public Task<bool> ChangePassword(int Id, string OldPassword, string NewPassword);

        public Task<AccountModel> GetAccountInfomation(int Id);
    }
}
