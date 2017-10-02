
CREATE PROC SpTbFeriadoListar
@Anho AS INT,
@Mes AS INT
AS
SELECT	T0.Fecha,
		T0.Festivo,
		T0.Motivo,
		T0.Activo
FROM	TbFeriado T0 WITH(NOLOCK)
WHERE	YEAR(T0.Fecha) = @Anho
AND		MONTH(T0.Fecha) = @Mes