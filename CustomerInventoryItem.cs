using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Inventory_for_Juntec
{
    internal class CustomerInventoryItem
    {
        public int CustomerInventoryID { get; set; }
        public string CustomerName { get; set; }
        public string PartNumber { get; set; }
        public string Dimention { get; set; } // Computed B
        public int AssignedQuantity { get; set; }
        public decimal Cost { get; set; }
    }
}
