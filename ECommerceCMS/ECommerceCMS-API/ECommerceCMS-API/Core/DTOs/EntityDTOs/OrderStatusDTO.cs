using ECommerceCMS_API.Core.Entities;

namespace ECommerceCMS_API.Core.DTOs.EntityDTOs
{
    public class OrderStatusDTO
    {
        public int Id { get; set; }
        public string Status { get; set; } = string.Empty;

        public OrderStatusDTO()
        {
                
        }

        public OrderStatusDTO(OrderStatus orderStatus)
        {
            this.Id = orderStatus.Id;
            this.Status = orderStatus.Status;
        }
    }
}
