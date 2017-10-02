
CREATE PROCEDURE SpTbAfpActualizar
@IdAfp AS INT,
@Codigo AS VARCHAR(10),
@Nombre AS VARCHAR(50),
@Descripcion AS VARCHAR(255),
@Activo AS BIT
AS
BEGIN
UPDATE TbAfp
SET Codigo = @Codigo,
Nombre = @Nombre,
Descripcion = @Descripcion,
Activo = @Activo
WHERE IdAfp = @IdAfp
END