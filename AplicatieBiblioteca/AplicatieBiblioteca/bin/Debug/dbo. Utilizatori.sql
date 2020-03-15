CREATE TABLE [dbo].[Utilizatori]
(
	[IdUtilizator] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TipUtilizator] INT NULL, 
    [NumePrenume] VARCHAR(50) NULL, 
    [Email] VARCHAR(30) NULL, 
    [Parola] VARCHAR(30) NULL
)
