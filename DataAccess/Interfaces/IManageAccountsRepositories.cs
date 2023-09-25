using DataAccess.Models;

namespace DataAccess.Interfaces
{
    public interface IManageAccountsRepositories
    {
        public Task<IEnumerable<AccountModel>> GetAllAccount();

        public Task DeleteAccount(int Id);
    }
}
