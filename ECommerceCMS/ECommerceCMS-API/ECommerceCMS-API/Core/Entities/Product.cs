using ECommerceCMS_API.Core.DTOs.DbInteractionDTOs;
using ECommerceCMS_API.Infrastructure.Data;
using System.ComponentModel.DataAnnotations;

namespace ECommerceCMS_API.Core.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public SubCategory SubCategory { get; set; } = new SubCategory();
        public int SubCategoryId { get; set; }

        public Template Template { get; set; } = new Template();
        public int TemplateId { get; set; }

        public Discount? Discount { get; set; } = new Discount();
        public int? DiscountId { get; set; }

        public List<Value> Values { get; set; } = new List<Value>();
        public List<ShoppingCart>? ShoppingCarts { get; set; }
        public List<Photo>? Photos { get; set; }
        public List<Order>? Orders { get; set; }
        public List<Review>? Reviews { get; set; }

        public Product()
        {

        }
        public Product(ECommerceDbContext db, InputBlockDTO inputBlockDTO)
        {
            Dictionary<string, string> nameValue = inputBlockDTO.GetNameValueDictionary();
            List<Dictionary<string, string>> nameValueList = inputBlockDTO.GetInputGroupValueDictionary();

            if (nameValue.ContainsKey("Product.Id"))
                this.Id = Int32.Parse(nameValue["Product.Id"]);
            this.Name = nameValue["Product.Name"];
            this.Price = Decimal.Parse(nameValue["Product.Price"]);
            this.SubCategoryId = Int32.Parse(nameValue["Product.SubCategoryId"]);
            this.TemplateId = Int32.Parse(nameValue["Product.TemplateId"]);
            this.DiscountId = Int32.Parse(nameValue["Product.DiscountId"]);

            this.SubCategory = db.SubCategories.Where(s => s.Id == this.SubCategoryId).First();
            this.Template = db.Templates.Where(t => t.Id == this.TemplateId).First();
            this.Discount = db.Discounts.Where(d => d.Id == this.DiscountId).First();

            nameValueList.ForEach(nv =>
            {
                Value value = new Value();
                if (nv.ContainsKey("Value.MeasurementId"))
                {
                    value.MeasurementId = Int32.Parse(nv["Value.MeasurementId"]);
                    value.Measurement = db.Measurements.Where(m => m.Id == value.MeasurementId).First();
                }

                value.Val = nv["Value.Val"];

                value.Attribute_AttributeSetId = db.Attribute_AttributeSets
                    .Where(aas => aas.AttributeId == Int32.Parse(nv["Value.AttributeId"])
                        && aas.AttributeSetId == Int32.Parse(nv["Value.AttributeSetId"]))
                    .Select(aas => aas.Id)
                    .First();
                value.Attribute_AttributeSet = db.Attribute_AttributeSets.Where(aas => aas.Id == value.Attribute_AttributeSetId).First();

                value.Product = this;

                this.Values.Add(value);
            });
        }
    }
}
