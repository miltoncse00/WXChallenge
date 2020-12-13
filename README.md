Wooliesx Challenge API coding exercise

The swagger page of excerise is here https://wooliesxchallenge.azurewebsites.net/swagger/index.html


This is a Quick document of WooliesxChallege generated from postman. I have also attached postman json file in this repository.
postman document link here https://documenter.getpostman.com/view/2333773/TVsoGVyS

GET Excercise 1: User
https://wooliesxchallenge.azurewebsites.net//api/Answers/User
This is excercise 1: get the name and token of user.

curl --location --request GET 'https://wooliesxchallenge.azurewebsites.net//api/Answers/User'



GET Excercise 3:Product Sort - Low
https://wooliesxchallenge.azurewebsites.net/api/Product/Sort?sortOption=Low
This is Excercise 2 for sorting the product with Power Price.

PARAMS
sortOption Low
curl --location --request GET 'https://wooliesxchallenge.azurewebsites.net/api/Product/Sort?sortOption=Low'


GET Excercise 2:Product Sort -High
https://wooliesxchallenge.azurewebsites.net/api/Product/Sort?sortOption=High
This is excercise 2: sort the product with Higher price

PARAMS
sortOption  High


GET Excercise 2: Product Sort - Ascending
https://wooliesxchallenge.azurewebsites.net/api/Product/Sort?sortOption=Ascending
This is excercise 2: sort the product with name in ascending order

PARAMS
sortOption Ascending

GET Excercise 2:Product Sort - Descending
https://wooliesxchallenge.azurewebsites.net/api/Product/Sort?sortOption=Descending
This is excercise 2: sort the product with name in descending order

PARAMS
sortOption Descending

GET Excercise 2:Product Sort - Recommeded
https://wooliesxchallenge.azurewebsites.net/api/Product/Sort?sortOption=Recommended
This is excercise 2: sort the product based on popularity in shopper history

PARAMS
sortOption Recommended



POST TrolleyTotal
https://wooliesxchallenge.azurewebsites.net/api/TrolleyCalculator/TrolleyTotal
This is excercise 3: get the minimum price of trolley total

HEADERS
Content-Typeapplication/json
BODY raw

{
	  "products": [
		{
		  "name": "milk",
		  "price": 2
		},
	{
		  "name": "tea",
		  "price": 3
		}
	  ],
	  "specials": [
		{
	  
		  "quantities": [
			{
			  "name": "milk",
			  "quantity": 1
			},
			{
			  "name": "tea",
			  "quantity": 2
			}
		  ],
		  "total": 1
		}
	  ],
	  "quantities": [
		{
		  "name": "milk",
		  "quantity": 3
		},
	{
			  "name": "tea",
			  "quantity": 8
			}
	  ]
	}


