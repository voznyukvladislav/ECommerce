using ECommerceCMS_API.Core.DTOs.DbInteractionDTOs;
using ECommerceCMS_API.Infrastructure.Data;
using System.ComponentModel.DataAnnotations;

namespace ECommerceCMS_API.Core.Entities
{
    public class Value
    {
        [Key]
        public int Id { get; set; }
        public string Val { get; set; }

        public Product Product { get; set; } = new Product();
        public int ProductId { get; set; }

        public Attribute_AttributeSet Attribute_AttributeSet { get; set; } = new Attribute_AttributeSet();
        public int Attribute_AttributeSetId { get; set; }

        public Measurement? Measurement { get; set; }
        public int? MeasurementId { get; set; }

        public Value()
        {

        }
        public Value(ECommerceDbContext db, InputBlockDTO inputBlockDTO)
        {
            Dictionary<string, string> nameValue = inputBlockDTO.GetNameValueDictionary();
            if (nameValue.ContainsKey("Value.Id"))
                this.Id = Int32.Parse(nameValue["Value.Id"]);
            this.Val = nameValue["Value.Val"];

            this.ProductId = Int32.Parse(nameValue["Value.ProductId"]);
            this.Product = db.Products.Where(p => p.Id == this.ProductId).First();

            this.MeasurementId = Int32.Parse(nameValue["Value.MeasurementId"]);
            this.Measurement = db.Measurements.Where(m => m.Id == this.MeasurementId).First();

            this.Attribute_AttributeSet = db.Attribute_AttributeSets
                .Where(aas => aas.AttributeId == Int32.Parse(nameValue["Value.AttributeId"]) &&
                    aas.AttributeSetId == Int32.Parse(nameValue["Value.AttributeSetId"]))
                .First();
            this.Attribute_AttributeSetId = this.Attribute_AttributeSet.Id;
        }
    }
}
