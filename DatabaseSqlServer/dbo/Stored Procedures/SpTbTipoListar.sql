
CREATE PROCEDURE SpTbTipoListar
AS
BEGIN
SELECT IdTipo,
Nombre,
Descripcion,
Activo
FROM TbTipo
END