
CREATE PROCEDURE [dbo].[SpTbEmpleadoContactoActualizar]
@IdEmpleado AS INT,
@CodUbigeo AS CHAR(6),
@Zona AS VARCHAR(100),
@Direccion AS VARCHAR(255),
@Referencia AS VARCHAR(255),
@Email AS VARCHAR(50)
AS
BEGIN
	UPDATE TbEmpleadoContacto
	SET CodUbigeo = @CodUbigeo,
		Zona = @Zona,
		Direccion = @Direccion,
		Referencia = @Referencia,
		Email = @Email
	WHERE IdEmpleado = @IdEmpleado
END