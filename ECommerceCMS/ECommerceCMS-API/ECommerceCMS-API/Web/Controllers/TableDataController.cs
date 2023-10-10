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

        // Debug methods
        [HttpPost]
        [Route("insertData2")]
        public IActionResult InsertData()
        {
            int a = 0;

            return Ok();
        }
        [HttpPost]
        [Route("generate")]
        public IActionResult Generate()
        {
            /*Category c1 = new Category { Name = "AAA2" };
            Category c2 = new Category { Name = "BBB2" };
            this.Db.Categories.Add(c1);
            this.Db.Categories.Add(c2);

            SubCategory s1 = new SubCategory { Name = "CCC1", Category = c1 };
            SubCategory s2 = new SubCategory { Name = "CCC2", Category = c1 };

            SubCategory s3 = new SubCategory { Name = "DDD1", Category = c2 };
            SubCategory s4 = new SubCategory { Name = "DDD2", Category = c2 };

            this.Db.SubCategories.Add(s1);
            this.Db.SubCategories.Add(s2);
            this.Db.SubCategories.Add(s3);
            this.Db.SubCategories.Add(s4);*/


            Core.Entities.Attribute attribute = new Core.Entities.Attribute { Name = "Country of production" };
            Core.Entities.Attribute attribute1 = new Core.Entities.Attribute { Name = "Name of production company" };
            this.Db.Attributes.Add(attribute);
            this.Db.Attributes.Add(attribute1);

            this.Db.SaveChanges();

            return Ok();
        }
        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete()
        {
            this.Db.Attributes.RemoveRange(this.Db.Attributes.Include(a => a.Attribute_AttributeSet).ThenInclude(a => a.AttributeSet).ToList());
            this.Db.AttributeSets.RemoveRange(this.Db.AttributeSets.ToList());
            this.Db.Attribute_AttributeSets.RemoveRange(this.Db.Attribute_AttributeSets.ToList());
            this.Db.Categories.RemoveRange(this.Db.Categories.ToList());
            this.Db.Discounts.RemoveRange(this.Db.Discounts.ToList());
            this.Db.Measurements.RemoveRange(this.Db.Measurements.ToList());
            this.Db.MeasurementSets.RemoveRange(this.Db.MeasurementSets.ToList());
            this.Db.Orders.RemoveRange(this.Db.Orders.ToList());
            this.Db.Photos.RemoveRange(this.Db.Photos.ToList());
            this.Db.Products.RemoveRange(this.Db.Products.ToList());
            this.Db.Reviews.RemoveRange(this.Db.Reviews.ToList());
            this.Db.Roles.RemoveRange(this.Db.Roles.ToList());
            this.Db.ShoppingCarts.RemoveRange(this.Db.ShoppingCarts.ToList());
            this.Db.SubCategories.RemoveRange(this.Db.SubCategories.ToList());
            this.Db.Templates.RemoveRange(this.Db.Templates.ToList());
            this.Db.Users.RemoveRange(this.Db.Users.ToList());
            this.Db.Values.RemoveRange(this.Db.Values.ToList());

            this.Db.SaveChanges();

            return Ok();
        }
    }
}
