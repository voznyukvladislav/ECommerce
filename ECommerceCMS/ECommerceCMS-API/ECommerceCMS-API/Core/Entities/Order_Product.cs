using ECommerceCMS_API.Core.DTOs.DbInteractionDTOs;
using ECommerceCMS_API.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ECommerceCMS_API.Core.Entities
{
    public class Order_Product
    {
        [Key]
        public int Id { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; } = new();

        public int OrderId { get; set; }
        public Order Order { get; set; } = new();

        public Order_Product()
        {
            
        }

        public Order_Product(ECommerceDbContext db, InputBlockDTO inputBlockDTO)
        {
            Dictionary<string, string> nameValue = inputBlockDTO.GetNameValueDictionary();
            
            this.Count = Convert.ToInt32(nameValue["Order_Product.Count"]);

            if (nameValue.ContainsKey("Order_Product.Id"))
            {
                this.Id = Convert.ToInt32(nameValue["Order_Product.Id"]);
            }

            if (nameValue.ContainsKey("Order_Product.OrderId"))
            {
                this.OrderId = Convert.ToInt32(nameValue["Order_Product.OrderId"]);
                this.Order = db.Orders
                .Where(o => o.Id == this.OrderId)
                .First();
            }

            if (nameValue.ContainsKey("Order_Product.ProductId"))
            {
                this.ProductId = Convert.ToInt32(nameValue["Order_Product.ProductId"]);
                this.Product = db.Products
                .Where(p => p.Id == this.ProductId)
                .First();
            }

            if (this.Id != 0)
            {
                this.Price = db.Order_Product
                .Where(op => op.Id == this.Id)
                .Select(op => op.Price)
                .First();
            }
            else
            {
                Product product = db.Products
                    .Where(p => p.Id == this.ProductId)
                    .Include(p => p.Discount)
                    .First();

                this.Price = product.Discount is null ? product.Price : product.Price - (product.Price * product.Discount.Value); 
            }

            this.TotalPrice = this.Price * this.Count;
        }
    }
}
