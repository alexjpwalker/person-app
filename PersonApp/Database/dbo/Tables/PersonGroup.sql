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

	/* Primary key ensures records are unique and can be the target of JOIN queries and performant foreign keys. I give every table a primary key.
	Trailing comma is good for source control as a future modification won't have to touch this line */
	CONSTRAINT PK_PersonGroup_Id PRIMARY KEY (Id),
)
