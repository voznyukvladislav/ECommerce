using ECommerceCMS_API.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceCMS_API.Web.Controllers
{
    public class TableDataController : Controller
    {
        public ITableDataService TableDataService { get; set; }
        public TableDataController(ITableDataService tableDataService) {
            this.TableDataService = tableDataService;
        }
        public IActionResult GetTableData(string tableName, int pageNum, int pageSize)
        {
            try
            {
                return Ok(this.TableDataService.GetTableData(tableName, pageNum, pageSize));
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public IActionResult GetPagesNumber(string tableName, int pageNum) { 
            try
            {
                return Ok(this.TableDataService.GetTablePagesNumber(tableName, pageNum));
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
