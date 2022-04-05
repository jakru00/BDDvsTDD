using System;
using TechTalk.SpecFlow;

namespace BDDvsTDD.Specs.StepDefinitions
{
    [Binding]
    public class AddingEntriesToTheListStepDefinitions
    {
        [Given(@"there is at least one entry")]
        public void GivenThereIsAtLeastOneEntry()
        {
            throw new PendingStepException();
        }

        [When(@"the user starts the app")]
        public void WhenTheUserStartsTheApp()
        {
            throw new PendingStepException();
        }

        [Then(@"all entries shall be displayed")]
        public void ThenAllEntriesShallBeDisplayed()
        {
            throw new PendingStepException();
        }

        [Given(@"the product name is (.*)")]
        public void GivenTheProductNameIsTomate(string p0)
        {
            throw new PendingStepException();
        }

        [Given(@"the amount is (.*)")]
        public void GivenTheAmountIs(int p0)
        {
            throw new PendingStepException();
        }

        [Given(@"the price is (.*)")]
        public void GivenThePriceIs(Decimal p0)
        {
            throw new PendingStepException();
        }

        [When(@"the user adds the entry")]
        public void WhenTheUserPresses()
        {
            throw new PendingStepException();
        }

        [Then(@"the entry shall be added to the existing entries with the given properties")]
        public void ThenTheEntryShallBeAddedToTheExistingEntriesWithTheGivenProperties()
        {
            throw new PendingStepException();
        }
    }
}
