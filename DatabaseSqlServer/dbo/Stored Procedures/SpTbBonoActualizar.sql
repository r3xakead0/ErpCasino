
CREATE PROCEDURE SpTbBonoActualizar
@IdBono AS INT,
@Nombre AS VARCHAR(50),
@Descripcion AS VARCHAR(255),
@Monto AS DECIMAL(9,2),
@Activo AS BIT
AS
BEGIN
UPDATE TbBono
SET Nombre = @Nombre,
Descripcion = @Descripcion,
Monto = @Monto,
Activo = @Activo
WHERE IdBono = @IdBono
END