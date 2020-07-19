using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.DTOs
{
    public class CategoryUpdateDTO
    {
        public string? name { get; set; }
        public int? parent_id { get; set; }
        public bool? is_active { get; set; }
    }
}
