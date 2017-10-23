
CREATE PROCEDURE [dbo].[SpTbBonoEmpleadoExisteCalculo]
@Anho AS INT,
@Mes AS INT,
@IdBono AS INT
AS
BEGIN
	SELECT	COUNT(T0.IdBonoEmpleado) AS Cantidad
	FROM	TbBonoEmpleado T0
	WHERE	YEAR(T0.Fecha) = @Anho 
	AND		MONTH(T0.Fecha) = @Mes
	AND		T0.IdBono = @IdBono
END