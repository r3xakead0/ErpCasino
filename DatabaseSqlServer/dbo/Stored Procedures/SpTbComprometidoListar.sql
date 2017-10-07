CREATE PROCEDURE [dbo].[SpTbComprometidoListar]
@Anho AS SMALLINT,
@Mes AS TINYINT,
@IdSala AS INT = NULL ,
@CodigoEmpleado AS VARCHAR(10) = NULL 
AS
BEGIN
	SELECT	T0.IdComprometido,
			T0.Anho,
			T0.Mes,
			T0.IdSala,
			T0.CodigoEmpleado,
			T0.Comprometido
	FROM	TbComprometido T0 WITH(NOLOCK)
	WHERE	T0.Anho = @Anho 
	AND		T0.Mes = @Mes 
	AND		(@IdSala IS NULL OR T0.IdSala = @IdSala)
	AND		(@CodigoEmpleado IS NULL OR T0.CodigoEmpleado = @CodigoEmpleado)
	ORDER BY T0.Anho,
			T0.Mes,
			T0.IdSala
END