CREATE PROC SpObtenerNombreCompleto
@Codigo VARCHAR(10),
@Activo BIT = NULL
AS
BEGIN
	DECLARE @NOMCOMPLETO AS VARCHAR(150)

	SELECT	TOP 1
			@NOMCOMPLETO = T0.ApellidoPaterno + ' ' + T0.ApellidoMaterno + ', ' + T0.Nombres 
	FROM	TbEmpleado T0
	WHERE	(@Activo IS NULL OR T0.Activo = @Activo)
	AND		T0.Codigo = @Codigo

	IF @NOMCOMPLETO IS NULL
	BEGIN
		SELECT	TOP 1
				@NOMCOMPLETO = T0.ApellidoPaterno + ' ' + T0.ApellidoMaterno + ', ' + T0.Nombres 
		FROM	TbCandidato T0
		WHERE	(@Activo IS NULL OR T0.Activo = @Activo)
		AND		T0.Contratado = 0
		AND		T0.Codigo = @Codigo
	END

	SELECT @NOMCOMPLETO AS NombreCompleto

END