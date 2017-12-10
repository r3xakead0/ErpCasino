
CREATE PROCEDURE [dbo].[SpTbDescuentoInsertar]
@IdDescuento AS INT OUTPUT,
@Nombre AS VARCHAR(50),
@Descripcion AS VARCHAR(255),
@Monto AS DECIMAL(9,2),
@Calculado AS BIT,
@Activo AS BIT
AS
BEGIN
	INSERT INTO TbDescuento (Nombre,Descripcion,Monto,Calculado,Activo)
	VALUES (@Nombre,@Descripcion,@Monto,@Calculado,@Activo)
	SET @IdDescuento = @@IDENTITY
END