use Assignments

--SET II (Using the same tables as Assignment 2)

-- 1st query (Retrieve a list of MANAGERS.select e.mgr_id as 'ManagerId',(select ename from emp where empno=e.mgr_id) as 'Manager',e.ename as 'Manager of' from emp e join emp f on e.mgr_id=f.empno)
select * from emp 
	where job='manager'

-- 2nd query (Find out the names and salaries of all employees earning more than 1000 per month.)
select ename as 'Employee Name',salary from emp 
	where salary>1000

-- 3rd query (Display the names and salaries of all employees except JAMES.)
select ename as 'Employee Name',salary from emp 
	where ename <>'james'

-- 4th query (Find out the details of employees whose names begin with ‘S’.)
select * from emp 
	where ename like 'S%'

-- 5th query (Find out the names of all employees that have ‘A’ anywhere in their name.)
select * from emp 
	where ename like '%A%'

-- 6th query (Find out the names of all employees that have ‘L’ as their third character in their name.)
select * from emp 
	where ename like '__L%'

-- 7th query (Compute daily salary of JONES.)
select ename as 'Employee Name',(salary*12)/365 as 'Daily salary' from emp 
	where ename='Jones'

-- 8th query (Calculate the total monthly salary of all employees.)
select sum(salary) as 'Total Monthly Salary' from emp

-- 9th query (Print the average annual salary.)
select avg(salary*12) as 'Average Annual Salary' from emp

-- 10th query (Select the name, job, salary, department number of all employees except SALESMAN from department number 30.)
select ename as 'Employee Name',job,salary,deptno from emp 
	where not (job='salesman' and deptno=30)

-- 11th query (List unique departments of the EMP table.)
select distinct(e.deptno),d.dname from emp e 
	join dept d on e.deptno=d.deptno

-- 12th query (List the name and salary of employees who earn more than 1500 and are in department 10 or 30. Label the columns Employee and Monthly Salary respectively.)
select ename as 'Employee Name',salary as 'Monthly Salary' from emp 
	where salary>1500 and deptno in(10,30)

-- 13th query (Display the name, job, and salary of all the employees whose job is MANAGER or ANALYST and their salary is not equal to 1000, 3000, or 5000.)
select ename as 'Employee Name',job,salary from emp 
	where job in ('manager','analyst') and salary not in (1000,3000,5000)

-- 14th query (Display the name, salary and commission for all employees whose commission amount is greater than their salary increased by 10%.)
select ename as 'Employee Name',salary,comm as 'commission' from emp 
	where comm>(salary * 1.10)

-- 15th query (Display the name of all employees who have two Ls in their name and are in department 30 or their manager is 7782.)
select ename as 'Employee Name' from emp 
	where (ename like '%L%L%' and deptno=30) or mgr_id=7782


-- 16th query (Display the names of employees with experience of over 30 years and under 40 yrs. Count the total number of employees. i took 1st january 2025 as the end date)
select ename from Emp 
	where datediff(Year,Hire_Date,GetDate()) between 20 and 40
select count(*) as Total from Emp 
	where datediff(Year,Hire_Date,GetDate()) between 30 and 40

-- 17th query (Retrieve the names of departments in ascending order and their employees in descending order.)
select e.ename as'Employee',d.dname as'Department' from emp e 
	join dept d on e.deptno=d.deptno 
	order by dname ASC,ename DESC

-- 18th query (Find out experience of MILLER. i took 1st january 2025 as the end date)
select ename as'Employee' ,
	datediff(year,hire_date,GETDATE()) as 'experience' from emp 
	where ename='miller'