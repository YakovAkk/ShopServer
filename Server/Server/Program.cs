
using DataDomain.Data.Sql.Database;
using DataDomain.Data.Sql.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Repositories.Repositories;
using Repositories.Repositories.Base;
using Services.Services;
using Services.Services.Base;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



/// ///////////////////// // Error 404

builder.Services.AddMvcCore(config =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});

/// /////////////////////////

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<BaseRepository<UserModel>, UserRepository>();

builder.Services.AddDbContext<AppDBContent>(options =>
options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=LegoDB;Trusted_Connection=True;TrustServerCertificate=True;"));



//Identity has been registered  here 
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDBContent>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
