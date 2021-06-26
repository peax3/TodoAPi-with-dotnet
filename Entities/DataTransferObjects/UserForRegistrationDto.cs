using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
   public class UserForRegistrationDto
   {
      [Required(ErrorMessage = "Name is a required field")]
      public string Name { get; set; }

      [Required(ErrorMessage = "Email is a required fiels")]
      [EmailAddress(ErrorMessage = "Email is not valid")]
      public string Email { get; set; }

      [Required(ErrorMessage = "Password is required")]
      [MinLength(7, ErrorMessage = "Password must be more than 7 characters")]
      public string Password { get; set; }
   }
}
