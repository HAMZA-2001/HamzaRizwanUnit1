Feature: A happy-path scenario of a customer journey to purchase a single item.

Scenario: Customer successfully purchase a single item
	Given the customer is on the homepage of Swag Labs website
	When the customer logs in with valid credentials
	And they add product "Sauce Labs Backpack" to the basket
	And they proceed to checkout
	And they provide valid checkout information
	And the customer confirms the order
	Then the customer should see and order confirmation message

Scenario: Verify Item Prices from CSV File
	When the customer logs in with valid credentials
	Then  I iterate over each item in CSV file to ensure both website's and CSV file prices matches




