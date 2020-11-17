# Flyon

This is .NET Core 3.1 project that is patterned on the REST architectural style and contains simplified functionality of travel agency WEB application.

The project was created in N-Tier Architecture. 
Presentation Tier is the closest to the user and contains controllers, view models, mappers and data validation.

Logic Tier is responsible for the data flow between Presentation and Data tiers. It can be also used to connect with external services.

Data Tier is responsible for connection with database and handle its requests and responses.

There are also appended simple unit tests by using XUnit. 
