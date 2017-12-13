CREATE PROCEDURE SpTbSueldoCandidatoActualizar
@IdSueldoCandidato AS INT,
@Fecha AS DATE,
@CodigoCandidato AS VARCHAR(10),
@Sueldo AS DECIMAL(9,2),
@BonoNocturnoMinutos AS INT,
@BonoNocturnoTotal AS DECIMAL(9,2),
@BonoHorasExtrasMinutos AS INT,
@BonoHorasExtrasTotal AS DECIMAL(9,2),
@BonoFeriadoMinutos AS INT,
@BonoFeriadoTotal AS DECIMAL(9,2),
@DescuentoTardanzaMinutos AS INT,
@DescuentoTardanzaTotal AS DECIMAL(9,2),
@DescuentoInasistenciaMinutos AS INT,
@DescuentoInasistenciaTotal AS DECIMAL(9,2)
AS
BEGIN
	UPDATE	TbSueldoCandidato
	SET		Fecha = @Fecha,
			CodigoCandidato = @CodigoCandidato,
			Sueldo = @Sueldo,
			BonoNocturnoMinutos = @BonoNocturnoMinutos,
			BonoNocturnoTotal = @BonoNocturnoTotal,
			BonoHorasExtrasMinutos = @BonoHorasExtrasMinutos,
			BonoHorasExtrasTotal = @BonoHorasExtrasTotal,
			BonoFeriadoMinutos = @BonoFeriadoMinutos,
			BonoFeriadoTotal = @BonoFeriadoTotal,
			DescuentoTardanzaMinutos = @DescuentoTardanzaMinutos,
			DescuentoTardanzaTotal = @DescuentoTardanzaTotal,
			DescuentoInasistenciaMinutos = @DescuentoInasistenciaMinutos,
			DescuentoInasistenciaTotal = @DescuentoInasistenciaTotal
	WHERE	IdSueldoCandidato = @IdSueldoCandidato
END