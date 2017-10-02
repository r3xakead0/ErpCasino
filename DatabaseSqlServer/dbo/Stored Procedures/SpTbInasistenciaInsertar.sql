CREATE PROCEDURE SpTbInasistenciaInsertar
	@IdInasistencia AS INT OUTPUT,
	@Codigo AS VARCHAR(10),
	@FechaRegistro AS DATE,
	@FechaHoraEntrada AS DATETIME,
	@FechaHoraSalida AS DATETIME,
	@IdUsuarioCreador AS INT,
	@FechaCreacion AS DATETIME,
	@Tipo AS VARCHAR(10),
	@Asunto AS VARCHAR(10),
	@Detalle AS VARCHAR(255),
	@CITT AS VARCHAR(20)
AS
BEGIN
	INSERT INTO TbInasistencia (Codigo,FechaRegistro,FechaHoraEntrada,FechaHoraSalida,IdUsuarioCreador,FechaCreacion,Tipo,Asunto,Detalle,CITT)
	VALUES (@Codigo,@FechaRegistro,@FechaHoraEntrada,@FechaHoraSalida,@IdUsuarioCreador,@FechaCreacion,@Tipo,@Asunto,@Detalle,@CITT)
	SET @IdInasistencia = @@IDENTITY
END