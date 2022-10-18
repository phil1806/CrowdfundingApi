
using BLL.Interfaces;
using BLL.Services;
using CrowdfundingApi.Infrastructure;
using DAL.Interfaces;
using DAL.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepo, UserRepo>();

builder.Services.AddScoped<TokenManager>();

builder.Services.AddScoped<IContributionService, ContributionService>();
builder.Services.AddScoped<IContributionRepo, ContributionRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

