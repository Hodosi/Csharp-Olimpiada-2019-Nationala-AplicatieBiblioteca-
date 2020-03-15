CREATE TABLE [dbo].[Imprumuturi]
(
	[IdImprumut] INT NOT NULL PRIMARY KEY IDENTITY, 
    [IdCititor] INT NULL, 
    [IdCarte] INT NULL, 
    [DataImprumut] DATETIME NULL, 
    [DataRestituire] DATETIME NULL
)
