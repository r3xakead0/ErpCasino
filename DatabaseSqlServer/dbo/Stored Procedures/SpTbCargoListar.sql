
CREATE PROCEDURE SpTbCargoListar
AS
BEGIN
	SELECT	IdCargo,
			Nombre,
			Descripcion,
			Activo,
			Bono
	FROM	TbCargo
END