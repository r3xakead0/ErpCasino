
CREATE PROCEDURE [dbo].[SpTbUbigeoListarProvincias]
@Departamento AS INT
AS
BEGIN
	SELECT	T0.Provincia,
			T0.Nombre
	FROM	TbUbigeo T0
	WHERE	T0.Departamento = @Departamento 
	AND		T0.Provincia > 0
	AND		T0.Distrito = 0
END