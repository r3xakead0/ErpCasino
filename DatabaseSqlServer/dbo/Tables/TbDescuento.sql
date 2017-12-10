CREATE TABLE [dbo].[TbDescuento] (
    [IdDescuento] INT            IDENTITY (1, 1) NOT NULL,
    [Nombre]      VARCHAR (50)   NOT NULL,
    [Descripcion] VARCHAR (255)  NOT NULL,
    [Monto]       DECIMAL (9, 2) NOT NULL,
    [Calculado]   BIT            CONSTRAINT [DF_TbDescuento_Calculado] DEFAULT ((0)) NOT NULL,
    [Activo]      BIT            NOT NULL,
    CONSTRAINT [PK_TbDescuento] PRIMARY KEY CLUSTERED ([IdDescuento] ASC)
);



