using System;
using TechTalk.SpecFlow;

namespace BDDvsTDD.Specs.StepDefinitions
{
    [Binding]
    public class DeleteEntryStepDefinitions
    {
        [When(@"the user presses a delete button")]
        public void WhenTheUserPressesADeleteButton()
        {
            throw new PendingStepException();
        }

        [Then(@"a confirmation window should appear")]
        public void ThenAConfirmationWindowShouldAppear()
        {
            throw new PendingStepException();
        }

        [When(@"the user confirms")]
        public void WhenTheUserConfirms()
        {
            throw new PendingStepException();
        }

        [Then(@"the Product will be deleted from the list")]
        public void ThenTheProductWillBeDeletedFromTheList()
        {
            throw new PendingStepException();
        }
    }
}
