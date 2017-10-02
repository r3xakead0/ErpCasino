
CREATE PROCEDURE SpTbDescuentoEliminar
@IdDescuento AS INT
AS
BEGIN
DELETE FROM TbDescuento
WHERE IdDescuento = @IdDescuento
END