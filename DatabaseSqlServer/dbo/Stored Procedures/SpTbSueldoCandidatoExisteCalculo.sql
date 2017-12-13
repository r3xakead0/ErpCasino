CREATE PROCEDURE [dbo].[SpTbSueldoCandidatoExisteCalculo]
@Anho AS INT,
@Mes AS INT
AS
BEGIN
	SELECT	COUNT(T0.IdSueldoCandidato) AS Cantidad
	FROM	TbSueldoCandidato T0
	WHERE	YEAR(T0.Fecha) = @Anho 
	AND		MONTH(T0.Fecha) = @Mes
END