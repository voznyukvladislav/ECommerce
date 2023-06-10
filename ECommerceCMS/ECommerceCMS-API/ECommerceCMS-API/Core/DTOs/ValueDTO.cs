using ECommerceCMS_API.Core.Entities;

namespace ECommerceCMS_API.Core.DTOs
{
    public class ValueDTO
    {
        public int Id { get; set; }
        public string Val { get; set; }
        public int ProductId { get; set; }
        public int AttributeSetId { get; set; }
        public int AttributeId { get; set; }
        public ValueDTO()
        {

        }
        public ValueDTO(Value value)
        {
            this.Id = value.Id;
            this.Val = value.Val;
            this.ProductId = value.ProductId;
            this.AttributeSetId = value.AttributeSetId;
            this.AttributeId = value.AttributeId;
        }
    }
}
