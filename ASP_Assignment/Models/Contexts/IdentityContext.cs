using ASP_Assignment.Models.Entities;
using ASP_Assignment.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASP_Assignment.Models.Contexts
{
    public class IdentityContext : IdentityDbContext<AppUser>
    {

        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {

        }

        public DbSet<CommentEntity> Comments { get; set; }
        public DbSet<ProductTagEntity> ProductTags { get; set; }
        public DbSet<TagEntity> Tags { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<AddressEntity> AspNewAddresses { get; set; }
        public DbSet<UserAddressEntity> AspNetUsersAddresses { get; set; }

        /* 
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var userId = Guid.NewGuid().ToString();
            var roleId = Guid.NewGuid().ToString();


            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = roleId,
                    Name = "admin",
                    NormalizedName = "ADMIN"
                }
                );

            var passwordHasher = new PasswordHasher<AppUser>();

            builder.Entity<AppUser>().HasData(new AppUser
            {
                Id = userId,
                FirstName = "RedLeader1",
                LastName = "",
                UserName = "administrator@domain.com",
                Email = "administrator@domain.com",
                PasswordHash = passwordHasher.HashPassword(null!, "Password1!"),

            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = roleId,
                UserId = userId,
            });

        }
        */
    }
}
