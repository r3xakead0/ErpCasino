
CREATE PROCEDURE [dbo].[SpTbPostulanteReclutamientoEliminar]
@IdPostulante AS INT
AS
BEGIN
	DELETE FROM TbPostulanteReclutamiento
	WHERE IdPostulante = @IdPostulante
END