
CREATE PROCEDURE SpTbGratificacionDetalleActualizar
@IdGratificacionDetalle AS INT,
@IdGratificacion AS INT,
@Anho AS INT,
@Mes AS INT,
@CodigoEmpleado AS VARCHAR(10),
@BonoNocturno AS NCHAR(20),
@BonoHorasExtras AS NCHAR(20),
@DiasCalendario AS INT,
@DiasInasistencia AS INT
AS
BEGIN
UPDATE TbGratificacionDetalle
SET IdGratificacion = @IdGratificacion,
Anho = @Anho,
Mes = @Mes,
CodigoEmpleado = @CodigoEmpleado,
BonoNocturno = @BonoNocturno,
BonoHorasExtras = @BonoHorasExtras,
DiasCalendario = @DiasCalendario,
DiasInasistencia = @DiasInasistencia
WHERE IdGratificacionDetalle = @IdGratificacionDetalle
END