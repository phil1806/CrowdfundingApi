
using BLL.Interfaces;
using BLL.Services;
using CrowdfundingApi.Infrastructure;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CrowdfundingApi {


    public class CrowdfundingApi {

        public static void Main(string[] args) {


            string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  policy => {
                                      policy.WithOrigins("http://localhost:4200").AllowAnyHeader();
                                  });
            });

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            //INJECTION DES DEPENDANCES
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IUserRepo, UserRepo>();

            builder.Services.AddScoped<IProjectService, ProjectService>();
            builder.Services.AddScoped<IProjectRepo, ProjectRepo>();

            builder.Services.AddScoped<IPalierService, PalierService>();
            builder.Services.AddScoped<IPalierRepo, PalierRepo>();




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
            if (app.Environment.IsDevelopment()) {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors(MyAllowSpecificOrigins);
            app.UseStaticFiles();


            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();

        }

    

    }
}