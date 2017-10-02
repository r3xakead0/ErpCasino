
CREATE PROCEDURE SpTbTipoObtener
@IdTipo AS INT
AS
BEGIN
SELECT TOP 1 
IdTipo,
Nombre,
Descripcion,
Activo
FROM TbTipo
WHERE IdTipo = @IdTipo
END