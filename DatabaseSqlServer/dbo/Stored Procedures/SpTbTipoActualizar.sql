
CREATE PROCEDURE SpTbTipoActualizar
@IdTipo AS INT,
@Nombre AS VARCHAR(50),
@Descripcion AS VARCHAR(255),
@Activo AS BIT
AS
BEGIN
UPDATE TbTipo
SET Nombre = @Nombre,
Descripcion = @Descripcion,
Activo = @Activo
WHERE IdTipo = @IdTipo
END