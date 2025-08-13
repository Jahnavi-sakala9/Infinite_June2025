-- create db

use rrsdatabase;
create database rrsdatabase;
drop database rrsdatabase;
use sqlpractice1;

-- customers
create table dbo.customers (
  custid       int identity primary key,
  custname     nvarchar(100) not null,
  phone        nvarchar(20) null,
  mailid       nvarchar(150) not null unique,
  password     nvarchar(100) not null,
  role         varchar(10) not null check (role in ('user','admin')),
  isdeleted    bit not null default(0)
);

-- trains
create table dbo.trains (
  trainid      int identity primary key,
  trainno      varchar(10) not null unique,
  trainname    nvarchar(120) not null,
  source       nvarchar(80) not null,
  destination  nvarchar(80) not null,
  isdeleted    bit not null default(0)
);

-- per-class config (seats & price)
create table dbo.trainclasses (
  trainclassid int identity primary key,
  trainid      int not null foreign key references dbo.trains(trainid),
  class        varchar(10) not null,
  totalseats   int not null check (totalseats > 0),
  costperseat  decimal(10,2) not null check (costperseat >= 0),
  isdeleted    bit not null default(0),
  constraint uq_train_class unique(trainid, class)
);

-- reservations
create table dbo.reservations (
  bookingid     int identity primary key,
  custid        int not null foreign key references dbo.customers(custid),
  trainclassid  int not null foreign key references dbo.trainclasses(trainclassid),
  dateoftravel  date not null,
  seatsbooked   int not null check (seatsbooked > 0),
  totalcost     decimal(10,2) not null,
  dateofbooking datetime2 not null default sysutcdatetime(),
  isdeleted     bit not null default(0)
);

-- cancellations
create table dbo.cancellations (
  cancelid           int identity primary key,
  bookingid          int not null foreign key references dbo.reservations(bookingid),
  ticketcancelled    int not null,
  amountrefunded     decimal(10,2) not null,
  dateofcancellation datetime2 not null default sysutcdatetime()
);

-- seed admin + one train & class (demo)
insert into customers (custname, phone, mailid, password, role)
values (n'admin', n'0000000000', n'admin@railway.com', n'admin123', 'admin');

insert into trains (trainno, trainname, source, destination)
values ('12727', n'godavari exp', n'hyderabad', n'vizag');

declare @tid int = scope_identity();

insert into dbo.trainclasses (trainid, class, totalseats, costperseat)
values (@tid, 'sleeper', 200, 450.00),
       (@tid, '3ac', 90, 1100.00);

-- simhadri express
insert into trains (trainno, trainname, source, destination)
values ('17240', n'simhadri express', n'guntur', n'visakhapatnam');
declare @tid1 int = scope_identity();
insert into trainclasses (trainid, class, totalseats, costperseat)
values (@tid1, 'sleeper', 180, 400.00),
       (@tid1, '3ac', 80, 950.00),
       (@tid1, '2ac', 60, 1400.00);

-- tirumala express
insert into trains (trainno, trainname, source, destination)
values ('17488', n'tirumala express', n'kadapa', n'visakhapatnam');
declare @tid2 int = scope_identity();
insert into trainclasses (trainid, class, totalseats, costperseat)
values (@tid2, 'sleeper', 200, 420.00),
       (@tid2, '3ac', 90, 1000.00),
       (@tid2, '2ac', 60, 1600.00);

-- chennai express
insert into trains (trainno, trainname, source, destination)
values ('12604', n'chennai express', n'hyderabad', n'chennai');
declare @tid3 int = scope_identity();
insert into trainclasses (trainid, class, totalseats, costperseat)
values (@tid3, 'sleeper', 220, 500.00),
       (@tid3, '3ac', 100, 1200.00),
       (@tid3, '2ac', 60, 1800.00);

-- bangalore express
insert into trains (trainno, trainname, source, destination)
values ('16502', n'bangalore express', n'vijayawada', n'bangalore');
declare @tid4 int = scope_identity();
insert into trainclasses (trainid, class, totalseats, costperseat)
values (@tid4, 'sleeper', 200, 480.00),
       (@tid4, '3ac', 90, 1150.00);

-- kerala express
insert into trains (trainno, trainname, source, destination)
values ('12625', n'kerala express', n'thiruvananthapuram', n'new delhi');
declare @tid5 int = scope_identity();
insert into trainclasses (trainid, class, totalseats, costperseat)
values (@tid5, 'sleeper', 210, 600.00),
       (@tid5, '3ac', 100, 1400.00),
       (@tid5, '2ac', 60, 2200.00);

-- user
insert into customers (custname, phone, mailid, password, role)
values ('jahnavi', '9999999999', 'jahn@railway.local', 'jahnavi123', 'user');

select * from customers;
select * from reservations;
select * from trains;
select * from trainclasses;
select * from cancellations;
