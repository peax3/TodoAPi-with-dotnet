using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
   public class TodoForCreationDto
   {
      [Required(ErrorMessage = "Activity is a required field")]
      public string Activity { get; set; }
      public bool IsCompleted { get; set; } = false;
   }
}
