using Microsoft.EntityFrameworkCore;
namespace RentalMgtSystem.Models
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
        public DbSet<Unit> Unit { get; set; }
        public DbSet<TenantContract> TenantContract { get; set; }

        public  DbSet<Utility> Utility { get; set; }
        public DbSet<UtilityAccount> UtilityAccount { get; set; }
    }
}
