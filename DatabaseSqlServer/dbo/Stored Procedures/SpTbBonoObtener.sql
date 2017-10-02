
CREATE PROCEDURE SpTbBonoObtener
@IdBono AS INT
AS
BEGIN
SELECT TOP 1 
IdBono,
Nombre,
Descripcion,
Monto,
Activo
FROM TbBono
WHERE IdBono = @IdBono
END