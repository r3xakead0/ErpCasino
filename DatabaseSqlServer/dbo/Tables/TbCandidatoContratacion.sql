CREATE TABLE [dbo].[TbCandidatoContratacion] (
    [IdCandidato]                 INT  NOT NULL,
    [InduccionFechaInicio]        DATE NOT NULL,
    [InduccionFechaFin]           DATE NULL,
    [InduccionEstado]             BIT  CONSTRAINT [DF_TbCandidatoContratacion_Induccion] DEFAULT ((0)) NOT NULL,
    [InformeDisciplinarioEstado]  BIT  CONSTRAINT [DF_TbCandidatoContratacion_Diciplina] DEFAULT ((0)) NOT NULL,
    [InformeAdministrativoEstado] BIT  CONSTRAINT [DF_TbCandidatoContratacion_Informe] DEFAULT ((0)) NOT NULL,
    [DocumentacionEstado]         BIT  CONSTRAINT [DF_TbCandidatoContratacion_Documentacion] DEFAULT ((0)) NOT NULL,
    [Observacion]                 TEXT NOT NULL,
    CONSTRAINT [PK_TbCandidatoContratacion] PRIMARY KEY CLUSTERED ([IdCandidato] ASC),
    CONSTRAINT [FK_TbCandidatoContratacion_TbCandidato] FOREIGN KEY ([IdCandidato]) REFERENCES [dbo].[TbCandidato] ([IdCandidato])
);



