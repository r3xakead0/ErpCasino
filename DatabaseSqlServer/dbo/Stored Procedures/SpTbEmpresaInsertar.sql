CREATE PROCEDURE SpTbEmpresaInsertar
@IdEmpresa AS INT OUTPUT,
@NombreComercial AS VARCHAR(100),
@RazonSocial AS VARCHAR(100),
@RUC AS VARCHAR(15),
@DomicilioFiscal AS VARCHAR(255),
@CodUbigeo AS CHAR(6)
AS
BEGIN
	INSERT INTO TbEmpresa (NombreComercial,RazonSocial,RUC,DomicilioFiscal,CodUbigeo)
	VALUES (@NombreComercial,@RazonSocial,@RUC,@DomicilioFiscal,@CodUbigeo)
	SET @IdEmpresa = @@IDENTITY
END