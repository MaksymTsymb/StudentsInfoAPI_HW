/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
DECLARE @adminId UNIQUEIDENTIFIER = NEWID()
INSERT INTO Users
VALUES (@adminId, 'Admin', 'Alexandr', 'Brulov', '1970-03-02', 'nAmXe6fEw67i35vHRcLc1S7tFqMxT3yBe7QHpAzxoAw=');

DECLARE @studentId UNIQUEIDENTIFIER = NEWID()
INSERT INTO Users
VALUES (@studentId, 'Student', 'Vasya', 'Pupkin', '1990-05-04', 'nAmXe6fEw67i35vHRcLc1S7tFqMxT3yBe7QHpAzxoAw=');

DECLARE @adminStudentId UNIQUEIDENTIFIER = NEWID()
INSERT INTO Users
VALUES (@adminStudentId, 'AdminStudent', 'Izya', 'Fomin', '1995-12-03', 'nAmXe6fEw67i35vHRcLc1S7tFqMxT3yBe7QHpAzxoAw=');


DECLARE @adminRoleId UNIQUEIDENTIFIER = NEWID()
INSERT INTO Roles
VALUES (@adminRoleId, 'Administrator')

DECLARE @studentRoleId UNIQUEIDENTIFIER = NEWID()
INSERT INTO Roles
VALUES (@studentRoleId, 'Student')


INSERT INTO UserRoles
VALUES (@adminId, @adminRoleId)

INSERT INTO UserRoles
VALUES (@studentId, @studentRoleId)

INSERT INTO UserRoles
VALUES (@adminStudentId, @adminRoleId)

INSERT INTO UserRoles
VALUES (@adminStudentId, @studentRoleId)