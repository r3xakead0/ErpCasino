CREATE TABLE [dbo].[TbPrestamoCuota] (
    [IdPrestamoCuota] INT            IDENTITY (1, 1) NOT NULL,
    [IdPrestamo]      INT            NOT NULL,
    [Fecha]           DATE           NOT NULL,
    [Monto]           DECIMAL (9, 2) NOT NULL,
    [Pagado]          BIT            NOT NULL,
    CONSTRAINT [PK_TbPrestamoCuota] PRIMARY KEY CLUSTERED ([IdPrestamoCuota] ASC)
);

