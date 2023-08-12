using ECommerceCMS_API.Core.Entities;

namespace ECommerceCMS_API.Core.DTOs.EntityDTOs
{
    public class ValueDTO
    {
        public int Id { get; set; }
        public string Val { get; set; }
        public int ProductId { get; set; }
        public int Attribute_AttributeSetId { get; set; }
        public int AttrubuteId { get; set; }
        public int AttributeSetId { get; set; }
        public ValueDTO()
        {

        }
        public ValueDTO(Value value)
        {
            Id = value.Id;
            Val = value.Val;
            ProductId = value.ProductId;
            Attribute_AttributeSetId = value.Attribute_AttributeSetId;
            AttrubuteId = value.Attribute_AttributeSet.AttributeId;
            AttributeSetId = value.Attribute_AttributeSet.AttributeSetId;
        }
    }
}
