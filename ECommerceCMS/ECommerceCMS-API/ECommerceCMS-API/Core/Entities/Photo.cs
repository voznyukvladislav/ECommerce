using ECommerceCMS_API.Core.DTOs.DbInteractionDTOs;
using ECommerceCMS_API.Infrastructure.Data;

namespace ECommerceCMS_API.Core.Entities
{
    public class Photo
    {
        public int Id { get; set; }
        public string Source { get; set; }
        public Product Product { get; set; } = new Product();
        public int ProductId { get; set; }
        public Photo()
        {

        }
        public Photo(ECommerceDbContext db, InputBlockDTO inputBlockDTO)
        {
            Dictionary<string, string> nameValue = inputBlockDTO.GetNameValueDictionary();
            if (nameValue.ContainsKey("Photo.Id"))
                this.Id = Int32.Parse(nameValue["Photo.Id"]);

            this.Source = nameValue["Photo.Source"];
            this.ProductId = Int32.Parse(nameValue["Photo.ProductId"]);
            this.Product = db.Products.Where(p => p.Id == this.ProductId).First();
        }
    }
}
