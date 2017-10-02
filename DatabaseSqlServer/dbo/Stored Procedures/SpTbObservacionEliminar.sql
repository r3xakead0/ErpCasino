
CREATE PROCEDURE SpTbObservacionEliminar
@IdObservacion AS INT
AS
BEGIN
DELETE FROM TbObservacion
WHERE IdObservacion = @IdObservacion
END