CREATE TABLE [dbo].[TbEmpleadoRecurso] (
    [IdEmpleado]                  INT             NOT NULL,
    [IdArea]                      INT             NOT NULL,
    [IdCargo]                     INT             NOT NULL,
    [FechaInicio]                 DATE            NOT NULL,
    [FechaCese]                   DATE            NULL,
    [Cesado]                      BIT             NOT NULL,
    [NumeroHijos]                 TINYINT         NOT NULL,
    [IdBanco]                     INT             NULL,
    [CuentaBanco]                 VARCHAR (50)    NULL,
    [CCI]                         VARCHAR (50)    NULL,
    [ONP]                         BIT             NULL,
    [IdAfp]                       INT             NULL,
    [CUSPP]                       VARCHAR (50)    NULL,
    [CodComision]                 VARCHAR (10)    NULL,
    [CuentaCTS]                   VARCHAR (50)    NULL,
    [Sueldo]                      DECIMAL (10, 2) NULL,
    [IdBancoCTS]                  INT             NULL,
    [IdSala]                      INT             NOT NULL,
    [RetencionJudicialNominal]    DECIMAL (10, 2) NULL,
    [RetencionJudicialPorcentual] DECIMAL (10, 2) NULL,
    [FechaUltimaVacacion]         DATE            NULL,
    [Autogenerado]                VARCHAR (50)    NULL,
    CONSTRAINT [PK_TbEmpleadoRecurso_1] PRIMARY KEY CLUSTERED ([IdEmpleado] ASC),
    CONSTRAINT [FK_TbEmpleadoRecurso_TbAfp] FOREIGN KEY ([IdAfp]) REFERENCES [dbo].[TbAfp] ([IdAfp]),
    CONSTRAINT [FK_TbEmpleadoRecurso_TbArea] FOREIGN KEY ([IdArea]) REFERENCES [dbo].[TbArea] ([IdArea]),
    CONSTRAINT [FK_TbEmpleadoRecurso_TbBanco] FOREIGN KEY ([IdBanco]) REFERENCES [dbo].[TbBanco] ([IdBanco]),
    CONSTRAINT [FK_TbEmpleadoRecurso_TbCargo] FOREIGN KEY ([IdCargo]) REFERENCES [dbo].[TbCargo] ([IdCargo]),
    CONSTRAINT [FK_TbEmpleadoRecurso_TbEmpleado] FOREIGN KEY ([IdEmpleado]) REFERENCES [dbo].[TbEmpleado] ([IdEmpleado])
);

















