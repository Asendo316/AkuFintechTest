using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AcuTestRestAPI.Domain.v1.auth;
using AcuTestRestAPI.Domain.v1.user;
using AcuTestRestAPI.Domain.v1.files;

namespace AcuTestAPI.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public DbSet<UserProfile> UserProfile { get; set; }

        public DbSet<ComparedFiles> ComparedFiles { get; set; }

        }
}
