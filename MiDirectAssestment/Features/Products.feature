Feature: Products



@addingRandomProductsToBasket
Scenario: Add random products to shoppingcart
	 Given User navigates to https://www.saucedemo.com/
        And User should see that page contains Login
        And User fills username as standard_user
        And User fills password as secret_sauce
        And User clicks login button in the page
        And User clicks addchart button for random 3 products
        And User should see 3 in shopping card icon
        And User clicks shoppingcardicon button in the page
        And User checks shoppingcart page if carts are in the cartlist


@addingRandomProductsAndRemove
Scenario: Add random products and remove
	 Given User navigates to https://www.saucedemo.com/
        And User should see that page contains Login
        And User fills username as standard_user
        And User fills password as secret_sauce
        And User clicks login button in the page
        And User clicks addchart button for random 3 products
        And User should see 3 in shopping card icon
        And User clicks shoppingcardicon button in the page
        And User checks shoppingcart page if carts are in the cartlist
        And User removes all product in cartlist
        And User clicks checkout button in the page
        And User should see that page contains CHECKOUT: YOUR INFORMATION
        And User fills firstname as murat
        And User fills lastname as guven
        And User fills postalcode as 17100
        And User clicks continue button in the page
        And User should see that page contains CHECKOUT: OVERVIEW
        And User should see that total price is $0.00

        



@testSortingFunctionality
Scenario: Sorting According To All Options
	 Given User navigates to https://www.saucedemo.com/
        And User should see that page contains Login
        And User fills username as standard_user
        And User fills password as secret_sauce
        And User clicks login button in the page
        And User should see that page contains PRODUCTS
        And User clicks sorting button in the page
        And User selects <sortingType> on the dropdown
        Then User should see that firstelement in the page is <firstelement>


         Examples:
          | sortingType             | firstelement                      | 
          | Name (Z to A)           | Test.allTheThings() T-Shirt (Red) | 
          | Price (low to high)     | Sauce Labs Onesie                 | 
          | Price (high to low)     | Sauce Labs Fleece Jacket          | 
          |Name (A to Z)            | Sauce Labs Backpack               | 


