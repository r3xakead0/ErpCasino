CREATE TABLE [dbo].[TbInasistencia] (
    [IdInasistencia]       INT           IDENTITY (1, 1) NOT NULL,
    [Codigo]               VARCHAR (10)  NOT NULL,
    [FechaRegistro]        DATE          NOT NULL,
    [FechaHoraEntrada]     DATETIME      NOT NULL,
    [FechaHoraSalida]      DATETIME      NOT NULL,
    [IdUsuarioCreador]     INT           NOT NULL,
    [FechaCreacion]        DATETIME      NOT NULL,
    [IdUsuarioModificador] INT           NULL,
    [FechaModificacion]    DATETIME      NULL,
    [Tipo]                 VARCHAR (10)  NULL,
    [Asunto]               VARCHAR (10)  NULL,
    [Detalle]              VARCHAR (255) NULL,
    [CITT]                 VARCHAR (20)  NULL,
    CONSTRAINT [PK_TbInasistencia] PRIMARY KEY CLUSTERED ([IdInasistencia] ASC)
);

