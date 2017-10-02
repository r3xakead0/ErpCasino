CREATE TABLE [dbo].[TbArea] (
    [IdArea]      INT           IDENTITY (1, 1) NOT NULL,
    [Nombre]      VARCHAR (50)  NOT NULL,
    [Descripcion] VARCHAR (255) NOT NULL,
    [Activo]      BIT           NOT NULL,
    CONSTRAINT [PK_TbArea] PRIMARY KEY CLUSTERED ([IdArea] ASC)
);

