CREATE PROCEDURE [dbo].[SpTbPrestamoObtener]
@IdPrestamo AS INT
AS
BEGIN
	SELECT	TOP 1 
			IdPrestamo,
			Fecha,
			CodigoEmpleado,
			Motivo,
			Monto,
			Cuotas,
			Pagado
	FROM	TbPrestamo
	WHERE	IdPrestamo = @IdPrestamo
END