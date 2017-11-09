CREATE TABLE [dbo].[TbPlanillaDetalleResumen] (
    [IdPlanillaDetalleResumen] INT            IDENTITY (1, 1) NOT NULL,
    [IdPlanilla]               INT            NOT NULL,
    [CodigoEmpleado]           VARCHAR (10)   NOT NULL,
    [SueldoBase]               DECIMAL (9, 2) NOT NULL,
    [SueldoBruto]              DECIMAL (9, 2) NOT NULL,
    [Pension]                  DECIMAL (9, 2) NOT NULL,
    [Impuesto]                 DECIMAL (9, 2) NOT NULL,
    [SueldoNeto]               DECIMAL (9, 2) NOT NULL,
    [Deduccion]                DECIMAL (9, 2) NOT NULL,
    [SueldoPago]               DECIMAL (9, 2) NOT NULL,
    CONSTRAINT [PK_TbPlanillaDetalleResumen] PRIMARY KEY CLUSTERED ([IdPlanillaDetalleResumen] ASC),
    CONSTRAINT [FK_TbPlanillaDetalleResumen_TbPlanilla] FOREIGN KEY ([IdPlanilla]) REFERENCES [dbo].[TbPlanilla] ([IdPlanilla]) ON DELETE CASCADE
);



