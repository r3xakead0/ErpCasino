CREATE TABLE [dbo].[TbOnpComision] (
    [IdOnpComision]    INT             IDENTITY (1, 1) NOT NULL,
    [Anho]             INT             NOT NULL,
    [Mes]              INT             NOT NULL,
    [PorcentajeAporte] DECIMAL (10, 2) NOT NULL,
    CONSTRAINT [PK_TbOnpComision] PRIMARY KEY CLUSTERED ([IdOnpComision] ASC)
);

