CREATE PROCEDURE [dbo].[SpTbDescuentoEmpleadoExisteCalculo]
@Anho AS INT,
@Mes AS INT,
@IdDescuento AS INT
AS
BEGIN
	SELECT	COUNT(T0.IdDescuentoEmpleado) AS Cantidad
	FROM	TbDescuentoEmpleado T0
	WHERE	YEAR(T0.Fecha) = @Anho 
	AND		MONTH(T0.Fecha) = @Mes
	AND		T0.IdDescuento = @IdDescuento
END