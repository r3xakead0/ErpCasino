
CREATE PROCEDURE [dbo].[SpTbPostulanteContratar]
@IdPostulante AS INT
AS
BEGIN
	UPDATE	TbPostulante 
	SET		Candidato = 1
	WHERE	IdPostulante = @IdPostulante
END