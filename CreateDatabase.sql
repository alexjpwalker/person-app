DROP DATABASE IF EXISTS CrunchyFrog
GO

/* All object names are in PascalCase by SQL Server convention. */
CREATE DATABASE [CrunchyFrog]
 CONTAINMENT = NONE
 ON PRIMARY 
( NAME = N'CrunchyFrog', FILENAME = N'F:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\CrunchyFrog.mdf' , SIZE = 8192KB , FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CrunchyFrog_log', FILENAME = N'F:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\CrunchyFrog_log.ldf' , SIZE = 8192KB , FILEGROWTH = 65536KB )
GO

USE CrunchyFrog
GO

IF NOT EXISTS (SELECT name FROM sys.filegroups WHERE is_default=1 AND name = N'PRIMARY') ALTER DATABASE [CrunchyFrog] MODIFY FILEGROUP [PRIMARY] DEFAULT
GO

/* Table name is the type of object stored in the table (a group of people), not pluralized.
I call it PersonGroup because 'Group' could rapidly become ambiguous as we add new tables. */
CREATE TABLE dbo.PersonGroup (
	/*
		- Id: All table primary keys will be named Id for consistency.
		- INT: lightweight (hence performant) and I'm not expecting us to have 2 billion PersonGroups anytime soon.
		- IDENTITY(1,1): allows us to "blindly" INSERT without needing to know about the existing data.
	*/
	Id INT IDENTITY(1,1) NOT NULL,
	/*
		- VARCHAR(50): VARCHAR instead of CHAR because we expect names to be "up to 50 characters", not "exactly 50 characters".
		VARCHAR instead of NVARCHAR because we don't really need Unicode.
		- UQ_PersonGroup_Name: [constraint type]_[table]_[column] by convention with UQ meaning UNIQUE
	*/
	Name VARCHAR(50) NOT NULL CONSTRAINT UQ_PersonGroup_Name UNIQUE,
	/*
		- CreatedDate: [action] + 'Date' for a date column (to describe it & make clear that it is a date)
		- DATETIME2: general purpose object that can represent pretty well any date we'd care about. DEFAULT is the insertion date.
		- GETDATE: the insertion date. By specifying this default, we can write INSERT queries without specifying CreatedDate.
	*/
	CreatedDate DATETIME2 NOT NULL CONSTRAINT DF_PersonGroup_CreatedDate DEFAULT GETDATE(),

	/* Primary key ensures records are unique and can be the target of JOIN queries and performant foreign keys. I give every table a primary key. */
	CONSTRAINT PK_PersonGroup_Id PRIMARY KEY (Id),
)
GO

CREATE TABLE dbo.Person (
	Id INT IDENTITY(1,1) NOT NULL,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	CreatedDate DATETIME2 NOT NULL CONSTRAINT DF_Person_CreatedDate DEFAULT GETDATE(),

	/* For a foreign key relation, we use the foreign table name + 'Id'. */
	PersonGroupId INT NOT NULL,

	CONSTRAINT PK_Person_Id PRIMARY KEY (Id),

	/* Ensure that each Person is mapped to a genuine PersonGroup, and also block PersonGroups from being deleted when they have People */
	CONSTRAINT FK_Person_PersonGroup FOREIGN KEY (PersonGroupId) REFERENCES dbo.PersonGroup (Id)
)
GO

INSERT INTO dbo.PersonGroup (Name)
VALUES ('Group 1'), ('Group 2'), ('Group 3')
GO

INSERT INTO dbo.Person (FirstName, LastName, PersonGroupId)
VALUES ('Graham', 'Chapman', 1),
       ('John', 'Cleese', 2),
	   ('Terry', 'Gilliam', 3),
	   ('Terry', 'Jones', 1),
	   ('Eric', 'Idle', 2),
	   ('Michael', 'Palin', 2)
GO
