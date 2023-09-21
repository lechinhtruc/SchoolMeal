using DataAccess.Data;
using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<HistoryLogModel>> GetAll()
        {
            var logs = await _db.Tbl_HistoryLog.OrderBy(x => x.DateTime).ToListAsync();
            return logs;
        }
    }
}