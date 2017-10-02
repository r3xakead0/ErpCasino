CREATE TABLE [dbo].[TbHorario] (
    [IdHorario]   INT          IDENTITY (1, 1) NOT NULL,
    [Anho]        SMALLINT     NOT NULL,
    [Semana]      TINYINT      NOT NULL,
    [FechaInicio] DATE         NOT NULL,
    [FechaFinal]  DATE         NOT NULL,
    [IdSala]      INT          NOT NULL,
    [IdCargo]     INT          NOT NULL,
    [Fecha]       DATE         NOT NULL,
    [Codigo]      VARCHAR (10) NOT NULL,
    [Dia]         TINYINT      NOT NULL,
    [Turno]       TINYINT      NOT NULL,
    [HoraInicio]  TIME (7)     NOT NULL,
    [HoraFinal]   TIME (7)     NOT NULL,
    [Horas]       TINYINT      NOT NULL,
    CONSTRAINT [PK_TbHorario] PRIMARY KEY CLUSTERED ([IdHorario] ASC)
);




GO


