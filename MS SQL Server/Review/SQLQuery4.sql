---Review

begin try
	select 1/0
end try
begin catch
	select ERROR_MESSAGE();
end catch

Declare @CID int;
set @CID = 2;

select * from Users
where CountryID = @CID;

Declare @stock nvarchar(50);
set @stock = (select Status from Users where UserID = 1);

if @stock = 'Active'
	Print 'Status is Active.';
else
	print 'Status is InActive';


Declare @Counter int = 1;

while @Counter <= 5
Begin
	print 'Counter value' + CAST(@Counter AS nvarchar)
	set @Counter = @Counter + 1;
end
----------------------------------------------------------
-------------===String Functions===--------------

select SUBSTRING('Hello world !', 8, 5) AS SubStringExample;

SELECT LEFT('AdventureWorks', 9) AS LeftExample, 
       RIGHT('AdventureWorks', 5) AS RightExample;

SELECT LEN('Hello, World!') AS LengthExample;

SELECT REPLACE('Hello, World!', 'World', 'SQL') AS ReplaceExample;

SELECT REPLICATE('SQL', 3) AS ReplicateExample;

SELECT UPPER('Hello') AS UpperExample, 
       LOWER('WORLD') AS LowerExample;

SELECT LTRIM('    SQL') AS LTrimExample, 
       RTRIM('Server    ') AS RTrimExample;

SELECT STUFF('SQL Server', 5, 6, 'Database') AS StuffExample;

SELECT SOUNDEX('Smith') AS SoundexExample1, 
       SOUNDEX('Syth') AS SoundexExample2;
----------------------------------------------------------
-------------===DateTime Functions===--------------

SELECT GETDATE() AS CurrentDateTime;

Select SYSDATETIME()

select GETUTCDATE()

select DATEADD(Day , 10 , GETDATE())

select DATEDIFF(Day , '2024-08-01' , GETDATE())

select Year('2024-08-01')

select Month('2024-08-01')

select DATENAME(Month , '2024-08-01')

select DATEPART(WEEKDAY , '2024-08-01')

SELECT ISDATE('2024-08-30') AS IsValidDate, 
       ISDATE('Not a Date') AS IsNotValidDate;
-----------------------------------------------------
----------====Aggregriate Function====--------------

---COUNT_BIG , STDEV(standard deviation) , VAR, 

-----------------------------------------------------
-------------=====Control Of Flow=====---------------
Declare @c int = 1;
while @c <= 5
Begin
	set @c = @c + 1;
	if @c = 3
	begin
		continue;
	end
	print 'Counter value '+Cast(@c As varchar);
end
-------------------------------------------------------
---Pauses execution for a specified time or until a specific time is reached
waitFor Delay '00:00:10';
print '10 second have passed'

---------------------------------------------------------
------===Error Handling===--------
Begin try
	DECLARE @result INT;
    SET @result = 10 / 0;
End try

Begin Catch
	select ERROR_NUMBER();
	Select ERROR_MESSAGE();
End Catch

-------------------------------------------------------
---THROW is used to raise an error. It can include an error number,a message, and a state.
Begin Try
	if(1 = 1)
		Begin
			THROW 50000, 'Custom error message', 1;
		end
end Try

BEGIN CATCH
    SELECT 
        ERROR_NUMBER() AS ErrorNumber,
        ERROR_MESSAGE() AS ErrorMessage;
END CATCH
----------------------------------------------------------
Begin Transaction

Insert into Company_SD.dbo.Project
values('Ebad El Rahman' , 1000 , 'Nasr City' , 'Alex' , 20);
save Transaction S1;

if @@ERROR <> 0
Begin
	ROLLBACK Transaction S1;
	PRINT 'Transaction rolled back due to an error.';
End
Else
Begin
	COMMIT Transaction;
	PRINT 'Transaction committed successfully.';
END
--------------------------------------------------------
Select * ,
case
	when Dnum = 10 then 'Department 10'
	when Dnum = 20 then 'Department 20'
	else 'Department 30'
end as DepartmentCategory
from Company_SD.dbo.Project
--------------------------------------------------------
select top (3)Percent * from Employee
order by Lname
Offset 1 rows
fetch next 2 rows only;

DECLARE @intVar INT = 10;
DECLARE @decimalVar DECIMAL(5,2) = @intVar;

SELECT CONVERT(VARCHAR(10), GETDATE()) AS ConvertedDate;


SELECT 
    CAST('2024-09-01' AS DATE) AS CastDate,
    CONVERT(DATE, '2024-09-01') AS ConvertDate;

SELECT PARSE('01 September 2024' AS DATETIME USING 'en-GB') AS ParsedDate;

SELECT GETDATE() AS CurrentDateTime;

SELECT CAST(GETDATE() AS DATE) AS CurrentDate;

SELECT DATEADD(DAY, 10, GETDATE()) AS NewDate;

SELECT DATEDIFF(DAY, '2024-09-01', GETDATE()) AS DaysDifference;

create sequence Invoicseq As Int Start with 1 Increment by 1;

select next value for Invoicseq;

select @@IDENTITY

