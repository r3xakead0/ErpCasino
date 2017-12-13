CREATE PROCEDURE SpTbSueldoCandidatoEliminar
@IdSueldoCandidato AS INT
AS
BEGIN
	DELETE FROM TbSueldoCandidato
	WHERE IdSueldoCandidato = @IdSueldoCandidato
END