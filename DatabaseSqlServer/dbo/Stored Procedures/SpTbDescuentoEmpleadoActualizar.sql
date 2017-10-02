
CREATE PROCEDURE SpTbDescuentoEmpleadoActualizar
@IdDescuentoEmpleado AS INT,
@Fecha AS DATE,
@CodigoEmpleado AS VARCHAR(10),
@IdDescuento AS INT,
@Motivo AS VARCHAR(255),
@Monto AS DECIMAL(9,2)
AS
BEGIN
	UPDATE	TbDescuentoEmpleado
	SET		Fecha = @Fecha,
			CodigoEmpleado = @CodigoEmpleado,
			IdDescuento = @IdDescuento,
			Motivo = @Motivo,
			Monto = @Monto
	WHERE	IdDescuentoEmpleado = @IdDescuentoEmpleado
END