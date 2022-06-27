Feature: PetStoreApi

 Background:
        Given The user set base url as : https://petstore.swagger.io/v2

 ###### Pet Tests ###############################################################################################################################################################
    
    @getAvailablePets
    Scenario: /pet/findByStatus?status=available
        Given The user sends get request to /pet/findByStatus?status= with "available"
        * The user should see the response 200
        * The user controls getAvailablePets details in response

    
    #First I added a pending pet , because there is no pending pet in the database
    @getPendingPets
    Scenario: /pet/findByStatus?status=pending
        Given  The user sends post request to /pet for pending test
        * The user should see the response 200
        * The user should see id is "26062022" in the response
        * The user sends get request to /pet/findByStatus?status= with "pending"
        * The user should see the response 200
        * The user controls getPendingPets details in response
        * The user send delete request to /pet/ with "26062022"
        * The user should see the response 200


    @getSoldPets
    Scenario: /pet/findByStatus?status=sold
        Given The user sends get request to /pet/findByStatus?status= with "sold"
        * The user should see the response 200
        * The user controls getSoldPets details in response

   @getPostPutDelPet
    Scenario: Tests get a spesific pet , post a new pet, update the pet and delete pet 
        Given The user sends get request to /pet/ with "25062022"
        * The user should see the response 404
        * The user sends post request to /pet 
        * The user should see id is "25062022" in the response
        * The user sends post request for "25062022" to update name "Michael"
        * The user should see the response 200
        * The user send delete request to /pet/ with "25062022"
        * The user should see the response 200
        * The user sends get request to /pet/ with "25062022"
        * The user should see the response 404
        * The user send delete request to /pet/ with "25062022"
        * The user should see the response 404


    @postInvalidID
    Scenario: post an invalid id for a pet and see 400 invalid input response
        Given  The user sends post request to /pet with invalid Id
        * The user should see the response 400
        * The user should see message is "bad input" in the response

    @getInvalidID
    Scenario: get an invalid id for a pet and see 400-4 invalid input response
        Given  The user sends get request to /pet/ with "aaaa"
        * The user should see the response 404
        * The user should see message is "NumberFormatException" in the response
 
 ###### Store Tests ###############################################################################################################################################################

     @getPostDelStoreOrder
    Scenario: Tests get a spesific store order , post a new order,and delete order 
        Given The user sends get request to /store/order/ with "8"
        * The user should see the response 404
        * The user sends post request to /store/order
        * The user should see the response 200
        * The user should see id is "8" in the response
        * The user should see status is "placed" in the response
        * The user sends get request to /store/order/ with "8"
        * The user should see the response 200
        * The user send delete request to /store/order/ with "8"
        * The user should see the response 200
        * The user should see message is "8" in the response
        * The user sends get request to /store/order/ with "8"
        * The user should see the response 404
        * The user should see message is "Order not found" in the response
        * The user send delete request to /store/order/ with "8"
        * The user should see the response 404
        * The user should see message is "Order Not Found" in the response


    @GetandDeleteInvalidID
    Scenario: GetAndDeleteInvalidStoreID
        Given The user sends get request to /store/order/ with "22"
        * The user should see message is "Order not found" in the response
        * The user should see the response 404
        * The user sends get request to /store/order/ with "AA"
        * The user should see the response 404
        * The user should see message is "java.lang.NumberFormatException: For input string: "AA"" in the response
        * The user send delete request to /store/order/ with "aa"
        * The user should see the response 404
        * The user should see message is "java.lang.NumberFormatException: For input string: "aa"" in the response
