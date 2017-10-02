CREATE PROCEDURE [dbo].[SpTbAfpComisionObtener]
@IdAfp AS INT,
@Anho AS INT,
@Mes AS INT
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
	WHERE	IdAfp = @IdAfp 
	AND		Anho = @Anho
	AND		Mes = @Mes
END