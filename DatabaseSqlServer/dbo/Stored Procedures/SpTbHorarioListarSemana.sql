-- exec SpTbHorarioListarSemana 2017, 27, 1
CREATE PROC [dbo].[SpTbHorarioListarSemana]
@Anho AS SMALLINT,
@Semana AS TINYINT,
@IdSala AS INT
AS
BEGIN

	SELECT	IdHorario,
			Anho,
			Semana,
			FechaInicio,
			FechaFinal,
			IdSala,
			IdCargo,
			Fecha,
			Codigo,
			Dia,
			Turno,
			HoraInicio,
			HoraFinal,
			Horas
	FROM	TbHorario
	WHERE	Anho = @Anho 
	AND		Semana = @Semana
	AND		IdSala = @IdSala
	ORDER BY Dia, IdCargo, Turno  

END