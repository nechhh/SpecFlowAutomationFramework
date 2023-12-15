Feature: Login Functionalities

A short summary of the feature

@Login @smoke
Scenario: Valid Admin login
	#Given User open the browser and launch HRMS application
	When user enters valid email and valid password
	And click on login button
	Then user is logged in successfully into the application
