
CREATE PROCEDURE SpTbBancoInsertar
@IdBanco AS INT,
@Codigo AS VARCHAR(10),
@Nombre AS VARCHAR(50),
@Descripcion AS VARCHAR(255),
@Activo AS BIT
AS
BEGIN
INSERT INTO TbBanco (Codigo,Nombre,Descripcion,Activo)
VALUES (@Codigo,@Nombre,@Descripcion,@Activo)
SET @IdBanco = @@IDENTITY
END