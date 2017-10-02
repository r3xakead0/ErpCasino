
CREATE PROCEDURE SpTbAdelantoObtener
@IdAdelanto AS INT
AS
BEGIN
SELECT TOP 1 
IdAdelanto,
Fecha,
CodigoEmpleado,
Tipo,
IdBanco,
Numero,
Monto
FROM TbAdelanto
WHERE IdAdelanto = @IdAdelanto
END