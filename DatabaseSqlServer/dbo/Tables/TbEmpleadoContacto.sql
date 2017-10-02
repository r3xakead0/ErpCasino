CREATE TABLE [dbo].[TbEmpleadoContacto] (
    [IdEmpleado] INT           NOT NULL,
    [CodUbigeo]  CHAR (6)      NOT NULL,
    [Zona]       VARCHAR (100) NOT NULL,
    [Direccion]  VARCHAR (255) NOT NULL,
    [Referencia] VARCHAR (255) NOT NULL,
    [Email]      VARCHAR (50)  NULL,
    CONSTRAINT [PK_TbEmpleadoContacto_1] PRIMARY KEY CLUSTERED ([IdEmpleado] ASC),
    CONSTRAINT [FK_TbEmpleadoContacto_TbEmpleado] FOREIGN KEY ([IdEmpleado]) REFERENCES [dbo].[TbEmpleado] ([IdEmpleado])
);







