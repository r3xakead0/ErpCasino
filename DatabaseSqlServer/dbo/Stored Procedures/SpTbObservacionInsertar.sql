CREATE PROCEDURE SpTbObservacionInsertar
@IdObservacion AS INT OUTPUT,
@Nombre AS VARCHAR(50),
@Descripcion AS VARCHAR(255),
@Activo AS BIT
AS
BEGIN
INSERT INTO TbObservacion (Nombre,Descripcion,Activo)
VALUES (@Nombre,@Descripcion,@Activo)
SET @IdObservacion = @@IDENTITY
END