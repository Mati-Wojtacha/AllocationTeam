using AllocationTeamAPI;
using AllocationTeamAPI.Repositories;
using AllocationTeamAPI.Services;
using Microsoft.EntityFrameworkCore;
using AllocationTeamAPI.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using AllocationTeamAPI.Interfaces;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IMatchResultRepository, MatchResultRepository>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<MatchResultService>();

builder.Services.AddSingleton<ITokenManager, TokenManager>();



var jwtConfig = builder.Configuration.GetSection("JwtConfig").Get<JwtConfig>();
builder.Services.AddSingleton(jwtConfig);

builder.Services.AddJwtBearerSetup(jwtConfig);

builder.Services.AddScoped<JwtTokenService>();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;


builder.Services.AddSingleton<DatabaseConnectionChecker>(serviceProvider =>
{
    return new DatabaseConnectionChecker(connectionString);
});

builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseMySql(
        connectionString,
        new MySqlServerVersion(new Version(8, 3, 0))
    )
);



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerSetup();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<TokenValidationMiddleware>();


app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();


