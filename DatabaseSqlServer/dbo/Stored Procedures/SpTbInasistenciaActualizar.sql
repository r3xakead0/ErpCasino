
CREATE PROCEDURE [dbo].[SpTbInasistenciaActualizar]
@IdInasistencia AS INT,
@Codigo AS VARCHAR(10),
@FechaRegistro AS DATE,
@FechaHoraEntrada AS DATETIME,
@FechaHoraSalida AS DATETIME,
@IdUsuarioModificador AS INT,
@FechaModificacion AS DATETIME,
@Tipo AS VARCHAR(10),
@Asunto AS VARCHAR(10),
@Detalle AS VARCHAR(255),
@CITT AS VARCHAR(20)
AS
BEGIN
	UPDATE	TbInasistencia
	SET		Codigo = @Codigo,
			FechaRegistro = @FechaRegistro,
			FechaHoraEntrada = @FechaHoraEntrada,
			FechaHoraSalida = @FechaHoraSalida,
			IdUsuarioModificador = @IdUsuarioModificador,
			FechaModificacion = @FechaModificacion,
			Tipo = @Tipo,
			Asunto = @Asunto,
			Detalle = @Detalle,
			CITT = @CITT
	WHERE	IdInasistencia = @IdInasistencia
END