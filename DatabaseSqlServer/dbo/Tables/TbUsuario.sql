CREATE TABLE [dbo].[TbUsuario] (
    [IdUsuario]            INT          IDENTITY (1, 1) NOT NULL,
    [Usuario]              VARCHAR (10) NOT NULL,
    [Nombre]               VARCHAR (50) NOT NULL,
    [Email]                VARCHAR (50) NOT NULL,
    [Contrasenha]          VARCHAR (10) NOT NULL,
    [Bloqueado]            BIT          CONSTRAINT [DF_TbUsuario_Bloqueado] DEFAULT ((0)) NOT NULL,
    [Activo]               BIT          CONSTRAINT [DF_TbUsuario_Activo] DEFAULT ((1)) NOT NULL,
    [IdUsuarioCreador]     INT          NOT NULL,
    [FechaCreacion]        DATETIME     NOT NULL,
    [IdUsuarioModificador] INT          NULL,
    [FechaModificacion]    DATETIME     NULL,
    CONSTRAINT [PK_TbUsuario] PRIMARY KEY CLUSTERED ([IdUsuario] ASC)
);



