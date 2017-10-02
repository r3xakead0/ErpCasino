
CREATE PROCEDURE [dbo].[SpTbCargoObtener]
@IdCargo AS INT
AS
BEGIN
	SELECT	TOP 1 
			IdCargo,
			Nombre,
			Descripcion,
			Activo
	FROM	TbCargo
	WHERE	IdCargo = @IdCargo
END