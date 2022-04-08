Feature: Adding Entries to the list
As a customer
I want to add new entries to the shopping list
By typing in name and optionally amount and price
So that they all are displayed in the list

Scenario: Add an entry
	Given the product name is Tomate
	And the amount is 2
	And the price is 1,5 
	When the user adds the entry
	Then the entry shall be added to the existing entries with the given properties