
CREATE PROC [dbo].[SpTbFeriadoListarAnho]
@Anho AS INT
AS
BEGIN
	SELECT	T0.Fecha,
			T0.Festivo,
			T0.Motivo,
			T0.Activo
	FROM	TbFeriado T0 WITH(NOLOCK)
	WHERE	YEAR(T0.Fecha) = @Anho
	ORDER BY T0.Fecha
END