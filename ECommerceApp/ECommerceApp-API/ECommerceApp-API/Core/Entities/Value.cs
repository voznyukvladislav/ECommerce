using ECommerceCMS_API.Core.DTOs.DbInteractionDTOs;
using ECommerceCMS_API.Infrastructure.Data;
using System.ComponentModel.DataAnnotations;

namespace ECommerceCMS_API.Core.Entities
{
    public class Value
    {
        [Key]
        public int Id { get; set; }
        public string Val { get; set; } = string.Empty;

        public Product Product { get; set; } = new Product();
        public int ProductId { get; set; }

        public Attribute_AttributeSet Attribute_AttributeSet { get; set; } = new Attribute_AttributeSet();
        public int Attribute_AttributeSetId { get; set; }

        public Measurement? Measurement { get; set; }
        public int? MeasurementId { get; set; }

        public Value()
        {

        }
    }
}
