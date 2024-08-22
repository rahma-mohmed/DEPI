select * from sales.customers
order by customer_id
offset 10 rows
fetch next 5 rows only

select CAST(zip_code as int) from sales.customers

select CONVERT(int,zip_code) from sales.customers

---CONVERT(datetime , shipped_date , style)

select CONVERT(datetime , shipped_date)
from sales.orders

---culture
select parse(zip_code as int)from sales.customers

---subquires (self contained:no dependency , correlated : depend on value of outer)
---multi-valued: return multiple values as a single column (IN)

---correlated 

---CTE : improve readability , recursive quieries , reusability
WITH AveragePrice AS
(
	select Avg(list_price) as avgp from production.products
)

select product_id , product_name from production.products
where list_price > (select avgp from AveragePrice);

---intersect result present in both result set

