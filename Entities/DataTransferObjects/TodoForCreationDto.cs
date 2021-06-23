using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
   public class TodoForCreationDto
   {
      public string Activity { get; set; }
      public bool IsCompleted { get; set; } = false;
   }
}
