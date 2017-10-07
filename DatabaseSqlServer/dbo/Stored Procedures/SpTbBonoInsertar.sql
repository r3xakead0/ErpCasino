
CREATE PROCEDURE [dbo].[SpTbBonoInsertar]
@IdBono AS INT OUTPUT,
@Nombre AS VARCHAR(50),
@Descripcion AS VARCHAR(255),
@Activo AS BIT,
@Calculado AS BIT,
@Monto AS DECIMAL(9,2)
AS
BEGIN
	INSERT INTO TbBono (Nombre,Descripcion,Activo,Calculado,Monto)
	VALUES (@Nombre,@Descripcion,@Activo,@Calculado,@Monto)
	SET @IdBono = @@IDENTITY
END