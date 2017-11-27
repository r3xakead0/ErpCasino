CREATE TABLE [dbo].[TbVacacion] (
    [IdVacacion]             INT            IDENTITY (1, 1) NOT NULL,
    [PeriodoFechaInicial]    DATE           NOT NULL,
    [PeriodoFechaFinal]      DATE           NOT NULL,
    [FechaInicial]           DATE           NOT NULL,
    [FechaFinal]             DATE           NOT NULL,
    [Dias]                   TINYINT        NOT NULL,
    [CodigoEmpleado]         VARCHAR (10)   NOT NULL,
    [Sueldo]                 DECIMAL (9, 2) NOT NULL,
    [AsignacionFamiliar]     DECIMAL (9, 2) NOT NULL,
    [PromedioHorasExtras]    DECIMAL (9, 2) NOT NULL,
    [PromedioBonificacion]   DECIMAL (9, 2) NOT NULL,
    [Redondeo]               DECIMAL (9, 2) NOT NULL,
    [TotalBruto]             DECIMAL (9, 2) NOT NULL,
    [idAfpComision]          INT            NULL,
    [ComisionAfp]            VARCHAR (10)   NULL,
    [idOnpComision]          INT            NULL,
    [PensionMonto]           DECIMAL (9, 2) NOT NULL,
    [RetencionJudicialMonto] DECIMAL (9, 2) NOT NULL,
    [TotalDescuento]         DECIMAL (9, 2) NOT NULL,
    [TotalNeto]              DECIMAL (9, 2) NOT NULL,
    CONSTRAINT [PK_TbVacacion] PRIMARY KEY CLUSTERED ([IdVacacion] ASC)
);






GO



GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'0.00% al 100.00%', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TbVacacion', @level2type = N'COLUMN', @level2name = N'idAfpComision';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Categorias del Tipo 5 (Comision de AFP)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TbVacacion', @level2type = N'COLUMN', @level2name = N'ComisionAfp';

