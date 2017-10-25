CREATE PROCEDURE [dbo].[SpTbReciboListar]
@Anho AS SMALLINT,
@Mes AS TINYINT
AS
BEGIN
	SELECT	T0.IdRecibo,
			T0.Anho,
			T0.Mes,
			T0.CodigoEmpleado,
			T0.Tipo,
			T0.Concepto,
			T0.Fecha,
			T0.Monto 
	FROM	TbRecibo T0 WITH(NOLOCK)
	WHERE	T0.Anho = @Anho 
	AND		T0.Mes = @Mes
END