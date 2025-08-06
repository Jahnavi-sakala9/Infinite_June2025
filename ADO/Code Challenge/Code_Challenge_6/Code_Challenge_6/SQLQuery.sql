use Assesments;


CREATE TABLE Employee2 (
    Empid INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(100),
    Salary int,
    Gender CHAR(1)
);

insert into Employee2 (Name, Salary, Gender)
values 
('Jahnavi', 65000, 'F'),
('Reshma', 52000, 'F'),
('Srinivas', 89000, 'M'),
('Priya', 41000.00, 'F'),
('Lakshimi', 47000.00, 'F'),
('Mahesh', 54000.00, 'M'),
('Jay', 50000.00, 'M')


create procedure insert_employee
    @name varchar(100),
    @givensalary int,
    @gender char(1),
    @generatedempid int output,
    @calculatedsalary decimal(10,2) output
as
begin
    set @calculatedsalary = @givensalary * 0.9;
 
    insert into employee2 (name, salary, gender)
    values (@name, @calculatedsalary, @gender);
 
    set @generatedempid = scope_identity();
end;


drop procedure update_employee_salary

create procedure update_employee_salary
    @empid int,
    @updatedsalary decimal(10,2) output
as
begin
    update employee1
    set salary = salary + 100
    where Empid = @empid;

    select @updatedsalary = salary
    from employee1
    where Empid = @empid;
end;



select * from employee2

create procedure update_employee_salary
    @empid int,
    @name varchar(100) output,
    @gender char(1) output,
    @updated_salary int output,
    @net_salary int output
as
begin
    update employee2
    set salary = salary + 100
    where empid = @empid;

    select 
        @name = name,
        @gender = gender,
        @updated_salary = salary,
        @net_salary = salary - (salary / 10)
    from employee2
    where empid = @empid;
end
