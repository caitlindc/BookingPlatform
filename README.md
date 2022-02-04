BOOKING PLATFORM

Requirements:
- User should be able to see the list of rooms.
- User should be able to book rooms.

Validation:
 - User should not be able to book dates for a room that have already been booked for that dates.
 - Number of people in a booking should fit in the room capacity.
 - Date from should be greater than current date.
 - Date to should be greater than date from.

Overview:
Booking Platform is a Web API project that lets the user see list of available rooms and book rooms. It focuses on the backend with an API as the front end.
There are 2 endpoints, one for getting the list of rooms and one for booking.
Swagger is used for the documentation of the API.

Data Storage:
For the data storage, PostgreSQL is used.


 Project Architecture

 The architecture used for the solution is CLEAN ARCHITECTURE.
 The solution is consists of 4 projects:
 DOMAIN - contains all the entities that represents database tables

