# SecurePrivacy.ai .NET Challenge


## Description for Task 1
Develop a small .NET/C# web application with a basic Angular front-end, integrating
MongoDB, and considering GDPR compliance aspects.

## Requirements
You must have *docker* installed on your operating system (Linux, Windows or Mac).  

# Steps to run the application

### Run the command:
- ` docker-compose -f ./Backend/docker-compose.yml up --build` 

### After, access http://localhost:4200 into a web-browser and start to using the **System**.


# Features included

- Cookies consent
- Grud for a product
- Test button to task2

## Description for Task 2
Write a C# function to evaluate binary strings based on specific criteria

## Description
 1. Thefunction accepts a binary string as input.
 2. Check if the binary string is 'good' based on these conditions:
   ● Equalnumberof0's and 1's.
   ● Forevery prefix, the number of 1's is not less than the number of 0's.

## Requirements
You must *.net 8* installed on your operating system

### Run the command for .net8:
- `cd Backend\SecurePrivacy\Test`
- `dotnet test`

Or you can using the swagger 
http://localhost:8081/swagger/index.html
and call the binary post

Or you can use directly the frontend in the test Binary button.