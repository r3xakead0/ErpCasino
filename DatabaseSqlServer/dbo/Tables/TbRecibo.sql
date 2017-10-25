CREATE TABLE [dbo].[TbRecibo] (
    [IdRecibo]       INT            IDENTITY (1, 1) NOT NULL,
    [Anho]           SMALLINT       NOT NULL,
    [Mes]            TINYINT        NOT NULL,
    [CodigoEmpleado] VARCHAR (10)   NOT NULL,
    [Tipo]           VARCHAR (10)   NOT NULL,
    [Concepto]       VARCHAR (50)   NOT NULL,
    [Fecha]          DATE           NOT NULL,
    [Monto]          DECIMAL (9, 2) NOT NULL,
    CONSTRAINT [PK_TbRecibo] PRIMARY KEY CLUSTERED ([IdRecibo] ASC)
);

