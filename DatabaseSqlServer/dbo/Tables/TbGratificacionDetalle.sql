CREATE TABLE [dbo].[TbGratificacionDetalle] (
    [IdGratificacionDetalle] INT            IDENTITY (1, 1) NOT NULL,
    [IdGratificacion]        INT            NOT NULL,
    [Anho]                   INT            NOT NULL,
    [Mes]                    INT            NOT NULL,
    [CodigoEmpleado]         VARCHAR (10)   NOT NULL,
    [BonoNocturno]           DECIMAL (9, 4) NOT NULL,
    [BonoHorasExtras]        DECIMAL (9, 4) NOT NULL,
    [DiasCalendario]         INT            NOT NULL,
    [DiasInasistencia]       INT            NOT NULL,
    CONSTRAINT [PK_TbGratificacionDetalle] PRIMARY KEY CLUSTERED ([IdGratificacionDetalle] ASC)
);

