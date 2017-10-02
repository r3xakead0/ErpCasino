CREATE PROCEDURE [dbo].[SpTbUbigeoObtenerDetalle]
@Departamento AS INT,
@Provincia AS INT,
@Distrito AS INT
AS
BEGIN
	SELECT	TOP 1 
			T0.Codigo,
			T0.Departamento,
			T0.Provincia,
			T0.Distrito,
			T0.Nombre
	FROM	TbUbigeo T0
	WHERE	T0.Departamento = @Departamento 
	AND		T0.Provincia = @Provincia
	AND		T0.Distrito = @Distrito
END