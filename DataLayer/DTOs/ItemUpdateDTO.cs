using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.DTOs
{
    public class ItemUpdateDTO
    {
        public int? category { get; set; }
        public string? title { get; set; }
        public string description { get; set; }
        public string? price { get; set; }
    }
}
