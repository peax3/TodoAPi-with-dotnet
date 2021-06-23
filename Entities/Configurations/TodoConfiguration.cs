using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Configurations
{
   public class TodoConfiguration : IEntityTypeConfiguration<Todo>
   {
      public void Configure(EntityTypeBuilder<Todo> builder)
      {
         builder.HasData(new Todo
         {
            Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
            Activity = "Walk the dog",
            IsCompleted = false
         },
         new Todo
         {
            Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
            Activity = "Walk the dog",
            IsCompleted = false
         },
         new Todo
         {
            Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
            Activity = "Walk the dog",
            IsCompleted = false
         });
         ;
      }
   }
}
