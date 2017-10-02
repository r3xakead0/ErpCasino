CREATE PROCEDURE SpTbGratificacionDetalleInsertar
@IdGratificacionDetalle AS INT OUTPUT,
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
INSERT INTO TbGratificacionDetalle (IdGratificacion,Anho,Mes,CodigoEmpleado,BonoNocturno,BonoHorasExtras,DiasCalendario,DiasInasistencia)
VALUES (@IdGratificacion,@Anho,@Mes,@CodigoEmpleado,@BonoNocturno,@BonoHorasExtras,@DiasCalendario,@DiasInasistencia)
SET @IdGratificacionDetalle = @@IDENTITY
END