
CREATE PROCEDURE [dbo].[SpTbTipoListar]
AS
BEGIN
	SELECT	T0.IdTipo,
			T0.Nombre,
			T0.Descripcion,
			T0.Activo
	FROM	TbTipo T0 WITH(NOLOCK)
END