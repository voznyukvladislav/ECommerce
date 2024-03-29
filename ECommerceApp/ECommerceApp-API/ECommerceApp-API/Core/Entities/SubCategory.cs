﻿using System.ComponentModel.DataAnnotations;

namespace ECommerceCMS_API.Core.Entities
{
    public class SubCategory
    {
        [Key]
        public int Id { get; set; }       
        public string Name { get; set; } = string.Empty;

        public Category Category { get; set; } = new Category();
        public int CategoryId { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();

        public SubCategory()
        {

        }
    }
}
