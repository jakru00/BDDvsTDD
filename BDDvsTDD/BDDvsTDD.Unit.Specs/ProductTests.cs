using System;
using Xunit;

namespace BDDvsTDD.Unit.Specs
{
    public class ProductTests
    {
        [Fact]
        public void shouldConstructProduct()
        {
            Product testProd = new("Tomate", 1.5f, 3);
            Assert.Equal(testProd.Name, "Tomate");
            Assert.Equal(testProd.Price, 1.5);
            Assert.Equal(testProd.Amount, 3);
        }

        [Fact]
        public void shouldNotAllowNegativeAmount() 
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product("Test", 5, -1));
        }

        [Fact]
        public void shouldNotAllowNegativePrice()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product("Test", -5, 1));
        }


        [Theory]
        [InlineData("",5,1)]
        [InlineData(" ", 5, 1)]
        [InlineData("   ", 5, 1)]
        public void shouldNotAllowEmptyName(string name, float price, int amount)
        {
            Assert.Throws<EmptyNameException>(() => new Product(name,price,amount));
        }
    }
}