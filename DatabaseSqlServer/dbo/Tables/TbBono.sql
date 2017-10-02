﻿CREATE TABLE [dbo].[TbBono] (
    [IdBono]      INT            IDENTITY (1, 1) NOT NULL,
    [Nombre]      VARCHAR (50)   NOT NULL,
    [Descripcion] VARCHAR (255)  NOT NULL,
    [Monto]       DECIMAL (9, 2) NOT NULL,
    [Activo]      BIT            NOT NULL,
    CONSTRAINT [PK_TbBono] PRIMARY KEY CLUSTERED ([IdBono] ASC)
);

