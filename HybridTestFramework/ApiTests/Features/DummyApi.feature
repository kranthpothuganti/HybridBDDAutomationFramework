Feature: Dummy API test

  Scenario: Validate GET request from dummy API
    Given the API base URL is "https://jsonplaceholder.typicode.com"
    When I send a GET request to "/posts/1"
    Then the response status code should be 200
    And the response should contain "userId"