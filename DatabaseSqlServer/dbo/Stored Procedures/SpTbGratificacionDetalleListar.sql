CREATE PROCEDURE SpTbGratificacionDetalleListar
@IdGratificacion AS INT
AS
BEGIN
SELECT	IdGratificacionDetalle,
		IdGratificacion,
		Anho,
		Mes,
		CodigoEmpleado,
		BonoNocturno,
		BonoHorasExtras,
		DiasCalendario,
		DiasInasistencia
FROM	TbGratificacionDetalle
WHERE	IdGratificacion = @IdGratificacion
END