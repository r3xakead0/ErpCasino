CREATE TABLE [dbo].[TbEmpresa] (
    [IdEmpresa]       INT           IDENTITY (1, 1) NOT NULL,
    [NombreComercial] VARCHAR (100) NOT NULL,
    [RazonSocial]     VARCHAR (100) NOT NULL,
    [RUC]             VARCHAR (15)  NOT NULL,
    [DomicilioFiscal] VARCHAR (255) NOT NULL,
    [CodUbigeo]       CHAR (6)      NOT NULL,
    CONSTRAINT [PK_TbEmpresa] PRIMARY KEY CLUSTERED ([IdEmpresa] ASC)
);

