using Entities.Configurations;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class RepositoryContext : DbContext
   {
      public RepositoryContext(DbContextOptions options)
         : base(options)
      {

      }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.ApplyConfiguration(new TodoConfiguration());
      }

      public DbSet<Todo> Todos { get; set; }
      public DbSet<User> Users { get; set; }
   }
}
