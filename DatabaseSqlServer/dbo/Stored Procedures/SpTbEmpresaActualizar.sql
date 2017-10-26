CREATE PROCEDURE SpTbEmpresaActualizar
@IdEmpresa AS INT,
@NombreComercial AS VARCHAR(100),
@RazonSocial AS VARCHAR(100),
@RUC AS VARCHAR(15),
@DomicilioFiscal AS VARCHAR(255),
@CodUbigeo AS CHAR(6)
AS
BEGIN
	UPDATE	TbEmpresa
	SET		NombreComercial = @NombreComercial,
			RazonSocial = @RazonSocial,
			RUC = @RUC,
			DomicilioFiscal = @DomicilioFiscal,
			CodUbigeo = @CodUbigeo
	WHERE	IdEmpresa = @IdEmpresa
END