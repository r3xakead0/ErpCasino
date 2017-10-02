
CREATE PROCEDURE [dbo].[SpTbPostulanteReclutamientoActualizar]
@IdPostulante AS INT,
@CargoCurriculum AS VARCHAR(10),
@FechaRecepcion AS DATE,
@Observacion AS VARCHAR(255)
AS
BEGIN
	UPDATE	TbPostulanteReclutamiento
	SET		CargoCurriculum = @CargoCurriculum,
			FechaRecepcion = @FechaRecepcion,
			Observacion	= @Observacion
	WHERE	IdPostulante = @IdPostulante
END