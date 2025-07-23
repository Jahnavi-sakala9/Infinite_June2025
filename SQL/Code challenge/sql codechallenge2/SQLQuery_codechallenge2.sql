use Assesments;

-------------------------------------------sql Code Challenge 2-----------------------------------

--1st query (Write a query to display your birthday( day of week))
select cast('2004-04-09' as date) as 'Birthday Date',
	datename(weekday,'2004-04-09') as 'Day of week'


--2nd query (Write a query to display your age in days)
select cast('2004-04-09' as date) as 'Birthday Date',
	datediff(day, '2004-04-09', getdate()) as 'Age In Days'


 use Assesments
create table dept(
	deptno int primary key,
	dname varchar(30),
	loc varchar(30)
	);

insert into dept values
	(10,'ACCOUNTING','NEW YORK'),
	(20,'RESEARCH','DALLAS'),
	(30,'SALES','CHICAGO'),
	(40,'OPERATIONS','BOSTON');

select * from dept;

--emp table
create table emp(
	empno int primary key,
	ename varchar(30) not null,
	job varchar(30) not null,
	mgr_id int,
	hire_date date,
	salary int,
	comm int,
	deptno int references dept(deptno)
	);

insert into emp values
	(7369,'SMITH','CLERK',7902,'17-DEC-80',800,null,20),
	(7499,'ALLEN','SALESMAN',7698,'20-FEB-81',1600,300,30),
	(7521,'WARD','SALESMAN',7698,'22-FEB-81',1250,500,30),
	(7566,'JONES','MANAGER',7839,'02-APR-81',2975,null,20),
	(7654,'MARTIN','SALESMAN',7698,'28-SEP-81',1250,1400,30),
	(7698,'BLAKE','MANAGER',7839,'01-MAY-81',2850,null,30),
	(7782,'CLARK','MANAGER',7839,'09-JUN-81',2450,null,10),
	(7788,'SCOTT','ANALYST',7566,'19-APR-87',3000,null,20),
	(7839,'KING','PRESIDENT',null,'17-NOV-81',5000,null,10),
	(7844,'TURNER','SALESMAN',7698,'08-SEP-81',1500,0,30),
	(7876,'ADAMS','CLERK',7788,'23-MAY-87',1100,null,20),
	(7900,'JAMES','CLERK',7698,'03-DEC-81',950,null,30),
	(7902,'FORD','ANALYST',7566,'03-DEC-81',3000,null,20),
	(7934,'MILLER','CLERK',7782,'23-JAN-82',1300,null,10);

select * from emp

update emp set hire_date = '2018-07-09' where empno = 7934;
update emp set hire_date = '2017-07-10' where empno = 7844;
update emp set hire_date = '2017-07-11' where empno = 7900;
update emp set hire_date = '2016-07-12' where empno = 7566;
update emp set hire_date = '2015-07-13' where empno = 7839;

select * from emp


--3rd query (Write a query to display all employees information those who joined before 5 years in the current month
 --(Hint : If required update some HireDates in your EMP table of the assignment))
select * from emp 
	where month(hire_date) = month(getdate()) 
	and datediff(year, hire_date, getdate()) >= 5;



 --4th query (Create table Employee with empno, ename, sal, doj columns or use your emp table and perform the following operations in a single transaction
 --a. First insert 3 rows 
 --b. Update the second row sal with 15% increment  
 --c. Delete first row.
 --After completing above all actions, recall the deleted row without losing increment of second row.)

 
 drop table employee1
 create table employee1 (
    empno int primary key,
    ename varchar(100),
    sal int,
    doj date)

--4th query
begin transaction;
-- insert 3 employees
insert into employee1 values
	(101, 'Jahnavi', 16000, '2025-06-06'),
	(102, 'Reshma', 25000, '2020-04-05'),
	(103, 'Srinivas', 40000, '2019-02-18')
-- update salary of second employee
update employee1 set sal = sal * 1.15
	where empno = 102;
-- store first row data before deleting
declare @empno int, @ename varchar(100), @sal int, @doj date;
select @empno = empno, @ename = ename, @sal = sal, @doj = doj
	from employee1 where empno = 101;
-- delete the first employee
delete from employee1 where empno = 101;
select * from employee1
-- re-inserting values 
insert into employee1 values (@empno, @ename, @sal, @doj);
commit;

select * from employee1



 --5th query (Create a user defined function calculate Bonus for all employees of a  given dept using 	following conditions)
--a.For Deptno 10 employees 15% of sal as bonus.
--b.For Deptno 20 employees  20% of sal as bonus
--c.For Others employees 5%of sal as bonus

--5th query
create function dbo.calculate_bonus_Amount (@deptno int, @sal int)
returns int
as
begin
    declare @bonus int;
    if @deptno = 10
        set @bonus = @sal * 0.15;
    else if @deptno = 20
        set @bonus = @sal * 0.20;
    else
        set @bonus = @sal * 0.05;
    return @bonus;
end;

select empno as 'Employee No', ename as 'Employee Name', deptno as 'Department No', salary, dbo.calculate_bonus_amount(deptno, salary) as 'Bonus'


--6th query(Create a procedure to update the salary of employee by 500 whose dept name is Sales and current salary is below 1500 (use emp table))
select * from emp

create procedure update_sales_salary
as
begin
    update emp
    set salary = salary + 500
    where job = 'salesman' and salary < 1500;
    select empno, ename, job, salary
    from emp
    where job = 'salesman';
end;
exec update_sales_salary;

select ename,salary from emp where  job = 'salesman'




