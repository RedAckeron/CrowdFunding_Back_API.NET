CREATE TABLE [dbo].[Project_Contributor]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	IdProject INT,
	IdUser INT NOT NULL,
	Amount INT,
	InsertDate DATE,

	FOREIGN KEY(IdUser) REFERENCES [User](Id),
	FOREIGN KEY(IdProject) REFERENCES Project(Id)

)