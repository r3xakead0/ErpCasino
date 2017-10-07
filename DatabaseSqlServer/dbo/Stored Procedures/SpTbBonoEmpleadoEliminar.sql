
CREATE PROCEDURE SpTbBonoEmpleadoEliminar
@IdBonoEmpleado AS INT
AS
BEGIN
DELETE FROM TbBonoEmpleado
WHERE IdBonoEmpleado = @IdBonoEmpleado
END