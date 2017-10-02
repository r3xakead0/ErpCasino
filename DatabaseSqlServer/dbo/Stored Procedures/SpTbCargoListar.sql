
CREATE PROCEDURE [dbo].[SpTbCargoListar]
@Activo AS BIT = NULL
AS
BEGIN
	SELECT	T0.IdCargo,
			T0.Nombre,
			T0.Descripcion,
			T0.Activo
	FROM	TbCargo T0
	WHERE	(@Activo IS NULL OR T0.Activo = @Activo)
END