using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
   [Index(nameof(Email), IsUnique = true)]
   public class User
   {
      public Guid Id { get; set; }
      [Required(ErrorMessage = "Name is a required field")]
      public string Name { get; set; }
      [Required(ErrorMessage = "Email is a required fiels")]
      [EmailAddress(ErrorMessage = "Email is not valid")]
      public string Email { get; set; }
      public string Password { get; set; }
   }
}
