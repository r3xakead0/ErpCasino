
CREATE PROCEDURE SpTbSalaListar
AS
BEGIN
SELECT IdSala,
Nombre,
Descripcion,
CodUbigeo,
Zona,
Direccion,
Referencia,
Activo
FROM TbSala
END