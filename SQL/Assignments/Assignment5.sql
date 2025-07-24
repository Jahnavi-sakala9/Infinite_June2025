use Assignments

/*
1. Write a T-Sql based procedure to generate complete payslip of a given employee with respect to the following condition

   a) HRA as 10% of Salary
   b) DA as 20% of Salary
   c) PF as 8% of Salary
   d) IT as 5% of Salary
   e) Deductions as sum of PF and IT
   f) Gross Salary as sum of Salary, HRA, DA
   g) Net Salary as Gross Salary - Deductions

Print the payslip neatly with all details
*/

create or alter procedure proc_slip(@empid int)
as
begin
  declare @salary int, @hra int, @da int, @pf int, @it int;
  declare @deductions int, @grosssalary int, @netsalary int;
  declare @ename varchar(100);

  -- fetch employee data
  select @salary = salary, @ename = ename from emp where empno = @empid;

  if @salary is null
  begin
    print 'employee not found.';
    return;
  end

  -- compute components
  set @hra = @salary * 0.1;
  set @da = @salary * 0.2;
  set @pf = @salary * 0.08;
  set @it = @salary * 0.05;

  set @deductions = @pf + @it;
  set @grosssalary = @salary + @hra + @da;
  set @netsalary = @grosssalary - @deductions;

  if @grosssalary < @deductions
  begin
    print 'not possible';
  end

  -- printing the payslip
  print '====== payslip ======';
  print 'employee no     : ' + cast(@empid as varchar);
  print 'name            : ' + @ename;
  print 'basic salary    : ' + cast(@salary as varchar);
  print 'hra (10%)       : ' + cast(@hra as varchar);
  print 'da (20%)        : ' + cast(@da as varchar);
  print 'pf (8%)         : ' + cast(@pf as varchar);
  print 'it (5%)         : ' + cast(@it as varchar);
  print 'deductions      : ' + cast(@deductions as varchar);
  print 'gross salary    : ' + cast(@grosssalary as varchar);
  print 'net salary      : ' + cast(@netsalary as varchar);
  print '======================';
end;

exec proc_slip @empid = 7499;



--2nd query ( Create a trigger to restrict data manipulation on EMP table during General holidays. Display the error message like “Due to Independence day you cannot manipulate data” or "Due To Diwali", you cannot manipulate" etc
--Note: Create holiday table with (holiday_date,Holiday_name). Store at least 4 holiday details. try to match and stop manipulation )
create table holidays (
    holiday_date date primary key,
    holiday_name varchar(75)
)
drop table holidays
insert into holidays values
	('2025-01-01', 'New Year'),
	('2025-01-26', 'republic day'),
	('2025-08-15', 'independence day'),
	('2025-10-29', 'diwali')

drop trigger trg_block_on_holiday

create or alter trigger trg_block_on_holiday
on emp
instead of insert, update, delete
as
begin
	--declare @today date =cast(getdate() as date);
	declare @today date='2025-01-26'
    declare @holiday_name varchar(50);

    select @holiday_name = holiday_name 
    from holidays 
    where holiday_date = @today;

    if @holiday_name is not null
    begin
        raiserror('Due to %s, you cannot manipulate data', 16, 1, @holiday_name);
        rollback transaction;
    end
end

select * from emp
--Testing
insert into emp values(2309,'Jahnavi','Software Engineer',7566,'2004-09-04',7800,null,10)


