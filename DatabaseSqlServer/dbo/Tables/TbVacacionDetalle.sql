CREATE TABLE [dbo].[TbVacacionDetalle] (
    [IdVacacionDetalle] INT            IDENTITY (1, 1) NOT NULL,
    [IdVacacion]        INT            NOT NULL,
    [Anho]              SMALLINT       NOT NULL,
    [Numero]            TINYINT        NOT NULL,
    [Mes]               TINYINT        NOT NULL,
    [HorasExtrasMonto]  DECIMAL (9, 2) NOT NULL,
    [BonificacionMonto] DECIMAL (9, 2) NOT NULL,
    CONSTRAINT [PK_TbVacacionDetalle] PRIMARY KEY CLUSTERED ([IdVacacionDetalle] ASC)
);

