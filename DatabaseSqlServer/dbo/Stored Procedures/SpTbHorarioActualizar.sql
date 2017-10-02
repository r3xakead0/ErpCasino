CREATE PROCEDURE [dbo].[SpTbHorarioActualizar]
	@IdHorario AS INT,
	@Anho AS SMALLINT,
	@Semana AS TINYINT,
	@FechaInicio AS DATE,
	@FechaFinal AS DATE,
	@IdSala AS INT,
	@IdCargo AS INT,
	@Fecha AS DATE,
	@Codigo AS VARCHAR(10),
	@Dia AS TINYINT,
	@Turno AS TINYINT,
	@HoraInicio AS TIME,
	@HoraFinal AS TIME,
	@Horas AS TINYINT
AS
BEGIN
	UPDATE	TbHorario
	SET		Anho = @Anho,
			Semana = @Semana,
			FechaInicio = @FechaInicio,
			FechaFinal = @FechaFinal,
			IdSala = @IdSala,
			IdCargo = @IdCargo,
			Fecha = @Fecha,
			Codigo = @Codigo,
			Dia = @Dia,
			Turno = @Turno,
			HoraInicio = @HoraInicio,
			HoraFinal = @HoraFinal,
			Horas = @Horas
	WHERE	IdHorario = @IdHorario
END