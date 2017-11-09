CREATE PROCEDURE SpTbVacacionDetalleEliminar
@IdVacacionDetalle AS INT
AS
BEGIN
	DELETE FROM TbVacacionDetalle
	WHERE IdVacacionDetalle = @IdVacacionDetalle
END