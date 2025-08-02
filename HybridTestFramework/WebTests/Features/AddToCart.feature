@Cart
Feature: Add item to cart

  Scenario: Add backpack to cart
    Given I log in with "standard_user" and "secret_sauce"
    When I add "Sauce Labs Backpack" to cart
    Then I should see "Sauce Labs Backpack" in the cart
  
  Scenario: Add Sauce labs Bike Light to cart
    Given I log in with "standard_user" and "secret_sauce"
    When I add "Sauce Labs Bike Light" to cart
    Then I should see "Sauce Labs Bike Light" in the cart