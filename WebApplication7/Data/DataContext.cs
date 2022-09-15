using Microsoft.EntityFrameworkCore;

namespace WebApplication7.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }
        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}
