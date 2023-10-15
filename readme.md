# Online Retail Store Mangaement REST API

The Online Retail Store Management System is a .NET Core application that allows you to manage customers, orders, products, and suppliers for an online retail store.

API Documentation - https://documenter.getpostman.com/view/20871743/2s9YR6ZtXi

## Table of Contents

- [Features](#features)
- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)
- [Database Structure](#database-structure)

## Features

- **Customer Management:** Create, update, and delete customer information.
- **Order Processing:** Manage and track customer orders, including order status and order type.
- **Product Management:** Add, update, and remove products, including details such as name, price, and supplier.
- **Supplier Management:** Maintain a list of suppliers for your products.
- **Database Integration:** Utilize Microsoft SQL Server for data storage.
- **API Endpoints:** Access data through API endpoints for seamless integration with other applications.

## Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [Microsoft SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [SQL Server Management Studio (Optional)](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms)

## Getting Started

1. Clone the repository:

   ```bash
   git clone https://github.com/Benuka-Punchihewa/retail-store-management-api
   cd retail-store-management-api

2. Use the [script.sql](https://github.com/Benuka-Punchihewa/retail-store-management-api/blob/main/script.sql) to create database tables.

3. Update the connection string in RetailManagement/appsettings.json to point to your SQL Server database.

2. Run the application:

   ```bash
   dotnet build
   dotnet run --project ./RetailManagement

## Database Structure

The Online Retail Store Management System uses a SQL Server database to store information about customers, orders, products, and suppliers. Below is a detailed overview of the tables and their respective attributes.

### Customer Table

The `Customer` table stores information about customers, including their username, email, and creation date.

- `UserId`: Unique identifier for the customer.
- `Username`: Customer's username (up to 30 characters).
- `Email`: Customer's email address (up to 20 characters).
- `FirstName`: Customer's first name (up to 20 characters).
- `LastName`: Customer's last name (up to 20 characters).
- `CreatedOn`: Date and time when the customer was created.
- `IsActive`: Indicates whether the customer account is active (boolean).

### Order Table

The `Order` table tracks customer orders, including references to products, order status, and order type.

- `OrderId`: Unique identifier for the order.
- `ProductId`: Foreign key referencing the `Product` table.
- `OrderStatus`: An integer representing the order status.
- `OrderType`: An integer representing the order type.
- `OrderBy`: Foreign key referencing the `Customer` table (customer who placed the order).
- `OrderedOn`: Date and time when the order was placed.
- `ShippedOn`: Date and time when the order was shipped.
- `IsActive`: Indicates whether the order is active (boolean).

### Product Table

The `Product` table contains product information, including product name, price, and supplier details.

- `ProductId`: Unique identifier for the product.
- `ProductName`: Product name (up to 50 characters).
- `UnitPrice`: Price per unit (decimal).
- `SupplierId`: Foreign key referencing the `Supplier` table.
- `CreatedOn`: Date and time when the product was created.
- `IsActive`: Indicates whether the product is active (boolean).

### Supplier Table

The `Supplier` table stores data about suppliers, including their name and creation date.

- `SupplierId`: Unique identifier for the supplier.
- `SupplierName`: Supplier's name (up to 50 characters).
- `CreatedOn`: Date and time when the supplier was created.
- `IsActive`: Indicates whether the supplier is active (boolean).

This structured database design provides a comprehensive foundation for managing customer accounts, orders, products, and suppliers in your online retail system.

Please note that additional columns or tables may be present based on specific project requirements or enhancements.
