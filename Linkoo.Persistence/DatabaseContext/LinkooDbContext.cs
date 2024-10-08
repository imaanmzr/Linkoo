using Linkoo.Application.Contracts.Persistence.Repositories;
using Linkoo.Domain.Entities;
using Linkoo.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace Linkoo.Persistence.DatabaseContext
{
    public class LinkooDbContext : DbContext, IUnitOfWork
    {
        public LinkooDbContext(DbContextOptions<LinkooDbContext> options) : base(options)
        {
        }

        public DbSet<Activity> Activities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LinkooDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
                .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                entry.Entity.Date = DateTime.Now;
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.Date = DateTime.Now;
                }

            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public async Task CommitChangesAsync()
        {
           await base.SaveChangesAsync();
        }
    }
}