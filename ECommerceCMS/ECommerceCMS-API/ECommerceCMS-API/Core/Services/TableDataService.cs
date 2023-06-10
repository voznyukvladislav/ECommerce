using ECommerceCMS_API.Core.DTOs;
using ECommerceCMS_API.Core.Entities;
using ECommerceCMS_API.Core.Interfaces;
using ECommerceCMS_API.Infrastructure.Data;
using System.Text.Json;

namespace ECommerceCMS_API.Core.Services
{
    public class TableDataService : ITableDataService
    {
        public ECommerceDbContext ECommerceDbContext { get; set; }
        private Dictionary<string, Func<int, int, string>> tableDataDictionary;
        private Dictionary<string, Func<int, int>> tablePagesNumberDictionary;

        public TableDataService(ECommerceDbContext eCommerceDbContext) {
            this.ECommerceDbContext = eCommerceDbContext;

            var comparer = StringComparer.OrdinalIgnoreCase;
            this.tableDataDictionary = new Dictionary<string, Func<int, int, string>>(comparer)
             {
                {
                    "Attributes",
                    (pageNum, pageSize) => {
                        List<Entities.Attribute> attributes = this.ECommerceDbContext
                            .Attributes
                            .OrderBy(a => a.Id)
                            .Skip((pageNum - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();
                        
                        List<AttributeDTO> attributeDTOs = new List<AttributeDTO>();
                        attributes.ForEach(a =>
                        {
                            attributeDTOs.Add(new AttributeDTO(a));
                        });
                        return JsonSerializer.Serialize(attributeDTOs);
                    } 
                },
                {
                    "AttributeSets",
                    (pageNum, pageSize) => {
                        List<AttributeSet> attributeSets = this.ECommerceDbContext
                            .AttributeSets
                            .OrderBy(a => a.Id)
                            .Skip((pageNum - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();

                        List<AttributeSetDTO> attributeDTOs = new List<AttributeSetDTO>();
                        attributeSets.ForEach(a =>
                        {
                            attributeDTOs.Add(new AttributeSetDTO(a));
                        });
                        return JsonSerializer.Serialize(attributeDTOs);
                    }
                },
                {
                    "Categories",
                    (pageNum, pageSize) => {
                        List<Category> categories = this.ECommerceDbContext
                            .Categories
                            .OrderBy(a => a.Id)
                            .Skip((pageNum - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();

                        List<CategoryDTO> categoryDTOs = new List<CategoryDTO>();
                        categories.ForEach(c =>
                        {
                            categoryDTOs.Add(new CategoryDTO(c));
                        });
                        return JsonSerializer.Serialize(categoryDTOs);
                    }
                },
                {
                    "Discounts",
                    (pageNum, pageSize) => {
                        List<Discount> discounts = this.ECommerceDbContext
                            .Discounts
                            .OrderBy(a => a.Id)
                            .Skip((pageNum - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();

                        List<DiscountDTO> discountDTOs = new List<DiscountDTO>();
                        discounts.ForEach(d =>
                        {
                            discountDTOs.Add(new DiscountDTO(d));
                        });
                        return JsonSerializer.Serialize(discountDTOs);
                    }
                },
                {
                    "Measurements",
                    (pageNum, pageSize) => {
                        List<Measurement> measurements = this.ECommerceDbContext
                            .Measurements
                            .OrderBy(a => a.Id)
                            .Skip((pageNum - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();

                        List<MeasurementDTO> measurementDTOs = new List<MeasurementDTO>();
                        measurements.ForEach(m =>
                        {
                            measurementDTOs.Add(new MeasurementDTO(m));
                        });
                        return JsonSerializer.Serialize(measurementDTOs);
                    }
                },
                {
                    "MeasurementSets",
                    (pageNum, pageSize) => {
                        List<MeasurementSet> data = this.ECommerceDbContext
                            .MeasurementSets
                            .OrderBy(a => a.Id)
                            .Skip((pageNum - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();

                        List<MeasurementSetDTO> dtos = new List<MeasurementSetDTO>();
                        data.ForEach(i =>
                        {
                            dtos.Add(new MeasurementSetDTO(i));
                        });
                        return JsonSerializer.Serialize(dtos);
                    }
                },
                {
                    "Orders",
                    (pageNum, pageSize) => {
                        List<Order> data = this.ECommerceDbContext
                            .Orders
                            .OrderBy(a => a.Id)
                            .Skip((pageNum - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();

                        List<OrderDTO> dtos = new List<OrderDTO>();
                        data.ForEach(i =>
                        {
                            dtos.Add(new OrderDTO(i));
                        });
                        return JsonSerializer.Serialize(dtos);
                    }
                },
                {
                    "Products",
                    (pageNum, pageSize) => {
                        List<Product> data = this.ECommerceDbContext
                            .Products
                            .OrderBy(a => a.Id)
                            .Skip((pageNum - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();

                        List<ProductDTO> dtos = new List<ProductDTO>();
                        data.ForEach(i =>
                        {
                            dtos.Add(new ProductDTO(i));
                        });
                        return JsonSerializer.Serialize(dtos);
                    }
                },
                {
                    "Reviews",
                    (pageNum, pageSize) => {
                        List<Review> data = this.ECommerceDbContext
                            .Reviews
                            .OrderBy(a => a.Id)
                            .Skip((pageNum - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();

                        List<ReviewDTO> dtos = new List<ReviewDTO>();
                        data.ForEach(i =>
                        {
                            dtos.Add(new ReviewDTO(i));
                        });
                        return JsonSerializer.Serialize(dtos);
                    }
                },
                {
                    "Roles",
                    (pageNum, pageSize) => {
                        List<Role> data = this.ECommerceDbContext
                            .Roles
                            .OrderBy(a => a.Id)
                            .Skip((pageNum - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();

                        List<RoleDTO> dtos = new List<RoleDTO>();
                        data.ForEach(i =>
                        {
                            dtos.Add(new RoleDTO(i));
                        });
                        return JsonSerializer.Serialize(dtos);
                    }
                },
                {
                    "ShoppingCarts",
                    (pageNum, pageSize) => {
                        List<ShoppingCart> data = this.ECommerceDbContext
                            .ShoppingCarts
                            .OrderBy(a => a.Id)
                            .Skip((pageNum - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();

                        List<ShoppingCartDTO> dtos = new List<ShoppingCartDTO>();
                        data.ForEach(i =>
                        {
                            dtos.Add(new ShoppingCartDTO(i));
                        });
                        return JsonSerializer.Serialize(dtos);
                    }
                },
                {
                    "SubCategories",
                    (pageNum, pageSize) => {
                        List<SubCategory> data = this.ECommerceDbContext
                            .SubCategories
                            .OrderBy(a => a.Id)
                            .Skip((pageNum - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();

                        List<SubCategoryDTO> dtos = new List<SubCategoryDTO>();
                        data.ForEach(i =>
                        {
                            dtos.Add(new SubCategoryDTO(i));
                        });
                        return JsonSerializer.Serialize(dtos);
                    }
                },
                {
                    "Templates",
                    (pageNum, pageSize) => {
                        List<Template> data = this.ECommerceDbContext
                            .Templates
                            .OrderBy(a => a.Id)
                            .Skip((pageNum - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();

                        List<TemplateDTO> dtos = new List<TemplateDTO>();
                        data.ForEach(i =>
                        {
                            dtos.Add(new TemplateDTO(i));
                        });
                        return JsonSerializer.Serialize(dtos);
                    }
                },
                {
                    "Users",
                    (pageNum, pageSize) => {
                        List<User> data = this.ECommerceDbContext
                            .Users
                            .OrderBy(a => a.Id)
                            .Skip((pageNum - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();

                        List<UserDTO> dtos = new List<UserDTO>();
                        data.ForEach(i =>
                        {
                            dtos.Add(new UserDTO(i));
                        });
                        return JsonSerializer.Serialize(dtos);
                    }
                },
                {
                    "Values",
                    (pageNum, pageSize) => {
                        List<Value> data = this.ECommerceDbContext
                            .Values
                            .OrderBy(a => a.Id)
                            .Skip((pageNum - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();

                        List<ValueDTO> dtos = new List<ValueDTO>();
                        data.ForEach(i =>
                        {
                            dtos.Add(new ValueDTO(i));
                        });
                        return JsonSerializer.Serialize(dtos);
                    }
                },

            };
            this.tablePagesNumberDictionary = new Dictionary<string, Func<int, int>>(comparer)
            {
                {
                    "Attributes",
                    (pageSize) =>
                    {
                        int pagesNum = this.ECommerceDbContext.Attributes.Count() / pageSize;
                        if(pagesNum < 1) pagesNum = 1;
                        return pagesNum;
                    }                    
                },
                {
                    "AttributeSets",
                    (pageSize) =>
                    {
                        int pagesNum = this.ECommerceDbContext.AttributeSets.Count() / pageSize;
                        if(pagesNum < 1) pagesNum = 1;
                        return pagesNum;
                    }
                },
                {
                    "Categories",
                    (pageSize) =>
                    {
                        int pagesNum = this.ECommerceDbContext.Categories.Count() / pageSize;
                        if(pagesNum < 1) pagesNum = 1;
                        return pagesNum;
                    }
                },
                {
                    "Discounts",
                    (pageSize) =>
                    {
                        int pagesNum = this.ECommerceDbContext.Discounts.Count() / pageSize;
                        if(pagesNum < 1) pagesNum = 1;
                        return pagesNum;
                    }
                },
                {
                    "Measurements",
                    (pageSize) =>
                    {
                        int pagesNum = this.ECommerceDbContext.Measurements.Count() / pageSize;
                        if(pagesNum < 1) pagesNum = 1;
                        return pagesNum;
                    }
                },
                {
                    "MeasurementSets",
                    (pageSize) =>
                    {
                        int pagesNum = this.ECommerceDbContext.MeasurementSets.Count() / pageSize;
                        if(pagesNum < 1) pagesNum = 1;
                        return pagesNum;
                    }
                },
                {
                    "Orders",
                    (pageSize) =>
                    {
                        int pagesNum = this.ECommerceDbContext.Orders.Count() / pageSize;
                        if(pagesNum < 1) pagesNum = 1;
                        return pagesNum;
                    }
                },
                {
                    "Products",
                    (pageSize) =>
                    {
                        int pagesNum = this.ECommerceDbContext.Products.Count() / pageSize;
                        if(pagesNum < 1) pagesNum = 1;
                        return pagesNum;
                    }
                },
                {
                    "Reviews",
                    (pageSize) =>
                    {
                        int pagesNum = this.ECommerceDbContext.Reviews.Count() / pageSize;
                        if(pagesNum < 1) pagesNum = 1;
                        return pagesNum;
                    }
                },
                {
                    "Roles",
                    (pageSize) =>
                    {
                        int pagesNum = this.ECommerceDbContext.Roles.Count() / pageSize;
                        if(pagesNum < 1) pagesNum = 1;
                        return pagesNum;
                    }
                },
                {
                    "ShoppingCarts",
                    (pageSize) =>
                    {
                        int pagesNum = this.ECommerceDbContext.ShoppingCarts.Count() / pageSize;
                        if(pagesNum < 1) pagesNum = 1;
                        return pagesNum;
                    }
                },
                {
                    "SubCategories",
                    (pageSize) =>
                    {
                        int pagesNum = this.ECommerceDbContext.SubCategories.Count() / pageSize;
                        if(pagesNum < 1) pagesNum = 1;
                        return pagesNum;
                    }
                },
                {
                    "Templates",
                    (pageSize) =>
                    {
                        int pagesNum = this.ECommerceDbContext.Templates.Count() / pageSize;
                        if(pagesNum < 1) pagesNum = 1;
                        return pagesNum;
                    }
                },
                {
                    "Users",
                    (pageSize) =>
                    {
                        int pagesNum = this.ECommerceDbContext.Users.Count() / pageSize;
                        if(pagesNum < 1) pagesNum = 1;
                        return pagesNum;
                    }
                },
                {
                    "Values",
                    (pageSize) =>
                    {
                        int pagesNum = this.ECommerceDbContext.Values.Count() / pageSize;
                        if(pagesNum < 1) pagesNum = 1;
                        return pagesNum;
                    }
                },
            };
        }

        public string GetTableData(string tableName, int pageNum, int pageSize)
        {
            return this.tableDataDictionary[tableName](pageNum, pageSize);
        }

        public string GetTablePagesNumber(string tableName, int pageSize)
        {
            return this.tablePagesNumberDictionary[tableName](pageSize).ToString();
        }
    }
}
