CREATE PROCEDURE [dbo].[SpTbHorarioInsertar]
	@IdHorario AS INT OUTPUT,
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
	INSERT INTO TbHorario (Anho,Semana,FechaInicio,FechaFinal,IdSala,IdCargo,Fecha,Codigo,Dia,Turno,HoraInicio,HoraFinal,Horas)
	VALUES (@Anho,@Semana,@FechaInicio,@FechaFinal,@IdSala,@IdCargo,@Fecha,@Codigo,@Dia,@Turno,@HoraInicio,@HoraFinal,@Horas)
	SET @IdHorario = @@IDENTITY
END