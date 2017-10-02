
CREATE PROCEDURE SpTbAfpInsertar
@IdAfp AS INT,
@Codigo AS VARCHAR(10),
@Nombre AS VARCHAR(50),
@Descripcion AS VARCHAR(255),
@Activo AS BIT
AS
BEGIN
INSERT INTO TbAfp (Codigo,Nombre,Descripcion,Activo)
VALUES (@Codigo,@Nombre,@Descripcion,@Activo)
SET @IdAfp = @@IDENTITY
END