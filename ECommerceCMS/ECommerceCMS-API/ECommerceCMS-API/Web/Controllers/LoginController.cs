using ECommerceCMS_API.Core.DTOs;
using ECommerceCMS_API.Core.DTOs.DbInteractionDTOs;
using ECommerceCMS_API.Core.DTOs.EntityDTOs;
using ECommerceCMS_API.Core.Entities;
using ECommerceCMS_API.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ECommerceCMS_API.Web.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ECommerceDbContext _db;
        public LoginController(ECommerceDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(InputBlockDTO inputBlockDTO)
        {
            try
            {
                Message message;
                if (this.HttpContext.User.Identity!.IsAuthenticated)
                {
                    message = Message.CreateFailed("Authentication", "You are already authenticated.");
                    return BadRequest(message);
                }

                LoginFormDTO loginFormDTO = new LoginFormDTO(inputBlockDTO);
                User? user = this._db.Users
                    .Where(
                        u => (u.Login == loginFormDTO.Login
                        || u.Email == loginFormDTO.Login)
                        && u.Password == loginFormDTO.Password)
                    .Include(u => u.Role)
                    .FirstOrDefault();
                
                if (user is not null)
                {
                    List<Claim> claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, $"{user.Surname} {user.Name}"),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Role, user.Role.Name),
                        new Claim(ClaimTypes.MobilePhone, user.Phone)
                    };
                    var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                    await this.HttpContext.SignInAsync(claimsPrincipal);

                    UserDTO userDTO = new UserDTO(user);
                    userDTO.Password = "";

                    message = Message.CreateSuccessful("Authenticated", $"User {userDTO.Name} {userDTO.Surname} is successfuly authenticated.");
                    return Ok(new { userDTO, message });
                }

                message = Message.CreateFailed("Authentication failed", "User login or password are not correct.");
                return Unauthorized(message);
            } catch(Exception)
            {
                Message message = Message.CreateFailed("Internal error", "Internal error occurred during authentication process.");
                return BadRequest(new { message });
            }
        }

        [HttpPost]
        [Authorize]
        [Route("isAuthorized")]
        public IActionResult IsAuthorized()
        {
            return NoContent();
        }
        
        [HttpPost]
        [Authorize]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await this.HttpContext.SignOutAsync();
            Message message = Message.CreateSuccessful("Logout", "You've logged out successfully.");
            return Ok(message);
        }
    }
}
