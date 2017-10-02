CREATE PROCEDURE [dbo].[SpTbEmpleadoComboNombres]
AS
BEGIN
	SELECT	T0.Codigo,
			T0.ApellidoPaterno + ' ' + T0.ApellidoMaterno + ', ' + T0.Nombres AS Empleado 
	FROM	TbEmpleado T0
	WHERE	T0.Activo = 1
END