using DataAccess.Data;
using DataAccess.Interfaces;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public IReportRepositories Report { get; }

        public IAuthRepositories Auth { get; }

        public UnitOfWork(ApplicationDbContext db, IReportRepositories report, IAuthRepositories auth)
        {
            _db = db;
            Report = report;
            Auth = auth;
        }
    }
}
