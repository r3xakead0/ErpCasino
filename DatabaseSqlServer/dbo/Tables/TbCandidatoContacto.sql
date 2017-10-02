CREATE TABLE [dbo].[TbCandidatoContacto] (
    [IdCandidato] INT           NOT NULL,
    [CodUbigeo]   CHAR (6)      NOT NULL,
    [Zona]        VARCHAR (100) NOT NULL,
    [Direccion]   VARCHAR (255) NOT NULL,
    [Referencia]  VARCHAR (255) NOT NULL,
    [Email]       VARCHAR (50)  NOT NULL,
    CONSTRAINT [PK_TbCandidatoContacto_1] PRIMARY KEY CLUSTERED ([IdCandidato] ASC),
    CONSTRAINT [FK_TbCandidatoContacto_TbCandidato] FOREIGN KEY ([IdCandidato]) REFERENCES [dbo].[TbCandidato] ([IdCandidato])
);



