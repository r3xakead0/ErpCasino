CREATE PROCEDURE SpTbEmpresaObtener
AS
BEGIN
	SELECT	TOP 1 
			TT.IdEmpresa,
			TT.NombreComercial,
			TT.RazonSocial,
			TT.RUC,
			TT.DomicilioFiscal,
			TT.CodUbigeo
	FROM	TbEmpresa TT
END