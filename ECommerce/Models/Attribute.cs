﻿using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Attribute
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Value> Values { get; set; }
    }
}
