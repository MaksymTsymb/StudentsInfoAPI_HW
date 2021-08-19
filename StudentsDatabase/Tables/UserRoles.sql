﻿CREATE TABLE [dbo].[UserRoles]
(
	[UserId] UNIQUEIDENTIFIER NOT NULL,
	[RoleId] UNIQUEIDENTIFIER NOT NULL,
	FOREIGN KEY (UserId) REFERENCES Users(Id),
	FOREIGN KEY (RoleId) REFERENCES Roles(RoleId),
	CONSTRAINT PK_UserRoles PRIMARY KEY CLUSTERED (UserId, RoleId)
)
