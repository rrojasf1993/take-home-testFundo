using Loans.BackendInfrastructure.DataAccess;
using Loans.BackendInfrastructure.Repository;
using Loans.BackendInfrastructure.UnitOfWork;
using Loans.Cross.Interfaces;
using Loans.Cross.MappingConfiguration;
using Loans.Cross.Services;
using Loans.Domain.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LoansConnectionString")));

//add the different services
builder.Services.AddScoped<ILoanRepository,LoanRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//add automapper 
List<System.Reflection.Assembly> mappingProfileTypes = new List<System.Reflection.Assembly>() { typeof(LoanProfile).Assembly };
builder.Services.AddAutoMapper(s=>s.AddMaps(mappingProfileTypes.ToArray()));
//add services
builder.Services.AddScoped<ILoanService, LoanService>();
//add cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

//Seed data
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
    DataSeed.Initialize(db);
}

//add Cors policy
app.UseCors("AllowFrontend");

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
