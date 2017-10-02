
CREATE PROCEDURE [dbo].[SpTbAreaListar]
@Activo AS BIT = NULL
AS
BEGIN
	SELECT	T0.IdArea,
			T0.Nombre,
			T0.Descripcion,
			T0.Activo
	FROM	TbArea T0
	WHERE	(@Activo IS NULL OR T0.Activo = @Activo)
END