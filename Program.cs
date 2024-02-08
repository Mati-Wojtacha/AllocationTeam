using AllocationTeamAPI;
using AllocationTeamAPI.Repositories;
using AllocationTeamAPI.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IMatchResultRepository, MatchResultRepository>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<MatchResultService>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();


