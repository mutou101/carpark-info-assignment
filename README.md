# Carpark-Info
## carpark-info-assignment Back-end development documentation 


### Development tools and development environments 

Just start the project and run it, and he will create the SQLite database and tables locally. 

The Local paths C:\Users\Administrator\AppData\Local\carpark-info-assignment.db

Used Visual Studio 2022 tool. And the technology stack used AspNetCore 6.0, EntityFrameworkCore 8.0, AspNetCore.OpenApi 8.0, Sqlite, CsvHelper. 

### Realized User Stories 
 
The api/carpark/getAll get all the data by pagination. 

The api/carpark/getByQuery can meet the needs of the first user story. 
 
The api/carpark/addCarpark can add a carpark to database. 

The api/carpark/addBatchesByUpload can store data in CSV files to the database in batches. 

The api/carpark/addMyFavourite can add a specific carpark as my favourite. 

The api/myFavourite/created can created a user data.

The api/myFavourite/getByName can search for your favorite carparks by inputting your user name.

## Your Task
1. Given the CSV dataset (hdb-carpark-information-<timestamp>.csv) that contains details of a list of carparks, design the database to store the given information in the dataset and to support the below given user stories. ER diagram should be provided.
2. Write a batch job that will process and store the information into the database of your choice. This is a daily delta file that will be interfaced over from source. In the event there is an error processing the records in the file, the entire file should rollback.
3. Write the APIs that will fulfill the below given user stories. Swagger documentation should be provided. No front-end screens are required to be developed - just the APIs. However, you should be prepared to articulate how the APIs are envisoned to be utilised by the front-end developer. :)

### User Stories 

As a user, I want to be able to filter the list of carpark by the following criteria: 

Carpark that offer free parking 

Carpark that offer night parking 

Carpark that can meet my vehicle height requirement. 

As a user, I want to be able to add a specific carpark as my favourite. 
