using Linkoo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Linkoo.Persistence.DatabaseContext
{
    public class LinkooDbContext : DbContext
    {
        public LinkooDbContext(DbContextOptions<LinkooDbContext> options) : base(options)
        {
        }

        public DbSet<Activity> Activities { get; set; }
    }
}