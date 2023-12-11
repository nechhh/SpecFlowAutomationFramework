Feature: Login Functionalities

A short summary of the feature

@Login @smoke
Scenario: Valid Admin login
	Given User open the browser and launch HRMS application
	When user enters valid email "ADMIN" and valid password "Hum@nhrm123"
	And click on login button
	Then user is logged in as "Welcome Admin" successfully into the application
