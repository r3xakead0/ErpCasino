CREATE TABLE [dbo].[TbPlanillaAsistencia] (
    [IdPlanillaAsistencia]                   INT          IDENTITY (1, 1) NOT NULL,
    [IdPlanilla]                             INT          NOT NULL,
    [CodigoEmpleado]                         VARCHAR (10) NOT NULL,
    [Fecha]                                  DATE         NOT NULL,
    [Semana]                                 INT          NOT NULL,
    [FechaHoraInicio]                        DATETIME     NOT NULL,
    [FechaHoraFinal]                         DATETIME     NOT NULL,
    [MinutosAsistenciaTotal]                 INT          NOT NULL,
    [MinutosAsistenciaNormalDiurna]          INT          NOT NULL,
    [MinutosAsistenciaNormalNocturna]        INT          NOT NULL,
    [MinutosAsistenciaNormalDiurnaExtra1]    INT          NOT NULL,
    [MinutosAsistenciaNormalNocturnaExtra1]  INT          NOT NULL,
    [MinutosAsistenciaNormalDiurnaExtra2]    INT          NOT NULL,
    [MinutosAsistenciaNormalNocturnaExtra2]  INT          NOT NULL,
    [MinutosAsistenciaFeriadoDiurna]         INT          NOT NULL,
    [MinutosAsistenciaFeriadoNocturna]       INT          NOT NULL,
    [MinutosAsistenciaFeriadoDiurnaExtra1]   INT          NOT NULL,
    [MinutosAsistenciaFeriadoNocturnaExtra1] INT          NOT NULL,
    [MinutosAsistenciaFeriadoDiurnaExtra2]   INT          NOT NULL,
    [MinutosAsistenciaFeriadoNocturnaExtra2] INT          NOT NULL,
    [MinutosTardanzaTotal]                   INT          NOT NULL,
    [MinutosTardanzaNormalDiurna]            INT          NOT NULL,
    [MinutosTardanzaNormalNocturna]          INT          NOT NULL,
    [MinutosTardanzaFeriadoDiurna]           INT          NOT NULL,
    [MinutosTardanzaFeriadoNocturna]         INT          NOT NULL,
    [MinutosInasistenciaTotal]               INT          NOT NULL,
    CONSTRAINT [PK_TbPlantillaAsistencia] PRIMARY KEY CLUSTERED ([IdPlanillaAsistencia] ASC),
    CONSTRAINT [FK_TbPlanillaAsistencia_TbPlanilla] FOREIGN KEY ([IdPlanilla]) REFERENCES [dbo].[TbPlanilla] ([IdPlanilla]) ON DELETE CASCADE
);





