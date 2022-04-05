using Xunit;
using BDDvsTDD;

namespace BDDvsTDD.Unit.Specs
{
    public class ProductListModelTests
    {
        private readonly ProductListModel listObject = new();

        [Theory]
        [InlineData("Tomate",0.99,5)]
        public void shouldAddEntry(string name, float price, int amount)
        {
            listObject.addEntry(name, price, amount);
            Product entry = listObject.getEntry(name);
            Assert.Equal(entry.name, name);
            Assert.Equal(entry.price, price);
            Assert.Equal(entry.amount, amount);
            Assert.Single(listObject.getEntries());
        }
    }
}