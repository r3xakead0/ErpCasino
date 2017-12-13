CREATE TABLE [dbo].[TbSueldoCandidato] (
    [IdSueldoCandidato]            INT            IDENTITY (1, 1) NOT NULL,
    [Fecha]                        DATE           NOT NULL,
    [CodigoCandidato]              VARCHAR (10)   NOT NULL,
    [Sueldo]                       DECIMAL (9, 2) NOT NULL,
    [BonoNocturnoMinutos]          INT            NOT NULL,
    [BonoNocturnoTotal]            DECIMAL (9, 2) NOT NULL,
    [BonoHorasExtrasMinutos]       INT            NOT NULL,
    [BonoHorasExtrasTotal]         DECIMAL (9, 2) NOT NULL,
    [BonoFeriadoMinutos]           INT            NOT NULL,
    [BonoFeriadoTotal]             DECIMAL (9, 2) NOT NULL,
    [DescuentoTardanzaMinutos]     INT            NOT NULL,
    [DescuentoTardanzaTotal]       DECIMAL (9, 2) NOT NULL,
    [DescuentoInasistenciaMinutos] INT            NOT NULL,
    [DescuentoInasistenciaTotal]   DECIMAL (9, 2) NOT NULL,
    CONSTRAINT [PK_TbSueldoCandidato] PRIMARY KEY CLUSTERED ([IdSueldoCandidato] ASC)
);

