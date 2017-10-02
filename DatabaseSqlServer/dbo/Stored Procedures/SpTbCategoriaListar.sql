
CREATE PROCEDURE [dbo].[SpTbCategoriaListar]
@IdTipo AS INT
AS
BEGIN
	SELECT	IdCategoria,
			IdTipo,
			Codigo,
			Nombre,
			Activo
	FROM	TbCategoria
	WHERE	IdTipo = @IdTipo
	AND		Activo = 1
END