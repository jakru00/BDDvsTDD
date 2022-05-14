using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using TechTalk.SpecFlow;

namespace BDDvsTDD.Specs.StepDefinitions
{
    [Binding]
    public class DeleteEntryStepDefinitions
    {
        protected static WindowsDriver<WindowsElement> session;
        ProductListModel model = new ProductListModel();


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
            session.FindElementByAccessibilityId("addNameInput").SendKeys("Tomate");
            session.FindElementByAccessibilityId("addPriceInput").SendKeys("1");
            session.FindElementByAccessibilityId("addAmountInput").SendKeys("5");
            session.FindElementByAccessibilityId("addProductButton").Click();

            session.FindElementsByClassName("DataGridRow").Count().Should().Be(1);
        }

        [When(@"the user presses a delete button")]
        public void WhenTheUserPressesADeleteButton()
        {
            session.FindElementByAccessibilityId("deleteProductButton").Click();
        }

        [Then(@"a confirmation window should appear")]
        public void ThenAConfirmationWindowShouldAppear()
        {
            Assert.True(session.FindElementByName("Löschen bestätigen") != null);
        }

        [When(@"the user confirms")]
        public void WhenTheUserConfirms()
        {
            session.Keyboard.SendKeys(Keys.Enter);
        }

        [Then(@"the Product will be deleted from the list")]
        public void ThenTheProductWillBeDeletedFromTheList()
        {
            session.FindElementsByClassName("DataGridRow").Count().Should().Be(0);
        }
    }
}
