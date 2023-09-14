using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<SchoolRecord> Tbl_mealmoney { get; set; }
        public DbSet<AccountModel> Tbl_account { get; set; }
    }
}
