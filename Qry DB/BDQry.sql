--CREACION BD SQLSERVER

CREATE DATABASE Triario;
go
USE Triario;
--CREACION TABLAS
CREATE TABLE Employee  
(  
 id_num int IDENTITY(1,1) not null, 
 CC int not null primary key,
 FName varchar (20),  
 LName varchar(30),
 EUser char(1),  
 Email varchar(50),
 Salary money,
 Fk_Department varchar(5)
);  

CREATE TABLE Department  
(  
 id_num int IDENTITY(1,1) not null, 
 Id_Department varchar(5) not null primary key,
 Name varchar (20),  
);  
go
--CREACION RELACION
ALTER TABLE Employee
ADD CONSTRAINT Fk_Department_Employee
FOREIGN KEY (Fk_Department) REFERENCES Department (Id_Department)
go

--INSERT DATA

INSERT INTO Department (Id_Department, Name)
  VALUES ('SIS21', 'SISTEMAS');
INSERT INTO Department (Id_Department, Name)
  VALUES ('COM21', 'COMERCIAL');
INSERT INTO Department (Id_Department, Name)
  VALUES ('PRO21', 'PRODUCCIÒN');
INSERT INTO Employee (CC, FName,LName,EUser,Email,Salary,Fk_Department)
  VALUES (23, 'PEPE','PEREZ','1','PEPE@HOTMAIL.COM',5000,'PRO21');
  INSERT INTO Employee (CC, FName,LName,EUser,Email,Salary,Fk_Department)
  VALUES (52, 'FULANO','DE TAL','1','FULANO@HOTMAIL.COM',1500,'PRO21');
  INSERT INTO Employee (CC, FName,LName,EUser,Email,Salary,Fk_Department)
  VALUES (80, 'PEDRO','PEREZ','1','PEDRO@HOTMAIL.COM',3000,'COM21');
  INSERT INTO Employee (CC, FName,LName,EUser,Email,Salary,Fk_Department)
  VALUES (100, 'JUAN','VALDEZ','1','JUAN@HOTMAIL.COM',1000,'PRO21');
  INSERT INTO Employee (CC, FName,LName,EUser,Email,Salary,Fk_Department)
  VALUES (30, 'LUISA','OCHOA','1','LUISA@HOTMAIL.COM',1800,'SIS21');
  INSERT INTO Employee (CC, FName,LName,EUser,Email,Salary,Fk_Department)
  VALUES (60, 'ALEJANDRO','PEREZ','2','ALEPE@HOTMAIL.COM',5000,'SIS21');
  go

create or alter PROCEDURE Create_Department 
	(
		@Id_Department VARCHAR(5),
		@Name VARCHAR(50)
	)
  AS
  BEGIN
	BEGIN TRANSACTION;
		BEGIN TRY
			INSERT INTO Department (Id_Department, Name)
				VALUES (@Id_Department, @Name);
			COMMIT TRANSACTION;
		 END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION;
		END CATCH;
  END
  GO
 -- execute Create_Department @Id_Department='holi',@Name='holi2'
  --select* from Department

create or alter PROCEDURE Search_Department 
	(
		@Id_Department VARCHAR(5)
	)
  AS
  BEGIN
	BEGIN TRANSACTION;
		BEGIN TRY
			SELECT * FROM  Department 
				WHERE Id_Department=@Id_Department
			COMMIT TRANSACTION;
		 END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION;
		END CATCH;
  END
  GO
  --execute Search_Department @Id_Department='holi'
 -- select* from Department
  
create or alter PROCEDURE Actualizate_Department 
	(
		@Id_Department VARCHAR(5),
		@Name VARCHAR(50)
	)
  AS
  BEGIN
	BEGIN TRANSACTION;
		BEGIN TRY
			UPDATE  Department 
				SET Name=@Name
				WHERE Id_Department=@Id_Department
			COMMIT TRANSACTION;
		 END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION;
		END CATCH;
  END
  GO
 -- execute Actualizate_Department @Id_Department='holi',@Name='holi6'
  --select* from Department

create or alter PROCEDURE Delete_Department 
	(
		@Id_Department VARCHAR(5)
	)
  AS
  BEGIN
	BEGIN TRANSACTION;
		BEGIN TRY
			DELETE FROM  Department 
				WHERE Id_Department=@Id_Department
			COMMIT TRANSACTION;
		 END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION;
		END CATCH;
  END
  GO
  --execute Delete_Department @Id_Department='holi'
 -- select* from Department

 ---------********////////********-------****//////////*******----------
 --procedures Employee

create or alter PROCEDURE Create_Employee
	(  
		@CC int,
		@FName varchar (20),  
		@LName varchar(30),
		@EUser char(1),  
		@Email varchar(50),
		@Salary money,
		@Fk_Department varchar(5)
	)
  AS
  BEGIN
	BEGIN TRANSACTION;
		BEGIN TRY
		  INSERT INTO Employee (CC, FName,LName,EUser,Email,Salary,Fk_Department)
		  VALUES (@CC, @FName,@LName,@EUser,@Email,@Salary,@Fk_Department);
			COMMIT TRANSACTION;
		 END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION;
		END CATCH;
  END
GO


create or alter PROCEDURE Search_Employee 
	(  
		@CC int
	)
	
  AS
  BEGIN
	BEGIN TRANSACTION;
		BEGIN TRY
			SELECT * FROM  Employee 
				WHERE CC=@CC;
			COMMIT TRANSACTION;
		 END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION;
		END CATCH;
  END
 -- execute Search_Employee 		@CC =23
 GO
create or alter PROCEDURE Actualizate_Employee 
	(  
		@CC int,
		@FName varchar (20),  
		@LName varchar(30),
		@EUser char(1),  
		@Email varchar(50),
		@Salary money,
		@Fk_Department varchar(5)
	)
  AS
  BEGIN
	BEGIN TRANSACTION;
		BEGIN TRY
			UPDATE  Employee 
				SET 
		FName=@FName ,  
		LName=@LName ,
		EUser=@EUser ,  
		Email=@Email ,
		Salary=@Salary ,
		Fk_Department=@Fk_Department
				WHERE cc=@cc
			COMMIT TRANSACTION;
		 END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION;
		END CATCH;
  END
GO
  --select* from Employee

create or alter PROCEDURE Delete_Employee 
	(  
		@CC int
	)
	
  AS
  BEGIN
	BEGIN TRANSACTION;
		BEGIN TRY
			DELETE  FROM  Employee 
				WHERE CC=@CC;
			COMMIT TRANSACTION;
		 END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION;
		END CATCH;
  END
  --execute Delete_Employee 		@CC =123
  --SELECT * FROM Employee
  GO
create or alter PROCEDURE Sum_Salary_Department (@Id_Department varchar(5))
  AS
  BEGIN
	BEGIN TRANSACTION;
		BEGIN TRY
			SELECT sum(Em.Salary) as Sum_Salary, dep.Id_Department FROM Employee as Em INNER JOIN Department as Dep 
			on Em.Fk_Department = Dep.Id_Department where dep.Id_Department=@Id_Department
			group by Dep.Id_Department 
			COMMIT TRANSACTION;
		 END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION;
		END CATCH;
END
GO
--EXEC Sum_Salary_Department "SIS21"

--select * from Department


--DROP DATABASE Triario


