# antapp

PSiM - projekt (Project for PSiM course)

This is a web application built with ASP.NET Core.

## Modules

The application is divided into several modules:

*   **antapp**: The main web application project. ([antapp/](antapp/))
*   **antapp.LeaderBoard**: Manages the leaderboard functionality. ([antapp.LeaderBoard/](antapp.LeaderBoard/))
*   **antapp.Shared**: Contains shared code and utilities, including authentication and migrations. ([antapp.Shared/](antapp.Shared/))
*   **antapp.UserMenu**: Handles user-specific menus and features. ([antapp.UserMenu/](antapp.UserMenu/))
*   **Chat**: Implements chat functionality. ([Chat/](Chat/))
*   **GameMap**: Manages the game map features. ([GameMap/](GameMap/))
*   **LoginService**: Handles user login and authentication services. ([LoginService/](LoginService/))

## Technologies

*   C#
*   ASP.NET Core
*   Entity Framework Core (implied by Migrations and DbContext usage)

## Setup

1.  Clone the repository.
2.  Open the solution file `antapp.sln` in Visual Studio.
3.  Ensure the database connection string in `appsettings.json` (or equivalent configuration) is correctly set up for your environment. The connection string name appears to be "db" as seen in [`antapp.Shared.SharedModule.AddSharedModule`](antapp.Shared/SharedModule.cs) and [`Program.cs`](antapp/Program.cs).
4.  Build the solution.
5.  Run the `antapp` project.

## Building the Project

You can build the project using the .NET CLI:

sh
dotnet build antapp.sln


Or by building the solution in Visual Studio.
