CREATE TABLE [dbo].[TbComprometido] (
    [IdComprometido] INT          IDENTITY (1, 1) NOT NULL,
    [Anho]           SMALLINT     NOT NULL,
    [Mes]            TINYINT      NOT NULL,
    [IdSala]         INT          NOT NULL,
    [CodigoEmpleado] VARCHAR (10) NOT NULL,
    [Comprometido]   BIT          NOT NULL,
    CONSTRAINT [PK_TbComprometido] PRIMARY KEY CLUSTERED ([IdComprometido] ASC)
);

