using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practika.Models
{
    internal class Orders
    {
        public int ID_Orders { get; set; }
        public int Status { get; set; }
        public int TypeofOrder { get; set; }
        public decimal TotalAmount { get; set; }
        public string DateOfOrder { get; set; } 
        public int PaymentMethod { get; set; }
        public int ID_User { get; set; }
        public int ID_Products { get; set; }
    }
}
