CREATE DATABASE Sock_Selling
GO

USE Sock_Selling
GO

CREATE TABLE Persons
(
    Id INT PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL,
    Role NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    Phone NVARCHAR(15),
    Status NVARCHAR(20) NOT NULL
);

CREATE TABLE Accounts
(
    Id INT PRIMARY KEY,
    PersonId INT,
    Username NVARCHAR(50) NOT NULL,
    Password NVARCHAR(100) NOT NULL,
    Status NVARCHAR(20) NOT NULL,
    FOREIGN KEY (PersonId) REFERENCES Persons(Id)
);

CREATE TABLE Payments
(
    Id INT PRIMARY KEY,
    Name NVARCHAR(50),
    Description NVARCHAR(500),
    AccountId INT,
    FOREIGN KEY (AccountId) REFERENCES Accounts(Id)
);

CREATE TABLE Orders
(
    Id INT PRIMARY KEY,
    Address NVARCHAR(100) NOT NULL,
    CreatedAt DATETIME NOT NULL,
    AccountId INT,
    FOREIGN KEY (AccountId) REFERENCES Accounts(Id)
);

CREATE TABLE Categories
(
    Id INT PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL,
    Description NVARCHAR(255),
    Status NVARCHAR(20) NOT NULL
);

CREATE TABLE Products
(
    Id INT PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Inventory INT NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    Color NVARCHAR(50),
    Design NVARCHAR(255),
    Highlight BIT NOT NULL,
    Description NVARCHAR(255),
    CategoryId INT,
    Status NVARCHAR(20) NOT NULL,
    FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
);

CREATE TABLE ProductImages
(
    Id INT PRIMARY KEY,
    ProductId INT,
    Image IMAGE,
    Description NVARCHAR(255),
    IsPrimary BIT,
    CreatedAt DATETIME,
    CONSTRAINT FK_ProductImages_ProductId FOREIGN KEY (ProductId) REFERENCES Products(Id)
);

CREATE TABLE Sizes
(
    Id INT PRIMARY KEY,
    Size INT NOT NULL,
    Status NVARCHAR(20) NOT NULL
);

CREATE TABLE Product_Size
(
    Id INT PRIMARY KEY,
    ProductId INT,
    SizeId INT,
    FOREIGN KEY (ProductId) REFERENCES Products(Id),
    FOREIGN KEY (SizeId) REFERENCES Sizes(Id)
);

CREATE TABLE Category_Product
(
    Id INT PRIMARY KEY,
    CategoryId INT,
    ProductId INT,
    FOREIGN KEY (CategoryId) REFERENCES Categories(Id),
    FOREIGN KEY (ProductId) REFERENCES Products(Id)
);

CREATE TABLE SaleOffs
(
    Id INT PRIMARY KEY,
    Description NVARCHAR(255),
    StartDate DATETIME NOT NULL,
    EndDate DATETIME NOT NULL,
    Discount DECIMAL(5, 2) NOT NULL,
    ProductId INT,
    FOREIGN KEY (ProductId) REFERENCES Products(Id)
);

CREATE TABLE OrderDetails
(
	Id INT PRIMARY KEY,
	OrderId INT,
	ProductId INT,
	Quantity INT,
	Price MONEY,
	Status VARCHAR(20)
	FOREIGN KEY (ProductId) REFERENCES Products(Id),
	FOREIGN KEY (OrderId) REFERENCES Orders(Id),
)


-- Chèn dữ liệu vào bảng Person
INSERT INTO Persons (Id, Name, Email, Phone, Role, Status)
VALUES 
    (1, 'Nguyen Van A', 'nguyenvana@example.com', '123456789', 'user', 'active'),
    (2, 'Tran Thi B', 'tranthib@example.com', '987654321', 'user', 'active'),
    (3, 'Le Van C', 'levanc@example.com', '456789123', 'user', 'inactive'),
    (4, 'Pham Thi D', 'phamthid@example.com', '741852963', 'admin', 'active');

-- Chèn dữ liệu vào bảng Accounts
INSERT INTO Accounts (Id, PersonId, Username, Password, Status)
VALUES 
    (101, 1, 'nguyenvana', 'password123', 'active'),
    (102, 2, 'tranthib', 'password456', 'active'),
    (103, 3, 'levanc', 'password789', 'inactive'),
    (104, 4, 'phamthid', 'passwordadmin', 'active');

-- Dữ liệu cho bảng Payments
INSERT INTO Payments (Id, Name, Description, AccountId)
VALUES (1, 'Payment Method 1', 'Description of Payment Method 1', 101);

-- Dữ liệu cho bảng Orders
INSERT INTO Orders (Id, Address, CreatedAt, AccountId)
VALUES (1, '123 Street, City', GETDATE(), 101);

-- Dữ liệu cho bảng Categories
INSERT INTO Categories (Id, Name, Description, Status)
VALUES (1, 'Category 1', 'Description of Category 1', 'active');

-- Dữ liệu cho bảng Products
INSERT INTO Products (Id, Name, Inventory, Price, Color, Design, Highlight, Description, CategoryId, Status)
VALUES 
(1, 'Product 1', 100, 10.00, 'Red', 'Design 1', 0, 'Description of Product 1', 1, 'active'),
(2, 'Product 2', 100, 10.00, 'Red', 'Design 1', 0, 'Description of Product 1', 1, 'active');

-- Dữ liệu cho bảng Sizes
INSERT INTO Sizes (Id, Size, Status)
VALUES (1, 10, 'active');

-- Dữ liệu cho bảng Product_Size
INSERT INTO Product_Size (Id, ProductId, SizeId)
VALUES (1, 1, 1);

-- Dữ liệu cho bảng Category_Product
INSERT INTO Category_Product (Id, CategoryId, ProductId)
VALUES (1, 1, 1);

-- Dữ liệu cho bảng SaleOff
INSERT INTO SaleOffs (Id, Description, StartDate, EndDate, Discount, ProductId)
VALUES (1, 'Sale 1', GETDATE(), DATEADD(DAY, 7, GETDATE()), 0.10, 1);

-- Dữ liệu cho bảng OrderDetail
INSERT INTO OrderDetails (Id, OrderId, ProductId, Quantity, Price, Status)
VALUES (1, 1, 1, 2, 20.00, 'active');

-- Dữ liệu cho bảng ProductImages
INSERT INTO ProductImages (Id, ProductId, Image, Description, IsPrimary, CreatedAt)
VALUES 
(1, 1, '/images/product1.jpg', 'Front view of Product 1', 1, GETDATE()),
(2, 1, '/images/product1-back.jpg', 'Back view of Product 1', 0, GETDATE()),
(3, 2, '/images/product2.jpg', 'Product 2 in action', 1, GETDATE()),
(4, 2, '/images/product2-side.jpg', 'Side view of Product 2', 0, GETDATE());










EXEC sp_configure;


EXEC sp_configure 'show advanced options', 1;
RECONFIGURE;
EXEC sp_configure 'user instances enabled';

EXEC sp_configure 'user instances enabled', 2;
RECONFIGURE;