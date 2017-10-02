CREATE TABLE [dbo].[TbFeriado] (
    [Fecha]   DATE          NOT NULL,
    [Festivo] BIT           CONSTRAINT [DF_TbFeriado_Festivo] DEFAULT ((0)) NOT NULL,
    [Motivo]  VARCHAR (100) NOT NULL,
    [Activo]  BIT           CONSTRAINT [DF_TbFeriado_Activo] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_TbFeriado] PRIMARY KEY CLUSTERED ([Fecha] ASC)
);



