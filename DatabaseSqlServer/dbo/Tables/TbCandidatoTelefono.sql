CREATE TABLE [dbo].[TbCandidatoTelefono] (
    [IdCandidatoTelefono] INT          IDENTITY (1, 1) NOT NULL,
    [IdCandidato]         INT          NOT NULL,
    [CodTipoTelefono]     VARCHAR (10) CONSTRAINT [DF_TbCandidatoTelefono_CodTipoTelefono] DEFAULT ('Codigo de Categoria') NOT NULL,
    [Numero]              VARCHAR (20) NOT NULL,
    CONSTRAINT [PK_TbCandidatoTelefono] PRIMARY KEY CLUSTERED ([IdCandidatoTelefono] ASC),
    CONSTRAINT [FK_TbCandidatoTelefono_TbCandidato] FOREIGN KEY ([IdCandidato]) REFERENCES [dbo].[TbCandidato] ([IdCandidato])
);

