CREATE PROCEDURE SpTbMovilidadActualizar
@IdMovilidad AS INT,
@Anho AS SMALLINT,
@Mes AS TINYINT,
@CodigoEmpleado AS VARCHAR(10),
@Monto AS DECIMAL(9,2),
@IdUsuarioModificador AS INT,
@FechaModificacion AS DATETIME
AS
BEGIN
	UPDATE	TbMovilidad
	SET		Anho = @Anho,
			Mes = @Mes,
			CodigoEmpleado = @CodigoEmpleado,
			Monto = @Monto,
			IdUsuarioModificador = @IdUsuarioModificador,
			FechaModificacion = @FechaModificacion
	WHERE	IdMovilidad = @IdMovilidad
END