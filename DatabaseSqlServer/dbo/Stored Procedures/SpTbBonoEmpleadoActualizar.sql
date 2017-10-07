
CREATE PROCEDURE SpTbBonoEmpleadoActualizar
@IdBonoEmpleado AS INT,
@Fecha AS DATE,
@CodigoEmpleado AS VARCHAR(10),
@IdBono AS INT,
@Motivo AS VARCHAR(255),
@Monto AS DECIMAL(9,2)
AS
BEGIN
UPDATE TbBonoEmpleado
SET Fecha = @Fecha,
CodigoEmpleado = @CodigoEmpleado,
IdBono = @IdBono,
Motivo = @Motivo,
Monto = @Monto
WHERE IdBonoEmpleado = @IdBonoEmpleado
END