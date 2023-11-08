using ECommerceCMS_API.Core.DTOs.DbInteractionDTOs;
using ECommerceCMS_API.Core.DTOs;
using ECommerceCMS_API.Core.Entities;
using ECommerceCMS_API.Core.Interfaces;
using ECommerceCMS_API.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerceCMS_API.Web.Controllers
{
    [Route("api/tableData")]
    [ApiController]
    public class TableDataController : Controller
    {
        public ITableDataService TableDataService { get; set; }
        public ECommerceDbContext Db { get; set; }
        public TableDataController(ITableDataService tableDataService, ECommerceDbContext db) {
            this.TableDataService = tableDataService;
            this.Db = db;

            this.Db.Database.EnsureCreated();
        }

        [HttpGet]
        [Authorize]
        [Route("getTableData")]
        public IActionResult GetTableData(string tableName, int pageNum, int pageSize)
        {            
            try
            {
                return Ok(this.TableDataService.GetTableData(tableName, pageNum, pageSize));
            } catch(Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Authorize]
        [Route("getPagesNumber")]
        public IActionResult GetPagesNumber(string tableName, int pageSize) { 
            try
            {
                return Ok(this.TableDataService.GetTablePagesNumber(tableName, pageSize));
            } catch(Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Authorize]
        [Route("getSearchResult")]
        public IActionResult GetSearchResult(string tableName, string input)
        {
            try
            {
                return Ok(this.TableDataService.GetSearchResult(tableName, Int32.Parse(input)));
            } catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Authorize]
        [Route("getSimpleDto")]
        public IActionResult GetSimpleDto(string tableName, int pageNum, int pageSize)
        {
            try
            {
                return Ok(this.TableDataService.GetSimpleDto(tableName, pageNum, pageSize));
            } catch(Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("insertData")]
        public IActionResult InsertData(InputBlockDTO inputBlockDTO)
        {
            try
            {
                Message message = new Message();
                this.TableDataService.InsertData(inputBlockDTO, out message);
                return Accepted(message);
            }
            catch (Exception)
            {
                Message message = Message.CreateFailed("Insertion failed", "Error occurred during insertion process.");
                return BadRequest(message);
            }
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        [Route("updateData")]
        public IActionResult UpdateData(InputBlockDTO inputBlockDTO)
        {
            try
            {
                Message message = new Message();
                this.TableDataService.UpdateData(inputBlockDTO, out message);
                return Accepted(message);
            }
            catch (Exception)
            {
                Message message = Message.CreateFailed("Updating failed", "Error occurred during updating process.");
                return BadRequest(message);
            }
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [Route("deleteData")]
        public IActionResult Delete(string tableName, string id)
        {
            try
            {
                this.TableDataService.DeleteData(tableName, Int32.Parse(id));
                Message message = Message.CreateSuccessful("Deleted", $"Data on table {tableName} with id {id} has been deleted successfully.");
                return Accepted(message);
            }
            catch (Exception)
            {
                Message message = Message.CreateFailed("Deleting failed", "Error occurred during deleting process.");
                return BadRequest(message);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("getMeasurementsFromSet")]
        public IActionResult GetMeasurementsFromSet(int measurementSetId)
        {
            try
            {
                return Ok(this.TableDataService.GetMeasurementsFromSet(measurementSetId));
            }
            catch(Exception) {
                return BadRequest();
            }            
        }
    }
}
