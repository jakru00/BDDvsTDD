using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDDvsTDD
{
    public class ProductListModel
    {
        public ProductListModel() { entries = new List<Product>(0); }
        private List<Product> entries;
        public Product[] getEntries() { return entries.ToArray(); }
        public void addEntry(string name, float price, int amount) 
        {
            entries.Add(new Product(name, price, amount));
        }
        public void removeEntry(string name) { }
        public void editEntry(string name) { }
        public Product getEntry(string name) 
        { 
            return entries.FirstOrDefault(product => product.name == name);
        }
    }
}
