Feature: User Login

  Background:
    Given user is on login page

  Scenario: Successful login
    When user logs in with valid credentials
    Then the dashboard should be displayed

  Scenario Outline: Invalid login
    When the user logs in with username "<username>" and password "<password>"
    Then an error message should be shown

    Examples:
      | username      | password    |
      | invalid_user  | secret123   |
      | blank_user    |             |
