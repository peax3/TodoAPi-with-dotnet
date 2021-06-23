﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Entities.Models
{
   public class ErrorDetails
   {
      public int statusCode { get; set; }
      public string Message { get; set; }
      public override string ToString()
      {
         return JsonSerializer.Serialize(this);
      }
   }
}
