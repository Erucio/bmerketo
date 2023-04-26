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

        public DbSet<AddressEntity> AspNewAddresses { get; set; }
        public DbSet<UserAddressEntity> AspNetUsersAddresses { get; set; }
    }
}
