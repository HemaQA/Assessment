Feature: Login functionality

Scenario Outline: Login validation with multiple inputs
    Given user is on login page
    When user enters "<username>" and "<password>"
    And user clicks login
    Then login outcome should be "<expectedResult>"

Examples:
| username | password | expectedResult |
| john     | demo     | success        |
| john     |          | error          |
|          | demo     | behavior       |
| invalid  | invalid  | behavior       |
|          |          | error          |

Scenario: Verify login page UI elements
    Given user is on login page
    Then username field should be visible
    And password field should be visible
    And login button should be visible
    And forgot login info link should be visible