using ECommerceApp_API.Core.DTOs.FilterDTO;
using ECommerceApp_API.Core.DTOs.ProductDTOs;
using ECommerceApp_API.Core.Interfaces;
using ECommerceApp_API.Infrastructure.Data;
using ECommerceCMS_API.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp_API.Web.Controllers
{
    [Route("api/filter")]
    [ApiController]
    public class FilterController : ControllerBase
    {
        private readonly ECommerceDbContext _db;
        private readonly IFilterService _filterService;

        public FilterController(ECommerceDbContext db, IFilterService filterService)
        {
            this._db = db;
            _filterService = filterService;
        }

        [HttpGet]
        [Route("getSortings")]
        public IActionResult GetSortings()
        {
            try
            {
                List<SortingDTO> sortingDTOs = SortingDTO.GetSortingDTOs();
                return Ok(sortingDTOs);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("getFilters")]
        public IActionResult GetFilters(int subCategoryId)
        {
            try
            {
                FilterSetDTO sendingFilterDTO = this._filterService.GetSendingFilter(this._db, subCategoryId);
                return Ok(sendingFilterDTO);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("getProducts")]
        public IActionResult GetProducts(FilterSetDTO filterSetDTO, int subCategoryId)
        {
            try
            {
                FinalFilterSet finalFilterSet = this._filterService.GetFinalFilterSet(filterSetDTO);
                List<Product> products = this._filterService.GetProducts(this._db, finalFilterSet, subCategoryId);
                List<ProductSimpleDTO> productSimpleDTOs = products.Select(p => new ProductSimpleDTO(p)).ToList();
                return Ok(productSimpleDTOs);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
