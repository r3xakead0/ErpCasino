
CREATE PROCEDURE [dbo].[SpTbDescuentoObtener]
@IdDescuento AS INT
AS
BEGIN
	SELECT	TOP 1 
			IdDescuento,
			Nombre,
			Descripcion,
			Monto,
			Calculado,
			Activo
	FROM	TbDescuento
	WHERE	IdDescuento = @IdDescuento
END