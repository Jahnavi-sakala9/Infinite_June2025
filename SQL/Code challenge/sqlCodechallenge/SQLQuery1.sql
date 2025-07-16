create database Assesments
use Assesments

create table book(
	Id int primary key, 
	Title varchar(250), 
	Author varchar(250), 
	isbn_no varchar(30) unique, 
	Published_date DateTime);

Insert into book values(1,'My First SQL book', 'Mary Parker' ,'981483029127','2012-02-22 12:08:17')
Insert into book values	(2,'My Second SQL book', 'John Mayer' ,'857300923713','1972-07-03 09:22:45')
Insert into book values(3,'My Third SQL book','Cary Flint', '523120967812', '2015-10-18 14:05:44')

select * from book;

--1st query
Select * from book where Author like '%er';


CREATE TABLE reviews (
    id INT PRIMARY KEY,
    book_id INT,
    reviewer_name VARCHAR(250),
    content VARCHAR(250),
    rating INT,
    published_date DATETIME,
    FOREIGN KEY (book_id) REFERENCES book(id)
);

insert into reviews values(1,1,'John Smith','My First review',4,'2017-12-10 05:50:11')
insert into reviews values(2,2,'John Smith','My second review',5,'2017-10-13 15:05:12')
insert into reviews values(3,2,'Alice Walker','Another review',1,'2017-10-22 23:47:10')

--2nd query
Select title as 'Title', author as 'Author Name', reviewer_name as 'Reviewer Name'
from book join reviews  ON book.id = reviews.book_id;

--3rd query
Select reviewer_name as 'Reviewer Name'
From reviews
Group By reviewer_name
Having Count(book_id) > 1;

create table customer(
	id int primary key,
	Name varchar(50),
	Age int,
	Address varchar(50),
	salary int);

insert into customer values(1,'Ramesh',32,'Ahmedabad',2000)
insert into customer values(2,'Khilan',25,'Delhi',1500)
insert into customer values(3,'kaushik',23,'Kota',2000)
insert into customer values(4,'Chaitali',25,'Mumbai',6500)
insert into customer values(5,'Hardik',27,'Bhopal',8500)
insert into customer values(6,'Komal',22,'MP',4500)
insert into customer values(7,'Muffy',24,'Indore',10000)

select * from customer;

--4th query (Display the Name for the customer from above customer table who live in same address which has character o anywhere in address)
SELECT name as Name
From customer
Where address LIKE '%o%';

Create table orders (
    oid INT PRIMARY KEY,
    order_date dateTime,
    customer_id INT,
    amount int,
    FOREIGN KEY (customer_id) REFERENCES customer(id)
);
insert into orders values(102,'2009-10-08 00:00:00', 3, 3000)
insert into orders values(100,'2009-10-08 00:00:00', 3, 1500)
insert into orders values(101,'2009-12-20 00:00:00', 2, 1560)
insert into orders values(103,'2008-05-20 00:00:00', 4, 2060)

--5th query(Write a query to display the Date,Total no of customer placed order on same Date)
SELECT order_date,
COUNT(customer_id) AS 'Total No. of Customers'
From orders
GROUP BY order_date
ORDER BY order_date;


create table Employee(
	id int primary key,
	Name varchar(50),
	Age int,
	Address varchar(50),
	salary int);

insert into Employee values(1,'Ramesh',32,'Ahmedabad',2000)
insert into Employee values(2,'Khilan',25,'Delhi',1500)
insert into Employee values(3,'kaushik',23,'Kota',2000)
insert into Employee values(4,'Chaitali',25,'Mumbai',6500)
insert into Employee values(5,'Hardik',27,'Bhopal',8500)
insert into Employee values(6,'Komal',22,'MP',null)
insert into Employee values(7,'Muffy',24,'Indore',null)


--6th query(Display the Names of the Employee in lower case, whose salary is null)
Select Lower(name) AS 'Employee name'
From employee
Where salary IS NULL;

Create table Studentdetails (
	RegisterNo int primary key,
	Name varchar(25),
	Age int,
	Qualification Varchar(20),
	MobileNo varchar(12),
	Mail_Id varchar(25),
	location varchar(25),
	gender varchar(5));

insert into Studentdetails values(2,'sai',22,'B.E','9952836777','sai@gmail.com','Chennai','M')
insert into Studentdetails values(3,'Kumar',20,'BSC','7890125648','kumar@gmail.com','Madurai','M')
insert into Studentdetails values(4,'Selvi',22,'BTech','8904567342','selvi@gmail.com','Selam','F')
insert into Studentdetails values(5,'Nisha',25,'M.E','7834672310','nisha@gmail.com','Theni','F')
insert into Studentdetails values(6,'SaiSaran',21,'B.A','7890345678','saran@gmail.com','Madurai','F')
insert into Studentdetails values(7,'Tom',23,'BCA','8901234675','tom@gmail.com','Pune','M')

--7th query
SELECT gender, COUNT(*) AS total_count
FROM Studentdetails
GROUP BY gender;
