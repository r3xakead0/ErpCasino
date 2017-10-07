CREATE TABLE [dbo].[TbMetaSala] (
    [IdMetaSala]       INT            IDENTITY (1, 1) NOT NULL,
    [IdSala]           INT            NOT NULL,
    [Anho]             SMALLINT       NOT NULL,
    [Mes]              TINYINT        NOT NULL,
    [CantidadPersonal] INT            NOT NULL,
    [MontoPersonal]    DECIMAL (9, 2) NOT NULL,
    [MontoGrupal]      DECIMAL (9, 2) NOT NULL,
    [Cumplido]         BIT            NOT NULL,
    CONSTRAINT [PK_TbMetaSala] PRIMARY KEY CLUSTERED ([IdMetaSala] ASC)
);

