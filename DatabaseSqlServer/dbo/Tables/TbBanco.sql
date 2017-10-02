CREATE TABLE [dbo].[TbBanco] (
    [IdBanco]     INT           IDENTITY (1, 1) NOT NULL,
    [Codigo]      VARCHAR (10)  NOT NULL,
    [Nombre]      VARCHAR (50)  NOT NULL,
    [Descripcion] VARCHAR (255) NOT NULL,
    [Activo]      BIT           NOT NULL,
    CONSTRAINT [PK_TbBanco] PRIMARY KEY CLUSTERED ([IdBanco] ASC)
);

