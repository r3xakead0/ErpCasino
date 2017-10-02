
CREATE PROCEDURE [dbo].[SpTbUbigeoObtener]
@Codigo AS CHAR(6)
AS
BEGIN
	SELECT	TOP 1 
			T0.Codigo,
			T0.Departamento,
			T0.Provincia,
			T0.Distrito,
			T0.Nombre
	FROM	TbUbigeo T0
	WHERE	T0.Codigo = @Codigo
END