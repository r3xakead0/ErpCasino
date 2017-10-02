
CREATE PROCEDURE [dbo].[SpTbPaisObtener]
@CodPais AS CHAR(3)
AS
BEGIN
	SELECT	TOP 1 
			CodPais,
			Nombre,
			Name,
			Nom,
			Iso2,
			PhoneCode
	FROM	TbPais
	WHERE	CodPais = @CodPais
END