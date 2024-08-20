CREATE DATABASE UserDB;
GO

CREATE TABLE Users (
    UserID INT PRIMARY KEY,
    Username NVARCHAR(50),
    Email NVARCHAR(100),
    PasswordHash NVARCHAR(255),
    Status NVARCHAR(20),
    AddressLine1 NVARCHAR(100),
    AddressLine2 NVARCHAR(100),
    City NVARCHAR(50),
    State NVARCHAR(50),
    PostalCode NVARCHAR(20),
    CountryID INT foreign key references Countries,
    CreatedAt DATETIME
);

CREATE TABLE Countries (
    CountryID INT PRIMARY KEY,
    CountryName NVARCHAR(50)
);

INSERT INTO Countries (CountryID, CountryName) VALUES
(1, 'United States'),
(2, 'Canada'),
(3, 'United Kingdom');
