CREATE PROCEDURE [dbo].[SpTbReciboResumen]
@Anho AS SMALLINT,
@Mes AS TINYINT
AS
BEGIN

	SELECT	T0.Anho,
			T0.Mes,
			T0.CodigoEmpleado,
			0.0 AS TotalSueldo, --FALTA
			SUM(CASE WHEN T0.Tipo = 'Bono' THEN T0.Monto ELSE 0.0 END) AS TotalBonos,
			SUM(CASE WHEN T0.Tipo = 'Descuento' THEN T0.Monto ELSE 0.0 END) AS TotalDescuentos
	FROM	TbRecibo T0 WITH(NOLOCK)
	WHERE	T0.Anho = @Anho 
	AND		T0.Mes = @Mes
	GROUP BY T0.Anho,
			T0.Mes,
			T0.CodigoEmpleado
	ORDER BY T0.CodigoEmpleado

END