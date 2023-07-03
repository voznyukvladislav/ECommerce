using ECommerceCMS_API.Core.DTOs.DbInteractionDTOs;
using System.ComponentModel.DataAnnotations;

namespace ECommerceCMS_API.Core.Entities
{
    public class Discount
    {
        [Key]
        public int Id { get; set; }
        public decimal Value { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        public Discount()
        {

        }
        public Discount(InputBlockDTO inputBlockDTO)
        {
            Dictionary<string, string> nameValues = inputBlockDTO.GetNameValueDictionary();
            if (nameValues.ContainsKey("Discount.Id"))
                this.Id = Int32.Parse(nameValues["Discount.Id"]);
            this.Value = Decimal.Parse(nameValues["Discount.Value"]);
        }
    }
}
