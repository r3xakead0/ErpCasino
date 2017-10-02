CREATE PROCEDURE SpTbDescuentoEmpleadoInsertar
@IdDescuentoEmpleado AS INT OUTPUT,
@Fecha AS DATE,
@CodigoEmpleado AS VARCHAR(10),
@IdDescuento AS INT,
@Motivo AS VARCHAR(255),
@Monto AS DECIMAL(9,2)
AS
BEGIN
	INSERT INTO TbDescuentoEmpleado (Fecha,CodigoEmpleado,IdDescuento,Motivo,Monto)
	VALUES (@Fecha,@CodigoEmpleado,@IdDescuento,@Motivo,@Monto)
	SET @IdDescuentoEmpleado = @@IDENTITY
END