
CREATE PROCEDURE SpTbGratificacionEliminar
@IdGratificacion AS INT
AS
BEGIN
DELETE FROM TbGratificacion
WHERE IdGratificacion = @IdGratificacion
END