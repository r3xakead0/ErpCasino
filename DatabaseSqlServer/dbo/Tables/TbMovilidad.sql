CREATE TABLE [dbo].[TbMovilidad] (
    [IdMovilidad]          INT            IDENTITY (1, 1) NOT NULL,
    [Anho]                 SMALLINT       NOT NULL,
    [Mes]                  TINYINT        NOT NULL,
    [CodigoEmpleado]       VARCHAR (10)   NOT NULL,
    [Monto]                DECIMAL (9, 2) NOT NULL,
    [IdUsuarioCreador]     INT            NOT NULL,
    [FechaCreacion]        DATETIME       NOT NULL,
    [IdUsuarioModificador] INT            NULL,
    [FechaModificacion]    DATETIME       NULL,
    CONSTRAINT [PK_TbMovilidad] PRIMARY KEY CLUSTERED ([IdMovilidad] ASC)
);

