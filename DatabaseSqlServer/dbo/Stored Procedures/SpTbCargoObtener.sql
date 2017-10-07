
CREATE PROCEDURE SpTbCargoObtener
@IdCargo AS INT
AS
BEGIN
	SELECT	TOP 1 
			IdCargo,
			Nombre,
			Descripcion,
			Activo,
			Bono
	FROM	TbCargo
	WHERE	IdCargo = @IdCargo
END