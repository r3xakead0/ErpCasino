CREATE TABLE [dbo].[TbPostulanteHistorial] (
    [IdPostulante]       INT           NOT NULL,
    [IdPostulanteEstado] INT           NOT NULL,
    [Acepto]             BIT           NOT NULL,
    [Nota]               VARCHAR (255) NOT NULL
);

