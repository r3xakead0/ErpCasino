CREATE PROCEDURE SpTbMovilidadEliminar
@IdMovilidad AS INT
AS
BEGIN
DELETE FROM TbMovilidad
WHERE IdMovilidad = @IdMovilidad
END