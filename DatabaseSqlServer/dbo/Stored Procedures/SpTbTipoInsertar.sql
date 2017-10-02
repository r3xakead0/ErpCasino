
CREATE PROCEDURE SpTbTipoInsertar
@IdTipo AS INT,
@Nombre AS VARCHAR(50),
@Descripcion AS VARCHAR(255),
@Activo AS BIT
AS
BEGIN
INSERT INTO TbTipo (Nombre,Descripcion,Activo)
VALUES (@Nombre,@Descripcion,@Activo)
SET @IdTipo = @@IDENTITY
END