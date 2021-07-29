CREATE TABLE [dbo].[StudentsInfoTable]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [FamilyName] NVARCHAR(50) NOT NULL, 
    [DateOfBirth] DATETIME NOT NULL, 
    [GeneralGrade] INT NOT NULL, 
    [Nationality] NVARCHAR(50) NOT NULL
)
