using ECommerceCMS_API.Core.Entities;
using ECommerceCMS_API.Core.DTOs.DbInteractionDTOs;

namespace ECommerceCMS_API.Infrastructure.Data
{
    public class InputHandler
    {
        public static dynamic Handle(InputBlockDTO inputBlockDTO)
        {
            switch(inputBlockDTO.Title) {
                case "Attributes":
                    return new Core.Entities.Attribute(inputBlockDTO);
                case "AttributeSets":
                    return 1;

                case "Categories":
                    return 1;

                case "Discounts":
                    return 1;

                case "Measurements":
                    return 1;

                case "MeasurementSets":
                    return 1;

                case "Orders":
                    return 1;

                case "Photos":
                    return 1;

                case "Products":
                    return 1;

                case "Reviews":
                    return 1;

                case "Roles":
                    return 1;

                case "ShoppingCarts":
                    return 1;

                case "SubCategories":
                    return 1;

                case "Templates":
                    return 1;

                case "Users":
                    return 1;

                case "Values":
                    return 1;

                default: return 0;
            }
        }
        /*
        private Core.Entities.Attribute HandleAttribute(InputBlockDTO inputBlockDTO)
        {
            Core.Entities.Attribute attribute = new Core.Entities.Attribute();
            Dictionary<string, string> nameValue = new Dictionary<string, string>();
            inputBlockDTO.InputDTOs.ForEach(i =>
            {
                List<string> names = new List<string>();
                i.Names.ForEach(name =>
                {
                    names.Add(name);
                });

                List<string> values = new List<string>();
                i.Values.ForEach(value =>
                {
                    values.Add(value);
                });

                
            });

            return new Core.Entities.Attribute();
        }
        private AttributeSet HandleAttributeSet(InputBlockDTO inputBlockDTO)
        {
            return new AttributeSet();
        }
        private Category HandleCategory(InputBlockDTO inputBlockDTO)
        {
            return new Category();
        }
        private Discount HandleDiscount(InputBlockDTO inputBlockDTO)
        {
            return new Discount();
        }
        private Measurement HandleMeasurement(InputBlockDTO inputBlockDTO)
        {
            return new Measurement();
        }
        private MeasurementSet HandleMeasurementSet(InputBlockDTO inputBlockDTO)
        {
            return new MeasurementSet();
        }        
        private Order HandleOrder(InputBlockDTO inputBlockDTO)
        {
            return new Order();
        }
        private Photo HandlePhoto(InputBlockDTO inputBlockDTO)
        {
            return new Photo();
        }
        private Product HandleProduct(InputBlockDTO inputBlockDTO)
        {
            return new Product();
        }
        private Review HandleReview(InputBlockDTO inputBlockDTO)
        {
            return new Review();
        }
        private Role HandleRole(InputBlockDTO inputBlockDTO)
        {
            return new Role();
        }
        private ShoppingCart HandleShoppingCart(InputBlockDTO inputBlockDTO)
        {
            return new ShoppingCart();
        }
        private SubCategory HandleSubCategory(InputBlockDTO inputBlockDTO)
        {
            return new SubCategory();
        }
        private Template HandleTemplate(InputBlockDTO inputBlockDTO)
        {
            return new Template();
        }
        private User HandleUser(InputBlockDTO inputBlockDTO)
        {
            return new User();
        }
        private Value HandleValue(InputBlockDTO inputBlockDTO)
        {
            return new Value();
        }*/
    }
}
