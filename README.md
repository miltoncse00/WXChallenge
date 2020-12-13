Wooliesx Challenge API coding exercise

The swagger page of excerise is here https://wooliesxchallenge.azurewebsites.net/swagger/index.html


This is a Quick document of WooliesxChallege generated from postman. I have also attached postman json file in this repository.

Excercise 1

Postman Request Document:

{
	"info": {
		"_postman_id": "e0fdbd4c-5fc2-447b-b481-ffccef8b9421",
		"name": "devWooliesXChallenge",
		"schema": "https://schema.getpostman.com/json/collection/v2.1.0/collection.json"
	},
	"item": [
		{
			"name": "Excercise 1: User ",
			"request": {
				"method": "GET",
				"header": [],
				"url": {
					"raw": "https://wooliesxchallenge.azurewebsites.net//api/Answers/User",
					"protocol": "https",
					"host": [
						"wooliesxchallenge",
						"azurewebsites",
						"net"
					],
					"path": [
						"",
						"api",
						"Answers",
						"User"
					]
				},
				"description": "This is excercise 1: get the name and token of user."
			},
			"response": []
		},
		{
			"name": "Excercise 3:Product Sort - Low",
			"request": {
				"method": "GET",
				"header": [],
				"url": {
					"raw": "https://wooliesxchallenge.azurewebsites.net/api/Product/Sort?sortOption=Low",
					"protocol": "https",
					"host": [
						"wooliesxchallenge",
						"azurewebsites",
						"net"
					],
					"path": [
						"api",
						"Product",
						"Sort"
					],
					"query": [
						{
							"key": "sortOption",
							"value": "Low"
						}
					]
				},
				"description": "This is Excercise 2 for sorting the product with Power Price."
			},
			"response": []
		},
		{
			"name": "Excercise 2:Product Sort -High",
			"request": {
				"method": "GET",
				"header": [],
				"url": {
					"raw": "https://wooliesxchallenge.azurewebsites.net/api/Product/Sort?sortOption=High",
					"protocol": "https",
					"host": [
						"wooliesxchallenge",
						"azurewebsites",
						"net"
					],
					"path": [
						"api",
						"Product",
						"Sort"
					],
					"query": [
						{
							"key": "sortOption",
							"value": "High"
						}
					]
				},
				"description": "This is excercise 2: sort the product with Higher price"
			},
			"response": []
		},
		{
			"name": "Excercise 2: Product Sort - Ascending",
			"request": {
				"method": "GET",
				"header": [],
				"url": {
					"raw": "https://wooliesxchallenge.azurewebsites.net/api/Product/Sort?sortOption=Ascending",
					"protocol": "https",
					"host": [
						"wooliesxchallenge",
						"azurewebsites",
						"net"
					],
					"path": [
						"api",
						"Product",
						"Sort"
					],
					"query": [
						{
							"key": "sortOption",
							"value": "Ascending"
						}
					]
				},
				"description": "This is excercise 2: sort the product with name in ascending order"
			},
			"response": []
		},
		{
			"name": "Excercise 2:Product Sort - Descending",
			"request": {
				"method": "GET",
				"header": [],
				"url": {
					"raw": "https://wooliesxchallenge.azurewebsites.net/api/Product/Sort?sortOption=Descending",
					"protocol": "https",
					"host": [
						"wooliesxchallenge",
						"azurewebsites",
						"net"
					],
					"path": [
						"api",
						"Product",
						"Sort"
					],
					"query": [
						{
							"key": "sortOption",
							"value": "Descending"
						}
					]
				},
				"description": "This is excercise 2: sort the product with name in descending order"
			},
			"response": []
		},
		{
			"name": "Excercise 2:Product Sort - Recommeded",
			"request": {
				"method": "GET",
				"header": [],
				"url": {
					"raw": "https://wooliesxchallenge.azurewebsites.net/api/Product/Sort?sortOption=Recommended",
					"protocol": "https",
					"host": [
						"wooliesxchallenge",
						"azurewebsites",
						"net"
					],
					"path": [
						"api",
						"Product",
						"Sort"
					],
					"query": [
						{
							"key": "sortOption",
							"value": "Recommended"
						}
					]
				},
				"description": "This is excercise 2: sort the product based on popularity in shopper history"
			},
			"response": []
		},
		{
			"name": "TrolleyTotal",
			"protocolProfileBehavior": {
				"disabledSystemHeaders": {
					"content-type": true
				}
			},
			"request": {
				"method": "POST",
				"header": [
					{
						"key": "Content-Type",
						"value": "application/json",
						"type": "text"
					}
				],
				"body": {
					"mode": "raw",
					"raw": "\t{\r\n\t  \"products\": [\r\n\t\t{\r\n\t\t  \"name\": \"milk\",\r\n\t\t  \"price\": 2\r\n\t\t},\r\n\t{\r\n\t\t  \"name\": \"tea\",\r\n\t\t  \"price\": 3\r\n\t\t}\r\n\t  ],\r\n\t  \"specials\": [\r\n\t\t{\r\n\t  \r\n\t\t  \"quantities\": [\r\n\t\t\t{\r\n\t\t\t  \"name\": \"milk\",\r\n\t\t\t  \"quantity\": 1\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t  \"name\": \"tea\",\r\n\t\t\t  \"quantity\": 2\r\n\t\t\t}\r\n\t\t  ],\r\n\t\t  \"total\": 1\r\n\t\t}\r\n\t  ],\r\n\t  \"quantities\": [\r\n\t\t{\r\n\t\t  \"name\": \"milk\",\r\n\t\t  \"quantity\": 3\r\n\t\t},\r\n\t{\r\n\t\t\t  \"name\": \"tea\",\r\n\t\t\t  \"quantity\": 8\r\n\t\t\t}\r\n\t  ]\r\n\t}"
				},
				"url": {
					"raw": "https://wooliesxchallenge.azurewebsites.net/api/TrolleyCalculator/TrolleyTotal",
					"protocol": "https",
					"host": [
						"wooliesxchallenge",
						"azurewebsites",
						"net"
					],
					"path": [
						"api",
						"TrolleyCalculator",
						"TrolleyTotal"
					]
				},
				"description": "This is excercise 3: get the minimum price of trolley total"
			},
			"response": []
		}
	],
	"protocolProfileBehavior": {}
}
