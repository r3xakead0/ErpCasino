
CREATE PROCEDURE SpTbEmpleadoTelefonoActualizar
@IdEmpleadoTelefono AS NCHAR(20),
@IdEmpleado AS INT,
@CodTipoTelefono AS VARCHAR(10),
@Numero AS VARCHAR(20)
AS
BEGIN
UPDATE TbEmpleadoTelefono
SET IdEmpleado = @IdEmpleado,
CodTipoTelefono = @CodTipoTelefono,
Numero = @Numero
WHERE IdEmpleadoTelefono = @IdEmpleadoTelefono
END