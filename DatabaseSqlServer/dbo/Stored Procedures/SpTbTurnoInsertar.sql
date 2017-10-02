CREATE PROCEDURE SpTbTurnoInsertar
@IdTurno AS INT OUTPUT,
@Numero AS INT,
@HoraInicial AS TIME,
@HoraFinal AS TIME,
@Activo AS BIT
AS
BEGIN
	INSERT INTO TbTurno (Numero,HoraInicial,HoraFinal,Activo)
	VALUES (@Numero,@HoraInicial,@HoraFinal,@Activo)
	SET @IdTurno = @@IDENTITY
END