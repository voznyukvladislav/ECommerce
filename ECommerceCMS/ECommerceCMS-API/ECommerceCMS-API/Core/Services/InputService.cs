using ECommerceCMS_API.Core.DTOs.DbInteractionDTOs;
using ECommerceCMS_API.Core.Entities;
using ECommerceCMS_API.Core.Interfaces;
using ECommerceCMS_API.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics.Metrics;

namespace ECommerceCMS_API.Core.Services
{
    public class InputService : IInputService
    {
        private readonly ECommerceDbContext _db;
        private readonly Dictionary<string, Func<InputBlockDTO>> _inputBlocks;
        private readonly Dictionary<string, Func<int, InputBlockDTO>> _updateInputBlocks;
        public InputService(ECommerceDbContext db)
        {
            this._db = db;
            var comparer = StringComparer.OrdinalIgnoreCase;
            this._inputBlocks = new Dictionary<string, Func<InputBlockDTO>>(comparer)
            {
                { 
                    "Attributes", () => {
                        InputBlockDTO inputBlockDTO = new InputBlockDTO();
                        inputBlockDTO.Title = "Attributes";
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateSimple("Attribute.Name", "Enter attribute name"));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateOneOfMany("Attribute.MeasurementSetId", "Select measurement set", "MeasurementSets"));

                        return inputBlockDTO;
                    }
                },
                {
                    "AttributeSets", () =>
                    {
                        InputBlockDTO inputBlockDTO = new InputBlockDTO();
                        inputBlockDTO.Title = "AttributeSets";
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateSimple("AttributeSet.Name", "Enter attribute set name"));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateManyOfMany("AttributeSet.Attributes", "Select attributes", "Attributes"));

