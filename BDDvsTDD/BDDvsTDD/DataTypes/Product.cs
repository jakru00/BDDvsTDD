﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDDvsTDD
{
    public class Product
    {
        public float price { get; set; }
        public string name { get; set; }
        public int amount { get; set; }

        public Product(string name, float price, int amount)
        {
            if (name.Trim().Length == 0)
            {
                throw new EmptyNameException();
            } else if (price < 0)
            {
                throw new NegativePriceException();
            } else if (amount < 0)
            {
                throw new NegativeAmountException();
            }
            this.price = price;
            this.name = name;
            this.amount = amount;
        }
    }
}