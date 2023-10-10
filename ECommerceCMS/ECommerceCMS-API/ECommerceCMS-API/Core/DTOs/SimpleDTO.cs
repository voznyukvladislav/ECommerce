using ECommerceCMS_API.Core.DTOs.EntityDTOs;
using ECommerceCMS_API.Core.Entities;

namespace ECommerceCMS_API.Core.DTOs
{
    public class SimpleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public SimpleDTO()
        {}
        public SimpleDTO(Entities.Attribute attribute)
        {
            this.Id = attribute.Id;
            this.Name = attribute.Name;
        }
        public SimpleDTO(AttributeSet attributeSet)
        {
            this.Id = attributeSet.Id;
            this.Name = attributeSet.Name;
        }
        public SimpleDTO(Category data) 
        {
            this.Id = data.Id;
            this.Name = data.Name;
        }
        public SimpleDTO(Discount data)
        {
            this.Id = data.Id;
            this.Name = data.Value.ToString();
        }
        public SimpleDTO(Measurement data)
        {
            this.Id = data.Id;
            this.Name = data.Name;
        }
        public SimpleDTO(MeasurementSet data)
        {
            this.Id = data.Id;
            this.Name = data.Name;
        }
        public SimpleDTO(Order data)
        {
            this.Id = data.Id;
            this.Name = $"Date: {data.Date}, UserId: {data.UserId}";
        }
        public SimpleDTO(Order_Product orderProduct)
        {
            this.Id = orderProduct.Id;
            this.Name = $"Order: {orderProduct.OrderId}, Product: {orderProduct.ProductId}";
        }

        public SimpleDTO(OrderStatus orderStatus)
        {
            this.Id = orderStatus.Id;
            this.Name = orderStatus.Status;
        }

        public SimpleDTO(Photo data)
        {
            this.Id = data.Id;
            this.Name = $"ProductId: {data.ProductId}, Source: {data.Source}";
        }
        public SimpleDTO(Product data)
        {
            this.Id = data.Id;
            this.Name = data.Name;
        }
        public SimpleDTO(Review data)
        {
            this.Id = data.Id;
            this.Name = $"UserId: {data.UserId}, Text: {data.Text}, Rating: {data.Rating}";
        }
        public SimpleDTO(Role data)
        {
            this.Id = data.Id;
            this.Name = data.Name;
        }
        public SimpleDTO(ShoppingCart data)
        {
            this.Id = data.Id;
            this.Name = $"UserId: {data.UserId}";
        }
        public SimpleDTO(SubCategory data)
        {
            this.Id = data.Id;
            this.Name = data.Name;
        }
        public SimpleDTO(Template data)
        {
            this.Id = data.Id;
            this.Name = data.Name;
        }
        public SimpleDTO(User data)
        {
            this.Id = data.Id;
            this.Name = data.Login + data.Name + data.Surname;
        }
        public SimpleDTO(Value data)
        {
            this.Id = data.Id;
            this.Name = $"ProductId: {data.ProductId}, Value: {data.Val}";
        }
    }
}
