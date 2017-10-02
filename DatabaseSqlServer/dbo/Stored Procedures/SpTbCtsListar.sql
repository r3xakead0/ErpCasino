
CREATE PROCEDURE SpTbCtsListar
AS
BEGIN
SELECT IdCts,
CodigoEmpleado,
Monto,
FechaPeriodoInicial,
FechaPeriodoFinal,
FechaDeposito
FROM TbCts
END