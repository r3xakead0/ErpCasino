
CREATE PROCEDURE SpTbTurnoListar
AS
BEGIN
	SELECT	IdTurno,
			Numero,
			HoraInicial,
			HoraFinal,
			Activo
	FROM	TbTurno
END