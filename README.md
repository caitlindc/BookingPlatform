BOOKING PLATFORM

Requirements:
- User should be able to see the list of rooms.
- User should be able to book rooms.

Validation:
 - User should not be able to book dates for a room that have already been booked for that dates.
 - Number of people in a booking should not be greater than the room capacity.
 - Date from should be greater than current date.
 - Date to should be greater than date from.
 - The room id should be existing.

Overview:
Booking Platform is a Web API project that lets the user see list of available rooms and book rooms. It focuses on the backend with an API as the front end.
There are 2 endpoints, one for getting the list of rooms and one for booking.
Swagger is used for the documentation of the API.

Users:
Since there's no requirement, I didn't prioritize adding a user logging feature. Anyone can use the api without authorization.

Endpoints:
1. GET api/rooms
    - get the list of rooms

2. POST api/bookings
    - books a room

Data Storage:
For the data storage, PostgreSQL is used with EF Core using Database-First Approach.

Database Migration:
For database migration, follow these steps:
- See the appsettings.json in the API project and update the connection to you database server.
- Set the API project as the start up project.
- Open package manager console and set the Infrastructure project as the default project.
- Run command: update-database

 PROJECT ARCHITECTURE

 The architecture used for the solution is CLEAN ARCHITECTURE.

 The application consists of 4 projects:

 DOMAIN
 - Contains all the entities that represents database tables. These should not depend on any other project in the solution.

 APPLICATION
 - Contains the business logic, validation and mapping. These should not have other project dependency other that the the Domain project.
 - Contains all the interfaces that could be implemented by the other layers such as the db context interface.
 - Command Query Responsibility Segregation (CQRS) pattern is used in this project using MediatR library. Each query and commanad has their own folder that contains dtos and validation for that query/command.
 - Fluent Validation library is used for the request validation.
 - AutoMapper is used for mapping from entity to response model.

 INFRASTRUCTURE
 - Dependent on the Application Layer.
 - Deals with external systems.
 - Implements the database context.

 WEB API
 - Provides an interface for the functionalities that other application can use using http protocol.

 The reason I chose to use Clean Architecture mainly because it is independent of UI and database. You could use any UI and any database system without changing anything in the Domain and Application projects, the UI could just reference the Application and since the implementation of the interfaces is in the Infrastructure layer, you only need to update the infrastructure layer when you want to change the database system.

 As for the CQRS pattern, some reasons why I used it are:

 - Since the queries and commands are separate it is easy to maintain bec. if there's any change in the use case it will only affect one query/command you don't have to worry it if it will affect other business logic.
 - It's simple(query for reading and coomand for writing) and readable.


TESTING
The project includes a unit for the application project which has the business logic for the application. Other than the GET and POST tests, it also includes test for all the validation.

TECHNOLOGIES USED:
- C# (10 years experience)
- ASP.NET Core (2 years experience)
- Entity Framework Core (6 months experience,  For Entity Framework (7 years experience))
- MediatR (6 months experience)
- Automapper (5 years experience)
- Fluent Validation (6 months experience)
- Dependency Injection (2 years experience)
- PostgreSQL (6 months experience)


If given more time, I would like to add these features:
- Logging
- User Management
- Improving the Swagger Documentation (Could have other endpoint details useful for users such as possible errors and description)
- Blazor UI project that could use the API





