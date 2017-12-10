
CREATE PROCEDURE [dbo].[SpTbDescuentoListar]
AS
BEGIN
	SELECT	IdDescuento,
			Nombre,
			Descripcion,
			Monto,
			Calculado,
			Activo
	FROM	TbDescuento WITH(NOLOCK)
END