using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace main.ServiceExtensions
{
   public static class ServiceExtensions
   {
      public static void ConfigureSqliteDb(this IServiceCollection services, IConfiguration configuration)
      {
         services.AddDbContext<RepositoryContext>(opts => opts.UseSqlite(
            configuration.GetConnectionString("sqliteConnection"), b => b.MigrationsAssembly("Main")));
      }
   }
}
