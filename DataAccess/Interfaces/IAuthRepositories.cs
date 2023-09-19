using DataAccess.Models;

namespace DataAccess.Interfaces
{
    public interface IAuthRepositories
    {
        public Task<AccountModel> Login(string Account, string Password);
    }
}
