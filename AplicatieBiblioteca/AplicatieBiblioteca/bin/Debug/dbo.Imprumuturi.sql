CREATE TABLE [dbo].[Imprumuturi] (
    [IdImprumut]     INT      IDENTITY (1, 1) NOT NULL,
    [IdCititor]      INT      NULL,
    [IdCarte]        INT      NULL,
    [DataImprumut]   VARCHAR(50) NULL,
    [DataRestituire] VARCHAR(50) NULL,
    PRIMARY KEY CLUSTERED ([IdImprumut] ASC)
);

