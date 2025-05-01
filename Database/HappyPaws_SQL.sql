create database HappyPaws
use HappyPaws

Create table Contact(
ContactId int primary key identity(1,1) not null,
Name varchar(50),
Email varchar(50),
Subject varchar(100),
Message varchar(Max)
);

select * from Contact;

Create table Location(
LocationId int primary key identity(1,1),
LocationName varchar(50)
);

INSERT into Location VALUES ('Barishal')
					
INSERT into Location VALUES ('Brahmanbaria')

INSERT into Location VALUES ('Chandpur')

INSERT into Location VALUES ('Chittagong')

INSERT into Location VALUES ('Dinajpur')

INSERT into Location VALUES ('Dhaka')

INSERT into Location VALUES ('Faridpur')

INSERT into Location VALUES ('Jessore')

INSERT into Location VALUES ('Khulna')

INSERT into Location VALUES ('Mymensingh')

INSERT into Location VALUES ('Narayanganj')

INSERT into Location VALUES ('Noakhali')

INSERT into Location VALUES ('Rajshahi')

INSERT into Location VALUES ('Rangpur')

INSERT into Location VALUES ('Sylhet');

select * from Location;


Create table [User](
UserId int primary key identity(1,1),
Username varchar(50),
Password varchar(50),
Name varchar(50),
Email varchar(50),
Mobile varchar(50),
Address varchar(Max),
Location varchar(50)
);

Alter table [User]
add unique (Username);


select * from [User];


Create table AdoptPet(
AdoptId int primary key identity(1,1),
PetBreed varchar(50),
NoOfPet int,
Description varchar(MAX),
Gender varchar(50),
Age varchar(50),
Price varchar(50),
PetType varchar(50),
OwnerName varchar(200),
PetImage varchar(500),
Location varchar(50),
Mobile varchar(50),
Address varchar(MAX),
CreateDate datetime
);

select * from AdoptPet;


Create table RequestPets(
RequestPetID int primary key identity(1,1),
UserID int,
AdoptId int
);

select * from RequestPets;

Create table VetAppointment(
AppointmentID int primary key identity(1,1),
PetBreed varchar(50),
NoOfPet int,
Age varchar(50),
Description varchar(MAX),
Location varchar(50),
OwnerName varchar(200),
Mobile varchar(50),
CreateDate datetime
);

select * from VetAppointment



Create table Bookings(
BookingID int primary key identity(1,1),
PetBreed varchar(50),
NoOfPet int,
Age varchar(50),
PetType varchar(50),
OwnerName varchar(200),
Mobile varchar(50),
Location varchar(50),
CreateDate datetime
);

select * from Bookings;




Create table Employee(
EmployeeID int primary key identity(1,1),
Username varchar(50) unique,
Password varchar(50),
Name varchar(50),
Gender varchar(50),
Email varchar(50),
Mobile varchar(50),
Location varchar(50),
Address varchar(MAX),
CreateDate datetime
);

select * from Employee;

