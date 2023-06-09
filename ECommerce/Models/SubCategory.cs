﻿using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class SubCategory
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
