Feature: CheckOut

A short summary of the feature

@checkOutEndToEndTest
Scenario: CheckComplete End To End Test
	 Given User navigates to https://www.saucedemo.com/
        And User should see that page contains Login
        And User fills username as standard_user
        And User fills password as secret_sauce
        And User clicks login button in the page
        And User clicks addchart button for random 3 products
        And User should see 3 in shopping card icon
        And User clicks shoppingcardicon button in the page
        And User clicks checkout button in the page
        And User should see that page contains CHECKOUT: YOUR INFORMATION
        And User fills firstname as murat
        And User fills lastname as guven
        And User fills postalcode as 17100
        And User clicks continue button in the page
        And User should see that page contains CHECKOUT: OVERVIEW
        And User clicks finish button in the page
        And User should see that page contains CHECKOUT: COMPLETE!
        And User should see that page contains THANK YOU FOR YOUR ORDER
        And User clicks back home button in the page
        And User should see that page contains PRODUCTS


@checkTotalPrice
Scenario: Check Total Price of Products
	 Given User navigates to https://www.saucedemo.com/
        And User should see that page contains Login
        And User fills username as standard_user
        And User fills password as secret_sauce
        And User clicks login button in the page
        And User clicks addchart button for random 3 products
        And User should see 3 in shopping card icon
        And User clicks shoppingcardicon button in the page
        And User clicks checkout button in the page
        And User should see that page contains CHECKOUT: YOUR INFORMATION
        And User fills firstname as murat
        And User fills lastname as guven
        And User fills postalcode as 17100
        And User clicks continue button in the page
        And User should see that page contains CHECKOUT: OVERVIEW
        And User checks shoppingcart total price is true



@checkOutWithProblemUser
Scenario: Check Out With Problem User
	 Given User navigates to https://www.saucedemo.com/
        And User should see that page contains Login
        And User fills username as problem_user
        And User fills password as secret_sauce
        And User clicks login button in the page
        And User clicks addchart button for product 1
        And User clicks addchart button for product 2
        And User clicks addchart button for product 3
        And User should see 2 in shopping card icon
        And User clicks shoppingcardicon button in the page
        And User clicks checkout button in the page
        And User should see that page contains CHECKOUT: YOUR INFORMATION
        And User fills firstname as murat
        And User fills lastname as guven
        And User fills postalcode as 17100
        And User clicks continue button in the page
        And User should see that page contains Error: Last Name is required
