CREATE TABLE [dbo].[TbPrestamo] (
    [IdPrestamo]     INT            IDENTITY (1, 1) NOT NULL,
    [Fecha]          DATE           NOT NULL,
    [CodigoEmpleado] VARCHAR (10)   NOT NULL,
    [Motivo]         VARCHAR (255)  NOT NULL,
    [Monto]          DECIMAL (9, 2) NOT NULL,
    [Cuotas]         INT            NOT NULL,
    [Pagado]         BIT            NOT NULL,
    CONSTRAINT [PK_TbPrestamo] PRIMARY KEY CLUSTERED ([IdPrestamo] ASC)
);

