USE Retail_store_db;

-- Database definition start
CREATE TABLE Customers (
    UserId UNIQUEIDENTIFIER PRIMARY KEY,
    Username VARCHAR(30),
    Email VARCHAR(20),
    FirstName VARCHAR(20),
    LastName VARCHAR(20),
    CreatedOn DATETIME,
    IsActive BIT
);

CREATE TABLE Suppliers (
    SupplierId UNIQUEIDENTIFIER PRIMARY KEY,
    SupplierName VARCHAR(50),
    CreatedOn DATETIME,
    IsActive BIT
);

CREATE TABLE Products (
    ProductId UNIQUEIDENTIFIER PRIMARY KEY,
    ProductName VARCHAR(50),
    UnitPrice DECIMAL(10, 2),
    SupplierId UNIQUEIDENTIFIER,
    CreatedOn DATETIME,
    IsActive BIT,
    FOREIGN KEY (SupplierId) REFERENCES Suppliers(SupplierId)
);

CREATE TABLE Orders (
    OrderId UNIQUEIDENTIFIER PRIMARY KEY,
    ProductId UNIQUEIDENTIFIER,
    OrderStatus TINYINT,
    OrderType TINYINT,
    OrderBy UNIQUEIDENTIFIER,
    OrderedOn DATETIME,
    ShippedOn DATETIME,
    IsActive BIT,
    FOREIGN KEY (ProductId) REFERENCES Products(ProductId),
    FOREIGN KEY (OrderBy) REFERENCES Customers(UserId)
);
-- Database definition end

-- Customers population start
INSERT INTO Customers (UserId, Username, Email, FirstName, LastName, CreatedOn, IsActive)
VALUES ('0c2c5b22-b9ea-45ba-bdfc-d39c4c61051a', 'john123', 'john123@gmail.com', 'John', 'Doe', GETDATE(), 1);
-- Customers population end

-- Suppliers population start
INSERT INTO Suppliers (SupplierId, SupplierName, CreatedOn, IsActive)
VALUES ('48b65b27-1bc5-4046-82ac-9f73d984d23d', 'ABC Suppliers', GETDATE(), 1);

INSERT INTO Suppliers (SupplierId, SupplierName, CreatedOn, IsActive)
VALUES ('66a67f17-c7ef-47b2-9ef3-b4ba8d6f1c9d', 'XYZ Suppliers', GETDATE(), 1);
-- Suppliers population end

-- Products population start
INSERT INTO Products (ProductId, ProductName, UnitPrice, SupplierId, CreatedOn, IsActive)
VALUES ('a793c50b-72c2-4843-83c1-950aa45d33b4', 'Dell Inspiron 7400', 999.99, '48b65b27-1bc5-4046-82ac-9f73d984d23d', GETDATE(), 1);

INSERT INTO Products (ProductId, ProductName, UnitPrice, SupplierId, CreatedOn, IsActive)
VALUES ('1cdbef37-368e-4fef-94a0-c7725e4afd43', 'Redmi Note 11', 499.99, '48b65b27-1bc5-4046-82ac-9f73d984d23d', GETDATE(), 1);

INSERT INTO Products (ProductId, ProductName, UnitPrice, SupplierId, CreatedOn, IsActive)
VALUES ('729510e7-f390-4ecd-97fe-89cf12bbb626', 'Logitech G403 Carbon', 199.99, '66a67f17-c7ef-47b2-9ef3-b4ba8d6f1c9d', GETDATE(), 1);

INSERT INTO Products (ProductId, ProductName, UnitPrice, SupplierId, CreatedOn, IsActive)
VALUES ('1214c939-d826-4e39-adca-966aafde0d8b', 'Logitech G502 Mouse', 149.99, '66a67f17-c7ef-47b2-9ef3-b4ba8d6f1c9d', GETDATE(), 1);
-- Products population end

-- Orders population start
INSERT INTO Orders (OrderId, ProductId, OrderStatus, OrderType, OrderBy, OrderedOn, ShippedOn, IsActive)
VALUES ('e9175c7d-8802-46a9-a48c-4df91290d875', 'a793c50b-72c2-4843-83c1-950aa45d33b4', 1, 1, '0c2c5b22-b9ea-45ba-bdfc-d39c4c61051a', GETDATE(), GETDATE(), 1);

INSERT INTO Orders (OrderId, ProductId, OrderStatus, OrderType, OrderBy, OrderedOn, ShippedOn, IsActive)
VALUES ('eb594703-b305-481e-85b8-04cb0e743097', '1cdbef37-368e-4fef-94a0-c7725e4afd43', 1, 1, '0c2c5b22-b9ea-45ba-bdfc-d39c4c61051a', GETDATE(), GETDATE(), 1);

INSERT INTO Orders (OrderId, ProductId, OrderStatus, OrderType, OrderBy, OrderedOn, ShippedOn, IsActive)
VALUES ('df27321b-1abe-4cb4-bd74-fbed5e462720', '729510e7-f390-4ecd-97fe-89cf12bbb626', 1, 1, '0c2c5b22-b9ea-45ba-bdfc-d39c4c61051a', GETDATE(), GETDATE(), 1);

INSERT INTO Orders (OrderId, ProductId, OrderStatus, OrderType, OrderBy, OrderedOn, ShippedOn, IsActive)
VALUES ('3e376c54-1248-41cf-a371-63b30bf63cba', '1214c939-d826-4e39-adca-966aafde0d8b', 1, 1, '0c2c5b22-b9ea-45ba-bdfc-d39c4c61051a', GETDATE(), GETDATE(), 1);
-- Orders population end