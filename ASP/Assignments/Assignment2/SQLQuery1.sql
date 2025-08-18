create database electricitybilldb;
use electricitybilldb;


create table dbo.electricitybill (
  id int identity(1,1) primary key,        
  consumer_number varchar(20) not null,
  consumer_name   varchar(50) not null,
  units_consumed  int not null,
  bill_amount     float not null
);

select * from electricitybill
