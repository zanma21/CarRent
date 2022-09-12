using System.Configuration;

using CarRent.Car.Domain;
using CarRent.Car.Infrastructure.Persistence;
using CarRent.Car.Persistence;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var connectionString = "Server=(localdb)\\mssqllocaldb;Database=CarRent;Trusted_Connection=True;MultipleActiveResultSets=true";
builder.Services.AddDbContext<CarContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddScoped<ICarRepository, CarRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseDeveloperExceptionPage();

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
