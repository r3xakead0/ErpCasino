CREATE TABLE [dbo].[TbPostulanteEstado] (
    [IdPostulanteEstado] INT           IDENTITY (1, 1) NOT NULL,
    [Nivel]              TINYINT       NOT NULL,
    [Nombre]             VARCHAR (50)  NOT NULL,
    [Descripcion]        VARCHAR (255) NULL,
    [Dependencia]        TINYINT       NOT NULL,
    [Activo]             BIT           CONSTRAINT [DF_TbPostulanteEstado_Activo] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_TbPostulanteEstado] PRIMARY KEY CLUSTERED ([IdPostulanteEstado] ASC)
);

