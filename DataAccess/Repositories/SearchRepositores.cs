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
            account.Username.Contains(searchString) ||
            account.PhoneNumber.Contains(searchString) ||
            account.CreatedAt.ToString().Contains(searchString) ||
            account.ExpiredAt.ToString().Contains(searchString)
            ).ToListAsync();

            var logs = await _db.Tbl_HistoryLog.Where(log =>
            log.Username.Contains(searchString) ||
            log.Action.Contains(searchString) ||
            log.Description.Contains(searchString) ||
            log.Controller.Contains(searchString) ||
            log.DateTime.ToString().Contains(searchString)
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
