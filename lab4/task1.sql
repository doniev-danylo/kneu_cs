-- create schema
create schema DreamHomeDB
go

exec sp_addextendedproperty 'MS_Description', 'lab4_apbd_kneu', 'SCHEMA', 'DreamHomeDB'
go
;

-- create tables
create table DreamHomeDB.Branch
(
    Bno    int,
    Street varchar(32),
    Area   varchar(32),
    City   varchar(32),
    Pcode  varchar(32),
    Tel_No varchar(32),
    Fax_No varchar(32),
)
go

create table DreamHomeDB.Staff
(
    Sno      int,
    FName    nvarchar(50),
    LName    nvarchar(50),
    Address  nvarchar(100),
    Tel_No   nvarchar(15),
    Position nvarchar(50),
    Sex      char(1),
    DOB      date,
    Salary   decimal(10, 2),
    NIN      nvarchar(15),
    Bno      int
)
go
create table DreamHomeDB.Property_for_Rent
(
    Pno    int,
    Street nvarchar(100),
    Area   nvarchar(50),
    City   nvarchar(50),
    Pcode  nvarchar(10),
    Type   nvarchar(50),
    Rooms  int,
    Rent   decimal(10, 2),
    Ono    int,
    Sno    int,
    Bno    int
)
go
create table DreamHomeDB.Renter
(
    Rno       int,
    FName     nvarchar(50),
    LName     nvarchar(50),
    Address   nvarchar(100),
    Tel_No    nvarchar(15),
    Pref_Type nvarchar(50),
    Max_Rent  decimal(10, 2),
    Bno       int
)
go
create table DreamHomeDB.Owner
(
    Ono     int,
    FName   nvarchar(50),
    LName   nvarchar(50),
    Address nvarchar(100),
    Tel_No  nvarchar(15)
)
go
create table DreamHomeDB.Viewing
(
    Rno     int,
    Pno     int,
    [Date]  date,
    Comment nvarchar(256)
)
go
;
-- set primary keys
alter table DreamHomeDB.Branch
    alter column Bno int not null
go

alter table DreamHomeDB.Branch
    add constraint Branch_pk
        primary key (Bno)
go

alter table DreamHomeDB.Owner
    alter column Ono int not null
go

alter table DreamHomeDB.Owner
    add constraint Owner_pk
        primary key (Ono)
go

alter table DreamHomeDB.Property_for_Rent
    alter column Pno int not null
go

alter table DreamHomeDB.Property_for_Rent
    add constraint Property_for_Rent_pk
        primary key (Pno)
go

alter table DreamHomeDB.Renter
    alter column Rno int not null
go

alter table DreamHomeDB.Renter
    add constraint Renter_pk
        primary key (Rno)
go

alter table DreamHomeDB.Staff
    alter column Sno int not null
go

alter table DreamHomeDB.Staff
    add constraint Staff_pk
        primary key (Sno)
go
;
-- insert test values 
-- Inserting data into DreamHomeDB.Branch table
insert into DreamHomeDB.Branch(Bno, Street, Area, City, Pcode, Tel_No, Fax_No)
values (1, '123 St', '#01', 'CityA', 'PC1', '1234567890', '0987654321'),
       (2, '456 St', '#02', 'CityB', 'PC2', '2345678901', '1098765432'),
       (3, '789 St', '#03', 'CityC', 'PC3', '3456789012', '2109876543')


-- Inserting data into DreamHomeDB.Staff table
insert into DreamHomeDB.Staff(Sno, FName, LName, Address, Tel_No, Position, Sex, DOB, Salary, NIN, Bno)
values (1, 'Alice', 'Brown', 'Street #1', '1235486789', 'Manager', 'F', '1991-01-01', 5000.00, 'AB123456C', 1),
       (2, 'Bob', 'Smith', 'Street #2', '3456789101', 'Assistant', 'M', '1992-02-02', 3000.00, 'BS234567D', 2),
       (3, 'Charlie', 'Green', 'Street #3', '5678910234', 'Clerk', 'M', '1993-03-03', 2000.00, 'CG345678E', 3)


-- Inserting data into DreamHomeDB.Property_for_Rent table
insert into DreamHomeDB.Property_for_Rent(Pno, Street, Area, City, Pcode, Type, Rooms, Rent, Ono, Sno, Bno)
values (1, 'Street #1', 'Area1', 'CityA', 'PC1', 'Flat', 2, 200.00, 1, 1, 1),
       (2, 'Street #2', 'Area2', 'CityB', 'PC2', 'House', 3, 300.00, 2, 2, 2),
       (3, 'Street #3', 'Area3', 'CityC', 'PC3', 'Bungalow', 4, 400.00, 3, 3, 3)


-- Inserting data into DreamHomeDB.Renter table
insert into DreamHomeDB.Renter(Rno, FName, LName, Address, Tel_No, Pref_Type, Max_Rent, Bno)
values (1, 'Don', 'Black', 'Street #4', '7891023456', 'Flat', 500.00, 1),
       (2, 'Emma', 'White', 'Street #5', '9102345678', 'House', 600.00, 2),
       (3, 'Frank', 'Gray', 'Street #6', '0123456789', 'Bungalow', 700.00, 3)


-- Inserting data into DreamHomeDB.Owner table
insert into DreamHomeDB.Owner(Ono, FName, LName, Address, Tel_No)
values (1, 'Gary', 'Purple', 'Street #7', '2345678901'),
       (2, 'Helen', 'Pink', 'Street #8', '5678901234'),
       (3, 'Ian', 'Orange', 'Street #9', '9012345678')


-- Inserting data into DreamHomeDB.Viewing table
insert into DreamHomeDB.Viewing(Rno, Pno, [Date], Comment)
values (1, 1, '2020-01-01', 'Nice property'),
       (2, 2, '2020-02-02', 'Good location'),
       (3, 3, '2020-03-03', 'Well maintained')


go;


-- Скласти список імен всіх клієнтів, які вже оглянули хоча б один об'єкт, що здається в оренду, і повідомили свою думку з цього приводу.
select R.FName as FirstName, R.LName as LastName, V.Comment
from DreamHomeDB.Renter R
         inner join DreamHomeDB.Viewing V on R.Rno = V.Rno
where V.Comment is not null;

-- Перелічити відділення компанії і об'єкти, що здаються в оренду, які розташовані в одному і тому ж місті, а також інші відділення компанії.
select B.Bno as BranchNumber, B.City as BranchCity, P.Pno as PropertyNumber, P.City as PropertyCity
from DreamHomeDB.Branch B
         left join DreamHomeDB.Property_for_Rent P on B.City = P.City;

-- Перелічити відділення компанії і об'єкти, що здаються в оренду, які розташовані в одному і тому ж місті, а також всі інші об'єкти.
select B.Bno as BranchNumber, B.City as BranchCity, P.Pno as PropertyNumber, P.City as PropertyCity
from DreamHomeDB.Property_for_Rent P
         left join DreamHomeDB.Branch B on B.City = P.City;

-- Перелічити відділення компанії і об'єкти, що здаються в оренду, розташовані в одному і тому ж місті, а також всі інші відділення і об'єкти.
select B.Bno as BranchNumber, B.City as BranchCity, P.Pno as PropertyNumber, P.City as PropertyCity
from DreamHomeDB.Branch B
         full join DreamHomeDB.Property_for_Rent P on B.City = P.City;


