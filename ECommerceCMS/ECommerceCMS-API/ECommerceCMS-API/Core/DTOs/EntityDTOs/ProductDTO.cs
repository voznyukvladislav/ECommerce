﻿using ECommerceCMS_API.Core.Entities;

namespace ECommerceCMS_API.Core.DTOs.EntityDTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string TemplateId { get; set; }
        public string DiscountId { get; set; }
        public string SubCategoryId { get; set; }
        public string Orders { get; set; }
        public string Reviews { get; set; }
        public string ShoppingCarts { get; set; }
        public string Values { get; set; }

        public ProductDTO()
        { }
        public ProductDTO(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Price = product.Price.ToString();
            TemplateId = product.TemplateId.ToString();
            DiscountId = product.DiscountId.ToString();
            SubCategoryId = product.SubCategoryId.ToString();
            if (product.Orders is not null)
                Orders = string.Join(", ", product.Orders.Select(o => o.Id));
            if (product.Reviews is not null)
                Reviews = string.Join(", ", product.Reviews.Select(r => r.Id));
            if (product.ShoppingCarts is not null)
                ShoppingCarts = string.Join(", ", product.ShoppingCarts.Select(sc => sc.Id));
            if (product.Values.Count != 0)
                Values = string.Join(", ", product.Values.Select(v => v.Id));
        }
    }
}
