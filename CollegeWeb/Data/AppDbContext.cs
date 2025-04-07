using Microsoft.EntityFrameworkCore;

namespace CollegeWeb.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<ContactMessage> ContactMessages { get; set; }

        // Add other DbSet<T> here
    }
}