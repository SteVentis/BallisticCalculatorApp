using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Modules.Security.Domain.Models;
using Modules.Security.Infrastructure.Context.ContextConfigurations;

namespace Modules.Security.Infrastructure.Context;

public sealed class IdentityAppDbContext : IdentityDbContext<User>
{
    public IdentityAppDbContext(DbContextOptions<IdentityAppDbContext> opt) : base(opt)
    {
    }

    public DbSet<User> UsersIdentity { get; set; } = null!;
    public DbSet<RefreshToken> RefreshTokens { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema("Security");

        builder.ApplyConfiguration(new RolesConfiguration());

        base.OnModelCreating(builder);
    }

}

