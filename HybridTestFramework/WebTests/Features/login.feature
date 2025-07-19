Feature: Login
	Scenario: Successful login
		Given user is on login page
		When user logs in with valid credentials
		Then adds an item to the cart
		Then wait for 5 seconds
		Then item should be present in cart
		Then wait for 10 seconds