using DataAccess.Models;

namespace DataAccess.Interfaces
{
    public interface IUserLog
    {
        public Task<HistoryLogModel> AddLog(HistoryLogModel historyLog);
        public Task<IEnumerable<HistoryLogModel>> GetAll();
        public Task Clear();
    }
}
