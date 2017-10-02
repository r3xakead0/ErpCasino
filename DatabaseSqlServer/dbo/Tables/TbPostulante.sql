CREATE TABLE [dbo].[TbPostulante] (
    [IdPostulante]          INT          IDENTITY (1, 1) NOT NULL,
    [Nombres]               VARCHAR (50) NOT NULL,
    [ApellidoPaterno]       VARCHAR (50) NOT NULL,
    [ApellidoMaterno]       VARCHAR (50) NOT NULL,
    [FechaNacimiento]       DATE         NOT NULL,
    [CodSexo]               VARCHAR (10) CONSTRAINT [DF_TbPostulante_CodSexo] DEFAULT ('Codigo de Categoria') NOT NULL,
    [CodDocumentoIdentidad] VARCHAR (10) CONSTRAINT [DF_TbPostulante_CodDocumentoIdentidad] DEFAULT ('Codigo de Categoria') NOT NULL,
    [NumeroDocumento]       VARCHAR (20) NOT NULL,
    [CodPais]               CHAR (3)     NOT NULL,
    [CodEstadoCivil]        VARCHAR (10) CONSTRAINT [DF_TbPostulante_CodEstadoCivil] DEFAULT ('Codigo de Categoria') NOT NULL,
    [Activo]                BIT          NOT NULL,
    [Candidato]             BIT          CONSTRAINT [DF_TbPostulante_Candidato] DEFAULT ((0)) NOT NULL,
    [CodNacimiento]         CHAR (6)     NULL,
    CONSTRAINT [PK_TbPostulante] PRIMARY KEY CLUSTERED ([IdPostulante] ASC),
    CONSTRAINT [FK_TbPostulante_TbPais] FOREIGN KEY ([CodPais]) REFERENCES [dbo].[TbPais] ([CodPais])
);






GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Iso-3', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TbPostulante', @level2type = N'COLUMN', @level2name = N'CodPais';

