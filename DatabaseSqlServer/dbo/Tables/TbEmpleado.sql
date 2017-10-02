CREATE TABLE [dbo].[TbEmpleado] (
    [IdEmpleado]            INT          IDENTITY (1, 1) NOT NULL,
    [Codigo]                VARCHAR (10) NOT NULL,
    [Nombres]               VARCHAR (50) NOT NULL,
    [ApellidoPaterno]       VARCHAR (50) NOT NULL,
    [ApellidoMaterno]       VARCHAR (50) NOT NULL,
    [FechaNacimiento]       DATE         NOT NULL,
    [CodSexo]               VARCHAR (10) CONSTRAINT [DF_TbEmpleado_CodSexo] DEFAULT ('Codigo de Categoria') NOT NULL,
    [CodDocumentoIdentidad] VARCHAR (10) CONSTRAINT [DF_TbEmpleado_CodDocumentoIdentidad] DEFAULT ('Codigo de Categoria') NOT NULL,
    [NumeroDocumento]       VARCHAR (20) NOT NULL,
    [CodPais]               CHAR (3)     NOT NULL,
    [CodEstadoCivil]        VARCHAR (10) CONSTRAINT [DF_TbEmpleado_CodEstadoCivil] DEFAULT ('Codigo de Categoria') NOT NULL,
    [Activo]                BIT          NOT NULL,
    [CodNacimiento]         VARCHAR (6)  NOT NULL,
    [IdCandidato]           INT          NULL,
    CONSTRAINT [PK_TbEmpleado] PRIMARY KEY CLUSTERED ([IdEmpleado] ASC),
    CONSTRAINT [FK_TbEmpleado_TbPais] FOREIGN KEY ([CodPais]) REFERENCES [dbo].[TbPais] ([CodPais])
);








GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Iso-3', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TbEmpleado', @level2type = N'COLUMN', @level2name = N'CodPais';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Codigo de Ubigeo', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TbEmpleado', @level2type = N'COLUMN', @level2name = N'CodNacimiento';

