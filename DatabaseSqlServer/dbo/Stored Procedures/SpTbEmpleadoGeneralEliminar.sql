
CREATE PROCEDURE [SpTbEmpleadoGeneralEliminar]
@IdEmpleado AS INT
AS
BEGIN
DELETE FROM TbEmpleado
WHERE IdEmpleado = @IdEmpleado
END