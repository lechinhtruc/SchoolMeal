using DataAccess.Models;

namespace DataAccess.Interfaces
{
    public interface IUserLog
    {
        public HistoryLogModel AddLog(HistoryLogModel historyLog);
        public Task<IEnumerable<HistoryLogModel>> GetAll();
    }
}
