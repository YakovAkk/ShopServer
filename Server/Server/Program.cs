
using DataDomain.Data.NoSql.Database;
using DataDomain.Data.NoSql.Models;
using DataDomain.Data.Sql.Database;
using DataDomain.Data.Sql.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Repositories.Repositories;
using Repositories.Repositories.Base;
using Repositories.RepositoriesMongo;
using Repositories.RepositoriesMongo.Base;
using Server.Token;
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

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
        {
            options.SlidingExpiration = true;
            options.ExpireTimeSpan = new TimeSpan(0, 1, 0);
        });

/// /////////////////////////


builder.Services.AddTransient<BaseRepository<UserModel>, UserRepository>();
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddTransient<MongoDbBase<BasketModel>, BasketRepository>();
builder.Services.AddTransient<BaseServiceForMongo<BasketModel>, BasketService>();

builder.Services.AddTransient<MongoDbBase<CategoryModel>, CategoryRepositoty>();
builder.Services.AddTransient<BaseServiceForMongo<CategoryModel>, CategoryService>();

builder.Services.AddTransient<MongoDbBase<LegoModel>, LegoRepository>();
builder.Services.AddTransient<BaseServiceForMongo<LegoModel>, LegoService>();

builder.Services.AddDbContext<AppDBContent>(options =>
options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=LegoDB;Trusted_Connection=True;TrustServerCertificate=True;"));

builder.Services.AddSingleton<MongoDatabase>();

//Identity has been registered  here 
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDBContent>();

builder.Services.AddCors();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            // ��������, ����� �� �������������� �������� ��� ��������� ������
                            ValidateIssuer = true,
                            // ������, �������������� ��������
                            ValidIssuer = AuthOptions.ISSUER,

                            // ����� �� �������������� ����������� ������
                            ValidateAudience = true,
                            // ��������� ����������� ������
                            ValidAudience = AuthOptions.AUDIENCE,
                            // ����� �� �������������� ����� �������������
                            ValidateLifetime = true,

                            // ��������� ����� ������������
                            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                            // ��������� ����� ������������
                            ValidateIssuerSigningKey = true,
                        };
                    });
builder.Services.AddControllersWithViews();

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

app.UseCors(options =>
{
    options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
});

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
