CREATE TABLE [dbo].[TbTipo] (
    [IdTipo]      INT           IDENTITY (1, 1) NOT NULL,
    [Nombre]      VARCHAR (50)  NOT NULL,
    [Descripcion] VARCHAR (255) NOT NULL,
    [Activo]      BIT           NOT NULL,
    CONSTRAINT [PK_TbTipo] PRIMARY KEY CLUSTERED ([IdTipo] ASC)
);

