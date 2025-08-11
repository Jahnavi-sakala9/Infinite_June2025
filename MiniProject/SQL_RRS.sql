CREATE DATABASE Railway_DB;
GO
USE Railway_DB;
GO
 
-- Customers
CREATE TABLE dbo.Customers(
  CustId     INT IDENTITY PRIMARY KEY,
  CustName   VARCHAR(80) NOT NULL,
  Phone      VARCHAR(20) NULL,
  MailId     VARCHAR(120) NULL,
  IsDeleted  BIT NOT NULL DEFAULT(0)       -- for soft delete (unit testing)
);
 
-- Trains (basic info)
CREATE TABLE dbo.Trains(
  TrainId    INT IDENTITY PRIMARY KEY,
  TrainNo    VARCHAR(10) UNIQUE NOT NULL,
  TrainName  VARCHAR(100) NOT NULL,
  Source     VARCHAR(50) NOT NULL,
  Destination VARCHAR(50) NOT NULL
);
 
-- Classes & inventory per train (availability, price)
CREATE TABLE dbo.TrainClasses(
  ClassId        INT IDENTITY PRIMARY KEY,
  TrainId        INT NOT NULL FOREIGN KEY REFERENCES dbo.Trains(TrainId),
  ClassCode      VARCHAR(10) NOT NULL,     -- SL / 3A / 2A
  AvailableSeats INT NOT NULL,
  Price          DECIMAL(10,2) NOT NULL
);
CREATE UNIQUE INDEX IX_Train_Class ON dbo.TrainClasses(TrainId, ClassCode);
 
-- Bookings
CREATE TABLE dbo.Bookings(
  BookingId      INT IDENTITY PRIMARY KEY,
  CustId         INT NOT NULL FOREIGN KEY REFERENCES dbo.Customers(CustId),
  TrainId        INT NOT NULL FOREIGN KEY REFERENCES dbo.Trains(TrainId),
  ClassCode      VARCHAR(10) NOT NULL,
  Qty            INT NOT NULL,
  TravelDate     DATE NOT NULL,
  TotalCost      DECIMAL(10,2) NOT NULL,
  DateOfBooking  DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
  IsCancelled    BIT NOT NULL DEFAULT(0)
);
 
-- Cancellations (50% refund)
CREATE TABLE dbo.Cancellations(
  CancelId         INT IDENTITY PRIMARY KEY,
  BookingId        INT NOT NULL UNIQUE FOREIGN KEY REFERENCES dbo.Bookings(BookingId),
  RefundAmount     DECIMAL(10,2) NOT NULL,
  DateOfCancellation DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME()
);
 
-- Seed: trains & classes
INSERT INTO dbo.Trains(TrainNo, TrainName, Source, Destination) VALUES
('17001','Golconda Exp','HYD','VJA'),
('12727','Godavari Exp','VSKP','HYD');
 
INSERT INTO dbo.TrainClasses(TrainId, ClassCode, AvailableSeats, Price)
SELECT TrainId,'SL',100,350 FROM dbo.Trains;
INSERT INTO dbo.TrainClasses(TrainId, ClassCode, AvailableSeats, Price)
SELECT TrainId,'3A',60,900 FROM dbo.Trains;
INSERT INTO dbo.TrainClasses(TrainId, ClassCode, AvailableSeats, Price)
SELECT TrainId,'2A',40,1300 FROM dbo.Trains;
 