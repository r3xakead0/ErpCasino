CREATE TABLE [dbo].[TbDescuentoEmpleado] (
    [IdDescuentoEmpleado] INT            IDENTITY (1, 1) NOT NULL,
    [Fecha]               DATE           NOT NULL,
    [CodigoEmpleado]      VARCHAR (10)   NOT NULL,
    [IdDescuento]         INT            NOT NULL,
    [Motivo]              VARCHAR (255)  NOT NULL,
    [Monto]               DECIMAL (9, 2) NOT NULL,
    CONSTRAINT [PK_TbDescuentoEmpleado] PRIMARY KEY CLUSTERED ([IdDescuentoEmpleado] ASC)
);

