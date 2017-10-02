
CREATE PROCEDURE SpTbDescuentoEmpleadoEliminar
@IdDescuentoEmpleado AS INT
AS
BEGIN
	DELETE FROM TbDescuentoEmpleado
	WHERE IdDescuentoEmpleado = @IdDescuentoEmpleado
END