CREATE PROCEDURE [dbo].[SpTbUbigeoListarDistritos]
@Departamento AS INT,
@Provincia AS INT
AS
BEGIN

	SELECT	T0.Distrito,
			T0.Nombre
	FROM	TbUbigeo T0
	WHERE	T0.Departamento = @Departamento 
	AND		T0.Provincia = @Provincia
	AND		T0.Distrito > 0

END