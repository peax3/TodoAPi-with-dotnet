using Contracts;
using Entities;
using Entities.Models;
using System.Threading.Tasks;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Repository
{
   public class AuthenticationManager : IAuthenticationManager
   {
      private readonly RepositoryContext _repositoryContext;
      private readonly int _salt = 12;

      public AuthenticationManager(RepositoryContext repositoryContext)
      {
         this._repositoryContext = repositoryContext;
      }

      public Task<string> CreateToken()
      {
         throw new System.NotImplementedException();
      }

      public async Task RegisterUser(User user)
      {
         user.Password = BCryptNet.HashPassword(user.Password, _salt);
         _repositoryContext.Users.Add(user);
         await _repositoryContext.SaveChangesAsync();
      }

      public Task<bool> ValidateUser()
      {
         throw new System.NotImplementedException();
      }
   }
}
