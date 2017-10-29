CREATE TABLE [dbo].[TbVacacion] (
    [IdVacacion]                 INT            IDENTITY (1, 1) NOT NULL,
    [PeriodoFechaInicial]        DATE           NOT NULL,
    [PeriodoFechaFinal]          DATE           NOT NULL,
    [PeriodoDias]                TINYINT        NOT NULL,
    [VacacionFechaInicial]       DATE           NOT NULL,
    [VacacionFechaFinal]         DATE           NOT NULL,
    [VacacionDias]               TINYINT        NOT NULL,
    [EmpleadoCodigo]             VARCHAR (10)   NOT NULL,
    [EmpleadoSueldo]             DECIMAL (9, 2) NOT NULL,
    [EmpleadoAsignacionFamiliar] DECIMAL (9, 2) NOT NULL,
    [PromedioHorasExtras]        DECIMAL (9, 2) NOT NULL,
    [PromedioBonificacion]       DECIMAL (9, 2) NOT NULL,
    [OtrosMonto]                 DECIMAL (9, 2) NOT NULL,
    [TotalBruto]                 DECIMAL (9, 2) NOT NULL,
    [PensionTipo]                CHAR (3)       NOT NULL,
    [PensionPorcentaje]          DECIMAL (5, 2) NOT NULL,
    [PensionTotal]               DECIMAL (9, 2) NOT NULL,
    [RetencionJudicialMonto]     DECIMAL (9, 2) NOT NULL,
    [TotalDescuento]             DECIMAL (9, 2) NOT NULL,
    [TotalNeto]                  DECIMAL (9, 2) NOT NULL,
    CONSTRAINT [PK_TbVacacion] PRIMARY KEY CLUSTERED ([IdVacacion] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'0.00% al 100.00%', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TbVacacion', @level2type = N'COLUMN', @level2name = N'PensionPorcentaje';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'ONP | AFP', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TbVacacion', @level2type = N'COLUMN', @level2name = N'PensionTipo';

