
CREATE PROCEDURE SpTbObservacionActualizar
@IdObservacion AS INT,
@Nombre AS VARCHAR(50),
@Descripcion AS VARCHAR(255),
@Activo AS BIT
AS
BEGIN
UPDATE TbObservacion
SET Nombre = @Nombre,
Descripcion = @Descripcion,
Activo = @Activo
WHERE IdObservacion = @IdObservacion
END