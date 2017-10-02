
CREATE PROCEDURE SpTbPrestamoEliminar
@IdPrestamo AS INT
AS
BEGIN
	DELETE FROM TbPrestamo
	WHERE IdPrestamo = @IdPrestamo

	DELETE FROM TbPrestamoCuota
	WHERE IdPrestamo = @IdPrestamo
END