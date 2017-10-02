
CREATE PROCEDURE [dbo].[SpTbPaisListar]
AS
BEGIN
	SELECT	CodPais,
			Nombre,
			Name,
			Nom,
			Iso2,
			PhoneCode
	FROM	TbPais
END