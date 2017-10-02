
CREATE PROCEDURE SpTbBonoInsertar
@IdBono AS INT OUTPUT,
@Nombre AS VARCHAR(50),
@Descripcion AS VARCHAR(255),
@Monto AS DECIMAL(9,2),
@Activo AS BIT
AS
BEGIN
INSERT INTO TbBono (Nombre,Descripcion,Monto,Activo)
VALUES (@Nombre,@Descripcion,@Monto,@Activo)
SET @IdBono = @@IDENTITY
END