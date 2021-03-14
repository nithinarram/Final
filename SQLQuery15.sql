select * from Menu;
select * from OrderedFood;
truncate table OrderedFood;
delete from Branch where branchid=2;
create table Cart (Id int identity(1,1) NOT NULL primary key,Fooditems varchar(50),Price int,Quantity int,Rname varchar(50),foreign key(Rname) references Restaurant(Rname));