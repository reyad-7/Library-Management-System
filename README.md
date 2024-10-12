# T|R Library System

## Project Overview
**T|R Library System** is a web-based application designed to manage library operations such as book checkouts, returns, member management, and penalties for late returns.

### Technologies Used
- **Backend**: ASP.NET Core MVC, Entity Framework Core, SQL Server
- **Frontend**: HTML/CSS, JavaScript, Bootstrap

## Features
- **Book Management**: Librarians can add and manage books.
- **Member Management**: Admins can add or manage library members.
- **Checkouts**: Members can check out books, and the system tracks due dates.
- **Returns & Penalties**: Members can return books, and penalties are automatically calculated for late returns.

## Project Structure
- **Controllers**: Handles HTTP requests, routing, and interactions with services.
- **Models**: Represents the database entities and maps to database tables.
- **Repositories**: Contains data access logic, handling CRUD operations via Entity Framework.
- **Services**: Contains business logic and interacts with repositories for data retrieval/storage.
- **View Models**: Provides data structure for passing data between the controller and views.
- **Views**: Razor views responsible for rendering the user interface (UI).
- **wwwroot**: Contains static assets such as CSS, JavaScript, and images.
- **Program.cs / Startup.cs**: The main entry point and configuration setup for the application, including service and middleware configuration.

## Setup Guide

### Prerequisites
1. Install the [.NET SDK](https://dotnet.microsoft.com/download) and [Visual Studio](https://visualstudio.microsoft.com/downloads/) with the ASP.NET and web development workload.
2. Install [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (Developer or Express edition).

### Steps to Run
1. **Clone the Repository**:
    ```bash
    git clone <repository_url>
    cd TR_Library_System
    ```
2. **Install Dependencies**:
    - Open **NuGet Package Manager Console** and install required packages for Entity Framework Core:
      ```bash
      Install-Package Microsoft.EntityFrameworkCore.SqlServer
      Install-Package Microsoft.EntityFrameworkCore.Tools
      ```
3. **Edit Connection String**:
    - Open `appsettings.json` and edit the connection string if your SQL Server requires a username and password.

4. **Run Migrations**:
    - In **Package Manager Console**, run:
      ```bash
      Update-Database
      ```
5. **Run the Application**:
    - Press `F5` or use:
      ```bash
      dotnet run
      ```

## User Manual

### Login and Registration
- Users (librarians and members) can log in with their credentials.
- Administrators manage librarian accounts.

### Search for Books
- Search for books by title, author, or genre.
- Use filters for more precise searches.

### Checkout Process
- Members can select books and check them out. The system will calculate the return date.

### Returning Books
- Members can return books by selecting the checkout entry.
- Penalties are automatically applied for overdue books.

### View Checkout History
- Members can view their checkout history on their dashboard.
- Admins can view and manage all checkouts.

### Penalties
- Penalties are automatically calculated for late returns and are visible in members’ accounts.

---
### Contributers
[Tawfik Mohamed Khalil](https://github.com/TawfikMohamed040)
[Mohamed Ahmed Reyad](https://github.com/reyad-7)

For more details on how to contribute or further extend the system, please refer to the **Documentation** folder.
