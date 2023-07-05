
# Project Title

Big Purple Bank 

A simple implementation of a GET API to get a list of banking products for an imaginary Bank.

Below are the details of different technical and developemnt aspects that I have attempted to detail in to the shared solution.

## Repository Details 

Folder **BigPurpleBankARMTemplates** has ARM templates used to create infrastructure on Azure cloud. 

Folder **BigPurpleBankAPIs** has API application code

## API Project Details

Clone the repo

Open the solution in Visual Studio 19 and above. Set project ConsumerDataStandards.API in the solution as Start up project. Build the solution and run the API project. 

Swagger UI will then be accessible at https://localhost:7010/swagger/index.html


## Core Technologies

1. Framework: .NET 6.0
2. Language: C# 
3. Database: Azure SQL
## API Reference

#### Get all Products

``` https
  GET /api/products
```
```
https://consumerdatastandardsaustralia.github.io/standards/#get products
```

| Parameter   | Type     | Description                             |
| :--------   | :------- | :-------------------------              |
| `UpdatedSince` | `datetime` | **Optional** |
| `effective` | `string` | **Optional**. Values: ALL, CURRENT, FUTURE             |
| `brand`    |  `string` | **Optional** |
| `ProductCategory` | `string` | **Optional**   |
|`Page`|`Int`| **Optional** Defaults to 1 if not provided|
|`PageSize`|`Int`| **Optional** Defaults to 10 if not provided|




## Authors

- [@prashanthkmbhat](https://www.github.com/prashanthkmbhat)

