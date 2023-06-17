# OnlineShop

This is the backend for a small app called online shop.

#The Arch is as follows:
The solution consists of three projects:
1. OnlineSystem.Api 
 This contains the APIs that the frontend will interact with.
2. OnlineSystem.Core
 This contains the core services and entities and everything related to the business logic.
3. OnlineSystem.Data
 This contains the implementation of the data access repos.

#Database schema:

1. Products table with columns (id, name, nameAr, description, price, HasAvailableStock, ImageUrl)
2. Categories table with columns (id, name, createdDate, parentCategoryId)
3. CategoryProduct relation table that links between product and category as many to many relationship.


#The implemented features are as follows:
1. an API for get the products with the categories information, sorted by product English name and it has pagination.
2. an API to add new product with all its data.
3. an API to remove existing product.
4. an API to signin existing user. (because of the shortage of time I used a mocking use data here in this API in the identity service)
   I used here JWT token as authentication schema and the endpoint will validate the data and return the token.
5. Added authentication and authorization to the products Api using authorize header which will make only the users with admin role
   to create or delete products. (NOTE: THIS COMMENTED BECAUSE AUTHENTICATION IS NOT COMPLETE FROM FE YET)

#To run the project
1. clone the repo.
2. Navigate to folder "OnlineSystem.Api".
3. Run "dotnet ef database update --project ..\OnlineSystem.Data\" to create the database with the tables
4. Run the API project.
 
