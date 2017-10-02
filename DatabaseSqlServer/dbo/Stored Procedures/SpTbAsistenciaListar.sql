CREATE PROCEDURE [dbo].[SpTbAsistenciaListar]
@FechaRegistro AS DATETIME
AS
BEGIN
	SELECT	T0.IdAsistencia,
			T0.Codigo,
			T0.FechaHoraEntrada,
			T0.FechaHoraSalida,
			T0.Origen,
			T0.FechaRegistro,
			T0.IdUsuarioCreador,
			T0.FechaCreacion,
			T0.Turno,
			T0.IdUsuarioModificador,
			T0.FechaModificacion
	FROM	TbAsistencia T0
	WHERE	T0.FechaRegistro = @FechaRegistro
END