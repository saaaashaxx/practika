using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practika.Models
{
    internal class Products
    {
        public int ID_Products { get; set; }
        public string Name { get; set; }
        public string Volume { get; set; } 
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
        public int ID_Suppliers { get; set; }
        public int ID_Categories { get; set; }
        public int ID_Brands { get; set; }
        public string img { get; set; }
    }
}
