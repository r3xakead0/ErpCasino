CREATE TABLE [dbo].[TbObservacionEmpleado] (
    [IdObservacionEmpleado] INT           IDENTITY (1, 1) NOT NULL,
    [Fecha]                 DATE          NOT NULL,
    [IdSala]                INT           NOT NULL,
    [CodigoEmpleado]        VARCHAR (10)  NOT NULL,
    [IdObservacion]         INT           NOT NULL,
    [Descripcion]           VARCHAR (255) NOT NULL,
    CONSTRAINT [PK_TbObservacionEmpleado] PRIMARY KEY CLUSTERED ([IdObservacionEmpleado] ASC)
);

