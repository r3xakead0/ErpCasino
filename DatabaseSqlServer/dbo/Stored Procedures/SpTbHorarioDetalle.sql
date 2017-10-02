
CREATE PROC [dbo].[SpTbHorarioDetalle]
@Anho AS SMALLINT,
@Semana AS TINYINT,
@IdSala AS INT,
@IdCargo AS INT
AS
SELECT	T0.IdHorario,
		T0.Anho,
		T0.Semana,
		T0.FechaInicio,
		T0.FechaFinal,
		T0.IdSala,
		T0.IdCargo,
		T0.Fecha,
		T0.Codigo,
		T0.Dia,
		T0.Turno,
		T0.HoraInicio,
		T0.HoraFinal,
		T0.Horas
FROM	TbHorario T0 
WHERE	T0.Anho = @Anho 
AND		T0.Semana = @Semana 
AND		T0.IdSala = @IdSala 
AND		T0.IdCargo = @IdCargo 
ORDER BY T0.Dia,
		T0.Turno