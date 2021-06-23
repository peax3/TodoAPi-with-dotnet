using System;


namespace Entities.DataTransferObjects
{
   public class TodoDto
   {
      public Guid Id { get; set; }
      public string Activity { get; set; }
      public bool IsCompleted { get; set; } = false;
   }
}
