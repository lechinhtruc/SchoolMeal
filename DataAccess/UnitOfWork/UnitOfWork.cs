using DataAccess.Data;
using DataAccess.Interfaces;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public IReportRepositories Report { get; }

        public IAuthRepositories Auth { get; }

        public IAccountRepositories Account { get; }

        public UnitOfWork(ApplicationDbContext db, IReportRepositories report, IAuthRepositories auth, IAccountRepositories account)
        {
            _db = db;
            Report = report;
            Auth = auth;
            Account = account;
        }
    }
}
