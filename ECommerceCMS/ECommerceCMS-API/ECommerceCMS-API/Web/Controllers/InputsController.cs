using ECommerceCMS_API.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceCMS_API.Web.Controllers
{
    [Route("api/inputs")]
    [ApiController]
    public class InputsController : ControllerBase
    {
        private readonly IInputService _inputService; 
        public InputsController(IInputService inputService)
        {
            this._inputService = inputService;
        }

        [HttpGet]
        [Route("getInputBlock")]
        public IActionResult GetInputBlock(string tableName)
        {
            try
            {
                return Ok(this._inputService.GetInputBlock(tableName));
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getInputGroups")]
        public IActionResult GetInputGroups(int templateId)
        {
            try
            {
                return Ok(this._inputService.GetInputGroups(templateId));
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getInputUpdateBlock")]
        public IActionResult GetUpdateInputBlock(string tableName, int id)
        {
            try
            {
                return Ok(this._inputService.GetUpdateInputBlock(tableName, id));
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getLoginInputBlock")]
        public IActionResult GetLoginInputBlock()
        {
            try
            {
                return Ok(this._inputService.GetLoginInputBlock());
            } catch(Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
