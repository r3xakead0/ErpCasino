CREATE PROCEDURE SpTbSalaActualizar
@IdSala AS INT,
@Nombre AS VARCHAR(50),
@Descripcion AS VARCHAR(255),
@CodUbigeo AS CHAR(6),
@Zona AS VARCHAR(100),
@Direccion AS VARCHAR(255),
@Referencia AS VARCHAR(255),
@Activo AS BIT
AS
BEGIN
UPDATE TbSala
SET Nombre = @Nombre,
Descripcion = @Descripcion,
CodUbigeo = @CodUbigeo,
Zona = @Zona,
Direccion = @Direccion,
Referencia = @Referencia,
Activo = @Activo
WHERE IdSala = @IdSala
END