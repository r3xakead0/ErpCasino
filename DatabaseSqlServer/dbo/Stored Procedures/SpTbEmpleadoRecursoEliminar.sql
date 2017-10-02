
CREATE PROCEDURE SpTbEmpleadoRecursoEliminar
@IdEmpleado AS INT
AS
BEGIN
DELETE FROM TbEmpleadoRecurso
WHERE IdEmpleado = @IdEmpleado
END