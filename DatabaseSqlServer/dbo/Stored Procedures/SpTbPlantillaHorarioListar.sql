CREATE PROCEDURE [dbo].[SpTbPlantillaHorarioListar]
@IdSala AS INT,
@IdCargo AS INT
AS
SELECT	T0.IdPlantillaHorario,
		T0.IdSala,
		T0.IdCargo,
		T0.Dia,
		T0.Turno,
		T0.HoraInicio,
		T0.HoraFin,
		T0.Horas
FROM	TbPlantillaHorario T0 
WHERE	T0.IdSala = @IdSala 
AND		T0.IdCargo = @IdCargo
ORDER BY T0.Dia, T0.Turno