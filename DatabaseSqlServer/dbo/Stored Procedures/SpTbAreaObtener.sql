
CREATE PROCEDURE [dbo].[SpTbAreaObtener]
@IdArea AS INT
AS
BEGIN
	SELECT	TOP 1 
			IdArea,
			Nombre,
			Descripcion,
			Activo
	FROM	TbArea
	WHERE	IdArea = @IdArea
END