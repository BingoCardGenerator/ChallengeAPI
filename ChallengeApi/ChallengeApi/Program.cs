using Microsoft.EntityFrameworkCore;
using ChallengeApi.DbContext;
using ChallengeApi.interfaces;
using ChallengeApi.Services;
using AutoMapper;
using AutoMapper.QueryableExtensions;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_MyAllowSpecificOrigins";

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

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
    builder =>
    {
        builder.WithOrigins("http://localhost");
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
