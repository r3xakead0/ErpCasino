CREATE PROCEDURE SpTbSalaInsertar
@IdSala AS INT OUTPUT,
@Nombre AS VARCHAR(50),
@Descripcion AS VARCHAR(255),
@CodUbigeo AS CHAR(6),
@Zona AS VARCHAR(100),
@Direccion AS VARCHAR(255),
@Referencia AS VARCHAR(255),
@Activo AS BIT
AS
BEGIN
	INSERT INTO TbSala (Nombre,Descripcion,CodUbigeo,Zona,Direccion,Referencia,Activo)
	VALUES (@Nombre,@Descripcion,@CodUbigeo,@Zona,@Direccion,@Referencia,@Activo)
	SET @IdSala = @@IDENTITY
END