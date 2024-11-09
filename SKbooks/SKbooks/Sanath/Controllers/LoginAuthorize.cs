using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using SKbooks.Models;
using SKbooks.Sanath.BLL;
using SKbooksAPI.Models.Response;
using Microsoft.AspNetCore.Authorization;
using SKbooksAPI.Models.Request;
using System.Data;
using System.Security.Claims;



namespace SKbooksAPI.Sanath.Controllers
{

    [Authorize]
    [Route("API")]
    [ApiController]
    public class LoginAuthorize : Controller
    {



        [HttpPost("login")]

        public IActionResult logToken([FromBody]LoginReqToken logtoken)
        {
            

            if (logtoken.mobile==123 && logtoken.Password =="123")
            {
            var  token   = GenerateToken();
                return Ok(new { token });

            }
            return Unauthorized();
            

        }
        //public IActionResult Login([FromBody] LoginRequest login)
        //{


        //    // Validate the user credentials (this should be against your database)           {
        //        var token = GenerateToken();
        //        return Ok(new { token });
        //    }

        //    return Unauthorized();
        //}

        private string GenerateToken()
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom secret key for authentication"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


          //  var claims = new[]
          //{
          //      new Claim(ClaimTypes.Name, username),
          //      new Claim(ClaimTypes.Role, role) // Add role claim
          //  };

           

            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
