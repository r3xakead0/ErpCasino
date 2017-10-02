CREATE TABLE [dbo].[TbCategoria] (
    [IdCategoria] INT          IDENTITY (1, 1) NOT NULL,
    [IdTipo]      INT          NOT NULL,
    [Codigo]      VARCHAR (10) NOT NULL,
    [Nombre]      VARCHAR (50) NOT NULL,
    [Activo]      BIT          NOT NULL,
    CONSTRAINT [PK_TbCategoria] PRIMARY KEY CLUSTERED ([IdCategoria] ASC),
    CONSTRAINT [FK_TbCategoria_TbTipo] FOREIGN KEY ([IdTipo]) REFERENCES [dbo].[TbTipo] ([IdTipo])
);



