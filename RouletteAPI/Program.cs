using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RouletteAPI.Data;
using RouletteAPI;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<RouletteAPIContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("RouletteAPIContext") ?? throw new InvalidOperationException("Connection string 'RouletteAPIContext' not found.")));

// Add services to the container.

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

app.MapBetEndpoints();

app.Run();
