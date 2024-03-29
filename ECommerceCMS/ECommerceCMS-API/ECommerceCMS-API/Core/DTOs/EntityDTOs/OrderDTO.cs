﻿using ECommerceCMS_API.Core.Entities;

namespace ECommerceCMS_API.Core.DTOs.EntityDTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public string Products { get; set; }
        public decimal TotalPrice { get; set; }
        public string OrderStatus { get; set; } = string.Empty;

        public OrderDTO()
        {

        }
        public OrderDTO(Order order)
        {
            Id = order.Id;
            Date = order.Date;
            UserId = order.UserId;
            if (order.Products.Count != 0)
                Products = string.Join(",", order.Products.Select(p => p.ProductId));
            TotalPrice = order.TotalPrice;
            OrderStatus = order.OrderStatus.Status;
        }
    }
}
