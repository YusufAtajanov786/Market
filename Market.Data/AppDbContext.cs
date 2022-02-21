using Market.Domain;
using Microsoft.EntityFrameworkCore;

namespace Market.Data
{
    public class AppDbContext:DbContext
    {

        public DbSet<Category> Category { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> dbContext)
            : base(dbContext)
        {

        }
    }
}
