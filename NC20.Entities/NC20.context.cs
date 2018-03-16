using Microsoft.EntityFrameworkCore;
using System;

namespace NC20.Entities
{
    public partial class NC20Entities : DbContext
    {
        public NC20Entities(DbContextOptions<NC20Entities> options) : base(options) { }
        public DbSet<Claim> Claim { get; set; }
        public DbSet<Image> Image { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<RoleClaim> RoleClaim { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserLoginToken> UserLoginToken { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User
            modelBuilder.Entity<User>()
                .HasMany(x => x.UserProfiles)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<User>()
                .HasMany(x => x.UserRoles)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<User>()
                .HasMany(x => x.UserLoginTokens)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.Cascade);

            // Claim
            modelBuilder.Entity<Claim>()
                .HasMany(x => x.RoleClaims)
                .WithOne(x => x.Claim)
                .OnDelete(DeleteBehavior.Cascade);

            // Role
            modelBuilder.Entity<Role>()
                .HasMany(x => x.RoleClaims)
                .WithOne(x => x.Role)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