                        return inputBlockDTO;
                    }
                },
                {
                    "Categories", () =>
                    {
                        InputBlockDTO inputBlockDTO = new InputBlockDTO();
                        inputBlockDTO.Title = "Categories";
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateSimple("Category.Name", "Enter category name"));
                        
                        return inputBlockDTO;
                    }
                },
                {
                    "Discounts", () =>
                    {
                        InputBlockDTO inputBlockDTO = new InputBlockDTO();
                        inputBlockDTO.Title = "Discounts";
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateSimple("Discount.Value", "Enter discount value (0.0 - 1.0)"));

                        return inputBlockDTO;
                    }
                },
                {
                    "Measurements", () =>
                    {
                        InputBlockDTO inputBlockDTO = new InputBlockDTO();
                        inputBlockDTO.Title = "Measurements";
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateSimple("Measurement.Name", "Enter measurement name"));

                        return inputBlockDTO;
                    }
                },
                {
                    "MeasurementSets", () =>
                    {
                        InputBlockDTO inputBlockDTO = new InputBlockDTO();
                        inputBlockDTO.Title = "MeasurementSets";
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateSimple("MeasurementSet.Name", "Enter measurement set name"));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateManyOfMany("MeasurementSet.Measurements", "Select measurements", "Measurements"));

                        return inputBlockDTO;
                    }
                },
                {
                    "Orders", () =>
                    {
                        InputBlockDTO inputBlockDTO = new InputBlockDTO();
                        inputBlockDTO.Title = "Orders";
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateSimple("Order.Date", "Enter order date"));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateOneOfMany("Order.UserId", "Select user", "Users"));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateManyOfMany("Order.Products", "Select products", "Products"));

                        return inputBlockDTO;
                    }
                },
                {
                    "Photos", () =>
                    {
                        InputBlockDTO inputBlockDTO = new InputBlockDTO();
                        inputBlockDTO.Title = "Photos";
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateSimple("Photo.Source", "Enter photo source"));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateOneOfMany("Photo.ProductId", "Select product", "Products"));

                        return inputBlockDTO;
                    }
                },
                {
                    "Products", () =>
                    {
                        InputBlockDTO inputBlockDTO = new InputBlockDTO();
                        inputBlockDTO.Title = "Products";
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateSimple("Product.Name", "Enter product name"));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateSimple("Product.Price", "Enter product price"));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateOneOfMany("Product.SubCategoryId", "Select subcategory", "SubCategories"));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateOneOfMany("Product.DiscountId", "Select discount", "Discounts"));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateExtensional("Product.TemplateId", "Select template", "Templates"));

                        return inputBlockDTO;
                    }
                },
                {
                    "Reviews", () =>
                    {
                        InputBlockDTO inputBlockDTO = new InputBlockDTO();
                        inputBlockDTO.Title = "Reviews";
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateSimple("Review.Text", "Enter review text"));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateSimple("Review.Rating", "Enter review rating"));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateOneOfMany("Review.UserId", "Select user", "Users"));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateOneOfMany("Review.ProductId", "Select product", "Products"));

                        return inputBlockDTO;
                    }
                },
                {
                    "Roles", () =>
                    {
                        InputBlockDTO inputBlockDTO = new InputBlockDTO();
                        inputBlockDTO.Title = "Roles";
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateSimple("Role.Name", "Enter role name"));

                        return inputBlockDTO;
                    }
                },
                {
                    "ShoppingCarts", () =>
                    {
                        InputBlockDTO inputBlockDTO = new InputBlockDTO();
                        inputBlockDTO.Title = "ShoppingCarts";
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateOneOfMany("ShoppingCart.UserId", "Select user", "Users"));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateManyOfMany("ShoppingCart.Products", "Select products", "Products"));

                        return inputBlockDTO;
                    }
                },
                {
                    "SubCategories", () =>
                    {
                        InputBlockDTO inputBlockDTO = new InputBlockDTO();
                        inputBlockDTO.Title = "SubCategories";
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateSimple("SubCategory.Name", "Enter subcategory name"));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateOneOfMany("SubCategory.CategoryId", "Select category", "Categories"));

                        return inputBlockDTO;
                    }
                },
                {
                    "Templates", () =>
                    {
                        InputBlockDTO inputBlockDTO = new InputBlockDTO();
                        inputBlockDTO.Title = "Templates";
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateSimple("Template.Name", "Enter template name"));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateManyOfMany("Template.AttributeSets", "Select attribute sets", "AttributeSets"));

                        return inputBlockDTO;
                    }
                },
                {
                    "Users", () =>
                    {
                        InputBlockDTO inputBlockDTO = new InputBlockDTO();
                        inputBlockDTO.Title = "Users";
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateSimple("User.Name", "Enter user name"));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateSimple("User.Surname", "Enter user surname"));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateSimple("User.Login", "Enter user login"));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateSimple("User.Password", "Enter user password"));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateSimple("User.Email", "Enter user email"));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateSimple("User.Phone", "Enter user phone"));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateOneOfMany("User.RoleId", "Select role", "Roles"));

                        return inputBlockDTO;
                    }
                },
                {
                    "Values", () =>
                    {
                        InputBlockDTO inputBlockDTO = new InputBlockDTO();
                        inputBlockDTO.Title = "Values";
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateSimple("Value.Val", "Enter value"));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateOneOfMany("Value.ProductId", "Select product", "Products"));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateOneOfMany("Value.AttributeSetId", "Select attribute set", "AttributeSets"));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateOneOfMany("Value.AttributeId", "Select attribute", "Attributes"));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateOneOfMany("value.MeasurementId", "Select measurement", "Measurements"));

                        return inputBlockDTO;
                    }
                }
            };
            this._updateInputBlocks = new Dictionary<string, Func<int, InputBlockDTO>>(comparer)
            {
                {
                    "Attributes", (id) => {
                        InputBlockDTO inputBlockDTO = new InputBlockDTO();
                        inputBlockDTO.Title = "Attributes";

                        Entities.Attribute attribute = this._db.Attributes
                            .Where(a => a.Id == id)
                            .Include(a => a.MeasurementSet)
                            .First();
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateStatic("Attribute.Id", attribute.Id.ToString()));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateSimple("Attribute.Name", "Enter attribute name", attribute.Name));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateOneOfMany("Attribute.MeasurementSetId", "Select measurement set", "MeasurementSets", attribute.MeasurementSetId?.ToString()));

                        return inputBlockDTO;
                    }
                },
                {
                    "AttributeSets", (id) =>
                    {
                        InputBlockDTO inputBlockDTO = new InputBlockDTO();
                        inputBlockDTO.Title = "AttributeSets";

                        AttributeSet attributeSet = this._db.AttributeSets
                            .Where(a => a.Id == id)
                            .Include(a => a.Attribute_AttributeSet)
                            .ThenInclude(a => a.Attribute)
                            .First();
                        string attributes = String.Join(' ', attributeSet.Attribute_AttributeSet.Select(a => a.AttributeId));

                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateStatic("AttributeSet.Id", attributeSet.Id.ToString()));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateSimple("AttributeSet.Name", "Enter attribute set name", attributeSet.Name));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateManyOfMany("AttributeSet.Attributes", "Select attributes", "Attributes", attributes));

                        return inputBlockDTO;
                    }
                },
                {
                    "Categories", (id) =>
                    {
                        Category category = this._db.Categories
                            .Where(c => c.Id == id)
                            .First();

                        InputBlockDTO inputBlockDTO = new InputBlockDTO();
                        inputBlockDTO.Title = "Categories";
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateStatic("Category.Id", category.Id.ToString()));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateSimple("Category.Name", "Enter category name", category.Name));

                        return inputBlockDTO;
                    }
                },
                {
                    "Discounts", (id) =>
                    {
                        Discount discount = this._db.Discounts
                            .Where(d => d.Id == id)
                            .First();

                        InputBlockDTO inputBlockDTO = new InputBlockDTO();
                        inputBlockDTO.Title = "Discounts";
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateStatic("Discount.Id", discount.Id.ToString()));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateSimple("Discount.Value", "Enter discount value (0.0 - 1.0)", discount.Value.ToString()));

                        return inputBlockDTO;
                    }
                },
                {
                    "Measurements", (id) =>
                    {
                        Measurement measurement = this._db.Measurements
                            .Where(m => m.Id == id)
                            .First();

                        InputBlockDTO inputBlockDTO = new InputBlockDTO();
                        inputBlockDTO.Title = "Measurements";
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateStatic("Measurement.Id", measurement.Id.ToString()));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateSimple("Measurement.Name", "Enter measurement name", measurement.Name));

                        return inputBlockDTO;
                    }
                },
                {
                    "MeasurementSets", (id) =>
                    {
                        MeasurementSet measurementSet = this._db.MeasurementSets.Where(ms => ms.Id == id)
                            .Include(ms => ms.Measurements)
                            .First();

                        InputBlockDTO inputBlockDTO = new InputBlockDTO();
                        inputBlockDTO.Title = "MeasurementSets";

                        string measurementIds = String.Join(' ', measurementSet.Measurements.Select(m => m.Id));

                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateStatic("MeasurementSet.Id", measurementSet.Id.ToString()));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateSimple("MeasurementSet.Name", "Enter measurement set name", measurementSet.Name));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateManyOfMany("MeasurementSet.Measurements", "Select measurements", "Measurements", measurementIds));

                        return inputBlockDTO;
                    }
                },
                {
                    "Orders", (id) =>
                    {
                        Order order = this._db.Orders
                            .Where(o => o.Id == id)
                            .Include(o => o.Products)
                            .First();

                        string productIds = String.Join(' ', order.Products.Select(p => p.Id));

                        InputBlockDTO inputBlockDTO = new InputBlockDTO();
                        inputBlockDTO.Title = "Orders";
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateStatic("Order.Id", order.Id.ToString()));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateSimple("Order.Date", "Enter order date", order.Date.ToString()));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateOneOfMany("Order.UserId", "Select user", "Users", order.UserId.ToString()));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateManyOfMany("Order.Products", "Select products", "Products", productIds));

                        return inputBlockDTO;
                    }
                },
                {
                    "Photos", (id) =>
                    {
                        Photo photo = this._db.Photos
                            .Where(p => p.Id == id)
                            .First();

                        InputBlockDTO inputBlockDTO = new InputBlockDTO();
                        inputBlockDTO.Title = "Photos";
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateStatic("Photo.Id", photo.Id.ToString()));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateSimple("Photo.Source", "Enter photo source", photo.Source));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateOneOfMany("Photo.ProductId", "Select product", "Products", photo.ProductId.ToString()));

                        return inputBlockDTO;
                    }
                },
                {
                    "Products", (id) =>
                    {
                        Product product = this._db.Products
                            .Where(p => p.Id == id)
                            .First();

                        InputBlockDTO inputBlockDTO = new InputBlockDTO();
                        inputBlockDTO.Title = "Products";
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateStatic("Product.Id", product.Id.ToString()));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateSimple("Product.Name", "Enter product name", product.Name));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateSimple("Product.Price", "Enter product price", product.Price.ToString()));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateOneOfMany("Product.SubCategoryId", "Select subcategory", "SubCategories", product.SubCategoryId.ToString()));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateOneOfMany("Product.DiscountId", "Select discount", "Discounts", product?.DiscountId.ToString()));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateExtensional("Product.TemplateId", "Select template", "Templates", product.TemplateId.ToString()));

                        return inputBlockDTO;
                    }
                },
                {
                    "Reviews", (id) =>
                    {
                        Review review = this._db.Reviews
                            .Where(r => r.Id == id)
                            .First();

                        InputBlockDTO inputBlockDTO = new InputBlockDTO();
                        inputBlockDTO.Title = "Reviews";
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateStatic("Review.Id", review.Id.ToString()));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateSimple("Review.Text", "Enter review text", review.Text));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateSimple("Review.Rating", "Enter review rating", review.Rating.ToString()));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateOneOfMany("Review.UserId", "Select user", "Users", review.UserId.ToString()));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateOneOfMany("Review.ProductId", "Select product", "Products", review.ProductId.ToString()));

                        return inputBlockDTO;
                    }
                },
                {
                    "Roles", (id) =>
                    {
                        Role role = this._db.Roles
                            .Where(r => r.Id == id)
                            .First();

                        InputBlockDTO inputBlockDTO = new InputBlockDTO();
                        inputBlockDTO.Title = "Roles";
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateStatic("Role.Id", role.Id.ToString()));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateSimple("Role.Name", "Enter role name"));

                        return inputBlockDTO;
                    }
                },
                {
                    "ShoppingCarts", (id) =>
                    {
                        ShoppingCart shoppingCart = this._db.ShoppingCarts
                            .Where(sc => sc.Id == id)
                            .First();
                        string productIds = String.Join(' ', shoppingCart.Products.Select(p => p.Id));

                        InputBlockDTO inputBlockDTO = new InputBlockDTO();
                        inputBlockDTO.Title = "ShoppingCarts";
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateStatic("PShoppingCart.Id", shoppingCart.Id.ToString()));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateOneOfMany("ShoppingCart.UserId", "Select user", "Users", shoppingCart.UserId.ToString()));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateManyOfMany("ShoppingCart.Products", "Select products", "Products", productIds));

                        return inputBlockDTO;
                    }
                },
                {
                    "SubCategories", (id) =>
                    {
                        SubCategory subCategory = this._db.SubCategories
                            .Where(sc => sc.Id == id)
                            .First();

                        InputBlockDTO inputBlockDTO = new InputBlockDTO();
                        inputBlockDTO.Title = "SubCategories";
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateStatic("SubCategory.Id", subCategory.Id.ToString()));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateSimple("SubCategory.Name", "Enter subcategory name", subCategory.Name));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateOneOfMany("SubCategory.CategoryId", "Select category", "Categories", subCategory.CategoryId.ToString()));

                        return inputBlockDTO;
                    }
                },
                {
                    "Templates", (id) =>
                    {
                        Template template = this._db.Templates
                            .Where(t => t.Id == id)
                            .First();

                        string attributeSetIds = String.Join(' ', template.AttributeSets.Select(a => a.Id));

                        InputBlockDTO inputBlockDTO = new InputBlockDTO();
                        inputBlockDTO.Title = "Templates";
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateStatic("Template.Id", template.Id.ToString()));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateSimple("Template.Name", "Enter template name", template.Name));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateManyOfMany("Template.AttributeSets", "Select attribute sets", "AttributeSets", attributeSetIds));

                        return inputBlockDTO;
                    }
                },
                {
                    "Users", (id) =>
                    {
                        User user = this._db.Users
                            .Where(u => u.Id == id)
                            .First();

                        InputBlockDTO inputBlockDTO = new InputBlockDTO();
                        inputBlockDTO.Title = "Users";
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateStatic("User.Id", user.Id.ToString()));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateSimple("User.Name", "Enter user name", user.Name));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateSimple("User.Surname", "Enter user surname", user.Surname));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateSimple("User.Login", "Enter user login", user.Login));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateSimple("User.Password", "Enter user password", user.Password));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateSimple("User.Email", "Enter user email", user.Email));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateSimple("User.Phone", "Enter user phone", user.Phone));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateOneOfMany("User.RoleId", "Select role", "Roles", user.RoleId.ToString()));

                        return inputBlockDTO;
                    }
                },
                {
                    "Values", (id) =>
                    {
                        Value value = this._db.Values
                            .Where(v => v.Id == id)
                            .First();

                        InputBlockDTO inputBlockDTO = new InputBlockDTO();
                        inputBlockDTO.Title = "Values";
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateStatic("Value.Id", value.Id.ToString()));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateSimple("Value.Val", "Enter value", value.Val.ToString()));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateOneOfMany("Value.ProductId", "Select product", "Products", value.ProductId.ToString()));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateOneOfMany("Value.AttributeSetId", "Select attribute set", "AttributeSets", value.Attribute_AttributeSet.AttributeSetId.ToString()));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateOneOfMany("Value.AttributeId", "Select attribute", "Attributes", value.Attribute_AttributeSet.AttributeId.ToString()));
                        inputBlockDTO.InputDTOs.Add(InputDTO.CreateOneOfMany("value.MeasurementId", "Select measurement", "Measurements", value.MeasurementId.ToString()));

                        return inputBlockDTO;
                    }
                }
            };
        }        

        public IEnumerable<InputGroupDTO> GetInputGroups(int templateId)
        {
            List<InputGroupDTO> inputGroups = new List<InputGroupDTO>();
            Template template = _db.Templates
                .Where(t => t.Id == templateId)
                .Include(t => t.AttributeSets)
                .ThenInclude(a => a.Attribute_AttributeSet)
                .ThenInclude(a => a.Attribute)
                .ThenInclude(a => a.MeasurementSet)
                .First();

            template.AttributeSets.ForEach(a =>
            {
                List<Entities.Attribute> attributes = new List<Entities.Attribute>();
                a.Attribute_AttributeSet.ForEach(a_as =>
                {
                    attributes.Add(a_as.Attribute);
                });

                List<InputDTO> inputs = new List<InputDTO>();
                attributes.ForEach(attr =>
                {
                    // If measurement exists
                    if(attr.MeasurementSet is not null)
                    {
                        inputs.Add(new InputDTO
                        {
                            Type = "simpleWithSelector",
                            Names = (new string[] { "Value.Val", "Value.AttributeId", "Value.MeasurementId" }).ToList(),
                            Values = (new string[] { "", $"{attr.Id}", "" }).ToList(),
                            Placeholders = new List<string>() { $"{attr.Name}", $"{attr.MeasurementSet.Name}" },
                            Links = (new string[] { $"{Constants.Url}/{Constants.GetMeasurementsFromSet}?measurementSetId={attr.MeasurementSetId}" }).ToList()
                        });
                    }
                    // If measurement is not chosen, measurement = null
                    else
                    {
                        inputs.Add(new InputDTO
                        {
                            Type = "simple",
                            Names = (new string[] { "Value.Val", "Value.AttributeId" }).ToList(),
                            Values = (new string[] { "", $"{attr.Id}"}).ToList(),
                            Placeholders = new List<string>() { $"{attr.Name}" },
                            Links = new List<string>()
                        });
                    }
                });

                inputGroups.Add(new InputGroupDTO
                {
                    CommonName = a.Name,
                    CommonValue = a.Id.ToString(),
                    InputDTOs = inputs
                });
            });

            return inputGroups;
        }
        public InputBlockDTO GetInputBlock(string tableName)
        {
            return this._inputBlocks[tableName]();
        }
        public InputBlockDTO GetUpdateInputBlock(string tableName, int id)
        {
            return this._updateInputBlocks[tableName](id);
        }
    }
}
