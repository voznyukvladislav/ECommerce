using ECommerceCMS_API.Core.Entities;

namespace ECommerceCMS_API.Core.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public string Products { get; set; }
        public OrderDTO()
        {

        }
        public OrderDTO(Order order)
        {
            this.Id = order.Id;
            this.Date = order.Date;
            this.UserId = order.UserId;
            if(order.Products.Count != 0)
                this.Products = String.Join(",", order.Products.Select(p => p.Id));
        }
    }
}
