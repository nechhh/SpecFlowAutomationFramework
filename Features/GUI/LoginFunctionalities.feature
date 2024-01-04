Feature: Login Functionalities

A short summary of the feature

@smoke @login
Scenario: Valid Admin login
	#Given User open the browser and launch HRMS application
	When user enters valid email and valid password
	And click on login button
	Then user is logged in successfully into the application

	@smoke @scenarioOutline
	Scenario Outline: Login with multiple credentials using Scenario Outline
	#Given User open the browser and launch HRMS application
	When user enters valid "<username>" and valid "<password>"
	And click on login button
	Then  user sees "<outcome>"
	
	Examples: 
	| username | password    | outcome |
	| ADMIN    | Hum@nhrm123 |success  |
	| admin    | Hum@nhrm123 |success  |
	| admin    | Hum@nhrm123 |success  |

