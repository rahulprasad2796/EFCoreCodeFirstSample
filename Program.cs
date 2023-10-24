using EFCoreCodeFirstSample.Models;
using EFCoreCodeFirstSample.Models.DataManager;
using EFCoreCodeFirstSample.Models.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//DB Context
string? connectionString = builder.Configuration.GetConnectionString("EmployeeDB");
builder.Services.AddDbContext<EmployeeContext>(opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeDB")));
// Repository Pattern
builder.Services.AddScoped<IDataRepository<Employee>, EmployeeManager>();
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
