using infomerc_site.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace infomerc_site.Data
{
    public class InfomercContext : IdentityDbContext<Usuario>
    {
        public InfomercContext(DbContextOptions<InfomercContext> options) : base(options)
        { 
        }

        public DbSet<Usuario> Usuarios { get; set; }

        //Blog
        public DbSet<Blog_Post> Blog_Post { get; set; }
        public DbSet<Blog_Categoria> Blog_Categoria { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Usuario>().ToTable("INFOMERC_Users");
            builder.Entity<IdentityUserRole<string>>().ToTable("INFOMERC_UserRoles");
            builder.Entity<IdentityUserLogin<string>>().ToTable("INFOMERC_UserLogins");
            builder.Entity<IdentityUserClaim<string>>().ToTable("INFOMERC_UserClaims");
            builder.Entity<IdentityRole>().ToTable("INFOMERC_Roles");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("INFOMERC_AspNetRoleClaims");
            builder.Entity<IdentityUserToken<string>>().ToTable("INFOMERC__AspNetUserTokens");
        }

    }
}