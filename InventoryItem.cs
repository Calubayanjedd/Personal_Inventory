using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Inventory_for_Juntec
{
    public class InventoryItem
    {
        public int MaterialID { get; set; }

        public string? PartNumber { get; set; }
        public string? Type { get; set; }
        public char ShapeCode { get; set; }
        public char BaseCode { get; set; }
        public decimal BaseValue { get; set; }
        public decimal Diameter { get; set; }
        public decimal Length { get; set; }
        public string? PressureRange { get; set; }
        public decimal PressureMax { get; set; }
        public decimal PressureMin { get; set; }
        public decimal RadiusTolerance { get; set; }
        public decimal Height { get; set; }
        public int Quantity { get; set; }

        public decimal Cost { get; set; }
    }
}
