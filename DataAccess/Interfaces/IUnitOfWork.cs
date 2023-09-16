namespace DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        IReportRepositories Report { get; }
        IAuthRepositories Auth { get; }
        IAccountRepositories Account { get; }
    }
}
