CREATE TABLE [dbo].[TbCts] (
    [IdCts]                  INT            IDENTITY (1, 1) NOT NULL,
    [Anho]                   SMALLINT       NOT NULL,
    [Periodo]                TINYINT        NOT NULL,
    [PeriodoFechaInicial]    DATE           NOT NULL,
    [PeriodoFechaFinal]      DATE           NOT NULL,
    [EmpleadoCodigo]         VARCHAR (10)   NOT NULL,
    [EmpleadoFechaIngreso]   DATE           NOT NULL,
    [EmpleadoSueldo]         DECIMAL (9, 2) NOT NULL,
    [EmpleadoAsigFam]        DECIMAL (9, 2) NOT NULL,
    [TotalBonificacion]      DECIMAL (9, 2) NOT NULL,
    [TotalHorasExtras]       DECIMAL (9, 2) NOT NULL,
    [TotalGratificacion]     DECIMAL (9, 2) NOT NULL,
    [PromedioBonificacion]   DECIMAL (9, 2) NOT NULL,
    [PromedioHorasExtras]    DECIMAL (9, 2) NOT NULL,
    [PromedioGratificacion]  DECIMAL (9, 2) NOT NULL,
    [ComputableTotal]        DECIMAL (9, 2) NOT NULL,
    [ComputableFechaInicial] DATE           NOT NULL,
    [ComputableFechaFinal]   DATE           NOT NULL,
    [ComputableMeses]        TINYINT        NOT NULL,
    [ComputableDias]         TINYINT        NOT NULL,
    [ComputablePagar]        DECIMAL (9, 2) NOT NULL,
    [BancoId]                INT            NOT NULL,
    [BancoCuenta]            VARCHAR (50)   NOT NULL,
    [DepositoFecha]          DATE           NOT NULL,
    [DepositoMonto]          DECIMAL (9, 2) NOT NULL,
    [DepositoOperacion]      VARCHAR (50)   NOT NULL,
    CONSTRAINT [PK_TbCts] PRIMARY KEY CLUSTERED ([IdCts] ASC)
);




GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'1 = Mayo a Octubre 
2 = Noviembre a Abril', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TbCts', @level2type = N'COLUMN', @level2name = N'Periodo';

