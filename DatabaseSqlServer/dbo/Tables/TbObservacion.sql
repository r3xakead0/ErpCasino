CREATE TABLE [dbo].[TbObservacion] (
    [IdObservacion] INT           IDENTITY (1, 1) NOT NULL,
    [Nombre]        VARCHAR (50)  NOT NULL,
    [Descripcion]   VARCHAR (255) NOT NULL,
    [Activo]        BIT           NOT NULL,
    CONSTRAINT [PK_TbObservacion] PRIMARY KEY CLUSTERED ([IdObservacion] ASC)
);

