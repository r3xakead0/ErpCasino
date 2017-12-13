/****** Object:  StoredProcedure [dbo].[SpObtenerNombreCompleto]    Script Date: 29/11/2017 6:30:12 p. m. ******/
--EXEC SpTrabajadorObtenerTipo 'GLA0211111'
--EXEC SpTrabajadorObtenerTipo 'GLA0200180'
--EXEC SpTrabajadorObtenerTipo 'GLA0200627'
CREATE PROC [dbo].[SpTrabajadorObtenerTipo]
@Codigo VARCHAR(10)
AS
BEGIN

	DECLARE @TIPO AS VARCHAR(15)
	SET @TIPO = 'Ninguno'

	DECLARE @CANTIDAD AS INT

	SELECT	@CANTIDAD = COUNT(T0.Codigo) 
	FROM	TbEmpleado T0
	WHERE	T0.Codigo = @Codigo

	IF @CANTIDAD > 0
		SET @TIPO = 'Empleado'

	ELSE
	BEGIN

		SELECT	@CANTIDAD = COUNT(T0.Codigo) 
		FROM	TbCandidato T0
		WHERE	T0.Codigo = @Codigo

		IF @CANTIDAD > 0
			SET @TIPO = 'Candidato'

	END

	SELECT @TIPO AS TipoEmpleado

END