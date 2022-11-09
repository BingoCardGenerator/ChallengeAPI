using Microsoft.EntityFrameworkCore;
using ChallengeApi.DbContext;
using ChallengeApi.interfaces;
using ChallengeApi.Services;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ChallengeApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adds a single instance of ChallengeService to the API.
builder.Services.AddTransient<IChallengeService, ChallengeService>();
builder.Services.AddTransient<Seed>();
builder.Services.AddDbContext<ChallengeContext>(options => 
   options.UseSqlServer(builder.Configuration.GetConnectionString("BingoConnStr")
        )
    );

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
    builder =>
    {
        builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost");
    });
});

var app = builder.Build();
if (args.Length == 1 && args[0].ToLower() == "seeddata")
    SeedData(app);

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    if (scopedFactory == null) return;

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<Seed>();
        if (service != null) service.SeedContext();
    }
}

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
