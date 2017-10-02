
CREATE PROCEDURE [dbo].[SpTbPostulanteReclutamientoObtener]
@IdPostulante AS INT
AS
BEGIN
	SELECT	TOP 1 
			T0.IdPostulante,
			T0.CargoCurriculum,
			T0.FechaRecepcion,
			T0.Observacion 
	FROM	TbPostulanteReclutamiento T0
	WHERE	T0.IdPostulante = @IdPostulante
END