CREATE TABLE [dbo].[TbPlanillaDetalleCantidad] (
    [IdPlanillaDetalleCantidad]                       INT          IDENTITY (1, 1) NOT NULL,
    [IdPlanilla]                                      INT          NOT NULL,
    [CodigoEmpleado]                                  VARCHAR (10) NOT NULL,
    [CantidadMinutosAsistenciaNormalDiurno]           INT          NOT NULL,
    [CantidadMinutosAsistenciaNormalDiurnoExtras1]    INT          NOT NULL,
    [CantidadMinutosAsistenciaNormalDiurnoExtras2]    INT          NOT NULL,
    [CantidadMinutosAsistenciaNormalNocturno]         INT          NOT NULL,
    [CantidadMinutosAsistenciaNormalNocturnoExtras1]  INT          NOT NULL,
    [CantidadMinutosAsistenciaNormalNocturnoExtras2]  INT          NOT NULL,
    [CantidadMinutosAsistenciaFeriadoDiurno]          INT          NOT NULL,
    [CantidadMinutosAsistenciaFeriadoDiurnoExtras1]   INT          NOT NULL,
    [CantidadMinutosAsistenciaFeriadoDiurnoExtras2]   INT          NOT NULL,
    [CantidadMinutosAsistenciaFeriadoNocturno]        INT          NOT NULL,
    [CantidadMinutosAsistenciaFeriadoNocturnoExtras1] INT          NOT NULL,
    [CantidadMinutosAsistenciaFeriadoNocturnoExtras2] INT          NOT NULL,
    [CantidadMinutosTardanzaNormalDiurno]             INT          NOT NULL,
    [CantidadMinutosTardanzaNormalNocturno]           INT          NOT NULL,
    [CantidadMinutosTardanzaFeriadoDiurno]            INT          NOT NULL,
    [CantidadMinutosTardanzaFeriadoNocturno]          INT          NOT NULL,
    [CantidadMinutosInasistencia]                     INT          NOT NULL,
    CONSTRAINT [PK_TbPlanillaDetalleCantidad] PRIMARY KEY CLUSTERED ([IdPlanillaDetalleCantidad] ASC),
    CONSTRAINT [FK_TbPlanillaDetalleCantidad_TbPlanilla] FOREIGN KEY ([IdPlanilla]) REFERENCES [dbo].[TbPlanilla] ([IdPlanilla]) ON DELETE CASCADE
);





