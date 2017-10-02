CREATE PROCEDURE [dbo].[SpTbAfpComisionActualizar]
@IdAfpComision AS INT,
@Anho AS INT,
@Mes AS INT,
@IdAfp AS INT,
@PorcentajeFondo AS DECIMAL(10,2),
@PorcentajeSeguro AS DECIMAL(10,2),
@PorcentajeComisionFlujo AS DECIMAL(10,2),
@PorcentajeComisionMixta AS DECIMAL(10,2)
AS
BEGIN
	UPDATE	TbAfpComision
	SET		Anho = @Anho,
			Mes = @Mes,
			IdAfp = @IdAfp,
			PorcentajeFondo = @PorcentajeFondo,
			PorcentajeSeguro = @PorcentajeSeguro,
			PorcentajeComisionFlujo = @PorcentajeComisionFlujo,
			PorcentajeComisionMixta = @PorcentajeComisionMixta
	WHERE	IdAfpComision = @IdAfpComision
END