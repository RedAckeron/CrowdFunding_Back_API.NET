﻿CREATE TABLE [dbo].[Project]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	IdOwner INT NOT NULL,
	Title VARCHAR(50) NOT NULL,
	Description VARCHAR(150),
	Goal INT NOT NULL,
	BeginDate DATE NOT NULL,
	EndDate DATE NOT NULL,
	isValidate BIT DEFAULT 0 NOT NULL,
   
	FOREIGN KEY(IdOwner) REFERENCES [User]([Id])
)
