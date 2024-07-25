use Online_Marketplace_DB
go

create table Users (
    UserID int primary key,
    Username nvarchar(255) NOT NULL,
    Email nvarchar(255) NOT NULL UNIQUE,
    PasswordHash nvarchar(255) NOT NULL,
    Status nvarchar(50) NOT NULL check(Status in ('Active', 'Terminated', 'Inactive')),
    AddressLine1 nvarchar(255),
    AddressLine2 nvarchar(255),
    City nvarchar(255),
    State nvarchar(255),
    PostalCode nvarchar(20),
    CountryID int,
    CreatedAt Datetime default getdate(),
   foreign key(CountryID) references Countries(CountryID)
);


create table Countries (
    CountryID int primary key,
    CountryName varchar(255) NOT NULL
);


create table Categories (
    CategoryID int primary key identity(1,1),
    CategoryName nvarchar(255) NOT NULL,
    Description nvarchar(MAX)
);

create table Items (
    ItemID int primary key identity(1,1),
    SellerID int,
    CategoryID int,
    Title nvarchar(255) NOT NULL,
    Description nvarchar(MAX),
    StartingPrice decimal(10, 2) NOT NULL,
    CurrentPrice decimal(10, 2) NOT NULL,
    StartDate Datetime,
    EndDate Datetime,
    ImageURL nvarchar(255),
    CreatedAt Datetime default getdate(),
    foreign key(SellerID) references Users(UserID),
    foreign key(CategoryID) references Categories(CategoryID)
);

create table Bids (
    BidID int primary key identity(1,1),
    ItemID int,
    UserID int,
    BidAmount decimal(10, 2) NOT NULL,
    BidTime Datetime default getdate(),
    foreign key(ItemID) references Items(ItemID),
    foreign key(UserID) references Users(UserID)
);

create table Orders (
    OrderID int primary key identity(1,1),
    BuyerID int,
    ItemID int,
    OrderDate Datetime default getdate(),
    TotalAmount decimal(10, 2) NOT NULL,
    foreign key(BuyerID) references Users(UserID),
    foreign key(ItemID) references Items(ItemID)
);


create table Notifications (
    NotificationID int primary key identity(1,1),
    UserID int,
    Message nvarchar(MAX),
    IsRead bit default 0,
    CreatedAt Datetime default getdate(),
    foreign key (UserID) references Users(UserID)
);

------------------------------------------------------------------------------------------------------------------------
create procedure createUser
    @Username nvarchar(255),
    @Email nvarchar(255),
    @PasswordHash nvarchar(255),
    @Status nvarchar(50),
    @AddressLine1 nvarchar(255),
    @AddressLine2 nvarchar(255),
    @City nvarchar(255),
    @State nvarchar(255),
    @PostalCode nvarchar(20),
    @CountryID int

AS
Begin 
	insert into Users(Username, Email, PasswordHash, Status, AddressLine1, AddressLine2, City, State, PostalCode, CountryID)
    VALUES (@Username, @Email, @PasswordHash, @Status, @AddressLine1, @AddressLine2, @City, @State, @PostalCode, @CountryID);
END

------------------------------------------------------------------------------------------------------------------------
create procedure UpdateUserStatus
    @UserID int,
    @Status nvarchar(50)
AS
BEGIN
    update Users
    set Status = @Status
    where UserID = @UserID;
END
------------------------------------------------------------------------------------------------------------------------
create procedure CreateItem
    @SellerID int,
    @CategoryID int,
    @Title nvarchar(255),
    @Description nvarchar(MAX),
    @StartingPrice decimal(10, 2),
    @CurrentPrice decimal(10, 2),
    @StartDate Datetime,
    @EndDate Datetime,
    @ImageURL nvarchar(255)
AS
BEGIN
    insert into Items (SellerID, CategoryID, Title, Description, StartingPrice, CurrentPrice, StartDate, EndDate, ImageURL)
    values(@SellerID, @CategoryID, @Title, @Description, @StartingPrice, @CurrentPrice, @StartDate, @EndDate, @ImageURL);
END
------------------------------------------------------------------------------------------------------------------------
create procedure PlaceBid
    @ItemID INT,
    @UserID INT,
    @BidAmount DECIMAL(10, 2)
AS
BEGIN
    insert into Bids (ItemID, UserID, BidAmount) values (@ItemID, @UserID, @BidAmount);
    update Items set CurrentPrice = @BidAmount where ItemID = @ItemID;
END
------------------------------------------------------------------------------------------------------------------------

---Retrieve all items along with their respective seller information:
select Items.*, Users.Username AS SellerName
from Items inner join Users on Items.SellerID = Users.UserID;


---Retrieve all users along with their items, if they have any:
select Users.*, Items.*
from Users left join Items on Users.UserID = Items.SellerID;


---Retrieve items with the number of bids each item has received:
select Items.ItemID, COUNT(Bids.BidID) AS NumBids
from Items left join Bids on Items.ItemID = Bids.ItemID
group by Items.ItemID;


---Retrieve users and the total amount they have spent on orders:
select Users.UserID, SUM(Orders.TotalAmount) AS TotalSpent
from Users left join Orders on Users.UserID = Orders.BuyerID
group by Users.UserID;


---Retrieve items along with their category names:
select Items.*, Categories.CategoryName
from Items inner join Categories on Items.CategoryID = Categories.CategoryID;
