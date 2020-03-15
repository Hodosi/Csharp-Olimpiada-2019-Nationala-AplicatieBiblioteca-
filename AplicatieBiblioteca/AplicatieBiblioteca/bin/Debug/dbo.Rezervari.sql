CREATE TABLE [dbo].[Rezervari]
(
	[IdRezervare] INT NOT NULL PRIMARY KEY IDENTITY, 
    [IdCititor] INT NULL, 
    [IdCarte] INT NULL, 
    [DataRezervare] DATETIME NULL, 
    [StatusRezervare] INT NULL
)
