Feature: List
	Tests related to list management


Scenario: Rename list
	Given I see list
	When I click right on list name
	And I click rename list
	Then I see popup dialog
	When I change list name
	And I click Done
	Then I list name changed 

Scenario: delete list
	Given I see list
	When I click right on list name
	And I click delete list
	Then I see confirmation popup
	When I click Delete list
	Then I see list is not displayed 

