using DataDomain.Data.Sql.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataDomain.Data.Sql.Database
{
    public class AppDBContent : IdentityDbContext
    {
        public DbSet<UserModel> Users { get; set; }

        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
