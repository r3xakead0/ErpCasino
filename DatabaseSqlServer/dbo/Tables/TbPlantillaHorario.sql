CREATE TABLE [dbo].[TbPlantillaHorario] (
    [IdPlantillaHorario] INT      IDENTITY (1, 1) NOT NULL,
    [IdSala]             INT      NOT NULL,
    [IdCargo]            INT      NOT NULL,
    [Dia]                INT      NOT NULL,
    [Turno]              INT      NOT NULL,
    [HoraInicio]         TIME (7) NOT NULL,
    [HoraFin]            TIME (7) NOT NULL,
    [Horas]              INT      NOT NULL,
    CONSTRAINT [PK_TbPlantillaHorario] PRIMARY KEY CLUSTERED ([IdPlantillaHorario] ASC)
);

