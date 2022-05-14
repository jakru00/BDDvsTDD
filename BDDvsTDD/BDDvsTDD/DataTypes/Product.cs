using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDDvsTDD
{
    public class Product
    {
        public Guid Uuid { get; set; }
        public float Price { get; set; }
        public string Name { get; set; }
        public float Amount { get; set; }

        public Product(string name, float price, float amount)
        {
            if (name.Trim().Length == 0)
            {
                throw new EmptyNameException();
            } 
            if (price < 0)
            {
                throw new ArgumentOutOfRangeException("Price is below 0");
            }
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("Amount is below 0");
            }

            Uuid = Guid.NewGuid();
            Price = price;
            Name = name;
            Amount = amount;
        }
    }
}
