using BlazorSignalR.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorSignalR.Server
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<NotificationMsg> NotificationMsgs => Set<NotificationMsg>();
    }
}
