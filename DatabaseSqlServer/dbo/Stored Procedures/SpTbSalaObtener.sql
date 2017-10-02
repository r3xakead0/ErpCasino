
CREATE PROCEDURE SpTbSalaObtener
@IdSala AS INT
AS
BEGIN
SELECT TOP 1 
IdSala,
Nombre,
Descripcion,
CodUbigeo,
Zona,
Direccion,
Referencia,
Activo
FROM TbSala
WHERE IdSala = @IdSala
END