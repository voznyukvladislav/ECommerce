using ECommerceCMS_API.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

using ECommerceCMS_API.Core.Entities;
using ECommerceCMS_API.Core.DTOs;

namespace ECommerceCMS_API.Web.Controllers
{
    [Route("api/tableMetadata")]
    [ApiController]
    public class MetadataController : ControllerBase
    {
        public ITableMetaDataService TableMetadataService { get; set; } 
        public MetadataController(ITableMetaDataService tableMetaDataService) {
            this.TableMetadataService = tableMetaDataService;
        }

        [HttpGet]
        [Route("getTableMetadata")]
        public IActionResult GetTableMetadata(string tableName)
        {
            try
            {
                return Ok(this.TableMetadataService.GetTableMetadata(tableName));
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }
    }
}
