using DataAccess.Models;

namespace DataAccess.Interfaces
{
    public interface IManageAccountsRepositories
    {
        public Task<IEnumerable<AccountModel>> GetAllAccount();

        public Task<AccountModel> CreateAccount(AccountModel account);

        public Task<IEnumerable<AccountRoles>> GetAccountRoles(int AccountId);

        public Task<AccountModel> UpdateAccount(AccountModel account, List<RoleModel> rolesList);

        public Task DeleteAccount(int Id);
    }
}
