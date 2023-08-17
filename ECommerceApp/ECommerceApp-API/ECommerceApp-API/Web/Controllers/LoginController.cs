using ECommerceApp_API.Core.DTOs.InputDTOs;
using ECommerceApp_API.Core.Interfaces;
using ECommerceApp_API.Infrastructure.Data;
using ECommerceCMS_API.Core.DTOs.EntityDTOs;
using ECommerceCMS_API.Core.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Register(PopupDTO popupDTO)
        {
            return Ok();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync(PopupDTO popupDTO)
        {
            // await this.HttpContext.SignInAsync();
            return Ok();
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
        [Route("logout")]
        public async Task<IActionResult> LogoutAsync()
        {
            await this.HttpContext.SignOutAsync();
            return Ok();
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
