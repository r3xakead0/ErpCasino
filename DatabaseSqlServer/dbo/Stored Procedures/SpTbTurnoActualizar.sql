CREATE PROCEDURE SpTbTurnoActualizar
@IdTurno AS INT,
@Numero AS INT,
@HoraInicial AS TIME,
@HoraFinal AS TIME,
@Activo AS BIT
AS
BEGIN
	UPDATE	TbTurno
	SET		Numero = @Numero,
			HoraInicial = @HoraInicial,
			HoraFinal = @HoraFinal,
			Activo = @Activo
	WHERE	IdTurno = @IdTurno
END