using DataAccess.Data;
using DataAccess.Interfaces;
using DataAccess.Models;

namespace DataAccess.Repositories
{
    public class UserLogRepositories : IUserLog
    {
        private readonly ApplicationDbContext _db;

        public UserLogRepositories(ApplicationDbContext db)
        {
            _db = db;
        }
        public HistoryLogModel AddLog(HistoryLogModel historyLog)
        {
            _db.Add(historyLog);
            _db.SaveChanges();
            return historyLog;
        }
    }
}