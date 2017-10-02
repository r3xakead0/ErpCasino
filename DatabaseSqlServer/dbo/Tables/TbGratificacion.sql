CREATE TABLE [dbo].[TbGratificacion] (
    [IdGratificacion]            INT            IDENTITY (1, 1) NOT NULL,
    [Periodo]                    VARCHAR (8)    NOT NULL,
    [FechaInicio]                DATE           NOT NULL,
    [FechaFinal]                 DATE           NOT NULL,
    [Dias]                       INT            NOT NULL,
    [CodigoEmpleado]             VARCHAR (10)   NOT NULL,
    [BonoNocturnoPromedio]       DECIMAL (9, 4) NOT NULL,
    [BonoHorasExtrasPromedio]    DECIMAL (9, 4) NOT NULL,
    [SueldoBase]                 DECIMAL (9, 4) NOT NULL,
    [AsignacionFamiliar]         DECIMAL (9, 4) NOT NULL,
    [DiasLaborados]              INT            NOT NULL,
    [GratificacionBruta]         DECIMAL (9, 4) NOT NULL,
    [BonoExtraordinario]         DECIMAL (9, 4) NOT NULL,
    [GratificacionNeta]          DECIMAL (9, 4) NOT NULL,
    [DescuentoRetencionJudicial] DECIMAL (9, 4) NOT NULL,
    [DescuentoImpuesto]          DECIMAL (9, 4) NOT NULL,
    [GratificacionPagar]         DECIMAL (9, 4) NOT NULL,
    CONSTRAINT [PK_TbGratificacion] PRIMARY KEY CLUSTERED ([IdGratificacion] ASC)
);

