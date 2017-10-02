
CREATE PROCEDURE [dbo].[SpTbEmpleadoTelefonoListar]
@IdEmpleado AS INT
AS
BEGIN
	SELECT	IdEmpleadoTelefono,
			IdEmpleado,
			CodTipoTelefono,
			Numero
	FROM	TbEmpleadoTelefono 
	WHERE	IdEmpleado = @IdEmpleado
END