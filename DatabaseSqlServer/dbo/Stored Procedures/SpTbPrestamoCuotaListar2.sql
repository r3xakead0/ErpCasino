CREATE PROCEDURE [dbo].[SpTbPrestamoCuotaListar2]
@Anho AS INT,
@Mes AS INT,
@CodigoEmpleado AS VARCHAR(10)
AS
BEGIN

	SELECT	T0.IdPrestamoCuota,
			T0.IdPrestamo,
			T0.Fecha,
			T0.Monto,
			T0.Pagado 
	FROM	TbPrestamoCuota T0 
	INNER JOIN TbPrestamo T1 ON T1.IdPrestamo = T0.IdPrestamo
	WHERE	YEAR(T0.Fecha) = @Anho 
	AND		MONTH(T0.Fecha) = @Mes 
	AND		T1.CodigoEmpleado = @CodigoEmpleado

END