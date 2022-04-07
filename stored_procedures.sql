CREATE PROCEDURE SelectAllUsers
AS
BEGIN
SELECT * FROM userdetailsTable
END

exec SelectAllUsers

CREATE PROCEDURE SelectUser @id int
AS
BEGIN
SELECT * FROM userdetailsTable where u_id = @id
END

exec SelectUser 9

CREATE PROC InsertUser @name varchar(50), @dob date, @phone varchar(50)
as
begin
insert into userdetailsTable (u_name, u_DOB, u_phone)
values (@name, @dob, @phone)
end

exec InsertUser 'owotwst', '1998-06-02', '123456789'



CREATE PROC DeleteUser @id int
as
begin
delete from userdetailsTable where u_id = @id
end

exec DeleteUser 19


create proc UpdateUser @id int, @name varchar(50), @dob date, @phone varchar(50)
as
begin
update userdetailsTable set u_name=@name, u_DOB=@dob, u_phone=@phone where u_id = @id
end

exec UpdateUser 20, 'testingSP', '1989-05-21', '777777'



