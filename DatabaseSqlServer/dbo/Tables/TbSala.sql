CREATE TABLE [dbo].[TbSala] (
    [IdSala]      INT           IDENTITY (1, 1) NOT NULL,
    [Nombre]      VARCHAR (50)  NOT NULL,
    [Descripcion] VARCHAR (255) NOT NULL,
    [CodUbigeo]   CHAR (6)      NOT NULL,
    [Zona]        VARCHAR (100) NOT NULL,
    [Direccion]   VARCHAR (255) NOT NULL,
    [Referencia]  VARCHAR (255) NOT NULL,
    [Activo]      BIT           CONSTRAINT [DF_TbSala_Activo] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_TbSala] PRIMARY KEY CLUSTERED ([IdSala] ASC)
);



