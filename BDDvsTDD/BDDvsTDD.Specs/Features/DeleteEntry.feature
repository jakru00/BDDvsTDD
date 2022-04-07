Feature: DeleteEntry

A short summary of the feature

Scenario: User Deletes an already exisiting Product from the list
	Given there is at least one entry
	When the user presses a delete button
	Then a confirmation window should appear
	When the user confirms
	Then the Product will be deleted from the list


