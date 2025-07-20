--Assignment 4

use Assignments

--1st query (Write a T-SQL Program to find the factorial of a given number.)
declare @number int=5
declare @factorialresult int=1
declare @temp int = @number

while @number>=2
begin
 set @factorialresult = @factorialresult*@number
 set @number=@number-1
end
print 'The Factorial of '+ cast(@temp as varchar) +' is ' +  cast(@factorialresult as varchar(20))

--2nd query (Create a stored procedure to generate multiplication table that accepts a number and generates up to a given number.)
create or alter proc multiple_table @number int,@limit int
as
begin
  declare @count int=1
  while @count<=@limit
  begin
    print cast(@number as varchar(20)) + ' * ' + cast(@count as varchar(20)) + ' = ' + cast(@number*@count as varchar(20))
    set @count = @count +1
  end
end

multiple_table 5,12

--3rd query(Create a function to calculate the status of the student. If student score >=50 then pass, else fail. Display the data neatly)
create table student (
    sid int,
    sname varchar(20)
);

insert into student (sid, sname) values
(1, 'jack'),
(2, 'rithvik'),
(3, 'jaspreeth'),
(4, 'praveen'),
(5, 'bisa'),
(6, 'suraj');

create table marks (
	mid int,
    sid int,
    score int
);

insert into marks values
	(1, 1, 23),
	(2, 6, 95),
	(3, 4, 98),
	(4, 2, 17),
	(5, 3, 53),
	(6, 5, 13);

create table student (
    sid int,
    sname varchar(20)
);

insert into student values
	(1, 'jack'),
	(2, 'rithvik'),
	(3, 'jaspreeth'),
	(4, 'praveen'),
	(5, 'bisa'),
	(6, 'suraj');

drop function Calculate

create function Calculate(@marks int) returns varchar(20)
as 
begin
 declare @status varchar(20)
 if @marks>=50
 begin
  set @status='pass'
 end
 else
 begin
  set @status='fail'
 end
 return @status
end

select s.sname as 'Student Name',m.score as 'Score',dbo.Calculate(m.score) as 'Status of student' from student s 
	join marks m on s.sid=m.mid