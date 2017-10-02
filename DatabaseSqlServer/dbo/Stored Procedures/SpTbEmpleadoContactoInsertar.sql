
CREATE PROCEDURE [dbo].[SpTbEmpleadoContactoInsertar]
@IdEmpleado AS INT,
@CodUbigeo AS CHAR(6),
@Zona AS VARCHAR(100),
@Direccion AS VARCHAR(255),
@Referencia AS VARCHAR(255),
@Email AS VARCHAR(50)
AS
BEGIN
	INSERT INTO TbEmpleadoContacto (IdEmpleado,CodUbigeo,Zona,Direccion,Referencia,Email)
	VALUES (@IdEmpleado,@CodUbigeo,@Zona,@Direccion,@Referencia,@Email)
END