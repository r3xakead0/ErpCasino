
CREATE PROCEDURE [dbo].[SpTbObservacionEmpleadoActualizar]
@IdObservacionEmpleado AS INT,
@Fecha AS DATE,
@IdSala AS INT,
@CodigoEmpleado AS VARCHAR(10),
@IdObservacion AS INT,
@Descripcion AS VARCHAR(255)
AS
BEGIN
UPDATE TbObservacionEmpleado
SET Fecha = @Fecha,
IdSala = @IdSala,
CodigoEmpleado = @CodigoEmpleado,
IdObservacion = @IdObservacion,
Descripcion = @Descripcion
WHERE IdObservacionEmpleado = @IdObservacionEmpleado
END