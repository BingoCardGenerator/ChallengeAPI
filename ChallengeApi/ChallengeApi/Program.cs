using Microsoft.EntityFrameworkCore;
using ChallengeApi.DbContext;
using ChallengeApi.interfaces;
using ChallengeApi.Services;
using AutoMapper;
using AutoMapper.QueryableExtensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adds a single instance of ChallengeService to the API.
builder.Services.AddTransient<IChallengeService, ChallengeService>();
builder.Services.AddDbContext<ChallengeContext>(options => 
   options.UseSqlServer(builder.Configuration.GetConnectionString("ChallengeConnStr")
        )
    );

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
