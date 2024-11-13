Stock Management System - README
Project Overview
This Stock Management System is a desktop application designed to streamline the management of inventory, clients, and orders for NewFlex, a foam company. The system is developed using C#, Windows Forms, and SQL Server. It automates various stock management tasks, providing easy access to essential data such as products, categories, clients, and orders.

Features
User Authentication: Secure login system for administrators to manage access to the application.
Client Management: Add, modify, delete, and search for client information.
Product Management: Add, modify, delete, search for products, and manage categories.
Order Management: Create and manage customer orders, linking products with clients and tracking order status.
Invoice Printing: Print product or category invoices.
Excel Export: Export product or client data to Excel for reporting purposes.
Technologies Used
C#: Programming language used for building the application logic.
Windows Forms: User interface framework used to design the desktop application.
SQL Server: Database used to store information about products, categories, clients, and orders.
Entity Framework: ORM (Object-Relational Mapping) tool used for database interactions.
Visual Studio: IDE used for application development.
System Requirements
Operating System: Windows 10 or higher.
.NET Framework: Version 4.8 or higher.
SQL Server: Any version of SQL Server, or SQL Server Express (local database support).
Visual Studio: (optional) for editing and compiling the application.
Installation Instructions
Clone the repository:
bash
Copy code
git clone https://github.com/medAminekhaddi/stock-management-system.git
Open the project in Visual Studio.
Set up the SQL Server database:
Create a new database and import the provided schema.
Configure the database connection string in the appsettings.json file.
Build the solution:
In Visual Studio, go to Build > Build Solution to compile the project.
Run the application:
Press F5 or select Debug > Start Debugging to launch the application.
Usage
Login: Use the credentials provided by the system administrator.
Manage Clients: Add, edit, and delete clients from the client section.
Manage Products: Add, edit, and delete products, or search by category.
Manage Orders: Create orders by selecting clients and products, then confirming the order.
Export Data: Use the Export to Excel feature to save client and product data in Excel format.
File Structure
StockManagementSystem/
bin/: Compiled binaries (do not commit to version control).
obj/: Intermediate build files (do not commit to version control).
AppData/: Database files and configuration.
StockManagementSystem.sln: Visual Studio solution file.
appsettings.json: Configuration file for database connections.
License
This project is licensed under the MIT License - see the LICENSE file for details.