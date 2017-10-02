CREATE TABLE [dbo].[TbAfpComision] (
    [IdAfpComision]           INT             IDENTITY (1, 1) NOT NULL,
    [Anho]                    INT             NOT NULL,
    [Mes]                     INT             NOT NULL,
    [IdAfp]                   INT             NOT NULL,
    [PorcentajeFondo]         DECIMAL (10, 2) NOT NULL,
    [PorcentajeSeguro]        DECIMAL (10, 2) NOT NULL,
    [PorcentajeComisionFlujo] DECIMAL (10, 2) NOT NULL,
    [PorcentajeComisionMixta] DECIMAL (10, 2) NOT NULL,
    CONSTRAINT [PK_TbAfpComision] PRIMARY KEY CLUSTERED ([IdAfpComision] ASC)
);

