using ECommerceCMS_API.Core.DTOs.DbInteractionDTOs;
using ECommerceCMS_API.Infrastructure.Data;
using System.ComponentModel.DataAnnotations;

namespace ECommerceCMS_API.Core.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public User User { get; set; } = new User();
        public int UserId { get; set; }

        public OrderStatus OrderStatus { get; set; } = new();
        public int OrderStatusId { get; set; }

        public decimal TotalPrice { get; set; }

        public List<Order_Product> Products { get; set; } = new();

        public Order()
        {

        }
        public Order(ECommerceDbContext db, InputBlockDTO inputBlockDTO)
        {
            Dictionary<string, string> nameValue = inputBlockDTO.GetNameValueDictionary();
            List<Order_Product> orderProducts = new();
            if (nameValue.ContainsKey("Order.Id"))
            {
                this.Id = Int32.Parse(nameValue["Order.Id"]);
                orderProducts = db.Order_Product.Where(op => op.OrderId == this.Id).ToList();
            }

            this.Date = DateTime.Parse(nameValue["Order.Date"]);
            this.UserId = Int32.Parse(nameValue["Order.UserId"]);
            this.User = db.Users.Where(u => u.Id == this.UserId).First();
            this.OrderStatusId = Int32.Parse(nameValue["Order.OrderStatusId"]);
            this.OrderStatus = db.OrderStatuses.Where(os => os.Id == this.OrderStatusId).First();

            List<string> productIds = nameValue["Order.Products"].Split(' ').ToList();
            productIds.ForEach(pi =>
            {
                //this.Products.Add(db.Products.Where(p => p.Id == Int32.Parse(pi)).First());
                int productId = Convert.ToInt32(pi);
                if (!orderProducts.Any(op => op.ProductId == productId))
                {
                    Order_Product orderProduct = new Order_Product()
                    {
                        Count = 1,
                        Order = this,
                        Price = db.Products.Where(p => p.Id == productId).Select(p => p.Price).First(),
                        ProductId = productId,
                        TotalPrice = db.Products.Where(p => p.Id == productId).Select(p => p.Price).First(),
                        Product = db.Products.Where(p => p.Id == productId).First()
                    };
                    this.Products.Add(orderProduct);
                    orderProducts.Add(orderProduct);
                }
            });
            db.Orders.Update(this);
            db.SaveChanges();
            
            orderProducts = db.Order_Product.Where(op => op.OrderId == this.Id).ToList();
            orderProducts.ForEach(op =>
            {
                if (!productIds.Contains($"{op.ProductId}"))
                {
                    db.Order_Product.Remove(op);
                }
            });
            db.SaveChanges();

            this.Products = db.Order_Product.Where(op => op.OrderId == this.Id).ToList();
            this.TotalPrice = this.Products.Sum(p => p.TotalPrice);
        }
    }
}
