
CREATE PROCEDURE [dbo].[SpTbEmpleadoListaSimple]
AS
BEGIN

	SELECT	T0.Codigo,
			T0.Nombres,
			T0.ApellidoPaterno,
			T0.ApellidoMaterno,
			T0.Activo
	FROM	TbEmpleado T0 WITH(NOLOCK)

END