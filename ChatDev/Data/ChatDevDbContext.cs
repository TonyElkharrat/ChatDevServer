using ChatDev.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChatDev.Data
{
    public class ChatDevDbContext : IdentityDbContext<ApiUser>
    {
        public ChatDevDbContext(DbContextOptions options) : base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleConfiguration());
        }

        public DbSet<Message> Messages { get; set; }
        public DbSet<ChatSubject> ChatSubjects { get; set; }

    }
}
