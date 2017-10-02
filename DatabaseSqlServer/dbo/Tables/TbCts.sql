CREATE TABLE [dbo].[TbCts] (
    [IdCts]               INT            IDENTITY (1, 1) NOT NULL,
    [FechaDeposito]       DATE           NOT NULL,
    [CodigoEmpleado]      VARCHAR (10)   NOT NULL,
    [Monto]               DECIMAL (9, 4) NOT NULL,
    [FechaPeriodoInicial] DATE           NOT NULL,
    [FechaPeriodoFinal]   DATE           NOT NULL,
    CONSTRAINT [PK_TbCts] PRIMARY KEY CLUSTERED ([IdCts] ASC)
);

