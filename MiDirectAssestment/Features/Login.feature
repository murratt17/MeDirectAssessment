Feature: Login

    @loginWithMultipleUsers
    Scenario: Try Login With Multiple Users
        Given User navigates to https://www.saucedemo.com/
        And User should see that page contains Login
        And User fills username as <username>
        And User fills password as <userpass>
        And User clicks login button in the page
        Then User should see loginstatus <loginstatus>


         Examples:
          | username                | userpass     | loginstatus |
          | standard_user           | secret_sauce | true        |
          | problem_user            | secret_sauce | true        |
          | performance_glitch_user | secret_sauce | true        |
          | locked_out_user         | secret_sauce | false       |
          | standard_user           |              | false       |
          |                         | secret_sauce | false       |
          |                         |              | false       |




@Logout
Scenario: test logout
	 Given User navigates to https://www.saucedemo.com/
        And User should see that page contains Login
        And User fills username as standard_user
        And User fills password as secret_sauce
        And User clicks login button in the page
        Then User should see loginstatus true
        And User clicks menu button in the page
        And User clicks logout button in the page
        And User should see loginpage