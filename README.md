# Survey Project README
Survey Project
This project is a web-based survey application that allows users to create and manage surveys, collect responses, and analyze the data.

Features
Create and manage surveys
Collect survey responses
Analyze survey data
User authentication and authorization
API for external integrations
Daily email notifications of survey responses using Hangfire
Technologies Used


.NET 8.0
ASP.NET MVC
Entity Framework Core
Layered Architecture

Database:
PostgreSQL

Cache:
Redis

Others:

Hangfire (for background tasks)
SendGrid (for sending emails)
GitHub Actions (for CI/CD)
Getting Started
Prerequisites
.NET 8.0 SDK
PostgreSQL
Redis
Installation
Clone the repository:

bash
Kodu kopyala
git clone https://github.com/Ogulcan-Dinsever/Survey.git
cd Survey
Set up the database:

Update the connection string in appsettings.json to point to your PostgreSQL instance.

Run the migrations to create the database schema:



Update the Redis settings in appsettings.json with your Redis server details.
Configure email settings:

Update the SendGrid settings in appsettings.json with your SendGrid API key.
Run the application:

bash

dotnet run
Usage
Navigate to http://localhost:5000 in your web browser.
Register a new user or log in with an existing account.
Create a new survey by filling in the necessary details.
Share the survey link with respondents.
View and analyze the responses in the admin dashboard.
API
The project includes an API for external integrations. The API provides endpoints to:

Retrieve survey data
Submit survey responses
Get daily response counts
Example: Get Daily Response Counts
http

GET /api/surveys/daily-response-counts
Background Tasks
The project uses Hangfire to handle background tasks such as sending daily email notifications. These tasks are configured in Startup.cs and can be monitored via the Hangfire dashboard.

Contributing
Contributions are welcome! Please fork the repository and create a pull request with your changes.
