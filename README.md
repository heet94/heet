# Library Management System

A web-based application built using *ASP.NET Core MVC* and *Entity Framework Core* that helps libraries manage books, members, and borrowing records efficiently.

---

## Table of Contents

- [Overview](#overview)  
- [Project Structure](#project-structure)  
- [Features](#features)  
- [Technology Stack](#technology-stack)  
- [Getting Started](#getting-started)  
- [Models Overview](#models-overview)  
- [Controllers Overview](#controllers-overview)  
- [Views Overview](#views-overview)  
- [Future Enhancements](#future-enhancements)  
- [Contributing](#contributing)  
- [License](#license)  
- [Authors & Credits](#authors--credits)  

---

## Overview

The Library Management System is a CRUD-based web application that allows:

- Adding, editing, and deleting *books*  
- Registering and managing *library members*  
- Recording *borrowing and returning* of books  
- Tracking which member has borrowed which book and when it’s due for return

It demonstrates *ASP.NET Core MVC architecture, **Entity Framework Core, and **basic library management operations*.

---

## Project Structure

LibraryManagementSystem/
│
├── Controllers/
│ ├── BooksController.cs
│ ├── MembersController.cs
│ ├── BorrowController.cs
│
├── Models/
│ ├── Book.cs
│ ├── Member.cs
│ ├── BorrowRecord.cs
│
├── Data/
│ ├── LibraryContext.cs
│
├── Views/
│ ├── Books/
│ ├── Members/
│ ├── Borrow/
│
├── wwwroot/
│ ├── css/
│ ├── js/
│
└── README.md

## Features

- 📚 *Books Management* – Add, edit, delete, and view books  
- 👥 *Members Management* – Register and manage members  
- 🔄 *Borrow/Return System* – Record borrowing and returning operations  
- 📅 *Due Tracking* – View borrowed books and due dates  
- 🔍 *Search and Filter* – Search books by title, author, or ISBN  
- 🧾 *Reports* – View borrowing history and member activity  

---

## Technology Stack

| Component | Technology |
|-----------|------------|
| Framework | ASP.NET Core MVC 8.0 |
| Language  | C# |
| Database  | SQL Server / SQLite |
| ORM       | Entity Framework Core |
| Frontend  | HTML5, CSS3, Bootstrap, Razor Views |
| IDE       | Visual Studio / VS Code |

---

## Getting Started


1. Configure the Database

Open appsettings.json

Update the connection string:

"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=LibraryDB;Trusted_Connection=True;MultipleActiveResultSets=true"
}

2. Apply Migrations
dotnet ef database update

3. Run the Project
dotnet run


or simply press F5 in Visual Studio.

4. Access the Application

Open your browser and go to:
👉 https://localhost:5001/

### 1. Clone the Repository
```bash


