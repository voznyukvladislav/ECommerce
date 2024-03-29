﻿using ECommerceCMS_API.Core.DTOs.DbInteractionDTOs;
using System.ComponentModel.DataAnnotations;

namespace ECommerceCMS_API.Core.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<SubCategory> SubCategories { get; set; } = new List<SubCategory>();
        public Category()
        {

        }
        public Category(InputBlockDTO inputBlockDTO)
        {
            Dictionary<string, string> nameValue = inputBlockDTO.GetNameValueDictionary();
            if (nameValue.ContainsKey("Category.Id"))
                this.Id = Int32.Parse(nameValue["Category.Id"]);
            this.Name = nameValue["Category.Name"];
        }
    }
}
