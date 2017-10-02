
CREATE PROCEDURE SpTbSueldoMinimoEliminar
@IdSueldoMinimo AS INT
AS
BEGIN
	DELETE FROM TbSueldoMinimo
	WHERE IdSueldoMinimo = @IdSueldoMinimo
END