
CREATE PROCEDURE [dbo].[SpTbPrestamoActualizar]
@IdPrestamo AS INT,
@Fecha AS DATE,
@CodigoEmpleado AS VARCHAR(10),
@Motivo AS VARCHAR(255),
@Monto AS DECIMAL(9,2),
@Cuotas AS INT,
@Pagado AS BIT
AS
BEGIN
	UPDATE	TbPrestamo
	SET		Fecha = @Fecha,
			CodigoEmpleado = @CodigoEmpleado,
			Motivo = @Motivo,
			Monto = @Monto,
			Cuotas = @Cuotas,
			Pagado = @Pagado
	WHERE	IdPrestamo = @IdPrestamo
END