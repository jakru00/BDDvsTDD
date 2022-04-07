using Xunit;

namespace BDDvsTDD.Unit.Specs.ProductListModelTests
{
    public class AddProdutTests
    {
        private readonly ProductListModel listObject = new();

        [Theory]
        [InlineData("Tomate",0.99,5)]
        public void shouldAddEntry(string name, float price, int amount)
        {
            int listLengthBefore = listObject.getEntries().Length;
            listObject.addEntry(name, price, amount);
            Product entry = listObject.getEntry(name);
            Assert.Equal(entry.name, name);
            Assert.Equal(entry.price, price);
            Assert.Equal(entry.amount, amount);
            Assert.Equal(listLengthBefore +1 ,listObject.getEntries().Length);
        }

        [Fact]
        public void shouldNotAllowDuplicateProductNames()
        {
            int listLengthBefore = listObject.getEntries().Length;
            listObject.addEntry("Test1", 1, 1);
            listObject.addEntry("Test1", 1, 1);
            Assert.Equal(listLengthBefore + 1, listObject.getEntries().Length);
        }
    }
}