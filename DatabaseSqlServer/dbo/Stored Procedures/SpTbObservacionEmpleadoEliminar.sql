
CREATE PROCEDURE SpTbObservacionEmpleadoEliminar
@IdObservacionEmpleado AS INT
AS
BEGIN
DELETE FROM TbObservacionEmpleado
WHERE IdObservacionEmpleado = @IdObservacionEmpleado
END