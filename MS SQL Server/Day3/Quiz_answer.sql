USE Store
Go

---1
select * from production.products;

---2
select product_name , list_price from production.products;

---3
select distinct category_id from production.products;

---4
select first_name + ' ' + last_name as [full_name] from sales.customers

---5
select top(5) * from production.products order by list_price Desc

---6
select * from production.products where list_price > 100;

---7
select * from sales.customers where city = 'New York';

---8
select * from sales.orders where order_status = 1

---9
select * from production.products order by list_price desc;

---10
select * from sales.customers order by last_name , first_name

---11
select category_id , sum(list_price) as [total_list_price]
from production.products
group by category_id

---12
select customer_id , count(order_id) as [number of orders]
from sales.orders
group by customer_id

---13
select category_id , sum(list_price) as [total_list_price]
from production.products
group by category_id
having sum(list_price) > 500

---14
insert into production.brands 
OUTPUT(inserted.brand_name)
values('BrandX');

---15
insert into production.categories 
OUTPUT(inserted.category_name)
values('Electronics');

---16
insert into sales.customers 
values('Alice', 'Johnson','987-654-3210','alice.johnson@example.com' ,'456 Elm St','Othertown','TX','54321');

---17
insert into sales.stores(store_name , phone , email , street , city , state , zip_code)
values('Tech Store','555-123-4567','contact@techstore.com','789 Tech Ave','Techville','CA','67890');

---18
insert into sales.staffs
values('Bob','Smith','bob.smith@example.com','555-987-6543',1,1,Null);

insert into sales.staffs(first_name , last_name , email , phone , active , store_id)
values('Bob','Smith','bob.smith@example.com','555-987-6543',1,1);

---19
update production.products set list_price = 119.99
where product_id = 1;

---20
update sales.customers set email = 'new.email@example.com' 
where customer_id = 2

---21
update sales.stores set phone = '123-456-7890'
where store_id = 3

---22
update production.categories set category_name = 'Appliances'
where category_id = 2

---23
update sales.staffs set active = 0

---24
delete from production.brands where brand_id = 2

---25
delete from production.categories where category_id = 3

---26
delete from sales.customers where customer_id = 4

---27
delete from sales.stores where store_id = 5

---28
---The DELETE statement conflicted with the REFERENCE constraint "FK__orders__staff_id__49C3F6B7".
---The conflict occurred in database "Store", table "sales.orders", column 'staff_id'.
delete from sales.orders where staff_id = 6;
delete from sales.staffs where staff_id = 6 

---29
insert into sales.orders(customer_id , order_status , order_date , required_date , shipped_date , store_id , staff_id)
values(1 , 1 ,'2024-07-01','2024-07-10',NULL , 1 , 1);

---30
update sales.orders
set shipped_date ='2024-07-05'
where order_id = 1;

---31
delete from sales.orders where order_status = 3;

---32
insert into production.products 
values('Electra Townie Original 7D - 2015/2016' , 1 , 1 , 2015 , 2000),
	   ('Trek Fuel EX 5 27.5 Plus - 2017' , 3 , 2 , 2017 , 3000),
	   ('Sun Bicycles Drifter 7 - Women - 2017' , 5 ,1 , 2017 , 23000);

---33
update production.stocks
set quantity = 0
where store_id = 1;
