using Hospital_Api.Models.DTO;
using Hospital_Api.Reopsitories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hospital_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            this.UserManager = userManager;
            this.tokenRepository = tokenRepository;
        }

        public UserManager<IdentityUser> UserManager { get; }

        //POST: /api/Auth/Register
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO registerRequestDTO)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDTO.Username,
                Email = registerRequestDTO.Username
            };

            var identityResult = await UserManager.CreateAsync(identityUser, registerRequestDTO.Password);

            if (identityResult.Succeeded)
            {
                //Add roles to this User 
                if (registerRequestDTO.Roles != null && registerRequestDTO.Roles.Any())
                {

                    // Inside the Register method, replace the problematic line with the following:
                    identityResult = await UserManager.AddToRolesAsync(identityUser, registerRequestDTO.Roles);
                   
                    if (identityResult.Succeeded)
                    
                    {
                    
                        return Ok(  "User registered successfully! You can now login "  );
                    }

                } 


            }

            return BadRequest("somthing went wrong, Please try again");
        }


        //POST: /api/Auth/Login
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequestDTO)
        {
            var user = await UserManager.FindByEmailAsync(loginRequestDTO.Username);
            if (user != null)
            {
                var checkPasswordResult = await UserManager.CheckPasswordAsync(user, loginRequestDTO.Password);

                if (checkPasswordResult)
                {
                    // Get Roles for this user
                    var roles = await UserManager.GetRolesAsync(user);
                    if (roles != null) 
                    {
                        //Create Token

                       var jwtToken = tokenRepository.CreateJWTToken(user, roles.ToList());

                        var response = new LoginResponseDto
                        {
                            JwtToken = jwtToken
                        };
                        
                        return Ok( response );
                    }
                   
                 
                }

            }

            return BadRequest("Something went wrong, check your username and password");
        }

    }
}
