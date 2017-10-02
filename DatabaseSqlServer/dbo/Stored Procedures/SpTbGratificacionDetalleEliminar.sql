
CREATE PROCEDURE SpTbGratificacionDetalleEliminar
@IdGratificacionDetalle AS INT
AS
BEGIN
DELETE FROM TbGratificacionDetalle
WHERE IdGratificacionDetalle = @IdGratificacionDetalle
END