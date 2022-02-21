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

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=LegoDB;Trusted_Connection=True;TrustServerCertificate=True;");
        //}
    }
}
