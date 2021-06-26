using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Main.Controllers
{
   [Route("api/auth")]
   [ApiController]
   public class AuthController : ControllerBase
   {
      private readonly IAuthenticationManager _authenticationManager;
      private readonly IMapper _mapper;

      public AuthController(IAuthenticationManager authenticationManager, IMapper mapper)
      {
         this._authenticationManager = authenticationManager;
         this._mapper = mapper;
      }


      [HttpPost]
      public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistrationDto)
      {
         if (userForRegistrationDto == null)
         {
            return BadRequest();
         }

         if (!ModelState.IsValid)
         {
            return UnprocessableEntity(ModelState);
         }

         var user = _mapper.Map<User>(userForRegistrationDto);

         await _authenticationManager.RegisterUser(user);

         return StatusCode(201);
      }
   }
}
