Feature: Functionalities for task list
	tests related to task management
	


Scenario: Check task on list
	Given I see task list
	When I select task as done
	Then I task is not displayed on list

	Scenario: Check finished tasks

	Given I see task list
	When I clikc "Show completed to-dos"
	Then I see tasks list which are completed

	Scenario: Add multiple tasks to list
	Given I see task list
	And I click "add a to-do"
	And I enter task name
	And I enter task name
	Then I see both tasks added to list

	Scenario: Delete task from list
	Given I see task list
	When I right click on task name
	Then submenu is opened
	And I click "delete to-do"
	Then popup confirmation is displayed
	When I click "Delete to-do"
	Then task is removed from list

	Scenario: Submenu for task
	Given I see task list
	When I double click on task
	Then submenu is displayed

	Scenario: Change task name
	Given I see task list
	When I double click on task
	Then submenu is displayed
	When I change task name
	And click Enter
	Then task name is changed 

	Scenario: Set task due date
	Given I see task list
	When I double click on task
	Then submenu is displayed
	When I set duedate for next week
	Then reminder is setup

	Scenario: Add comment to task
	Given I see task list
	When I double click on task
	Then submenu is displayed
	When I add comment to task
	And I press enter
	Then comment is added to task

