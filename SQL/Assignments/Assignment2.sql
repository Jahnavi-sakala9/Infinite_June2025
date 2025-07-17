use Assignments;

--dept table
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

--1st query(List all employees whose name begins with 'A'.)
select * from emp where ename like 'A%';

--2nd query(Select all those employees who don't have a manager.)
select * from emp where mgr_id is null;

--3rd query(List employee name, number and salary for those employees who earn in the range 1200 to 1400.)
select ename as 'Employee Name',empno as 'Employee Number', salary from emp where salary between 1200 and 1400;

--4th query(Give all the employees in the RESEARCH department a 10% pay rise. Verify that this has been done by listing all their details before and after the rise.)
--before updation
select * from emp where deptno =(
							select deptno from dept where dname='RESEARCH');
--after updation:
UPDATE emp SET salary = salary * 1.10 
	WHERE deptno in (
	select deptno from emp where deptno in (select deptno from dept where dname='RESEARCH'));

--Listing again
select * from emp where deptno =(
						select deptno from dept where dname='RESEARCH');

--5th query(Find the number of CLERKS employed. Give it a descriptive heading.)
select count(*) as 'No. of Clerks' from Emp where Job = 'Clerk';

--6th query(Find the average salary for each job type and the number of people employed in each job.)
select Job, count(*) as 'No. of Employees', avg(Salary) as 'Average Salary'
	from Emp
	group by job;

--7th query(List the employees with the lowest and highest salary.)
select ename as 'Employee Name',empno as 'Employee no.',salary as 'Salary' from Emp where Salary =(
						select min(Salary) from Emp) 
						or Salary = (select max(Salary) from Emp)

--8th query(List full details of departments that don't have any employees.)
select * from dept where deptno not in(
								select distinct deptno from emp)

--9th query(Get the names and salaries of all the analysts earning more than 1200 who are based in department 20. Sort the answer by ascending order of name.)
select ename as 'Employee Name', salary from emp 
	where job = 'ANALYST' and salary > 1200 and deptno = 20 
	order by ename asc;

--10th query(For each department, list its name and number together with the total salary paid to employees in that department.)
select d.dname,d.deptno,sum(e.salary) as 'Total Salary' 
	from dept d left join emp e 
	on d.deptno = e.deptno 
	group by d.dname, d.deptno;

--11th query(Find out salary of both MILLER and SMITH.)
select EName as 'Employee Name', Salary from Emp
	where EName in ('Miller', 'Smith')

--12th query(Find out the names of the employees whose name begin with ‘A’ or ‘M’.)
select Ename as 'Employee Name' from emp 
	where Ename like 'A%' or Ename like 'M%'

--13th query( Compute yearly salary of SMITH.)
select Ename as 'Employee Name',(salary*12) as 'Annual Salary' from emp 
	where Ename='SMITH'

--14th query(List the name and salary for all employees whose salary is not in the range of 1500 and 2850)
select ename as 'Employee Name',salary from emp 
	where salary not between 1500 and 2850

--15th query(Find all managers who have more than 2 employees reporting to them)
select mgr_id as 'Manager ID',count(*) as 'Reporting Employees' from emp 
	where mgr_id is not null
	group by mgr_id 
	having count(*)>2;

