CREATE TABLE [dbo].[TbAfp] (
    [IdAfp]       INT           IDENTITY (1, 1) NOT NULL,
    [Codigo]      VARCHAR (10)  NOT NULL,
    [Nombre]      VARCHAR (50)  NOT NULL,
    [Descripcion] VARCHAR (255) NOT NULL,
    [Activo]      BIT           NOT NULL,
    CONSTRAINT [PK_TbAfp] PRIMARY KEY CLUSTERED ([IdAfp] ASC)
);

