CREATE TABLE [dbo].[Rezervari] (
    [IdRezervare]     INT      IDENTITY (1, 1) NOT NULL,
    [IdCititor]       INT      NULL,
    [IdCarte]         INT      NULL,
    [DataRezervare]   VARCHAR(50) NULL,
    [StatusRezervare] INT      NULL,
    PRIMARY KEY CLUSTERED ([IdRezervare] ASC)
);

