
CREATE PROCEDURE SpTbEmpleadoContactoEliminar
@IdEmpleado AS INT
AS
BEGIN
DELETE FROM TbEmpleadoContacto
WHERE IdEmpleado = @IdEmpleado
END