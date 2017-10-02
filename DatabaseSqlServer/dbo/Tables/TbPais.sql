CREATE TABLE [dbo].[TbPais] (
    [CodPais]   CHAR (3)     CONSTRAINT [DF_TbPais_Codigo] DEFAULT ('Codigo unico ISO-3') NOT NULL,
    [Nombre]    VARCHAR (50) NOT NULL,
    [Name]      VARCHAR (50) NOT NULL,
    [Nom]       VARCHAR (50) NOT NULL,
    [Iso2]      CHAR (2)     NOT NULL,
    [PhoneCode] VARCHAR (10) NULL,
    CONSTRAINT [PK_TbPais] PRIMARY KEY CLUSTERED ([CodPais] ASC)
);



