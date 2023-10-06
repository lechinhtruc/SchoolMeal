using DataAccess.Models;

namespace DataAccess.Interfaces
{
    public interface ISearchRepositores
    {
        public Task<SearchResultModal> SearchData(string searchString);
    }
}
