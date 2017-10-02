CREATE TABLE [dbo].[TbSueldoMinimo] (
    [IdSueldoMinimo] INT             IDENTITY (1, 1) NOT NULL,
    [FechaInicio]    DATE            NOT NULL,
    [Monto]          DECIMAL (10, 2) NOT NULL,
    [Activo]         BIT             CONSTRAINT [DF_TbSueldoMinimo_Activo] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_TbSueldoMinimo] PRIMARY KEY CLUSTERED ([IdSueldoMinimo] ASC)
);

