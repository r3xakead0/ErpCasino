
CREATE PROCEDURE [dbo].[SpTbEmpleadoTelefonoInsertar]
@IdEmpleadoTelefono AS INT OUTPUT,
@IdEmpleado AS INT,
@CodTipoTelefono AS VARCHAR(10),
@Numero AS VARCHAR(20)
AS
BEGIN
INSERT INTO TbEmpleadoTelefono (IdEmpleado,CodTipoTelefono,Numero)
VALUES (@IdEmpleado,@CodTipoTelefono,@Numero)
SET @IdEmpleadoTelefono = @@IDENTITY
END