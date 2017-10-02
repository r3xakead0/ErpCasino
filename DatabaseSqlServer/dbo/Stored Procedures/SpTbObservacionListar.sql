
CREATE PROCEDURE SpTbObservacionListar
AS
BEGIN
SELECT IdObservacion,
Nombre,
Descripcion,
Activo
FROM TbObservacion
END