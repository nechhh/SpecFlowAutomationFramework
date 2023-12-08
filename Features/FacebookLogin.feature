Feature: Facebook Login

As a user, I want to log into Facebook so that I can access my acount. 

@Demo @smoke
Scenario: Successful login with valid credentials
	Given  I am on the Facebook login page
	When  I enter valid credentials 
	Then I should verify homepage title



