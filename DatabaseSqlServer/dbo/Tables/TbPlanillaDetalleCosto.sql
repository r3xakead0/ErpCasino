CREATE TABLE [dbo].[TbPlanillaDetalleCosto] (
    [IdPlanillaDetalleCosto]                 INT            IDENTITY (1, 1) NOT NULL,
    [IdPlanilla]                             INT            NOT NULL,
    [CodigoEmpleado]                         VARCHAR (10)   NOT NULL,
    [Base]                                   DECIMAL (9, 2) NOT NULL,
    [AsignacionFamiliar]                     DECIMAL (9, 2) NOT NULL,
    [Sueldo]                                 DECIMAL (9, 2) NOT NULL,
    [CostoMinutoNormalDiurno]                DECIMAL (9, 4) NOT NULL,
    [CostoMinutoNormalNocturno]              DECIMAL (9, 4) NOT NULL,
    [CostoMinutoNormalDiurnoExtras1]         DECIMAL (9, 4) NOT NULL,
    [CostoMinutoNormalNocturnoExtras1]       DECIMAL (9, 4) NOT NULL,
    [CostoMinutoNormalDiurnoExtras2]         DECIMAL (9, 4) NOT NULL,
    [CostoMinutoNormalNocturnoExtras2]       DECIMAL (9, 4) NOT NULL,
    [CostoMinutoFeriadoDiurno]               DECIMAL (9, 4) NOT NULL,
    [CostoMinutoFeriadoNocturno]             DECIMAL (9, 4) NOT NULL,
    [CostoMinutoFeriadoDiurnoExtras1]        DECIMAL (9, 4) NOT NULL,
    [CostoMinutoFeriadoNocturnoExtras1]      DECIMAL (9, 4) NOT NULL,
    [CostoMinutoFeriadoDiurnoExtras2]        DECIMAL (9, 4) NOT NULL,
    [CostoMinutoFeriadoNocturnoExtras2]      DECIMAL (9, 4) NOT NULL,
    [DescuentoMinutoTardanzaNormalDiurno]    DECIMAL (9, 4) NOT NULL,
    [DescuentoMinutoTardanzaNormalNocturno]  DECIMAL (9, 4) NOT NULL,
    [DescuentoMinutoTardanzaFeriadoDiurno]   DECIMAL (9, 4) NOT NULL,
    [DescuentoMinutoTardanzaFeriadoNocturno] DECIMAL (9, 4) NOT NULL,
    [DescuentoMinutoDominical]               DECIMAL (9, 4) NOT NULL,
    [DescuentoMinutoInasistencia]            DECIMAL (9, 4) NOT NULL,
    CONSTRAINT [PK_TbPlanillaDetalleCosto] PRIMARY KEY CLUSTERED ([IdPlanillaDetalleCosto] ASC),
    CONSTRAINT [FK_TbPlanillaDetalleCosto_TbPlanilla] FOREIGN KEY ([IdPlanilla]) REFERENCES [dbo].[TbPlanilla] ([IdPlanilla]) ON DELETE CASCADE
);



