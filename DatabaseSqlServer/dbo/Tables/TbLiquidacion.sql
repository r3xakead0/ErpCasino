CREATE TABLE [dbo].[TbLiquidacion] (
    [IdLiquidacion]           INT            IDENTITY (1, 1) NOT NULL,
    [CodigoEmpleado]          VARCHAR (10)   NOT NULL,
    [FechaIngreso]            DATE           NOT NULL,
    [FechaCese]               DATE           NOT NULL,
    [FechaDepositoInicial]    DATE           NOT NULL,
    [FechaDepositoFinal]      DATE           NOT NULL,
    [FechaLiquidacionInicial] DATE           NOT NULL,
    [FechaLiquidacionFinal]   DATE           NOT NULL,
    [CodigoMotivoCese]        VARCHAR (10)   NOT NULL,
    [FaltasInjustificadas]    INT            NOT NULL,
    [LicenciaSinGoce]         INT            NOT NULL,
    [Sueldo]                  DECIMAL (9, 4) NOT NULL,
    [AsignacioFamiliar]       DECIMAL (9, 4) NOT NULL,
    [PromedioHorasExtras]     DECIMAL (9, 4) NOT NULL,
    [PromedioOtrosIngresos]   DECIMAL (9, 4) NOT NULL,
    [PromedioGratificacion]   DECIMAL (9, 4) NOT NULL,
    [RemuneracionTotal]       DECIMAL (9, 4) NOT NULL,
    [RemuneracionMes]         DECIMAL (9, 4) NOT NULL,
    [RemineracionDia]         DECIMAL (9, 4) NOT NULL,
    CONSTRAINT [PK_TbLiquidacion] PRIMARY KEY CLUSTERED ([IdLiquidacion] ASC)
);

