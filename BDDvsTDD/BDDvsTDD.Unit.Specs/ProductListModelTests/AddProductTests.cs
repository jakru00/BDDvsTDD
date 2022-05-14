using Xunit;
using BDDvsTDD;

namespace BDDvsTDD.Unit.Specs.ProductListModelTests
{
    public class AddProdutTests
    {
        private readonly ProductListModel _listObject = new();

        [Theory]
        [InlineData("Tomate",0.99,5)]
        public void ShouldAddEntry(string name, float price, int amount)
        {
            int listLengthBefore = _listObject.GetEntries().Length;
            var entry  = _listObject.AddEntry(name, price, amount);
            Assert.True(entry != null);
            Assert.Equal(entry.Name, name);
            Assert.Equal(entry.Price, price);
            Assert.Equal(entry.Amount, amount);
            Assert.Equal(listLengthBefore +1 ,_listObject.GetEntries().Length);
        }

        [Fact]
        public void ShouldAllowDuplicateProductNames()
        {
            int listLengthBefore = _listObject.GetEntries().Length;
            _listObject.AddEntry("Test1", 1, 1);
            _listObject.AddEntry("Test1", 1, 1);
            Assert.Equal(listLengthBefore + 2, _listObject.GetEntries().Length);
        }
    }
}