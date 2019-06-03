Usage rule
Run application
Application start the login page

Sign in 
Email: john@gmail.com
Password: 123

After you see list of products.You will see the types of products above. You can filter products by its types 
For Example 
Heavy
Regular
Specialized.

If you click to any product you will see modal for add to cart.
Enter the quantity of day what you want how many days of to rent ,The price is calculated automatically when you enter the quantity of days and you will see price in readonly inputs.
For Example 
One time : 100
Premium Daily : 120
Regular Daily : 80

And Click add to cart button. It will be add to cart list. 
You can add as many products as you want, but without breaking the requirement of uniqueness. You can not add the same product for the second time.
Click Cart menu then you will see cart list. If you click the get invoice button you will see the invoice of product then if you click the Rent button . You will be buy product .
Click Cabinet menu then you will see products what you have bought. Click the Download invoice button then Invoice will be download to your PC as pdf. 

Application have two main tier. UI and Core. Core consists of several parts. 
Application prepared with domain driven architecthure.

Technologies
Caching
Logging,
Unit Testing
Dependency Injection(LightInject)
Automapper
Other helper packages

Class diagram is in RCE.Infrastructure Class Library.

Written by : Seymur Ganbarov