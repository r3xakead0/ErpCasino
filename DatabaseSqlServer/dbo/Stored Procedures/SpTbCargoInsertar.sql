
CREATE PROCEDURE SpTbCargoInsertar
@IdCargo AS INT OUTPUT,
@Nombre AS VARCHAR(50),
@Descripcion AS VARCHAR(255),
@Activo AS BIT,
@Bono AS DECIMAL(9,2)
AS
BEGIN
	INSERT INTO TbCargo (Nombre,Descripcion,Activo,Bono)
	VALUES (@Nombre,@Descripcion,@Activo,@Bono)
	SET @IdCargo = @@IDENTITY
END