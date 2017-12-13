CREATE PROCEDURE [dbo].[SpTbPrestamoListar2]
@CodigoEmpleado AS VARCHAR(10)
AS
BEGIN

	SELECT	IdPrestamo,
			Fecha,
			CodigoEmpleado,
			Motivo,
			Monto,
			Cuotas,
			Pagado
	FROM	TbPrestamo WITH(NOLOCK)
	WHERE	CodigoEmpleado = @CodigoEmpleado
	AND		Pagado = 0 --No pagado

END