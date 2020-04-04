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
