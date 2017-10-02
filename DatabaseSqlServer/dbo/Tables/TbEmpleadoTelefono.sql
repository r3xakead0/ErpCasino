CREATE TABLE [dbo].[TbEmpleadoTelefono] (
    [IdEmpleadoTelefono] INT          IDENTITY (1, 1) NOT NULL,
    [IdEmpleado]         INT          NOT NULL,
    [CodTipoTelefono]    VARCHAR (10) CONSTRAINT [DF_TbEmpleadoTelefono_CodTipoTelefono] DEFAULT ('Codigo de Categoria') NOT NULL,
    [Numero]             VARCHAR (20) NOT NULL,
    CONSTRAINT [PK_TbEmpleadoTelefono] PRIMARY KEY CLUSTERED ([IdEmpleadoTelefono] ASC),
    CONSTRAINT [FK_TbEmpleadoTelefono_TbEmpleado] FOREIGN KEY ([IdEmpleado]) REFERENCES [dbo].[TbEmpleado] ([IdEmpleado])
);





