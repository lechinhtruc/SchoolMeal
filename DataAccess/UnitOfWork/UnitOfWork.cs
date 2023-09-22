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

        public IUserLog UserLog { get; }

        public IManageAccountsRepositories ManageAccounts { get; }

        public UnitOfWork(ApplicationDbContext db,
            IReportRepositories report,
            IAuthRepositories auth,
            IAccountRepositories account,
            IUserLog userLog,
            IManageAccountsRepositories manageAccounts
            )
        {
            _db = db;
            Report = report;
            Auth = auth;
            Account = account;
            UserLog = userLog;
            ManageAccounts = manageAccounts;
        }
    }
}
