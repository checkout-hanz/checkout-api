# checkout api

clone all the repositories
 - merchant-management
 - checkout-api
 - payment-gateway
 - acquiring-bank
 - transaction-projection

1. run RabbitMq locally
  "docker run -d --hostname localhost --name some-rabbit -p 15672:15672 -p 5672:5672 rabbitmq:3-management"
  
2. run all the solutions using their default launchSettings profile

locally solution should run on following ports
  merchant-management 		- "https://localhost:7029;http://localhost:5029"
  payment-gateway 	  		- "https://localhost:7028;http://localhost:5028"
  checkout-api		  		- "https://localhost:7020;http://localhost:5020"
  acquiring-bank	  		- "https://localhost:7027;http://localhost:5027"
  transaction-projection	- "https://localhost:7026;http://localhost:5026"
  
All the api docs is in swagger.  
  
Architecture:

