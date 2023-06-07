using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Product
    {
        string productCode, description;
        decimal unitPrice;
        public Product() { }

        public string ProductCode
        {
            get { return productCode; }
            set { this.productCode = value; }
        }
        public string Description
        {
            get { return description; }
            set { this.description = value; }
        }
        public decimal UnitPrice
        {
            get { return unitPrice; }
            set { this.unitPrice = value; }
        }
    }
}
