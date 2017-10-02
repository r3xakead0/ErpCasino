
CREATE PROCEDURE SpTbDescuentoObtener
@IdDescuento AS INT
AS
BEGIN
SELECT TOP 1 
IdDescuento,
Nombre,
Descripcion,
Monto,
Activo
FROM TbDescuento
WHERE IdDescuento = @IdDescuento
END