CREATE PROCEDURE SpTbTurnoObtener
@IdTurno AS INT
AS
BEGIN
	SELECT	TOP 1 
			IdTurno,
			Numero,
			HoraInicial,
			HoraFinal,
			Activo
	FROM	TbTurno
	WHERE	IdTurno = @IdTurno
END