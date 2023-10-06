using DataAccess.Data;
using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class SearchRepositores : ISearchRepositores
    {
        private readonly ApplicationDbContext _db;

        public SearchRepositores(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<SearchResultModal> SearchData(string searchString)
        {
            var accounts = await _db.Tbl_Account.Where(account =>
            account.Username == searchString ||
            account.PhoneNumber == searchString ||
            account.Role == searchString ||
            account.CreatedAt.ToString() == searchString ||
            account.ExpiredAt.ToString() == searchString
            ).ToListAsync();

            var logs = await _db.Tbl_HistoryLog.Where(log =>
            log.Username == searchString ||
            log.Action == searchString ||
            log.Description == searchString ||
            log.Controller == searchString ||
            log.DateTime.ToString() == searchString
            ).ToListAsync();

            SearchResultModal searchResult = new()
            {
                Accounts = accounts,
                HistoryLog = logs,
            };
            return searchResult;
        }
    }
}
