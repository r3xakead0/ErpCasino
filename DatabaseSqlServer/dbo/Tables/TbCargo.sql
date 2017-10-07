CREATE TABLE [dbo].[TbCargo] (
    [IdCargo]     INT            IDENTITY (1, 1) NOT NULL,
    [Nombre]      VARCHAR (50)   NOT NULL,
    [Descripcion] VARCHAR (255)  NOT NULL,
    [Activo]      BIT            NOT NULL,
    [Bono]        DECIMAL (9, 2) NOT NULL,
    CONSTRAINT [PK_TbCargo] PRIMARY KEY CLUSTERED ([IdCargo] ASC)
);





