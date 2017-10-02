
CREATE PROCEDURE SpTbCtsObtener
@IdCts AS INT
AS
BEGIN
SELECT TOP 1 
IdCts,
CodigoEmpleado,
Monto,
FechaPeriodoInicial,
FechaPeriodoFinal,
FechaDeposito
FROM TbCts
WHERE IdCts = @IdCts
END