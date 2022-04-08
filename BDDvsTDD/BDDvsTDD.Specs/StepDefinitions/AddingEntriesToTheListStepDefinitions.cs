using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace BDDvsTDD.Specs.StepDefinitions
{
    [Binding]
    public class AddingEntriesToTheListStepDefinitions
    {
        protected static WindowsDriver<WindowsElement> session;

        ProductListModel model = new ProductListModel();
        string? nameMem;
        int amountMem;
        float priceMem;

        [BeforeTestRun]
        public static void SetupTest()
        {
            if (session == null)
            {
                var appiumOptions = new AppiumOptions();
                appiumOptions.AddAdditionalCapability("app", WinAppConfig.WpfAppId);
                appiumOptions.AddAdditionalCapability("deviceName", "WindowsPC");
                session = new WindowsDriver<WindowsElement>(new Uri(WinAppConfig.WindowsApplicationDriverUrl), appiumOptions);
            }
        }

        [AfterTestRun]
        public static void DisposeTest()
        {
            session?.Dispose();
        }

        [Given(@"there is at least one entry")]
        public void GivenThereIsAtLeastOneEntry()
        {
            if (model.getEntries().Length < 1)
            {
                model.addEntry("Tomate", 1.5f, 10);
            }
            Assert.True(model.getEntries().Length >= 1);
        }

        [When(@"the user starts the app")]
        public void WhenTheUserStartsTheApp()
        {
            Assert.True(true);
        }

        [Then(@"all entries shall be displayed")]
        public void ThenAllEntriesShallBeDisplayed()
        {
            Product[] allProducts = model.getEntries();
            foreach (Product product in allProducts)
            {
                session.FindElementByName(product.name);
                session.FindElementByName(product.price.ToString());
                session.FindElementByName(product.amount.ToString());
            }
        }

        [Given(@"the product name is (.*)")]
        public void GivenTheProductNameIsTomate(string name)
        {
            nameMem = name;
        }

        [Given(@"the amount is (.*)")]
        public void GivenTheAmountIs(int amount)
        {
            amountMem = amount;
        }

        [Given(@"the price is (.*)")]
        public void GivenThePriceIs(float price)
        {
            priceMem = price;
        }

        [When(@"the user adds the entry")]
        public void WhenTheUserPresses()
        {
            session.FindElementByAccessibilityId("addNameInput").SendKeys(nameMem);
            session.FindElementByAccessibilityId("addPriceInput").SendKeys(priceMem.ToString());
            session.FindElementByAccessibilityId("addAmountInput").SendKeys(amountMem.ToString());
            session.FindElementByAccessibilityId("AddProductButton").Click();
        }

        [Then(@"the entry shall be added to the existing entries with the given properties")]
        public void ThenTheEntryShallBeAddedToTheExistingEntriesWithTheGivenProperties()
        {
            session.FindElementByName(nameMem);
            session.FindElementByName(priceMem.ToString());
            session.FindElementByName(amountMem.ToString());
        }
    }
}
