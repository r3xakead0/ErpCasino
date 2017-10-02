CREATE PROCEDURE SpTbPrestamoCuotaEliminar
@IdPrestamoCuota AS INT
AS
BEGIN
	DELETE FROM TbPrestamoCuota
	WHERE IdPrestamoCuota = @IdPrestamoCuota
END