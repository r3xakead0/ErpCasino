
CREATE PROCEDURE SpTbBonoListar
AS
BEGIN
SELECT IdBono,
Nombre,
Descripcion,
Monto,
Activo
FROM TbBono
END