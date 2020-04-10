BD
-- Create Database
create database HealthDB;
go
use HealthDB;
go

--Create Users table
create table Users(
	Id int identity(1,1) primary key not null,
	Name varchar(50) not null,
	Email varchar(50) not null,
	AvatarUrl varchar(255) null,
	Password varchar(50) null,
	Rol int not null,
);


--Create Sickness table
create table Sickness(
	Id int identity(1,1) primary key not null,
	Name varchar(255) not null,
	ScientificNotation varchar(255) null,
	Description varchar(255) null,
	ImageUrl varchar(255) null
);

--Create MedicalHistory table
create table MedicalHistory(
	Id int identity(1,1) primary key not null,
	UserId int not null,
	Description varchar(300) null,
	Diagnostic varchar(300) not null,
	Treatment varchar(300) not null,
	AppointmentDate Date null,
	constraint FK_Users_MedicalHistory foreign key (UserId) references Users(Id),
);

-----Create Wellness table
create table Wellness(
	Id int identity(1,1) primary key not null,
	UserId int not null,
	checkBasketball BIT DEFAULT 0,
	checkSwimming BIT DEFAULT 0,
	checkRunning BIT DEFAULT 0,
	checkRugby BIT DEFAULT 0,
	constraint FK_Users_Wellness foreign key (UserId) references Users(Id),
);

create table UserSickness(
	Id int identity(1,1) primary key not null,
	UserId int not null,
	SicknessId int not null,
	constraint FK_User_UserSickness foreign key (USerId) references Users(Id),
	constraint FK_Sickness_UserSickness foreign key (SicknessId) references Sickness(Id)
);


insert into Users(Name, Email, AvatarUrl, Password, Rol)
values('Doctor Cool', 'drCool@medical.com', 'img_avatar.png','1', 1);