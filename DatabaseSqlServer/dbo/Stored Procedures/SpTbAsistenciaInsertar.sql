
CREATE PROCEDURE [dbo].[SpTbAsistenciaInsertar]
@IdAsistencia AS INT OUTPUT,
@Codigo AS VARCHAR(10),
@FechaHoraEntrada AS DATETIME,
@FechaHoraSalida AS DATETIME,
@Origen AS CHAR(1),
@FechaRegistro AS DATE,
@Turno AS TINYINT,
@IdUsuarioCreador AS INT
AS
BEGIN
	INSERT INTO TbAsistencia (Codigo,FechaHoraEntrada,FechaHoraSalida,Origen,FechaRegistro,Turno,IdUsuarioCreador,FechaCreacion)
	VALUES (@Codigo,@FechaHoraEntrada,@FechaHoraSalida,@Origen,@FechaRegistro,@Turno,@IdUsuarioCreador,GETDATE())
	SET @IdAsistencia = @@IDENTITY
END