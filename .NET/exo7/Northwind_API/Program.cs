using Microsoft.EntityFrameworkCore;
using Northwind_API.Entities;
using Northwind_API.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Ajouter DbContext et UnitOfWork
builder.Services.AddDbContext<NorthwindContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NorthwindDatabase")));

// Ajouter UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWorkMem>();

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

app.Run();
