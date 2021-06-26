using Entities.Models;
using System.Threading.Tasks;

namespace Contracts
{
   public interface IAuthenticationManager
   {
      Task<bool> ValidateUser();
      Task<string> CreateToken();
      Task RegisterUser(User user);
   }
}
