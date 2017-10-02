CREATE PROCEDURE [dbo].[SpTbAsistenciaActualizar]
@IdAsistencia AS INT,
@Codigo AS VARCHAR(10),
@FechaHoraEntrada AS DATETIME,
@FechaHoraSalida AS DATETIME,
@Origen AS CHAR(1),
@FechaRegistro AS DATE,
@Turno AS TINYINT,
@IdUsuarioModificador AS INT
AS
BEGIN
	UPDATE	TbAsistencia
	SET		Codigo = @Codigo,
			FechaHoraEntrada = @FechaHoraEntrada,
			FechaHoraSalida = @FechaHoraSalida,
			Origen = @Origen,
			FechaRegistro = @FechaRegistro,
			Turno = @Turno,
			IdUsuarioModificador = @IdUsuarioModificador,
			FechaModificacion = GETDATE()
	WHERE	IdAsistencia = @IdAsistencia
END