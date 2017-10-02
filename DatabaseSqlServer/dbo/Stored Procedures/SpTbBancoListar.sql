
CREATE PROCEDURE [dbo].[SpTbBancoListar]
@Codigo AS VARCHAR (10) = NULL,
@Nombre AS VARCHAR (50) = NULL,
@Descripcion AS VARCHAR (255) = NULL,
@Activo AS BIT = NULL
AS		
BEGIN
	SELECT	T0.IdBanco,
			T0.Codigo,
			T0.Nombre,
			T0.Descripcion,
			T0.Activo
	FROM	TbBanco T0
	WHERE	(@Codigo IS NULL OR T0.Codigo = @Codigo)
	AND		(@Nombre IS NULL OR T0.Nombre = @Nombre)
	AND		(@Descripcion IS NULL OR T0.Descripcion = @Descripcion)
	AND		(@Activo IS NULL OR T0.Activo = @Activo)
END