
CREATE PROCEDURE [dbo].[SpTbPostulanteEstadoListar] 
@IdPostulante AS INTEGER = NULL,
@Activo AS BIT = NULL
AS
BEGIN

	DECLARE @IdPostulanteEstado AS INT
	SELECT	@IdPostulanteEstado = ISNULL(MAX(T1.IdPostulanteEstado),0) 
	FROM	TbPostulanteHistorial T1 
	WHERE	T1.IdPostulante = @IdPostulante

	DECLARE @Dependencia AS INT
	SET @Dependencia = 0
	IF @IdPostulanteEstado > 0 
	BEGIN
		SELECT	@Dependencia = T2.Nivel
		FROM	TbPostulanteEstado T2 
		WHERE	T2.IdPostulanteEstado = @IdPostulanteEstado
	END

	SELECT	T0.IdPostulanteEstado,
			T0.Nivel,
			T0.Nombre,
			T0.Descripcion,
			T0.Dependencia,
			T0.Activo
	FROM	TbPostulanteEstado T0
	WHERE	(@Activo IS NULL OR T0.Activo = @Activo) 
	AND		T0.Dependencia = @Dependencia

	
END