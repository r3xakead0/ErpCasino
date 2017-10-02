CREATE TABLE [dbo].[TbAdelanto] (
    [IdAdelanto]     INT            IDENTITY (1, 1) NOT NULL,
    [Fecha]          DATE           NOT NULL,
    [CodigoEmpleado] VARCHAR (10)   NOT NULL,
    [Tipo]           VARCHAR (10)   NOT NULL,
    [IdBanco]        INT            NULL,
    [Numero]         VARCHAR (20)   NOT NULL,
    [Monto]          DECIMAL (9, 2) NOT NULL,
    CONSTRAINT [PK_TbAdelanto] PRIMARY KEY CLUSTERED ([IdAdelanto] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'BAN = BANCO 
EFE = EFECTIVO', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TbAdelanto', @level2type = N'COLUMN', @level2name = N'Tipo';

