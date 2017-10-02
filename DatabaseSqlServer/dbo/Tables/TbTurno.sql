CREATE TABLE [dbo].[TbTurno] (
    [IdTurno]     INT      IDENTITY (1, 1) NOT NULL,
    [Numero]      INT      NOT NULL,
    [HoraInicial] TIME (7) NOT NULL,
    [HoraFinal]   TIME (7) NOT NULL,
    [Activo]      BIT      CONSTRAINT [DF_TbTurno_Activo] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_TbTurno] PRIMARY KEY CLUSTERED ([IdTurno] ASC)
);

