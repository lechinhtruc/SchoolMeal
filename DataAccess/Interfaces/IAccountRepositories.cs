namespace DataAccess.Interfaces
{
    public interface IAccountRepositories
    {
        public Task<bool> ChangePassword(int Id, string OldPassword, string NewPassword);
    }
}
