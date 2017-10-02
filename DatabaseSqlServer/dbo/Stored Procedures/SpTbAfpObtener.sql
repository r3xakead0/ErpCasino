
CREATE PROCEDURE SpTbAfpObtener
@IdAfp AS INT
AS
BEGIN
SELECT TOP 1 
IdAfp,
Codigo,
Nombre,
Descripcion,
Activo
FROM TbAfp
WHERE IdAfp = @IdAfp
END