APIs :
1- Company API
  EndPoints:
  - InsertCompany[post]
  - GetAllCompanies[Get]
2- EndPoints API
  EndPoints:
  - InsertRegisteration[post]
  - GetCompanyRegisterations [Get]
  - GetTotalQuantitySumOfRegistrations [Get]

API Calling 

1.	Company API:  To Create new company and get companies from DB
 (Not require but to make it easier for myself)
I.	create New Company 
( send Json Body contain Company Name and the Return will be the model after Creation)
Request Path: server /api/Company (HttpReqest [post])
          Request:
{
  "name": "string"
}
}
Output:
    {
  "statusCode": 200,
  "data": {
    "id": "e04d369b-bdf9-4fc8-7737-08da05920e6a",
    "name": "string",
    "sendingRegistrations": null,
    "receivingRegistrations": null
  	}
    }
II.	Get All Companies from database
(Send empty Json Body and the Return will be List of Companies details)
Request Path: server /api/Company (HttpReqest [Get])
(Send Json Body contain Company Name and the Return will be the model after Creation)
          Request:
Output:    
  {
   		 "id": "e04d369b-bdf9-4fc8-7737-08da05920e6a",
    "name": "string",
  		  "sendingRegistrations": null,
 		   "receivingRegistrations": null
  },

2.	EndPoints API: Task End Points
I.	create a new registration
( send Json Body contain registration details and the Return will be the model after Creation)
Request Path: /api/EndPoints (HttpReqest [post])
          Request:
{
  "sendingCompanyID": "eaf5f253-b1fc-4a84-ad0f-c4ffebc5d9f3",
  "receivingCompanyID": "e91e5070-9cd4-4849-a159-cf69fafdcc2d",
  "quantity": 5
} 
Output:
    {
  	"statusCode": 200,
  	"data": {
   		 "id": "ca24d52f-9903-4c1b-aff4-08da0595e098",
   		 "sendingCompanyID": "eaf5f253-b1fc-4a84-ad0f-c4ffebc5d9f3",
    		"receivingCompanyID": "e91e5070-9cd4-4849-a159-cf69fafdcc2d",
   		 "quantity": 5,
  		  "createdAt": "2022-03-14T08:37:30.2698825Z",
  		  "sendingCompany": null,
    		"receivingCompany": null
  		}
}
II.	 retrieving all registrations for a specific company (Sending or Receiving). 
  (Send company ID in header and the Return will be the model after Creation)
Request Path: /api/EndPoints/companyID (HttpReqest [Get])
          Request: company ID in header (/api/EndPoints/companyID)
Output:
  	"[
 	     {
  	        "id": "6f9317a0-4f78-4245-8835-884bdba449b5",
 	         "name": "Crocobite4",
  	          "sendingRegistrations": [
 {
       		     "id": "dff972cd-6eeb-447c-affc-08da0595e098",
    		    "sendingCompanyID": "6f9317a0-4f78-4245-8835-884bdba449b5",
       		    "receivingCompanyID": "eaf5f253-b1fc-4a84-ad0f-c4ffebc5d9f3",
                      "quantity": 5,
    		    "createdAt": "2022-03-14T08:46:30.7231078",
    		    "receivingCompany": null
  	 	   }
 	   	],
   	 "receivingRegistrations": [
        	      {
   	           "id": "ed1876f7-a366-4282-affd-08da0595e098",
     	          "sendingCompanyID": "fd6e2349-7965-45bd-7738-08da05920e6a",
           	          "receivingCompanyID": "6f9317a0-4f78-4245-8835-884bdba449b5",
 	          "quantity": 5,
    	          "createdAt": "2022-03-14T08:46:35.8768311",
    	         "sendingCompany": null
   	    }
 	   ]
 	 }
] 
III.	returns the total Quantity sum of registrations for a specific company. 
(Sending or receiving). 
  (Send company ID and the Return will be the model after Creation)
Request Path: /api/EndPoints/SumOfQuantities (HttpReqest [Get])
          Request: company ID
Output:
[
  {
    "id": "6f9317a0-4f78-4245-8835-884bdba449b5",
    "name": "Crocobite4",
    "totalSumOfQuantities": 10,
    "sumOfSendingQuantity": 5,
    "sumOfReceivingQuantity": 5
  }
]




