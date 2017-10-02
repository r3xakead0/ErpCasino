
CREATE PROCEDURE [dbo].[SpTbUbigeoListarDepartamentos]
AS
BEGIN
	SELECT	T0.Departamento,
			T0.Nombre
	FROM	TbUbigeo T0
	WHERE	T0.Provincia = 0 
	AND		T0.Distrito = 0
END