create Database myStore;

use myStore;
Go

create schema sales;
Go

create schema production;
Go

create table myStore.production.categories(
	category_id int identity(1,1) primary key,
	category_name varchar(250) not null,
);

create table myStore.production.brands(
	brand_id int identity(1,1) primary key,
	brand_name varchar(250) not null
);

create table myStore.production.products(
	product_id int identity(1,1) primary key,
	product_name varchar(250) not null,
	brand_id int foreign key references myStore.production.brands(brand_id) on delete cascade on update cascade,
	category_id int foreign key references myStore.production.categories(category_id) on delete cascade on update cascade,
	model_year smallint not null,
	list_price decimal(10,2) not null
);

create table myStore.sales.stores(
	store_id int identity(1,1) primary key,
	store_name varchar(250) not null,
	email varchar(250),
	street varchar(250),
	city varchar(250),
	state varchar(10),
	zip_code varchar(5)
);

alter table myStore.sales.stores add phone varchar(250);

--phone : multi valued attribute
--create table myStore.sales.store_phones(
--	store_id int foreign key references myStore.sales.stores(store_id),
--	phone varchar(250),
--	primary key(store_id , phone)
--);


create table myStore.production.stocks(
	store_id int foreign key references myStore.sales.stores(store_id) on delete cascade on update cascade,
	product_id int foreign key references myStore.production.products(product_id) on delete cascade on update cascade,
	quantity int,
	primary key(store_id , product_id)
);

create table sales.staffs(
	staff_id int identity(1,1) primary key,
	first_name varchar(250) not null,
	last_name varchar(250) not null,
	email varchar(250) not null,
	phone varchar(25),
	active tinyint not null,
	store_id int foreign key references sales.stores(store_id) on delete cascade on update cascade,
	manager_id int foreign key references sales.staffs(staff_id) on delete no action --recursive/self relationship
);

create table sales.customers(
	customer_id int identity(1,1) primary key,
	first_name varchar(250) not null,
	last_name varchar(250) not null,
	phone varchar(25),
	email varchar(250) not null,
	street varchar(250),
	city varchar(250),
	state varchar(10),
	zip_code varchar(5)
);

create table sales.orders(
	order_id int identity(1,1) primary key,
	customer_id int foreign key references sales.customers(customer_id) on delete no action on update cascade,
	order_status tinyint not null,
	order_date date not null,
	required_date date not null,
	shipped_date date,
	store_id int foreign key references sales.stores(store_id) on delete cascade on update no action,
	staff_id int foreign key references sales.staffs(staff_id) on delete no action on update cascade
);

create table sales.order_items(
	order_id int foreign key references sales.orders(order_id) on delete cascade on update cascade,
	item_id int,
	product_id int foreign key references production.products(product_id) on delete cascade on update cascade,
	quantity int not null,
	list_price decimal(10 , 2) not null,
	discount decimal(4 , 2),
	primary key(order_id,item_id)
);

