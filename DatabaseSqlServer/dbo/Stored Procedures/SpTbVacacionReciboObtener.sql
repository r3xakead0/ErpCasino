CREATE PROCEDURE [dbo].[SpTbVacacionReciboObtener]
@IdVacacion AS INT
AS
BEGIN
	SELECT	TOP 1 
			IdVacacionRecibo,
			IdVacacion,
			Anho,
			Mes,
			MesNombre,
			EmpresaNombre,
			EmpresaDistrito,
			EmpleadoCodigo,
			EmpleadoNombres,
			EmpleadoApellidos,
			EmpleadoNroDocumento,
			Detalle,
			PeriodoInicio,
			PeriodoFinal,
			VacacionInicio,
			VacacionFinal,
			Sueldo,
			AsignacionFamiliar,
			PromedioHorasExtras,
			PromedioBonificacion,
			Redondeo,
			TotalBruto,
			RetencionJudicialMonto,
			PensionEntidad,
			PensionMonto,
			TotalDescuento,
			TotalNeto,
			TotalNetoLiteral
	FROM	TbVacacionRecibo
	WHERE	IdVacacion = @IdVacacion
END