using ECommerceCMS_API.Core.DTOs.DbInteractionDTOs;
using ECommerceCMS_API.Core.Entities;
using ECommerceCMS_API.Core.Interfaces;
using ECommerceCMS_API.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ECommerceCMS_API.Core.Services
{
    public class InputService : IInputService
    {
        private readonly ECommerceDbContext _db;
        private readonly Dictionary<string, Func<InputBlockDTO>> _inputBlocks;
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
    }
}
