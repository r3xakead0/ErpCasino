CREATE TABLE [dbo].[TbPostulanteContacto] (
    [IdPostulante] INT           NOT NULL,
    [CodUbigeo]    CHAR (6)      NOT NULL,
    [Zona]         VARCHAR (100) NOT NULL,
    [Direccion]    VARCHAR (255) NOT NULL,
    [Referencia]   VARCHAR (255) NOT NULL,
    [Email]        VARCHAR (50)  NOT NULL,
    CONSTRAINT [PK_TbPostulanteContacto] PRIMARY KEY CLUSTERED ([IdPostulante] ASC),
    CONSTRAINT [FK_TbPostulanteContacto_TbPostulante] FOREIGN KEY ([IdPostulante]) REFERENCES [dbo].[TbPostulante] ([IdPostulante])
);





