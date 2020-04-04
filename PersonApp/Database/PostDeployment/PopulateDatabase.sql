INSERT INTO dbo.PersonGroup (Name)
VALUES ('Group 1'), ('Group 2'), ('Group 3')
GO

/* Select IDs by name so that inserting People is independent of the auto-generated primary keys */
DECLARE @g1 INT = (SELECT Id FROM dbo.PersonGroup WHERE Name = 'Group 1')
DECLARE @g2 INT = (SELECT Id FROM dbo.PersonGroup WHERE Name = 'Group 2')
DECLARE @g3 INT = (SELECT Id FROM dbo.PersonGroup WHERE Name = 'Group 3')

/* My personal preference is to make the VALUES line up */
INSERT INTO dbo.Person (FirstName, LastName, PersonGroupId)
VALUES ('Graham', 'Chapman', @g1),
       ('John', 'Cleese', @g2),
	   ('Terry', 'Gilliam', @g3),
	   ('Terry', 'Jones', @g1),
	   ('Eric', 'Idle', @g2),
	   ('Michael', 'Palin', @g2)
GO
