CREATE TABLE [dbo].[TbPostulanteTelefono] (
    [IdPostulanteTelefono] INT          IDENTITY (1, 1) NOT NULL,
    [IdPostulante]         INT          NOT NULL,
    [CodTipoTelefono]      VARCHAR (10) CONSTRAINT [DF_TbPostulanteTelefono_CodTipoTelefono] DEFAULT ('Codigo de Categoria') NOT NULL,
    [Numero]               VARCHAR (20) NOT NULL,
    CONSTRAINT [PK_TbPostulanteTelefono] PRIMARY KEY CLUSTERED ([IdPostulanteTelefono] ASC),
    CONSTRAINT [FK_TbPostulanteTelefono_TbPostulante] FOREIGN KEY ([IdPostulante]) REFERENCES [dbo].[TbPostulante] ([IdPostulante])
);

