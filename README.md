# SecurePrivacy.ai .NET Challenge


## Description for Task 1
Develop a small .NET/C# web application with a basic Angular front-end, integrating
MongoDB, and considering GDPR compliance aspects.

## Requirements
You must have *docker* installed on your operating system (Linux, Windows or Mac).  

# Steps to run the application

### Run the command:
- ` docker-compose -f ./Backend/SecurePrivacy/docker-compose.yml up --build` 

### After, access http://localhost:4200 into a web-browser and start to using the **System**.


# Features included

- Cookie Consent: The application requests consent for the use of cookies.
- CRUD for Product: Interface to create, read, update, and delete products.
- Test Button: Access Task 2 through the test button.

## Description for Task 2
Write a C# function to evaluate binary strings based on specific criteria.

## Evaluation Criteria for Task 2
The function accepts a binary string as input and checks if it is 'good' based on the following criteria:

Equal number of 0's and 1's.
For every prefix, the number of 1's is not less than the number of 0's.

## Requirements
You must *.net 8* installed on your operating system:

# Steps to to run the tests
To run the tests for Task 2:

### Run the command:
1. Navigate to the directory:
- `cd Backend\SecurePrivacy\Test`
2. Run the tests with:
- `dotnet test`

Alternatively, you can use Swagger (if you started Task 1 earlier):

● Access http://localhost:8081/swagger/index.html and make calls to the API.

● Use directly the frontend in the test Binary button.