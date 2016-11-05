using Microsoft.EntityFrameworkCore;

namespace AspnetCoreWebAPI.Models
{
    public class DataContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }

        public DbSet<Product> Product { get; set; }
    }
}
