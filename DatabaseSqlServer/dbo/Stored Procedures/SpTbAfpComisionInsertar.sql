
CREATE PROCEDURE [dbo].[SpTbAfpComisionInsertar]
@IdAfpComision AS INT OUTPUT,
@Anho AS INT,
@Mes AS INT,
@IdAfp AS INT,
@PorcentajeFondo AS DECIMAL(10,2),
@PorcentajeSeguro AS DECIMAL(10,2),
@PorcentajeComisionFlujo AS DECIMAL(10,2),
@PorcentajeComisionMixta AS DECIMAL(10,2)
AS
BEGIN
	INSERT INTO TbAfpComision (Anho,Mes,IdAfp,PorcentajeFondo,PorcentajeSeguro,PorcentajeComisionFlujo,PorcentajeComisionMixta)	
	VALUES (@Anho,@Mes,@IdAfp,@PorcentajeFondo,@PorcentajeSeguro,@PorcentajeComisionFlujo,@PorcentajeComisionMixta)
	SET @IdAfpComision = @@IDENTITY
END