using Microsoft.EntityFrameworkCore;

namespace HRMSAPI.Models
{
    public class HRMSDbContext : DbContext
    {
        public HRMSDbContext(DbContextOptions<HRMSDbContext> options) : base(options)
        {

        }

        public DbSet<Flat> Flats { get; set; }
    }
}
