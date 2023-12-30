Feature: CreateUser

Create a new user

@api
Scenario: create new user with valid imputs
	Given user with name "Ozlem"
	And user with job "Hostess"
	When Send request to create user
	Then Validate user is created
