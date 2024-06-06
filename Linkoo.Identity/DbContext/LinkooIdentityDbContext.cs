using Linkoo.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Linkoo.Infrastructure.DbContext
{
    public class LinkooIdentityDbContext : IdentityDbContext<ApplicationUser>
{
    public LinkooIdentityDbContext(DbContextOptions<LinkooIdentityDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(LinkooIdentityDbContext).Assembly);
    }
}
}