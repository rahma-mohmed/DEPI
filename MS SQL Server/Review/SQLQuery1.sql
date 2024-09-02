create database Review

use Review;

-- Create Orders table
CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    OrderDate DATE,
    CustomerID INT,
    OrderAmount DECIMAL(10, 2)
);

-- Insert sample data into Orders table
INSERT INTO Orders (OrderID, OrderDate, CustomerID, OrderAmount) VALUES
(1, '2024-01-05', 101, 50.00),
(2, '2024-01-15', 102, 150.00),
(3, '2024-02-20', 103, 600.00),
(4, '2024-03-01', 104, 250.00),
(5, '2024-03-15', 105, 80.00),
(6, '2024-04-01', NULL, 120.00);

-- Create Customers table
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    CustomerName VARCHAR(100)
);

-- Insert sample data into Customers table
INSERT INTO Customers (CustomerID, CustomerName) VALUES
(101, 'Alice Smith'),
(102, 'Bob Johnson'),
(103, 'Carol Davis'),
(104, 'David Brown'),
(105, 'Eva White');


select o.orderId , o.orderDate , c.CustomerName, case
	when o.OrderAmount < 100 then 'Low Value'
	when o.OrderAmount between 100 and 500 then 'Medium value'
	when o.OrderAmount > 500 then 'High Vakue'
	else 'UnKnown'
	end
from Orders As o LEFT OUTER JOIN Customers AS c ON o.CustomerID = c.CustomerID

select o.orderId , o.orderDate , c.CustomerName
from Orders As o LEFT OUTER JOIN Customers AS c ON o.CustomerID = c.CustomerID
where c.CustomerName is Null


