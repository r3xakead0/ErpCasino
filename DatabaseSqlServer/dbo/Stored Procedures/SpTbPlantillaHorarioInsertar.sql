CREATE PROCEDURE [dbo].[SpTbPlantillaHorarioInsertar]
@IdPlantillaHorario AS INT OUTPUT,
@IdSala AS INT,
@IdCargo AS INT,
@Dia AS INT,
@Turno AS INT,
@HoraInicio AS TIME,
@HoraFin AS TIME,
@Horas AS INT 
AS
BEGIN
	INSERT INTO TbPlantillaHorario (IdSala,IdCargo,Dia,Turno,HoraInicio,HoraFin,Horas) 
	VALUES (@IdSala,@IdCargo,@Dia,@Turno,@HoraInicio,@HoraFin,@Horas) 
	SET @IdPlantillaHorario = @@IDENTITY
END