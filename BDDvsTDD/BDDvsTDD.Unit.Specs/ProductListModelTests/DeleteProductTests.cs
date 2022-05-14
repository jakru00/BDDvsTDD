using System;
using Xunit;

namespace BDDvsTDD.Unit.Specs.ProductListModelTests
{

    public class DeleteProductTestsFixture : IDisposable
    {
        public ProductListModel listObject { get; private set; }
        public int lenBeforeTest { get; private set; }

        public Product testProduct { get; }
        public Product testProduct1 { get; }
        public DeleteProductTestsFixture()
        {
            listObject = new ProductListModel();
            testProduct = listObject.AddEntry("Test", 1, 1);
            testProduct1 = listObject.AddEntry("Test1", 1, 1);
            lenBeforeTest = listObject.GetEntries().Length;
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
            listFixture.listObject.RemoveEntry(listFixture.testProduct.Uuid);
            Assert.Equal(listFixture.lenBeforeTest - 1, listFixture.listObject.GetEntries().Length);
        }

        [Fact]
        public void shouldRemoveOneProduct()
        {
            listFixture.listObject.RemoveEntry(listFixture.testProduct1.Uuid);
            listFixture.listObject.RemoveEntry(listFixture.testProduct1.Uuid);
            Assert.Equal(listFixture.lenBeforeTest - 1, listFixture.listObject.GetEntries().Length);
        }
    }
}
