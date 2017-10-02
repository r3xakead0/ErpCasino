/****** Script for SelectTopNRows command from SSMS  ******/

CREATE PROC SpTbFeriadoObtener
@Fecha AS DATE
AS
SELECT	T0.Fecha,
		T0.Festivo,
		T0.Motivo,
		T0.Activo
FROM	TbFeriado T0 WITH(NOLOCK)
WHERE	T0.Fecha = @Fecha