CREATE PROCEDURE SpTbSueldoCandidatoListar
@ANHO AS INT,
@MES AS INT
AS
BEGIN

	SELECT	IdSueldoCandidato,
			Fecha,
			CodigoCandidato,
			Sueldo,
			BonoNocturnoMinutos,
			BonoNocturnoTotal,
			BonoHorasExtrasMinutos,
			BonoHorasExtrasTotal,
			BonoFeriadoMinutos,
			BonoFeriadoTotal,
			DescuentoTardanzaMinutos,
			DescuentoTardanzaTotal,
			DescuentoInasistenciaMinutos,
			DescuentoInasistenciaTotal
	FROM	TbSueldoCandidato WITH(NOLOCK)
	WHERE	YEAR(Fecha) = @ANHO 
	AND		MONTH(Fecha) = @MES

END