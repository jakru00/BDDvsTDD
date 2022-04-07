using System;
using Xunit;

namespace BDDvsTDD.Unit.Specs.ProductListModelTests
{

    public class DeleteProductTestsFixture : IDisposable
    {
        public ProductListModel listObject { get; private set; }
        public int lenBeforeTest { get; private set; }
        public DeleteProductTestsFixture()
        {
            listObject = new ProductListModel();
            listObject.addEntry("Test", 1, 1);
            listObject.addEntry("Test1", 1, 1);
            lenBeforeTest = listObject.getEntries().Length;
        }

        public void Dispose() { }
    }
    public class DeleteProductTests : IClassFixture<DeleteProductTestsFixture>
    {
        DeleteProductTestsFixture listFixture;

        public DeleteProductTests(DeleteProductTestsFixture fixture) {
            listFixture = fixture;
        }

        [Fact]
        public void shouldRemoveProduct()
        {
            listFixture.listObject.removeEntry("Test");
            Assert.Equal(listFixture.lenBeforeTest - 1, listFixture.listObject.getEntries().Length);
        }

        [Fact]
        public void shouldRemoveOneProduct()
        {
            listFixture.listObject.removeEntry("Test");
            listFixture.listObject.removeEntry("Test");
            Assert.Equal(listFixture.lenBeforeTest - 1, listFixture.listObject.getEntries().Length);
        }
    }
}
