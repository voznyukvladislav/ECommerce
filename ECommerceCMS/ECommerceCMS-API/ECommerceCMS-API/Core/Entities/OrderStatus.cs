using ECommerceCMS_API.Core.DTOs.DbInteractionDTOs;
using ECommerceCMS_API.Infrastructure.Data;

namespace ECommerceCMS_API.Core.Entities
{
    public class OrderStatus
    {
        public int Id { get; set; }
        public string Status { get; set; } = string.Empty;
        public List<Order> Orders { get; set; } = new();

        public OrderStatus()
        {
            
        }
        public OrderStatus(ECommerceDbContext db, InputBlockDTO inputBlockDTO)
        {
            Dictionary<string, string> nameValue = inputBlockDTO.GetNameValueDictionary();
            this.Status = nameValue["OrderStatus.Status"];

            if (nameValue.ContainsKey("OrderStatus.Id"))
            {
                this.Id = Convert.ToInt32(nameValue["OrderStatus.Id"]);
            }
        }
    }
}
