using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Spotify.DTO;
using Spotify.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Spotify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration config;

        public AccountController(UserManager<ApplicationUser> userManager, IConfiguration config)
        {
            this.userManager = userManager;
            this.config = config;
        }
        [HttpPost("register")]//api/account/register
        public async Task<IActionResult> Register(RegisterUserDto userDTO)
        {
            if (ModelState.IsValid)
            {
                //create  ==>add user db
                ApplicationUser userModel = new ApplicationUser();
                userModel.Email = userDTO.Email;
                userModel.UserName = userDTO.UserName;
                IdentityResult result = await userManager.CreateAsync(userModel, userDTO.Password);
                if (result.Succeeded)
                {
                    return Ok("Created Success");
                }
                else
                    return BadRequest(result.Errors.First());
            }
            return BadRequest(ModelState);
        }

        [HttpPost("login")]//api/account/login
        public async Task<IActionResult> Login(LoginDTO userDto)
        {
            if (ModelState.IsValid)
            {
                //check 
                ApplicationUser userModel = await userManager.FindByNameAsync(userDto.UserName);
                if (userModel != null && await userManager.CheckPasswordAsync(userModel, userDto.Password))
                {
                    //claims
                    List<Claim> myClaims = new List<Claim>();
                    //id,name,role,color,jit
                    myClaims.Add(new Claim(ClaimTypes.NameIdentifier, userModel.Id));
                    myClaims.Add(new Claim(ClaimTypes.Name, userModel.UserName));
                    myClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

                    List<string> roles = (List<string>)await userManager.GetRolesAsync(userModel);
                    if (roles != null)
                    {
                        foreach (var item in roles)
                        {
                            myClaims.Add(new Claim(ClaimTypes.Role, item));
                        }
                    }
                    var authSecritKey =
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:SecrytKey"]));//asdZXCZX!#!@342352

                    SigningCredentials credentials =
                        new SigningCredentials(authSecritKey, SecurityAlgorithms.HmacSha256);

                    //craete token
                    JwtSecurityToken mytoken = new JwtSecurityToken(
                        issuer: config["JWT:ValidIss"],
                        audience: config["JWT:ValidAud"],
                        expires: DateTime.Now.AddHours(2),
                        claims: myClaims,
                        signingCredentials: credentials
                        );//signed token "resprest Toke"

                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(mytoken),
                        expiration = mytoken.ValidTo
                    });

                }
                //craete toke
                return BadRequest("Invalid Login Account");
            }
            return BadRequest(ModelState);
        }
    }
}
