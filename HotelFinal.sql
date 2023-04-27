create database final 
use final

select *from hotel
select *from Customer
select *from Employee1
select *from Rooms
select *from Admin
select *from Booking

alter table Rooms add RoomStatus varchar(10)
update Rooms set RoomStatus='Booked' where Room_No IN(1,2,3)
update Rooms set RoomStatus='Available' where Room_No IN(4,5)


create table hotel(Hotel_Id int primary key identity(1,1), Hotel_Name varchar(20), Hotel_Address varchar(30),Pincode int)
insert into hotel values ('Ramlella','Ratu Road',834006), 
('Bluee','Belapur',400603),
('Time Square','Thane',700603),
('Highland','DnChowk',834009),
('Maharaja','Lalpur',831212)

create table Customer(Customer_Id int primary key identity(1,1),Customer_Name varchar(20), Customer_DOB date,Customer_Address varchar(20),Customer_Contact int, Customer_Email varchar(20))

insert into Customer values 
('Ram','2-10-1958','New Delhi',960896,'Ram@gmail.com'),
('Rahul','3-11-2001','Mumbai',960897,'Rahul@gmail.com'),
('Moli','4-12-1993','Noida',960898,'Moli@gmail.com'),
('Apurva','5-13-1953','Srinagar',960889,'Apurva@gmail.com'),
('Sam','6-14-1978','Pune',860896,'Sam@gmail.com') 

alter table Customer add Age int 
update Customer
set Age = datediff(YY, Customer_DOB, getdate())

create table Employee1(Emp_Id int primary key identity(1,1),Emp_Name varchar(20),Emp_Grade varchar(20),Hotel_Id int foreign key references hotel(Hotel_Id))
insert into Employee1 values
('Kashish','Grade1',1),
('Harshit','Grade2',2),
('Nitya','Grade2',3),
('Shivani','Grade1',4),
('Reman','Grade1',5)

create table Rooms(Room_No int primary key identity(1,1),Room_Type varchar(20),Room_Price float, Hotel_Id int foreign key references hotel(Hotel_Id))
insert into Rooms values
('Deluxe',3000,1),
('Non-Ac',1800,2),
('Ac',2000,3),
('Deluxe',3000,4),
('Non-Ac',1800,5)

create table Admin(Admin_Id int  primary key identity(1,1),Admin_Name varchar(20), Admin_Type varchar(20))
insert into Admin values
('Piyush','Receptinist'),
('Vartika','Manager'),
('Harsh','Manager'),
('Simran','Receptinist'),
('Astha','Manager')
alter table Admin add Password varchar(15)
update Admin set Password='admin123'

create table Booking(DateOfBooking date)
insert into Booking values
('03-05-2023'),
('05-10-2023'),
('04-15-2023'),
('06-22-2023'),
('03-11-2023') 

alter table Booking add Room_No int foreign Key References Rooms (Room_No)
alter table Booking add Customer_Id int foreign Key References Customer(Customer_Id)

update Booking set Room_No=1,Customer_Id=1 where DateOfBooking='2023-03-05'
update Booking set Room_No=2,Customer_Id=2 where DateOfBooking='2023-05-10'
update Booking set Room_No=3,Customer_Id=3 where DateOfBooking='2023-04-15'
update Booking set Room_No=4,Customer_Id=4 where DateOfBooking='2023-06-22'
update Booking set Room_No=5,Customer_Id=5 where DateOfBooking='2023-03-11' 

alter table Booking add BookingId int primary key identity(101,1)

alter table hotel add Emp_Id int foreign Key References Employee1(Emp_Id)
alter table hotel add Customer_Id int foreign Key References Customer(Customer_Id)

update hotel set Emp_id=1 where Hotel_Id=1
update hotel set Emp_id=2 where Hotel_Id=2
update hotel set Emp_id=3 where Hotel_Id=3
update hotel set Emp_id=4 where Hotel_Id=4
update hotel set Emp_id=5 where Hotel_Id=5

update hotel set Customer_Id=1 where Hotel_Id=1
update hotel set Customer_Id=2 where Hotel_Id=2
update hotel set Customer_Id=3 where Hotel_Id=3
update hotel set Customer_Id=4 where Hotel_Id=4
update hotel set Customer_Id=5 where Hotel_Id=5

alter table Employee1 add emppass varchar(15)

update Employee1 set emppass='kas123' where Emp_Id=1
update Employee1 set emppass='har123' where Emp_Id=2
update Employee1 set emppass='nit123' where Emp_Id=3
update Employee1 set emppass='shi123' where Emp_Id=4
update Employee1 set emppass='rem123' where Emp_Id=5

alter table Customer add custpass varchar(15)
update Customer set custpass='ram123' where Customer_Id=1
update Customer set custpass='rah123' where Customer_Id=2
update Customer set custpass='mol123' where Customer_Id=3
update Customer set custpass='apu123' where Customer_Id=4
update Customer set custpass='sam123' where Customer_Id=5

