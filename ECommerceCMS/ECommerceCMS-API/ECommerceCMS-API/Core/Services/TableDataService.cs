using ECommerceCMS_API.Core.DTOs;
using ECommerceCMS_API.Core.DTOs.DbInteractionDTOs;
using ECommerceCMS_API.Core.DTOs.EntityDTOs;
using ECommerceCMS_API.Core.Entities;
using ECommerceCMS_API.Core.Interfaces;
using ECommerceCMS_API.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace ECommerceCMS_API.Core.Services
{
    public class TableDataService : ITableDataService
    {
        public ECommerceDbContext ECommerceDbContext { get; set; }

        private Dictionary<string, Func<int, int, string>> tableDataDictionary;
        private Dictionary<string, Func<int, int>> tablePagesNumberDictionary;
        private Dictionary<string, Func<int, string>> tableSearchDictionary;
        private Dictionary<string, Func<int, int, string>> tableSimpleDataDictionary;

        private Dictionary<string, Action<InputBlockDTO>> tableInsertionDictionary;
        private Dictionary<string, Action<InputBlockDTO>> tableUpdateDictionary;

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
                            .Include(a => a.MeasurementSet)
                            .Include(a => a.Attribute_AttributeSet)
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
                            .Include(a => a.Attribute_AttributeSet)
                            .Include(a => a.Templates)
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
                            .Include(c => c.SubCategories)
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
                            .Include(m => m.MeasurementSets)
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
                            .Include(ms => ms.Measurements)
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
                            .Include(o => o.User)
                            .Include(o => o.Products)
                            .Include(o => o.OrderStatus)
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
                    "Order_Product",
                    (pageNum, pageSize) => {
                        List<Order_Product> data = this.ECommerceDbContext
                            .Order_Product
                            .OrderBy(a => a.Id)
                            .Skip((pageNum - 1) * pageSize)
                            .Take(pageSize)
                            .Include(o => o.Order)
                            .Include(o => o.Product)
                            .ToList();

                        List<Order_Product_DTO> dtos = new List<Order_Product_DTO>();
                        data.ForEach(i =>
                        {
                            dtos.Add(new Order_Product_DTO(i));
                        });
                        return JsonSerializer.Serialize(dtos);
                    }
                },
                {
                    "OrderStatuses",
                    (pageNum, pageSize) => {
                        List<OrderStatus> data = this.ECommerceDbContext
                            .OrderStatuses
                            .OrderBy(a => a.Id)
                            .Skip((pageNum - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();

                        List<OrderStatusDTO> dtos = new List<OrderStatusDTO>();
                        data.ForEach(i =>
                        {
                            dtos.Add(new OrderStatusDTO(i));
                        });
                        return JsonSerializer.Serialize(dtos);
                    }
                },
                {
                    "Photos",
                    (pageNum, pageSize) =>
                    {
                        List<Photo> data = this.ECommerceDbContext
                            .Photos
                            .OrderBy(a => a.Id)
                            .Skip((pageNum - 1) * pageSize)
                            .Take(pageSize)
                            .Include(p => p.Product)
                            .ToList();

                        List<PhotoDTO> dtos = new List<PhotoDTO>();
                        data.ForEach(i =>
                        {
                            dtos.Add(new PhotoDTO(i));
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
                            .Include(p => p.Orders)
                            .Include(p => p.Reviews)
                            .Include(p => p.ShoppingCarts)
                            .Include(p => p.Values)
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
                            .Include(r => r.User)
                            .Include(r => r.Product)
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
                            .Include(r => r.Users)
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
                            .Include(sc => sc.Products)
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
                            .Include(t => t.AttributeSets)
                            .Include(t => t.Products)
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
                            .Include(u => u.Role)
                            .Include(u => u.Reviews)
                            .Include(u => u.ShoppingCarts)
                            .Include(u => u.Orders)
                            .ThenInclude(o => o.Products)
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
                            .Include(v => v.Product)
                            .Include(v => v.Attribute_AttributeSet)
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
                        double pagesNum = Convert.ToDouble(this.ECommerceDbContext.Attributes.Count()) / Convert.ToDouble(pageSize);
                        if(pagesNum < 1) return 1;
                        return (int) Math.Ceiling(pagesNum);
                    }                    
                },
                {
                    "AttributeSets",
                    (pageSize) =>
                    {
                        double pagesNum = Convert.ToDouble(this.ECommerceDbContext.AttributeSets.Count()) / Convert.ToDouble(pageSize);
                        if(pagesNum < 1) return 1;
                        return (int) Math.Ceiling(pagesNum);
                    }
                },
                {
                    "Categories",
                    (pageSize) =>
                    {
                        double pagesNum = Convert.ToDouble(this.ECommerceDbContext.Categories.Count()) / Convert.ToDouble(pageSize);
                        if(pagesNum < 1) return 1;
                        return (int) Math.Ceiling(pagesNum);
                    }
                },
                {
                    "Discounts",
                    (pageSize) =>
                    {
                        double pagesNum = Convert.ToDouble(this.ECommerceDbContext.Discounts.Count()) / Convert.ToDouble(pageSize);
                        if(pagesNum < 1) return 1;
                        return (int) Math.Ceiling(pagesNum);
                    }
                },
                {
                    "Measurements",
                    (pageSize) =>
                    {
                        double pagesNum = Convert.ToDouble(this.ECommerceDbContext.Measurements.Count()) / Convert.ToDouble(pageSize);
                        if(pagesNum < 1) return 1;
                        return (int) Math.Ceiling(pagesNum);
                    }
                },
                {
                    "MeasurementSets",
                    (pageSize) =>
                    {
                        double pagesNum = Convert.ToDouble(this.ECommerceDbContext.MeasurementSets.Count()) / Convert.ToDouble(pageSize);
                        if(pagesNum < 1) return 1;
                        return (int) Math.Ceiling(pagesNum);
                    }
                },
                {
                    "Orders",
                    (pageSize) =>
                    {
                        double pagesNum = Convert.ToDouble(this.ECommerceDbContext.Orders.Count()) / Convert.ToDouble(pageSize);
                        if(pagesNum < 1) return 1;
                        return (int) Math.Ceiling(pagesNum);
                    }
                },
                {
                    "Order_Product",
                    (pageSize) =>
                    {
                        double pagesNum = Convert.ToDouble(this.ECommerceDbContext.Order_Product.Count()) / Convert.ToDouble(pageSize);
                        if(pagesNum < 1) return 1;
                        return (int) Math.Ceiling(pagesNum);
                    }
                },
                {
                    "Photos",
                    (pageSize) =>
                    {
                        double pagesNum = Convert.ToDouble(this.ECommerceDbContext.Photos.Count()) / Convert.ToDouble(pageSize);
                        if(pagesNum < 1) return 1;
                        return (int) Math.Ceiling(pagesNum);
                    }
                },
                {
                    "Products",
                    (pageSize) =>
                    {
                        double pagesNum = Convert.ToDouble(this.ECommerceDbContext.Products.Count()) / Convert.ToDouble(pageSize);
                        if(pagesNum < 1) return 1;
                        return (int) Math.Ceiling(pagesNum);
                    }
                },
                {
                    "Reviews",
                    (pageSize) =>
                    {
                        double pagesNum = Convert.ToDouble(this.ECommerceDbContext.Reviews.Count()) / Convert.ToDouble(pageSize);
                        if(pagesNum < 1) return 1;
                        return (int) Math.Ceiling(pagesNum);
                    }
                },
                {
                    "Roles",
                    (pageSize) =>
                    {
                        double pagesNum = Convert.ToDouble(this.ECommerceDbContext.Roles.Count()) / Convert.ToDouble(pageSize);
                        if(pagesNum < 1) return 1;
                        return (int) Math.Ceiling(pagesNum);
                    }
                },
                {
                    "ShoppingCarts",
                    (pageSize) =>
                    {
                        double pagesNum = Convert.ToDouble(this.ECommerceDbContext.ShoppingCarts.Count()) / Convert.ToDouble(pageSize);
                        if(pagesNum < 1) return 1;
                        return (int) Math.Ceiling(pagesNum);
                    }
                },
                {
                    "SubCategories",
                    (pageSize) =>
                    {
                        double pagesNum = Convert.ToDouble(this.ECommerceDbContext.SubCategories.Count()) / Convert.ToDouble(pageSize);
                        if(pagesNum < 1) return 1;
                        return (int) Math.Ceiling(pagesNum);
                    }
                },
                {
                    "Templates",
                    (pageSize) =>
                    {
                        double pagesNum = Convert.ToDouble(this.ECommerceDbContext.Templates.Count()) / Convert.ToDouble(pageSize);
                        if(pagesNum < 1) return 1;
                        return (int) Math.Ceiling(pagesNum);
                    }
                },
                {
                    "Users",
                    (pageSize) =>
                    {
                        double pagesNum = Convert.ToDouble(this.ECommerceDbContext.Users.Count()) / Convert.ToDouble(pageSize);
                        if(pagesNum < 1) return 1;
                        return (int) Math.Ceiling(pagesNum);
                    }
                },
                {
                    "Values",
                    (pageSize) =>
                    {
                        double pagesNum = Convert.ToDouble(this.ECommerceDbContext.Values.Count()) / Convert.ToDouble(pageSize);
                        if(pagesNum < 1) return 1;
                        return (int) Math.Ceiling(pagesNum);
                    }
                },
            };
            this.tableSearchDictionary = new Dictionary<string, Func<int, string>>(comparer)
            {
                {
                    "Attributes",
                    (input) =>
                    {
                        List<Entities.Attribute> result = this.ECommerceDbContext
                        .Attributes
                        .Where(a => a.Id == input)
                        .ToList();
                        List<AttributeDTO> resultDTOs = new List<AttributeDTO>();
                        result.ForEach(i =>
                        {
                            resultDTOs.Add(new AttributeDTO(i));
                        });
                        return JsonSerializer.Serialize(resultDTOs);
                    }
                },
                {
                    "AttributeSets",
                    (input) =>
                    {
                        List<AttributeSet> result = this.ECommerceDbContext
                        .AttributeSets
                        .Where(el => el.Id == input)
                        .ToList();
                        List<AttributeSetDTO> resultDTOs = new List<AttributeSetDTO>();
                        result.ForEach(i =>
                        {
                            resultDTOs.Add(new AttributeSetDTO(i));
                        });
                        return JsonSerializer.Serialize(resultDTOs);
                    }
                },
                {
                    "Categories",
                    (input) =>
                    {
                        List<Category> result = this.ECommerceDbContext
                        .Categories
                        .Where(el => el.Id == input)
                        .ToList();
                        List<CategoryDTO> resultDTOs = new List<CategoryDTO>();
                        result.ForEach(i =>
                        {
                            resultDTOs.Add(new CategoryDTO(i));
                        });
                        return JsonSerializer.Serialize(resultDTOs);
                    }
                },
                {
                    "Discounts",
                    (input) =>
                    {
                        List<Discount> result = this.ECommerceDbContext
                        .Discounts
                        .Where(el => el.Id == input)
                        .ToList();
                        List<DiscountDTO> resultDTOs = new List<DiscountDTO>();
                        result.ForEach(i =>
                        {
                            resultDTOs.Add(new DiscountDTO(i));
                        });
                        return JsonSerializer.Serialize(resultDTOs);
                    }
                },
                {
                    "Measurements",
                    (input) =>
                    {
                        List<Measurement> result = this.ECommerceDbContext
                        .Measurements
                        .Where(el => el.Id == input)
                        .ToList();
                        List<MeasurementDTO> resultDTOs = new List<MeasurementDTO>();
                        result.ForEach(i =>
                        {
                            resultDTOs.Add(new MeasurementDTO(i));
                        });
                        return JsonSerializer.Serialize(resultDTOs);
                    }
                },
                {
                    "MeasurementSets",
                    (input) =>
                    {
                        List<MeasurementSet> result = this.ECommerceDbContext
                        .MeasurementSets
                        .Where(el => el.Id == input)
                        .ToList();
                        List<MeasurementSetDTO> resultDTOs = new List<MeasurementSetDTO>();
                        result.ForEach(i =>
                        {
                            resultDTOs.Add(new MeasurementSetDTO(i));
                        });
                        return JsonSerializer.Serialize(resultDTOs);
                    }
                },
                {
                    "Orders",
                    (input) =>
                    {
                        List<Order> result = this.ECommerceDbContext
                        .Orders
                        .Where(el => el.Id == input)
                        .ToList();
                        List<OrderDTO> resultDTOs = new List<OrderDTO>();
                        result.ForEach(i =>
                        {
                            resultDTOs.Add(new OrderDTO(i));
                        });
                        return JsonSerializer.Serialize(resultDTOs);
                    }
                },
                {
                    "Order_Product",
                    (input) =>
                    {
                        List<Order_Product> result = this.ECommerceDbContext
                        .Order_Product
                        .Where(el => el.Id == input)
                        .ToList();
                        List<Order_Product_DTO> resultDTOs = new List<Order_Product_DTO>();
                        result.ForEach(i =>
                        {
                            resultDTOs.Add(new Order_Product_DTO(i));
                        });
                        return JsonSerializer.Serialize(resultDTOs);
                    }
                },
                {
                    "Photos",
                    (input) =>
                    {
                        List<Photo> result = this.ECommerceDbContext
                        .Photos
                        .Where(el => el.Id == input)
                        .ToList();
                        List<PhotoDTO> resultDTOs = new List<PhotoDTO>();
                        result.ForEach(i =>
                        {
                            resultDTOs.Add(new PhotoDTO(i));
                        });
                        return JsonSerializer.Serialize(resultDTOs);
                    }
                },
                {
                    "Products",
                    (input) =>
                    {
                        List<Product> result = this.ECommerceDbContext
                        .Products
                        .Where(el => el.Id == input)
                        .ToList();
                        List<ProductDTO> resultDTOs = new List<ProductDTO>();
                        result.ForEach(i =>
                        {
                            resultDTOs.Add(new ProductDTO(i));
                        });
                        return JsonSerializer.Serialize(resultDTOs);
                    }
                },
                {
                    "Reviews",
                    (input) =>
                    {
                        List<Review> result = this.ECommerceDbContext
                        .Reviews
                        .Where(el => el.Id == input)
                        .ToList();
                        List<ReviewDTO> resultDTOs = new List<ReviewDTO>();
                        result.ForEach(i =>
                        {
                            resultDTOs.Add(new ReviewDTO(i));
                        });
                        return JsonSerializer.Serialize(resultDTOs);
                    }
                },
                {
                    "Roles",
                    (input) =>
                    {
                        List<Role> result = this.ECommerceDbContext
                        .Roles
                        .Where(el => el.Id == input)
                        .ToList();
                        List<RoleDTO> resultDTOs = new List<RoleDTO>();
                        result.ForEach(i =>
                        {
                            resultDTOs.Add(new RoleDTO(i));
                        });
                        return JsonSerializer.Serialize(resultDTOs);
                    }
                },
                {
                    "ShoppingCarts",
                    (input) =>
                    {
                        List<ShoppingCart> result = this.ECommerceDbContext
                        .ShoppingCarts
                        .Where(el => el.Id == input)
                        .ToList();
                        List<ShoppingCartDTO> resultDTOs = new List<ShoppingCartDTO>();
                        result.ForEach(i =>
                        {
                            resultDTOs.Add(new ShoppingCartDTO(i));
                        });
                        return JsonSerializer.Serialize(resultDTOs);
                    }
                },
                {
                    "SubCategories",
                    (input) =>
                    {
                        List<SubCategory> result = this.ECommerceDbContext
                        .SubCategories
                        .Where(el => el.Id == input)
                        .ToList();
                        List<SubCategoryDTO> resultDTOs = new List<SubCategoryDTO>();
                        result.ForEach(i =>
                        {
                            resultDTOs.Add(new SubCategoryDTO(i));
                        });
                        return JsonSerializer.Serialize(resultDTOs);
                    }
                },
                {
                    "Templates",
                    (input) =>
                    {
                        List<Template> result = this.ECommerceDbContext
                        .Templates
                        .Where(el => el.Id == input)
                        .ToList();
                        List<TemplateDTO> resultDTOs = new List<TemplateDTO>();
                        result.ForEach(i =>
                        {
                            resultDTOs.Add(new TemplateDTO(i));
                        });
                        return JsonSerializer.Serialize(resultDTOs);
                    }
                },
                {
                    "Users",
                    (input) =>
                    {
                        List<User> result = this.ECommerceDbContext
                        .Users
                        .Where(el => el.Id == input)
                        .ToList();
                        List<UserDTO> resultDTOs = new List<UserDTO>();
                        result.ForEach(i =>
                        {
                            resultDTOs.Add(new UserDTO(i));
                        });
                        return JsonSerializer.Serialize(resultDTOs);
                    }
                },
                {
                    "Values",
                    (input) =>
                    {
                        List<Value> result = this.ECommerceDbContext
                        .Values
                        .Where(el => el.Id == input)
                        .ToList();
                        List<ValueDTO> resultDTOs = new List<ValueDTO>();
                        result.ForEach(i =>
                        {
                            resultDTOs.Add(new ValueDTO(i));
                        });
                        return JsonSerializer.Serialize(resultDTOs);
                    }
                }
            };
            this.tableSimpleDataDictionary = new Dictionary<string, Func<int, int, string>>(comparer)
            {
                {
                    "Attributes",
                    (pageNum, pageSize) =>
                    {
                        List<SimpleDTO> result = this.ECommerceDbContext
                        .Attributes
                        .Select(a => new SimpleDTO(a))
                        .Skip((pageNum - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();
                        return JsonSerializer.Serialize(result);
                    }
                },
                {
                    "AttributeSets",
                    (pageNum, pageSize) =>
                    {
                        List<SimpleDTO> result = this.ECommerceDbContext
                        .AttributeSets
                        .Select(a => new SimpleDTO(a))
                        .Skip((pageNum - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();
                        return JsonSerializer.Serialize(result);
                    }
                },
                {
                    "Categories",
                    (pageNum, pageSize) =>
                    {
                        List<SimpleDTO> result = this.ECommerceDbContext
                        .Categories
                        .Select(a => new SimpleDTO(a))
                        .Skip((pageNum - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();
                        return JsonSerializer.Serialize(result);
                    }
                },
                {
                    "Discounts",
                    (pageNum, pageSize) =>
                    {
                        List<SimpleDTO> result = this.ECommerceDbContext
                        .Discounts
                        .Select(a => new SimpleDTO(a))
                        .Skip((pageNum - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();
                        return JsonSerializer.Serialize(result);
                    }
                },
                {
                    "Measurements",
                    (pageNum, pageSize) =>
                    {
                        List<SimpleDTO> result = this.ECommerceDbContext
                        .Measurements
                        .Select(a => new SimpleDTO(a))
                        .Skip((pageNum - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();
                        return JsonSerializer.Serialize(result);
                    }
                },
                {
                    "MeasurementSets",
                    (pageNum, pageSize) =>
                    {
                        List<SimpleDTO> result = this.ECommerceDbContext
                        .MeasurementSets
                        .Select(a => new SimpleDTO(a))
                        .Skip((pageNum - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();
                        return JsonSerializer.Serialize(result);
                    }
                },
                {
                    "Orders",
                    (pageNum, pageSize) =>
                    {
                        List<SimpleDTO> result = this.ECommerceDbContext
                        .Orders
                        .Select(a => new SimpleDTO(a))
                        .Skip((pageNum - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();
                        return JsonSerializer.Serialize(result);
                    }
                },
                {
                    "Order_Product",
                    (pageNum, pageSize) =>
                    {
                        List<SimpleDTO> result = this.ECommerceDbContext
                        .Order_Product
                        .Select(a => new SimpleDTO(a))
                        .Skip((pageNum - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();
                        return JsonSerializer.Serialize(result);
                    }
                },
                {
                    "OrderStatuses",
                    (pageNum, pageSize) =>
                    {
                        List<SimpleDTO> result = this.ECommerceDbContext
                        .OrderStatuses
                        .Select(a => new SimpleDTO(a))
                        .Skip((pageNum - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();
                        return JsonSerializer.Serialize(result);
                    }
                },
                {
                    "Photos",
                    (pageNum, pageSize) =>
                    {
                        List<SimpleDTO> result = this.ECommerceDbContext
                        .Photos
                        .Select(a => new SimpleDTO(a))
                        .Skip((pageNum - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();
                        return JsonSerializer.Serialize(result);
                    }
                },
                {
                    "Products",
                    (pageNum, pageSize) =>
                    {
                        List<SimpleDTO> result = this.ECommerceDbContext
                        .Products
                        .Select(a => new SimpleDTO(a))
                        .Skip((pageNum - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();
                        return JsonSerializer.Serialize(result);
                    }
                },
                {
                    "Reviews",
                    (pageNum, pageSize) =>
                    {
                        List<SimpleDTO> result = this.ECommerceDbContext
                        .Reviews
                        .Select(a => new SimpleDTO(a))
                        .Skip((pageNum - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();
                        return JsonSerializer.Serialize(result);
                    }
                },
                {
                    "Roles",
                    (pageNum, pageSize) =>
                    {
                        List<SimpleDTO> result = this.ECommerceDbContext
                        .Roles
                        .Select(a => new SimpleDTO(a))
                        .Skip((pageNum - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();
                        return JsonSerializer.Serialize(result);
                    }
                },
                {
                    "ShoppingCarts",
                    (pageNum, pageSize) =>
                    {
                        List<SimpleDTO> result = this.ECommerceDbContext
                        .ShoppingCarts
                        .Select(a => new SimpleDTO(a))
                        .Skip((pageNum - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();
                        return JsonSerializer.Serialize(result);
                    }
                },
                {
                    "SubCategories",
                    (pageNum, pageSize) =>
                    {
                        List<SimpleDTO> result = this.ECommerceDbContext
                        .SubCategories
                        .Select(a => new SimpleDTO(a))
                        .Skip((pageNum - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();
                        return JsonSerializer.Serialize(result);
                    }
                },
                {
                    "Templates",
                    (pageNum, pageSize) =>
                    {
                        List<SimpleDTO> result = this.ECommerceDbContext
                        .Templates
                        .Select(a => new SimpleDTO(a))
                        .Skip((pageNum - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();
                        return JsonSerializer.Serialize(result);
                    }
                },
                {
                    "Users",
                    (pageNum, pageSize) =>
                    {
                        List<SimpleDTO> result = this.ECommerceDbContext
                        .Users
                        .Select(a => new SimpleDTO(a))
                        .Skip((pageNum - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();
                        return JsonSerializer.Serialize(result);
                    }
                },
                {
                    "Values",
                    (pageNum, pageSize) =>
                    {
                        List<SimpleDTO> result = this.ECommerceDbContext
                        .Values
                        .Select(a => new SimpleDTO(a))
                        .Skip((pageNum - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();
                        return JsonSerializer.Serialize(result);
                    }
                }
            };

            this.tableInsertionDictionary = new Dictionary<string, Action<InputBlockDTO>>(comparer)
            {
                { 
                    "Attributes",
                    (inputBlockDTO) =>
                    {
                        Core.Entities.Attribute attribute = new Core.Entities.Attribute(inputBlockDTO);
                        this.ECommerceDbContext.Attributes.Add(attribute);
                        this.ECommerceDbContext.SaveChanges();

                        return;
                    }
                },
                {
                    "AttributeSets",
                    (inputBlockDTO) =>
                    {
                        AttributeSet attributeSet = new AttributeSet(this.ECommerceDbContext, inputBlockDTO);
                        this.ECommerceDbContext.AttributeSets.Add(attributeSet);
                        this.ECommerceDbContext.SaveChanges();

                        return;
                    }
                },
                {
                    "Categories",
                    (inputBlockDTO) =>
                    {
                        Category category = new Category(inputBlockDTO);
                        this.ECommerceDbContext.Categories.Add(category);
                        this.ECommerceDbContext.SaveChanges();

                        return;
                    }
                },
                {
                    "Discounts",
                    (inputBlockDTO) =>
                    {
                        Discount discount = new Discount(inputBlockDTO);
                        this.ECommerceDbContext.Discounts.Add(discount);
                        this.ECommerceDbContext.SaveChanges();

                        return;
                    }
                },
                {
                    "Measurements",
                    (inputBlockDTO) =>
                    {
                        Measurement measurement = new Measurement(inputBlockDTO);
                        this.ECommerceDbContext.Measurements.Add(measurement);
                        this.ECommerceDbContext.SaveChanges();

                        return;
                    }
                },
                {
                    "MeasurementSets",
                    (inputBlockDTO) =>
                    {
                        MeasurementSet measurementSet = new MeasurementSet(this.ECommerceDbContext, inputBlockDTO);
                        this.ECommerceDbContext.MeasurementSets.Add(measurementSet);
                        this.ECommerceDbContext.SaveChanges();

                        return;
                    }
                },
                {
                    "Orders",
                    (inputBlockDTO) =>
                    {
                        Order order = new Order(this.ECommerceDbContext, inputBlockDTO);
                        this.ECommerceDbContext.Orders.Add(order);
                        this.ECommerceDbContext.SaveChanges();

                        return;
                    }
                },
                {
                    "Order_Product",
                    (inputBlockDTO) =>
                    {
                        Order_Product orderProduct = new Order_Product(this.ECommerceDbContext, inputBlockDTO);
                        Order order = this.ECommerceDbContext.Orders
                            .Where(o => o.Id == orderProduct.OrderId)
                            .Include(o => o.Products)
                            .First();

                        if (!order.Products.Any(op => op.Id == orderProduct.Id))
                        {
                            this.ECommerceDbContext.Order_Product.Add(orderProduct);
                            this.ECommerceDbContext.SaveChanges();
                        }
                        else
                        {
                            Order_Product opDb = order.Products
                                .Where(op => op.Id == orderProduct.Id)
                                .First();
                            opDb.Count += orderProduct.Count;

                            orderProduct = opDb;

                            this.ECommerceDbContext.Order_Product.Update(orderProduct);
                            this.ECommerceDbContext.SaveChanges();
                        }
                        
                        order.TotalPrice = order.Products.Sum(op => op.TotalPrice);

                        this.ECommerceDbContext.Orders.Update(order);
                        this.ECommerceDbContext.SaveChanges();

                        return;
                    }
                },
                {
                    "OrderStatuses",
                    (inputBlockDTO) =>
                    {
                        OrderStatus orderStatus = new OrderStatus(this.ECommerceDbContext, inputBlockDTO);
                        this.ECommerceDbContext.OrderStatuses.Add(orderStatus);
                        this.ECommerceDbContext.SaveChanges();

                        return;
                    }
                },
                {
                    "Photos",
                    (inputBlockDTO) =>
                    {
                        Photo photo = new Photo(this.ECommerceDbContext, inputBlockDTO);
                        this.ECommerceDbContext.Photos.Add(photo);
                        this.ECommerceDbContext.SaveChanges();

                        return;
                    }
                },
                {
                    "Products",
                    (inputBlockDTO) =>
                    {
                        Product product = new Product(this.ECommerceDbContext, inputBlockDTO);
                        this.ECommerceDbContext.Products.Add(product);
                        this.ECommerceDbContext.SaveChanges();

                        return;
                    }
                },
                {
                    "Reviews",
                    (inputBlockDTO) =>
                    {
                        Review review = new Review(this.ECommerceDbContext, inputBlockDTO);
                        this.ECommerceDbContext.Reviews.Add(review);
                        this.ECommerceDbContext.SaveChanges();

                        return;
                    }
                },
                {
                    "Roles",
                    (inputBlockDTO) =>
                    {
                        Role role = new Role(inputBlockDTO);
                        this.ECommerceDbContext.Roles.Add(role);
                        this.ECommerceDbContext.SaveChanges();

                        return;
                    }
                },
                {
                    "ShoppingCarts",
                    (inputBlockDTO) =>
                    {

                    }
                },
                {
                    "SubCategories",
                    (inputBlockDTO) =>
                    {
                        SubCategory subCategory = new SubCategory(ECommerceDbContext, inputBlockDTO);
                        this.ECommerceDbContext.SubCategories.Add(subCategory);
                        this.ECommerceDbContext.SaveChanges();

                        return;
                    }
                },
                {
                    "Templates",
                    (inputBlockDTO) =>
                    {
                        Template template = new Template(ECommerceDbContext, inputBlockDTO);
                        this.ECommerceDbContext.Templates.Add(template);
                        this.ECommerceDbContext.SaveChanges();

                        return;
                    }
                },
                {
                    "Users",
                    (inputBlockDTO) =>
                    {
                        User user = new User(this.ECommerceDbContext, inputBlockDTO);
                        user.Password = Hashing.Hash(user.Password);

                        this.ECommerceDbContext.Users.Add(user);

                        ShoppingCart shoppingCart = new ShoppingCart()
                        {
                            User = user,
                            UserId = user.Id
                        };
                        this.ECommerceDbContext.ShoppingCarts.Add(shoppingCart);
                        this.ECommerceDbContext.SaveChanges();

                        return;
                    }
                },
                {
                    "Values",
                    (inputBlockDTO) =>
                    {
                        Value value = new Value(this.ECommerceDbContext, inputBlockDTO);
                        this.ECommerceDbContext.Values.Add(value);
                        this.ECommerceDbContext.SaveChanges();

                        return;
                    }
                }
            };
            this.tableUpdateDictionary = new Dictionary<string, Action<InputBlockDTO>>(comparer)
            {
                {
                    "Attributes",
                    (inputBlockDTO) =>
                    {
                        Core.Entities.Attribute attribute = new Core.Entities.Attribute(inputBlockDTO);
                        this.ECommerceDbContext.Attributes.Update(attribute);
                        this.ECommerceDbContext.SaveChanges();

                        return;
                    }
                },
                {
                    "AttributeSets",
                    (inputBlockDTO) =>
                    {
                        AttributeSet attributeSet = new AttributeSet(this.ECommerceDbContext, inputBlockDTO);
                        this.ECommerceDbContext.AttributeSets.Update(attributeSet);
                        this.ECommerceDbContext.SaveChanges();

                        return;
                    }
                },
                {
                    "Categories",
                    (inputBlockDTO) =>
                    {
                        Category category = new Category(inputBlockDTO);
                        this.ECommerceDbContext.Categories.Update(category);
                        this.ECommerceDbContext.SaveChanges();

                        return;
                    }
                },
                {
                    "Discounts",
                    (inputBlockDTO) =>
                    {
                        Discount discount = new Discount(inputBlockDTO);
                        this.ECommerceDbContext.Discounts.Update(discount);
                        this.ECommerceDbContext.SaveChanges();

                        return;
                    }
                },
                {
                    "Measurements",
                    (inputBlockDTO) =>
                    {
                        Measurement measurement = new Measurement(inputBlockDTO);
                        this.ECommerceDbContext.Measurements.Update(measurement);
                        this.ECommerceDbContext.SaveChanges();

                        return;
                    }
                },
                {
                    "MeasurementSets",
                    (inputBlockDTO) =>
                    {
                        MeasurementSet measurementSet = new MeasurementSet(this.ECommerceDbContext, inputBlockDTO);
                        this.ECommerceDbContext.MeasurementSets.Update(measurementSet);
                        this.ECommerceDbContext.SaveChanges();

                        return;
                    }
                },
                {
                    "Orders",
                    (inputBlockDTO) =>
                    {
                        Order order = new Order(this.ECommerceDbContext, inputBlockDTO);
                        this.ECommerceDbContext.Orders.Update(order);
                        this.ECommerceDbContext.SaveChanges();

                        return;
                    }
                },
                {
                    "Order_Product",
                    (inputBlockDTO) =>
                    {
                        Order_Product orderProduct = new Order_Product(this.ECommerceDbContext, inputBlockDTO);
                        this.ECommerceDbContext.Order_Product.Update(orderProduct);
                        this.ECommerceDbContext.SaveChanges();

                        Order order = this.ECommerceDbContext.Orders
                            .Where(o => o.Id == orderProduct.OrderId)
                            .Include(o => o.Products)
                            .First();

                        order.TotalPrice = order.Products.Sum(op => op.TotalPrice);
                        this.ECommerceDbContext.Orders.Update(order);
                        this.ECommerceDbContext.SaveChanges();

                        return;
                    }
                },
                {
                    "OrderStatuses",
                    (inputBlockDTO) =>
                    {
                        OrderStatus orderStatus = new OrderStatus(this.ECommerceDbContext, inputBlockDTO);
                        this.ECommerceDbContext.OrderStatuses.Update(orderStatus);
                        this.ECommerceDbContext.SaveChanges();

                        return;
                    }
                },
                {
                    "Photos",
                    (inputBlockDTO) =>
                    {
                        Photo photo = new Photo(this.ECommerceDbContext, inputBlockDTO);
                        this.ECommerceDbContext.Photos.Update(photo);
                        this.ECommerceDbContext.SaveChanges();

                        return;
                    }
                },
                {
                    "Products",
                    (inputBlockDTO) =>
                    {
                        Product product = new Product(this.ECommerceDbContext, inputBlockDTO);
                        this.ECommerceDbContext.Products.Update(product);
                        this.ECommerceDbContext.SaveChanges();

                        return;
                    }
                },
                {
                    "Reviews",
                    (inputBlockDTO) =>
                    {
                        Review review = new Review(this.ECommerceDbContext, inputBlockDTO);
                        this.ECommerceDbContext.Reviews.Update(review);
                        this.ECommerceDbContext.SaveChanges();

                        return;
                    }
                },
                {
                    "Roles",
                    (inputBlockDTO) =>
                    {
                        Role role = new Role(inputBlockDTO);
                        this.ECommerceDbContext.Roles.Update(role);
                        this.ECommerceDbContext.SaveChanges();

                        return;
                    }
                },
                {
                    "ShoppingCarts",
                    (inputBlockDTO) =>
                    {

                    }
                },
                {
                    "SubCategories",
                    (inputBlockDTO) =>
                    {
                        SubCategory subCategory = new SubCategory(ECommerceDbContext, inputBlockDTO);
                        this.ECommerceDbContext.SubCategories.Update(subCategory);
                        this.ECommerceDbContext.SaveChanges();

                        return;
                    }
                },
                {
                    "Templates",
                    (inputBlockDTO) =>
                    {
                        Template template = new Template(ECommerceDbContext, inputBlockDTO);
                        this.ECommerceDbContext.Templates.Update(template);
                        this.ECommerceDbContext.SaveChanges();

                        return;
                    }
                },
                {
                    "Users",
                    (inputBlockDTO) =>
                    {
                        User user = new User(this.ECommerceDbContext, inputBlockDTO);
                        user.Password = Hashing.Hash(user.Password);

                        this.ECommerceDbContext.Users.Update(user);
                        this.ECommerceDbContext.SaveChanges();

                        return;
                    }
                },
                {
                    "Values",
                    (inputBlockDTO) =>
                    {
                        Value value = new Value(this.ECommerceDbContext, inputBlockDTO);
                        this.ECommerceDbContext.Values.Update(value);
                        this.ECommerceDbContext.SaveChanges();

                        return;
                    }
                }
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

        public string GetSearchResult(string tableName, int input)
        {
            return this.tableSearchDictionary[tableName](input);
        }

        public string GetSimpleDto(string tableName, int pageNum, int pageSize)
        {
            return this.tableSimpleDataDictionary[tableName](pageNum, pageSize);
        }

        public List<SimpleDTO> GetMeasurementsFromSet(int measurementSetId)
        {
            MeasurementSet measurementSet = this.ECommerceDbContext
                .MeasurementSets
                .Where(ms => ms.Id == measurementSetId)
                .Include(ms => ms.Measurements)
                .First();

            return (measurementSet.Measurements.Select(m => new SimpleDTO(m))).ToList();
        }

        public void InsertData(InputBlockDTO inputBlockDTO)
        {
            this.tableInsertionDictionary[inputBlockDTO.Title](inputBlockDTO);
        }
        public void InsertData(InputBlockDTO inputBlockDTO, out Message message)
        {
            this.tableInsertionDictionary[inputBlockDTO.Title](inputBlockDTO);
            message = Message.CreateSuccessful("Inserted", $"Data in table {inputBlockDTO.Title} has been inserted successfully.");
        }
        public void DeleteData(string tableName, int id)
        {
            switch (tableName)
            {
                case "Attributes":
                    ECommerceDbContext.Attributes
                        .Remove(ECommerceDbContext
                            .Attributes
                            .Where(a => a.Id == id)
                            .First()
                        );

                    break;

                case "AttributeSets":
                    ECommerceDbContext.AttributeSets
                        .Remove(ECommerceDbContext
                            .AttributeSets
                            .Where(a => a.Id == id)
                            .First()
                        );

                    break;

                case "Categories":
                    ECommerceDbContext.Categories
                        .Remove(ECommerceDbContext
                            .Categories
                            .Where(a => a.Id == id)
                            .First()
                        );

                    break;

                case "Discounts":
                    ECommerceDbContext.Discounts
                        .Remove(ECommerceDbContext
                            .Discounts
                            .Where(a => a.Id == id)
                            .First()
                        );

                    break;

                case "Measurements":
                    ECommerceDbContext.Measurements
                        .Remove(ECommerceDbContext
                            .Measurements
                            .Where(a => a.Id == id)
                            .First()
                        );

                    break;

                case "MeasurementSets":
                    ECommerceDbContext.MeasurementSets
                        .Remove(ECommerceDbContext
                            .MeasurementSets
                            .Where(a => a.Id == id)
                            .First()
                        );

                    break;

                case "Orders":
                    ECommerceDbContext.Orders
                        .Remove(ECommerceDbContext
                            .Orders
                            .Where(a => a.Id == id)
                            .First()
                        );

                    break;

                case "Order_product":
                    Order order = ECommerceDbContext.Order_Product
                        .Where(op => op.Id == id)
                        .Include(op => op.Order)
                        .Select(op => op.Order)
                        .First();
                    
                    ECommerceDbContext.Order_Product
                        .Remove(ECommerceDbContext
                            .Order_Product
                            .Where(op => op.Id == id)
                            .First()
                        );
                    ECommerceDbContext.SaveChanges();

                    order.Products = this.ECommerceDbContext.Order_Product
                        .Where(op => op.OrderId == order.Id)
                        .ToList();

                    order.TotalPrice = order.Products.Sum(op => op.TotalPrice);
                    ECommerceDbContext.Orders.Update(order);
                    ECommerceDbContext.SaveChanges();

                    break;

                case "Photos":
                    ECommerceDbContext.Photos
                        .Remove(ECommerceDbContext
                            .Photos
                            .Where(a => a.Id == id)
                            .First()
                        );

                    break;

                case "Products":
                    ECommerceDbContext.Products
                        .Remove(ECommerceDbContext
                            .Products
                            .Where(a => a.Id == id)
                            .First()
                        );

                    break;

                case "Reviews":
                    ECommerceDbContext.Reviews
                        .Remove(ECommerceDbContext
                            .Reviews
                            .Where(a => a.Id == id)
                            .First()
                        );

                    break;

                case "Roles":
                    ECommerceDbContext.Roles
                        .Remove(ECommerceDbContext
                            .Roles
                            .Where(a => a.Id == id)
                            .First()
                        );

                    break;

                case "ShoppingCarts":
                    break;

                case "SubCategories":
                    ECommerceDbContext.SubCategories
                        .Remove(ECommerceDbContext
                            .SubCategories
                            .Where(a => a.Id == id)
                            .First()
                        );

                    break;

                case "Templates":
                    ECommerceDbContext.Templates
                        .Remove(ECommerceDbContext
                            .Templates
                            .Where(a => a.Id == id)
                            .First()
                        );

                    break;

                case "Users":
                    ECommerceDbContext.Users
                         .Remove(ECommerceDbContext
                             .Users
                             .Where(a => a.Id == id)
                             .First()
                         );

                    break;

                case "Values":
                    ECommerceDbContext.Values
                         .Remove(ECommerceDbContext
                             .Values
                             .Where(a => a.Id == id)
                             .First()
                         );

                    break;

                default: return;
            }

            this.ECommerceDbContext.SaveChanges();
        }

        public void UpdateData(InputBlockDTO inputBlockDTO)
        {
            this.tableUpdateDictionary[inputBlockDTO.Title](inputBlockDTO);
        }

        public void UpdateData(InputBlockDTO inputBlockDTO, out Message message)
        {            
            this.tableUpdateDictionary[inputBlockDTO.Title](inputBlockDTO);
            message = Message.CreateSuccessful("Updated", $"Data in table {inputBlockDTO.Title} has been updated successfully.");
        }
    }
}
