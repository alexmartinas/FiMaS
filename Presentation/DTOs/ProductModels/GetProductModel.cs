using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation.DTOs.ProductModels
{
    public class GetProductModel
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public DateTime BoughtAt { get; set; }
        public string Provider { get; set; }
        public double Quantity { get; set; }
    }
}
