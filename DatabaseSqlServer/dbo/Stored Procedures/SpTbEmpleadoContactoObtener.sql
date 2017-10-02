
CREATE PROCEDURE [dbo].[SpTbEmpleadoContactoObtener]
@IdEmpleado AS INT
AS
BEGIN
	SELECT	TOP 1 
			T0.IdEmpleado,
			T0.CodUbigeo,
			T0.Zona,
			T0.Direccion,
			T0.Referencia,
			T0.Email
	FROM	TbEmpleadoContacto T0
	WHERE	T0.IdEmpleado = @IdEmpleado
END