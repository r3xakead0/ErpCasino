CREATE PROCEDURE SpTbSueldoCandidatoInsertar
@IdSueldoCandidato AS INT OUTPUT,
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
	INSERT INTO TbSueldoCandidato (Fecha,CodigoCandidato,Sueldo,BonoNocturnoMinutos,BonoNocturnoTotal,BonoHorasExtrasMinutos,BonoHorasExtrasTotal,BonoFeriadoMinutos,BonoFeriadoTotal,DescuentoTardanzaMinutos,DescuentoTardanzaTotal,DescuentoInasistenciaMinutos,DescuentoInasistenciaTotal)
	VALUES (@Fecha,@CodigoCandidato,@Sueldo,@BonoNocturnoMinutos,@BonoNocturnoTotal,@BonoHorasExtrasMinutos,@BonoHorasExtrasTotal,@BonoFeriadoMinutos,@BonoFeriadoTotal,@DescuentoTardanzaMinutos,@DescuentoTardanzaTotal,@DescuentoInasistenciaMinutos,@DescuentoInasistenciaTotal)
	SET @IdSueldoCandidato = @@IDENTITY
END