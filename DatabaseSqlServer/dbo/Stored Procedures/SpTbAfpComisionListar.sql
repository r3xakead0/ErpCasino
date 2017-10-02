CREATE PROCEDURE [dbo].[SpTbAfpComisionListar]
@Anho AS INT,
@Mes AS INT
AS
BEGIN
	SELECT	T0.IdAfpComision,
			T0.Anho,
			T0.Mes,
			T0.IdAfp,
			T0.PorcentajeFondo,
			T0.PorcentajeSeguro,
			T0.PorcentajeComisionFlujo,
			T0.PorcentajeComisionMixta
	FROM	TbAfpComision T0
	WHERE	T0.Anho = @Anho 
	AND		T0.Mes = @Mes 
END