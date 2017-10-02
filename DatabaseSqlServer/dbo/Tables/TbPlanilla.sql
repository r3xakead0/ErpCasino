CREATE TABLE [dbo].[TbPlanilla] (
    [IdPlanilla]              INT            IDENTITY (1, 1) NOT NULL,
    [Anho]                    SMALLINT       NOT NULL,
    [Mes]                     TINYINT        NOT NULL,
    [DiasMes]                 TINYINT        NOT NULL,
    [DiasBase]                TINYINT        NOT NULL,
    [HorasBase]               TINYINT        NOT NULL,
    [SueldoMinimo]            DECIMAL (8, 2) NOT NULL,
    [AsignacionFamiliar]      DECIMAL (5, 2) NOT NULL,
    [PrimerasDosHorasExtras]  DECIMAL (5, 2) NOT NULL,
    [PosteriorDosHorasExtras] DECIMAL (5, 2) NOT NULL,
    [ONP]                     DECIMAL (5, 2) NOT NULL,
    [EsSalud]                 DECIMAL (5, 2) NOT NULL,
    [HorasNocturnas]          DECIMAL (5, 2) NOT NULL,
    [Feriado]                 DECIMAL (5, 2) NOT NULL,
    CONSTRAINT [PK_TbPlanilla] PRIMARY KEY CLUSTERED ([IdPlanilla] ASC)
);






GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'c', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TbPlanilla', @level2type = N'COLUMN', @level2name = N'PosteriorDosHorasExtras';




GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'c', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TbPlanilla', @level2type = N'COLUMN', @level2name = N'PrimerasDosHorasExtras';




GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Porcentaje del Sueldo Minimo', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TbPlanilla', @level2type = N'COLUMN', @level2name = N'AsignacionFamiliar';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Porcentaje de cargo por EsSalud', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TbPlanilla', @level2type = N'COLUMN', @level2name = N'EsSalud';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Porcentaje por las horas nocturnas (22:00 a 06:00)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TbPlanilla', @level2type = N'COLUMN', @level2name = N'HorasNocturnas';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Porcentaje de descuento por ONP', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TbPlanilla', @level2type = N'COLUMN', @level2name = N'ONP';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Horas laborales al dia', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TbPlanilla', @level2type = N'COLUMN', @level2name = N'HorasBase';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Porcentaje del feriado', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TbPlanilla', @level2type = N'COLUMN', @level2name = N'Feriado';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Dias del mes', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TbPlanilla', @level2type = N'COLUMN', @level2name = N'DiasMes';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Dias del mes segun ley', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TbPlanilla', @level2type = N'COLUMN', @level2name = N'DiasBase';

