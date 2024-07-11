select * from production.brands

select * from sales.customers

select city , count(*) from sales.customers
where state = 'CA' 
group by city
having count(*) > 10
order by city

select TOP(30)percent  * from sales.customers
order by zip_code

select distinct state , first_name from sales.customers

SELECT
product_id,
product_name,
category_id,
model_year,
list_price
FROM
production.products
WHERE
category_id = 1
order by list_price desc;


SELECT
product_id,
product_name,
category_id,
model_year,
list_price
FROM
production.products
WHERE
product_name LIKE '%[A-D]r___er%'

select distinct first_name + ' ' + last_name as [full name] from sales.customers

select * , coalesce(phone , Address,'NOT A val') from sales.customers

alter table sales.customers add Address varchar(100)

update sales.customers
set Address = 'Damietta'
where customer_id = 1;


