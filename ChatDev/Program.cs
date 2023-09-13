using ChatDev.Configuration;
using ChatDev.Contracts;
using ChatDev.Data;
using ChatDev.Repository;
using Google.Api;
using Microsoft.AspNetCore.Identity;
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

builder.Services.AddIdentityCore<ApiUser>().AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ChatDevDbContext>();

//DbContext
builder.Services.AddDbContext<ChatDevDbContext>(options => {
    options.UseSqlServer(connectionString);
});

//Anti Forgery Token 
builder.Services.AddAntiforgery(options => options.HeaderName = "X-CSRF-TOKEN");
builder.Services.AddAntiforgery();
builder.Services.AddMvc();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();

app.Run();
