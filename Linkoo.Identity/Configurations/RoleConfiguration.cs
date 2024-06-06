using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Linkoo.Identity.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
{
	builder.HasData(
		new List<IdentityRole>
		{
			new IdentityRole {Id = "cbc43a8e-f7bb-4445-baaf-1add431ffbbf",
			Name = "Administrator",
			NormalizedName = "ADMINISTRATOR"},

			new IdentityRole {Id = "1DA500FA-42A3-40C8-9850-8F11F0DD6B1C",
			Name = "User",
			NormalizedName = "USER"}
		}
	);
}
}
