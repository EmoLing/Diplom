
using Microsoft.EntityFrameworkCore;
using UserProfile.DbContexts;
using UserProfile.Repository;

string myAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("_myAllowSpecificOrigins",
        policy => policy
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = builder.Configuration.GetConnectionString("UsersDb");

builder.Services.AddDbContext<UserContext>(o
    => o.UseSqlServer(connectionString));
builder.Services.AddTransient<IUsersRepository, UsersRepository>();

var app = builder.Build();

app.UseCors(myAllowSpecificOrigins);
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
