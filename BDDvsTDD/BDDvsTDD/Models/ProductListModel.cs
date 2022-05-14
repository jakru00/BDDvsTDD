using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDDvsTDD
{
    public class ProductListModel
    {
        private List<Product> entries;

        public ProductListModel()
        {
            entries = new List<Product>(0);
        }

        public Product[] GetEntries()
        {
            return entries.ToArray();
        }

        public Product AddEntry(string name, float price, int amount)
        {
            var prod = new Product(name, price, amount);
            entries.Add(prod);
            return prod;
        }

        public void RemoveEntry(Guid uuid) {
            foreach (Product product in entries)
            {
                if (product.Uuid == uuid)
                {
                    entries.Remove(product);
                    return;
                }
            }
        }

        public Product GetEntry(Guid uuid) 
        { 
            return entries.FirstOrDefault(product => product.Uuid == uuid);
        }
    }
}
