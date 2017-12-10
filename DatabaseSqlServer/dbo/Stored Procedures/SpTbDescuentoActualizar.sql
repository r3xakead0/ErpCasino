
CREATE PROCEDURE [dbo].[SpTbDescuentoActualizar]
@IdDescuento AS INT,
@Nombre AS VARCHAR(50),
@Descripcion AS VARCHAR(255),
@Monto AS DECIMAL(9,2),
@Calculado AS BIT,
@Activo AS BIT
AS
BEGIN
	UPDATE	TbDescuento
	SET		Nombre = @Nombre,
			Descripcion = @Descripcion,
			Monto = @Monto,
			Calculado = @Calculado,
			Activo = @Activo
	WHERE	IdDescuento = @IdDescuento
END