Feature: Add item to cart

  Scenario: Add backpack to cart
    Given I log in with "standard_user" and "secret_sauce"
    When I add "Sauce Labs Backpack" to cart
    Then I should see "Sauce Labs Backpack" in the cart