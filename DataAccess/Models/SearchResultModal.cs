namespace DataAccess.Models
{
    public class SearchResultModal
    {
        public IEnumerable<AccountModel>? Accounts { get; set; }

        public IEnumerable<HistoryLogModel>? HistoryLog { get; set; }
    }
}
