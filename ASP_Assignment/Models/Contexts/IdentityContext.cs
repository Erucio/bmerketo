using ASP_Assignment.Models.Entities;
using ASP_Assignment.Models.Identity;
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<TagEntity>().HasData(
                new TagEntity { Id = 1, TagName = "Featured" },
                new TagEntity { Id = 2, TagName = "New" },
                new TagEntity { Id = 3, TagName = "Popular" }

             );
        }
    }
}
