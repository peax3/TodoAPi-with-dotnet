using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
   public class Todo
   {
      public Guid Id { get; set; }

      [Required(ErrorMessage = "Activity name is a required field")]
      public string Activity { get; set; }
      public bool IsCompleted { get; set; } = false;
   }
}
