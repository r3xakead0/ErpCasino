
CREATE PROCEDURE [dbo].[SpTbPostulanteReclutamientoInsertar]
@IdPostulante AS INT,
@CargoCurriculum AS VARCHAR(10),
@FechaRecepcion AS DATE,
@Observacion AS VARCHAR(255)
AS
BEGIN
	INSERT INTO TbPostulanteReclutamiento (IdPostulante,CargoCurriculum,FechaRecepcion,Observacion)
	VALUES (@IdPostulante,@CargoCurriculum,@FechaRecepcion,@Observacion)
END