Feature: Automated tests


	Scenario: Login to account
	Given I have opened start page
	When I go to sign in page
	And I enter username
	And I enter password
	Then I see profile page

	Scenario: Create task list and add element and delete list
	Given I have opened start page
	And I have log in
	When I create new list
	And add item to it
	Then I see this list
	When I click right on list name
	And I click Delete list
	Then list is removed 


