---1
select p.product_name ,c.category_name, b.brand_name
from production.products p 
inner join production.brands b
on p.brand_id = b.brand_id
inner join production.categories c
on p.category_id = c.category_id

---2
select p.product_name,COALESCE(SUM(quantity), 0) total_quantity
from production.products p inner join sales.order_items o
on p.product_id = o.product_id
group by(p.product_name)

---3
select concat(c.first_name ,'  ', c.last_name) as [customer_name] , s.store_name
from sales.customers c inner join sales.orders o
on o.customer_id = c.customer_id
inner join sales.stores s 
on s.store_id = o.store_id 

---4
select s.store_name , COALESCE(SUM(quantity), 0)[sales amount] from 
sales.order_items oi inner join sales.orders o
on oi.order_id = o.order_id
inner join sales.stores s
on s.store_id = o.store_id
group by(s.store_name)


---5
select o.order_id , o.order_status ,o.order_date , 
o.required_date , o.shipped_date , concat(c.first_name ,'  ', c.last_name) as [customer_name]
, s.store_name , concat(sf.first_name,' ',sf.last_name) [staff name]
from sales.orders o inner join sales.customers c
on o.customer_id = c.customer_id
inner join sales.stores s
on o.store_id = s.store_id
inner join sales.staffs sf
on sf.staff_id = o.staff_id

---6
select product_name 
from production.products
where product_name not in (
select p.product_name 
from production.products p
inner join sales.orders o
on p.product_id = o.order_id
)

---7
select c.category_name, avg(list_price)[average price]
from production.products p inner join production.categories c
on p.category_id = c.category_id
group by(c.category_name)

---8
select product_name , quantity
from production.products p inner join production.stocks s
on s.product_id = p.product_id

---9
select c.customer_id , count(o.order_id)
from sales.orders o inner join sales.customers c
on o.customer_id = c.customer_id
group by c.customer_id

---10
select sto.store_name , count(distinct(p.product_name))
from production.products p inner join sales.order_items it
on p.product_id = it.product_id
inner join sales.orders o
on o.order_id = it.order_id
inner join sales.stores sto
on sto.store_id = o.store_id
group by sto.store_name

--------------------------------------------------------------------------
---left join

-- 1
SELECT p.product_id, p.product_name, c.category_name
FROM production.products p
LEFT JOIN production.categories c
ON p.category_id = c.category_id;

---2
SELECT p.product_id, p.product_name, COALESCE(SUM(oi.quantity), 0) AS total_quantity_sold
FROM production.products p
LEFT JOIN sales.order_items oi
ON p.product_id = oi.product_id
GROUP BY p.product_id, p.product_name;

---3
SELECT o.order_id, o.order_date, concat(c.first_name ,'  ', c.last_name) as [customer_name]
FROM sales.orders o
LEFT JOIN sales.customers c
ON o.customer_id = c.customer_id;

---4
SELECT s.staff_id, s.first_name, s.last_name, st.store_name
FROM sales.staffs s
LEFT JOIN sales.stores st
ON s.store_id = st.store_id;

--5

---6
SELECT c.customer_id, c.first_name, c.last_name, COUNT(o.order_id) AS total_orders
FROM sales.customers c
LEFT JOIN sales.orders o
ON c.customer_id = o.customer_id
GROUP BY c.customer_id, c.first_name, c.last_name;

------------------------------------------------------
---Self join

---1
SELECT concat(e1.first_name , ' ', e1.last_name) [Employee Name],
       concat(e2.first_name, e2.last_name ) [Manager name]
FROM sales.staffs e1
LEFT JOIN sales.staffs e2
ON e1.manager_id = e2.staff_id;





