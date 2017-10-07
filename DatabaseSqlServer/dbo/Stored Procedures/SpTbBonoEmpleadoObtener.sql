
CREATE PROCEDURE SpTbBonoEmpleadoObtener
@IdBonoEmpleado AS INT
AS
BEGIN
SELECT TOP 1 
IdBonoEmpleado,
Fecha,
CodigoEmpleado,
IdBono,
Motivo,
Monto
FROM TbBonoEmpleado
WHERE IdBonoEmpleado = @IdBonoEmpleado
END