using ECommerceApp_API.Core.DTOs;
using ECommerceApp_API.Core.DTOs.InputDTOs;
using ECommerceApp_API.Core.Interfaces;
using ECommerceApp_API.Infrastructure.Data;
using ECommerceCMS_API.Core.DTOs.EntityDTOs;
using ECommerceCMS_API.Core.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ECommerceApp_API.Web.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ECommerceDbContext _db;
        private readonly IPopupService _popupService;
        public LoginController(ECommerceDbContext db, IPopupService popupService)
        {
            _db = db;
            _popupService = popupService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterAsync(PopupDTO popupDTO)
        {
            try
            {
                User newUser = new User(popupDTO, this._db);
                this._db.Users.Add(newUser);
                await this._db.SaveChangesAsync();

                MessageDTO message = MessageDTO.CreateSuccessful("Registration", "You have successfully registered.");
                return Ok(message);
            }
            catch (Exception)
            {
                MessageDTO message = MessageDTO.CreateFailed("Registration", "Error occurred during registration process.");
                return BadRequest(message);
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync(PopupDTO popupDTO)
        {
            try
            {
                Dictionary<string, string> inputValue = PopupDTO.GetDictionaryFromPopup(popupDTO);
                User? user = this._db.Users
                    .Where(u => 
                        (u.Email == inputValue["InputDTO.Login"]
                        || u.Login == inputValue["InputDTO.Login"])
                        && u.Password == inputValue["InputDTO.Password"])
                    .Include(u => u.Role)
                    .FirstOrDefault();

                if (user is not null)
                {
                    List<Claim> claims = new List<Claim> { 
                        new Claim(ClaimTypes.Name, $"{user.Name}"),
                        new Claim(ClaimTypes.Email, $"{user.Email}"),
                        new Claim(ClaimTypes.Role, $"{user.Role.Name}"),
                        new Claim(ClaimTypes.Surname, $"{user.Surname}"),
                        new Claim(ClaimTypes.MobilePhone, $"{user.Phone}")
                    };

                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                    await this.HttpContext.SignInAsync(claimsPrincipal);

                    MessageDTO message = MessageDTO.CreateSuccessful("Authentication", "You have authenticated successfully.");
                    UserInfoDTO userInfoDTO = new UserInfoDTO(user);

                    ContentMessageDTO<UserInfoDTO> contentMessage = new ContentMessageDTO<UserInfoDTO>(message, userInfoDTO);

                    return Ok(contentMessage);
                }
                else
                {
                    MessageDTO message = MessageDTO.CreateFailed("Authentication", "User not found.");
                    return BadRequest(message);
                }
            }
            catch (Exception)
            {
                MessageDTO message = MessageDTO.CreateFailed("Authentication", "Error occurred during authentication process.");
                return BadRequest(message);
            }            
        }

        [HttpGet]
        [Authorize]
        [Route("isAuthorized")]
        public IActionResult IsAuthorized()
        {
            return NoContent();
        }

        [HttpGet]
        [Authorize]
        [Route("logOut")]
        public async Task<IActionResult> LogoutAsync()
        {
            try
            {
                await this.HttpContext.SignOutAsync();
                MessageDTO message = MessageDTO.CreateSuccessful("Deauthorization", "You have successfully deauthorized.");
                return Ok(message);
            }
            catch (Exception)
            {
                MessageDTO message = MessageDTO.CreateFailed("Deauthorization", "Error occurred during deauthorization process.");
                return BadRequest(message);
            }
        }

        [HttpGet]
        [Route("getLoginPopup")]
        public IActionResult GetLoginPopup()
        {
            try
            {
                return Ok(this._popupService.GetLoginPopup());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getRegistrationPopup")]
        public IActionResult GetRegistrationPopup()
        {
            try
            {
                return Ok(this._popupService.GetRegistrationPopup());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
