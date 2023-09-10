using Microsoft.EntityFrameworkCore;

namespace ChatDev.Data
{
    public class ChatDevDbContext : DbContext
    {
        public ChatDevDbContext(DbContextOptions options) : base(options)
        {
                
        }

        public DbSet<User> Users { get; set; }

    }
}
