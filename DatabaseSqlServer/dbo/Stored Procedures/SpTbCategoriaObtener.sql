
CREATE PROCEDURE SpTbCategoriaObtener
@IdCategoria AS INT
AS
BEGIN
SELECT TOP 1 
IdCategoria,
IdTipo,
Codigo,
Nombre,
Activo
FROM TbCategoria
WHERE IdCategoria = @IdCategoria
END