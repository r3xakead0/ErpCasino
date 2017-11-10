CREATE PROCEDURE [dbo].[SpTbAfpComisionObtener2]
@IdAfpComision AS INT
AS
BEGIN
	SELECT	TOP 1 
			IdAfpComision,
			Anho,
			Mes,
			IdAfp,
			PorcentajeFondo,
			PorcentajeSeguro,
			PorcentajeComisionFlujo,
			PorcentajeComisionMixta
	FROM	TbAfpComision
	WHERE	IdAfpComision = @IdAfpComision
END