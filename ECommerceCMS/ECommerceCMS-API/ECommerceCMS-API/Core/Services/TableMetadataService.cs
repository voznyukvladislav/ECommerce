using ECommerceCMS_API.Core.DTOs.EntityDTOs;
using ECommerceCMS_API.Core.Entities;
using ECommerceCMS_API.Core.Interfaces;
using ECommerceCMS_API.Infrastructure.Data;
using System.Text.Json;

namespace ECommerceCMS_API.Core.Services
{
    public class TableMetadataService : ITableMetaDataService
    {
        public Dictionary<string, string> TableMetadataDictionary = new Dictionary<string, string>();
        public TableMetadataService() { 
            var comparer = StringComparer.OrdinalIgnoreCase;
            this.TableMetadataDictionary = new Dictionary<string, string>(comparer) {
                {
                    "Attributes",
                    JsonSerializer.Serialize(new AttributeDTO())
                },
                {
                    "AttributeSets",
                    JsonSerializer.Serialize(new AttributeSetDTO())
                },
                {
                    "Categories",
                    JsonSerializer.Serialize(new CategoryDTO())
                },
                {
                    "Discounts",
                    JsonSerializer.Serialize(new DiscountDTO())
                },
                {
                    "Measurements",
                    JsonSerializer.Serialize(new MeasurementDTO())
                },
                {
                    "MeasurementSets",
                    JsonSerializer.Serialize(new MeasurementSetDTO())
                },
                {
                    "Order_Product",
                    JsonSerializer.Serialize(new Order_Product_DTO())
                },
                {
                    "Orders",
                    JsonSerializer.Serialize(new OrderDTO())
                },
                {
                    "Photos",
                    JsonSerializer.Serialize(new PhotoDTO())
                },
                {
                    "Products",
                    JsonSerializer.Serialize(new ProductDTO())
                },
                {
                    "Reviews",
                    JsonSerializer.Serialize(new ReviewDTO())
                },
                {
                    "Roles",
                    JsonSerializer.Serialize(new RoleDTO())
                },
                {
                    "ShoppingCarts",
                    JsonSerializer.Serialize(new ShoppingCartDTO())
                },
                {
                    "SubCategories",
                    JsonSerializer.Serialize(new SubCategoryDTO())
                },
                {
                    "Templates",
                    JsonSerializer.Serialize(new TemplateDTO())
                },
                { 
                    "Users", 
                    JsonSerializer.Serialize(new UserDTO())
                },
                {
                    "Values",
                    JsonSerializer.Serialize(new ValueDTO())
                }
            };
        }

        public string GetTableMetadata(string tableName)
        {
            return this.TableMetadataDictionary[tableName];
        }
    }
}
