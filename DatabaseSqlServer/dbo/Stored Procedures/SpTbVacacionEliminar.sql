CREATE PROCEDURE SpTbVacacionEliminar
@IdVacacion AS INT
AS
BEGIN
	DELETE FROM TbVacacion
	WHERE IdVacacion = @IdVacacion
END