INSERT INTO dbo.PersonGroup (Name)
VALUES ('Group 1'), ('Group 2'), ('Group 3')
GO

/* My personal preference is to make the VALUES line up. */
INSERT INTO dbo.Person (FirstName, LastName, PersonGroupId)
VALUES ('Graham', 'Chapman', 1),
       ('John', 'Cleese', 2),
	   ('Terry', 'Gilliam', 3),
	   ('Terry', 'Jones', 1),
	   ('Eric', 'Idle', 2),
	   ('Michael', 'Palin', 2)
GO
