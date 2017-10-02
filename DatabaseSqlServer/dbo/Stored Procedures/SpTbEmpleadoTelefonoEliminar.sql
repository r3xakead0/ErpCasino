
CREATE PROCEDURE SpTbEmpleadoTelefonoEliminar
@IdEmpleadoTelefono AS NCHAR(20)
AS
BEGIN
DELETE FROM TbEmpleadoTelefono
WHERE IdEmpleadoTelefono = @IdEmpleadoTelefono
END