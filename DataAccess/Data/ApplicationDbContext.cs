using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<SchoolRecord> Tbl_Mealmoney { get; set; }
        public DbSet<AccountModel> Tbl_Account { get; set; }
        public DbSet<HistoryLogModel> Tbl_HistoryLog { get; set; }
        public DbSet<AccountRoles> Tbl_AccountRoles { get; set; }
    }
}
