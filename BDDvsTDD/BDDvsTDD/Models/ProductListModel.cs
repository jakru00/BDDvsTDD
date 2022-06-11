using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BDDvsTDD
{
    public class ProductListModel
    {
        private List<Product> entries;

        private const string persistentStoragePath = "./PersitantStorage.csv";

        public ProductListModel()
        {
            entries = new List<Product>(0);
            ImportCsv();
        }

        public Product[] GetEntries()
        {
            return entries.ToArray();
        }

        public Product AddEntry(string name, float price, float amount)
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

        public void ExportToCsv()
        {
            string csv = String.Join("\n", entries.Select(x => String.Join(',', new string[] { x.Name, x.Price.ToString(), x.Amount.ToString() })));
            File.WriteAllText(persistentStoragePath, csv);
        }

        public void ImportCsv()
        {
            if (File.Exists(persistentStoragePath))
            {
                using (var reader = new StreamReader(persistentStoragePath))
                {
                    while (!reader.EndOfStream)
                    {
                        string[] line = reader.ReadLine().Split(',');
                        string name = line[0];
                        try
                        {
                            float price = float.Parse(line[1]);
                            float amount = float.Parse(line[2]);
                            AddEntry(name, price, amount);
                        }
                        catch { }
                    }
                }
            }
        }


    }
}
