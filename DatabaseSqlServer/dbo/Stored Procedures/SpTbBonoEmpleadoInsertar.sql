CREATE PROCEDURE SpTbBonoEmpleadoInsertar
@IdBonoEmpleado AS INT OUTPUT,
@Fecha AS DATE,
@CodigoEmpleado AS VARCHAR(10),
@IdBono AS INT,
@Motivo AS VARCHAR(255),
@Monto AS DECIMAL(9,2)
AS
BEGIN
INSERT INTO TbBonoEmpleado (Fecha,CodigoEmpleado,IdBono,Motivo,Monto)
VALUES (@Fecha,@CodigoEmpleado,@IdBono,@Motivo,@Monto)
SET @IdBonoEmpleado = @@IDENTITY
END