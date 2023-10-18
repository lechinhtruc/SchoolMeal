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
        public async Task<HistoryLogModel> AddLog(HistoryLogModel historyLog)
        {
            await _db.AddAsync(historyLog);
            await _db.SaveChangesAsync();
            return historyLog;
        }

        public async Task Clear()
        {
            await _db.Tbl_HistoryLog.ExecuteDeleteAsync();
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<HistoryLogModel>> GetAll()
        {
            var logs = await _db.Tbl_HistoryLog.ToListAsync();
            return logs;
        }
    }
}