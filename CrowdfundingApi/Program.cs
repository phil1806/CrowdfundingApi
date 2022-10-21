
using BLL.Interfaces;
using BLL.Services;
using CrowdfundingApi.Infrastructure;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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

builder.Services.AddScoped<IStatusProjetService, StatusProjetService>();
builder.Services.AddScoped<IStatusProjetRepo, StatusProjetRepo>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => {
        options.TokenValidationParameters = new TokenValidationParameters() {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                builder.Configuration.GetSection("TokenInfo").GetSection("secret").Value))
        };
    });

builder.Services.AddAuthorization(options => {
    options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
    options.AddPolicy("ProjectOwner", policy => policy.RequireRole("ProjectOwner"));
    options.AddPolicy("Contributeur", policy => policy.RequireRole("Contributeur"));
    options.AddPolicy("Auth", policy => policy.RequireAuthenticatedUser());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

