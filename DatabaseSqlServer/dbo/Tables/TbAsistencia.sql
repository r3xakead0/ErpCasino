CREATE TABLE [dbo].[TbAsistencia] (
    [IdAsistencia]         INT          IDENTITY (1, 1) NOT NULL,
    [Codigo]               VARCHAR (10) NOT NULL,
    [FechaHoraEntrada]     DATETIME     NOT NULL,
    [FechaHoraSalida]      DATETIME     NOT NULL,
    [Origen]               CHAR (1)     NOT NULL,
    [FechaRegistro]        DATE         NOT NULL,
    [Turno]                TINYINT      NOT NULL,
    [IdUsuarioCreador]     INT          NOT NULL,
    [FechaCreacion]        DATETIME     NOT NULL,
    [IdUsuarioModificador] INT          NULL,
    [FechaModificacion]    DATETIME     NULL,
    CONSTRAINT [PK_TbAsistencia] PRIMARY KEY CLUSTERED ([IdAsistencia] ASC)
);








GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Codigo de Empleado o Candidato', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TbAsistencia', @level2type = N'COLUMN', @level2name = N'Codigo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'M - Manual
C - Carga', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TbAsistencia', @level2type = N'COLUMN', @level2name = N'Origen';

