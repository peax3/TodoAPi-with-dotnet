using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;


namespace main.ServiceExtensions
{
   public static class ServiceExtensions
   {
      public static void ConfigureSqliteDb(this IServiceCollection services, IConfiguration configuration)
      {
         services.AddDbContext<RepositoryContext>(opts => opts.UseSqlite(
            configuration.GetConnectionString("sqliteConnection"), b => b.MigrationsAssembly("Main")));
      }

      public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
      {
         var jwtSettings = configuration.GetSection("JwtSettings");
         var secretKey = Environment.GetEnvironmentVariable("JWTSECRET");
      }
   }
}
