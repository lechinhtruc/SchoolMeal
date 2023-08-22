namespace DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        IReportRepositories Report { get; }
    }
}
