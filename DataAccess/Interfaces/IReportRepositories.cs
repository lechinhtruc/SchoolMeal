using DataAccess.Models;

namespace DataAccess.Interfaces
{
    public interface IReportRepositories
    {
        public Task<IEnumerable<SchoolRecord>> ReportMealMoney(Guid schoolId, DateTime startDate, DateTime endDate);

        public Task<MemoryStream> ExportToExcel(Guid schoolId, DateTime startDate, DateTime endDate);

        public Task<MemoryStream> ExportToXml(Guid schoolId, DateTime startDate, DateTime endDate);
    }
}
