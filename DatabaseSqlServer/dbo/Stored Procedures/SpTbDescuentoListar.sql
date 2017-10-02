
CREATE PROCEDURE SpTbDescuentoListar
AS
BEGIN
SELECT IdDescuento,
Nombre,
Descripcion,
Monto,
Activo
FROM TbDescuento
END