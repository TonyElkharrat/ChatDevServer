using ChatDev.Configuration;
using ChatDev.Contracts;
using ChatDev.Data;
using ChatDev.Repository;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("ChatDevDbConnectionString");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Auto Mapper Config
builder.Services.AddAutoMapper(typeof(MapConfig));
//Repository 

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>)); 
builder.Services.AddScoped<IUsersRepository,UsersRepository>(); 

//DbContext
builder.Services.AddDbContext<ChatDevDbContext>(options => {
    options.UseSqlServer(connectionString);
});

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
