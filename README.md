# File Management

This Application is a Demo project to upload a document with identity. 

## Tools & Technologies
1. ASP.NET Core 3.1
2. ASP.NET Web API 5.2
3. ORM - Entity Framework Core 3.1
4. Web UI Framework - Angular 8/TypeScript
5. CSS Framework - BootStrap 4.3
6. Database - SQL Server (localDB)
7. Code Editor - Visual Studio 2019 
8. Authentication using JSON WebTokens (JWT) & ASP.NET Core Identity 

## Set-Up
1. Download the entire codebase to your local system.
2. Open the entire folder or solution file in the editor of your choice (VSCode or Visual studio)
3. Install the Nuget Packages by right clicking on the solution and selecting *Restore NuGet Packages*. 
   Also use the console to install packages using the *npm-install* command (This will run automatically on *Build* action as well).
4. This Project uses a local DB instance of SQL Server. In order to set up the connection and Database, follow the below steps
   - Open the SQL server object explorer using the View Menu. Then click on Add connection from the explorer window.
   - On the *Connect* window select *Local > MSSQLLocalDB* and then hit connect. This should display all the local databases under 
       local DB instance
   - Navigate to Tools > NugetPackageManager > PackageManagerConsole. In the console window select Default Project as *DataAccess*
   - Run the command *Update-Database*. This should create the required database tables and seed the initial data required.
   - The connection string can be changed *if required* in the *appsettings.json* file under *HomeAreaManagement* project.
5. Run the solution using ctrl + F5 to start without debugging. Make sure that *HomeAreaManagement* is selected as a default project. 
