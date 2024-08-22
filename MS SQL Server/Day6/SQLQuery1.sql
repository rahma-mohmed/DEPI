alter procedure ProcedureName2(
	@id int, ---output
	@count int output,
	@BrandId int = 0
)
AS
Begin
	select @count = count(*) from Departments
	where Dnum = @id
	and (@BrandId = 0 or MGRSSN = '1234')
end 
go

declare @c int = 0;
declare @brand int;

exec ProcedureName2 @id = 10 , @count = @c output , @BrandId = @brand;
--print @c
print @brand


---try carch : handle exceptions
begin try
end try

begin catch
select
	Error_Number() AS ErrorNumber,
	Error_Message() AS ErrorMessage,
	Error_severity() AS Errorseverity,
	Error_procedure() AS ErrorProcedure,
	Error_State() AS ErrorState,
	Error_line() AS Errorline;
end catch


---Function Types
---Scalar , table_valued , system Functions

---precompile (SP , function , view)

create function CheckOnListPrice
(
    @ListPrice int
)
returns nvarchar(250)
as
begin
	if(@ListPrice > 100)
	begin
	return 'expensive';
	end
	else
	begin
	return 'InExpensive';
	end

	return '';
end
go

select dbo.CheckOnListPrice(list_price) as priceState from production.products


create function TimeTitle(
	@productTitle nvarchar(250)
)
returns nvarchar(250)