
CREATE PROCEDURE SpTbCargoActualizar
@IdCargo AS INT,
@Nombre AS VARCHAR(50),
@Descripcion AS VARCHAR(255),
@Activo AS BIT,
@Bono AS DECIMAL(9,2)
AS
BEGIN
	UPDATE	TbCargo
	SET		Nombre = @Nombre,
			Descripcion = @Descripcion,
			Activo = @Activo,
			Bono = @Bono
	WHERE	IdCargo = @IdCargo
END