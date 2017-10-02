CREATE PROCEDURE [dbo].[SpTbAsistenciaResumenListar]
@ANHO AS INT,
@MES AS INT
AS
BEGIN

	SELECT	FechaRegistro AS Fecha,
			COUNT(T0.FechaCreacion) AS Cantidad  
	FROM	TbAsistencia T0
	WHERE	MONTH(T0.FechaRegistro) = @MES 
	AND		YEAR(T0.FechaRegistro) = @ANHO  
	GROUP BY T0.FechaRegistro

END