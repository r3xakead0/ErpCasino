using BE = ErpCasino.BusinessLibrary.BE;
using DA = ErpCasino.BusinessLibrary.DA;
using System.Data;
using System.Collections.Generic;
using System;
using System.Linq;

namespace ErpCasino.BusinessLibrary.LN
{

    public class Recibo
    {

        private List<BE.Feriado> lstBeFeriados = null;

        /// <summary>
        /// Listar el calculo detallado en minutos de las asistencias de los candidatos
        /// </summary>
        /// <param name="anho">Año en formato yyyy</param>
        /// <param name="mes">Mes en el rango de 1 al 12</param>
        /// <returns></returns>
        public List<BE.UI.AsistenciaCalculo> ListarAsistencias(int anho, int mes)
        {
            var lstUiAsistenciasCalculo = new List<BE.UI.AsistenciaCalculo>();

            try
            {

                if (this.lstBeFeriados == null)
                    this.lstBeFeriados = new DA.Feriado().ListarMes(anho, mes);

                DataTable dtAsistencias = new DA.Recibo().ListarAsistencias(anho, mes);
                foreach (DataRow drItem in dtAsistencias.Rows)
                {

                    #region Obtener datos de asistencia

                    string codEmpleado = drItem["Codigo"].ToString();
                    string nomEmpleado = drItem["Empleado"].ToString();
                    DateTime fecha = DateTime.Parse(drItem["Fecha"].ToString());
                    int semana = int.Parse(drItem["Semana"].ToString());

                    DateTime fechaHoraNocturnoInicio = DateTime.Parse(drItem["FechaHoraNocheInicial"].ToString());
                    DateTime fechaHoraNocturnoFinal = DateTime.Parse(drItem["FechaHoraNocheFinal"].ToString());

                    //Fecha y Hora segun horario programado
                    DateTime fechaHoraHorarioInicio = DateTime.Parse(drItem["FechaHoraHorarioInicial"].ToString());
                    DateTime fechaHoraHorarioFinal = DateTime.Parse(drItem["FechaHoraHorarioFinal"].ToString());
                    int horasHorario = int.Parse(drItem["HorasHorario"].ToString());

                    //Fecha y Hora segun horario Asistencia
                    int horasAsistencia = int.Parse(drItem["HorasAsistencia"].ToString());
                    DateTime fechaHoraAsistenciaInicio = new DateTime(1900, 01, 01);
                    DateTime fechaHoraAsistenciaFinal = new DateTime(1900, 01, 01);
                    if (horasAsistencia > 0) //Si Asistio
                    {
                        fechaHoraAsistenciaInicio = DateTime.Parse(drItem["FechaHoraAsistenciaInicial"].ToString());
                        fechaHoraAsistenciaFinal = DateTime.Parse(drItem["FechaHoraAsistenciaFinal"].ToString());
                    }

                    #endregion

                    int minutosAsistenciaNormalesTotales = 0;
                    int minutosAsistenciaNormalesDiurnas = 0;
                    int minutosAsistenciaNormalesNocturnas = 0;
                    int minutosAsistenciaNormalesDiurnasPrimerasExtras = 0;
                    int minutosAsistenciaNormalesNocturnasPrimerasExtras = 0;
                    int minutosAsistenciaNormalesDiurnasPosterioresExtras = 0;
                    int minutosAsistenciaNormalesNocturnasPosterioresExtras = 0;

                    int minutosTardanzaNormalesTotales = 0;
                    int minutosTardanzaNormalesDiurnas = 0;
                    int minutosTardanzaNormalesNocturnas = 0;

                    int minutosAsistenciaFeriadosTotales = 0;
                    int minutosAsistenciaFeriadosDiurnas = 0;
                    int minutosAsistenciaFeriadosNocturnas = 0;
                    int minutosAsistenciaFeriadosDiurnasPrimerasExtras = 0;
                    int minutosAsistenciaFeriadosNocturnasPrimerasExtras = 0;
                    int minutosAsistenciaFeriadosDiurnasPosterioresExtras = 0;
                    int minutosAsistenciaFeriadosNocturnasPosterioresExtras = 0;

                    int minutosTardanzaFeriadosTotales = 0;
                    int minutosTardanzaFeriadosDiurnas = 0;
                    int minutosTardanzaFeriadosNocturnas = 0;

                    int minutosInasistenciasTotales = 0;
                    int minutosInasistenciasNormales = 0;
                    int minutosInasistenciasFeriados = 0;

                    #region Calcular Horas Normales y Extras 

                    if (horasAsistencia > 0)
                    {

                        #region Calcular Minutos de Asistencias 

                        this.ObtenerMinutosAsistencia(fechaHoraNocturnoInicio,
                                                    fechaHoraNocturnoFinal,
                                                    fechaHoraHorarioInicio,
                                                    fechaHoraHorarioFinal,
                                                    out minutosAsistenciaNormalesDiurnas,
                                                    out minutosAsistenciaNormalesNocturnas,
                                                    out minutosAsistenciaNormalesDiurnasPrimerasExtras,
                                                    out minutosAsistenciaNormalesNocturnasPrimerasExtras,
                                                    out minutosAsistenciaNormalesDiurnasPosterioresExtras,
                                                    out minutosAsistenciaNormalesNocturnasPosterioresExtras,
                                                    out minutosAsistenciaFeriadosDiurnas,
                                                    out minutosAsistenciaFeriadosNocturnas,
                                                    out minutosAsistenciaFeriadosDiurnasPrimerasExtras,
                                                    out minutosAsistenciaFeriadosNocturnasPrimerasExtras,
                                                    out minutosAsistenciaFeriadosDiurnasPosterioresExtras,
                                                    out minutosAsistenciaFeriadosNocturnasPosterioresExtras);

                        minutosAsistenciaNormalesTotales = minutosAsistenciaNormalesDiurnas
                                                         + minutosAsistenciaNormalesNocturnas
                                                         + minutosAsistenciaNormalesDiurnasPrimerasExtras
                                                         + minutosAsistenciaNormalesNocturnasPrimerasExtras
                                                         + minutosAsistenciaNormalesDiurnasPosterioresExtras
                                                         + minutosAsistenciaNormalesNocturnasPosterioresExtras;

                        minutosAsistenciaFeriadosTotales = minutosAsistenciaFeriadosDiurnas
                                                         + minutosAsistenciaFeriadosNocturnas
                                                         + minutosAsistenciaFeriadosDiurnasPrimerasExtras
                                                         + minutosAsistenciaFeriadosNocturnasPrimerasExtras
                                                         + minutosAsistenciaFeriadosDiurnasPosterioresExtras
                                                         + minutosAsistenciaFeriadosNocturnasPosterioresExtras;

                        #endregion

                        #region Calcular Minutos de Tardanza

                        this.ObtenerMinutosTardanza(fechaHoraNocturnoInicio,
                            fechaHoraNocturnoFinal,
                            fechaHoraHorarioInicio,
                            fechaHoraAsistenciaInicio,
                            out minutosTardanzaNormalesDiurnas,
                            out minutosTardanzaNormalesNocturnas,
                            out minutosTardanzaFeriadosDiurnas,
                            out minutosTardanzaFeriadosNocturnas);

                        minutosTardanzaNormalesTotales = minutosTardanzaNormalesDiurnas
                                                       + minutosTardanzaNormalesNocturnas;

                        minutosTardanzaFeriadosTotales = minutosTardanzaFeriadosDiurnas
                                                       + minutosTardanzaFeriadosNocturnas;

                        #endregion

                    }
                    else
                    {

                        #region Calcular Minutos de Inasistencia

                        this.ObtenerMinutosInasistencia(fechaHoraHorarioInicio,
                            fechaHoraHorarioFinal,
                            out minutosInasistenciasNormales,
                            out minutosInasistenciasFeriados);

                        minutosInasistenciasTotales = minutosInasistenciasNormales
                                                    + minutosInasistenciasFeriados;

                        #endregion
                    }

                    #endregion

                    var uiAsistenciaCalculo = new BE.UI.AsistenciaCalculo();

                    uiAsistenciaCalculo.Codigo = codEmpleado;
                    //uiPlanillaAsistencia.NombreEmpleado = nomEmpleado;
                    uiAsistenciaCalculo.Fecha = fecha;
                    uiAsistenciaCalculo.Semana = semana;

                    uiAsistenciaCalculo.FechaHoraInicio = fechaHoraHorarioInicio;
                    uiAsistenciaCalculo.FechaHoraFinal = fechaHoraHorarioFinal;

                    //Asistencia Normales
                    uiAsistenciaCalculo.AsistenciaNormalTotal = minutosAsistenciaNormalesTotales;
                    uiAsistenciaCalculo.AsistenciaNormalDiurna = minutosAsistenciaNormalesDiurnas;
                    uiAsistenciaCalculo.AsistenciaNormalNocturna = minutosAsistenciaNormalesNocturnas;
                    uiAsistenciaCalculo.AsistenciaNormalDiurnaExtra1 = minutosAsistenciaNormalesDiurnasPrimerasExtras;
                    uiAsistenciaCalculo.AsistenciaNormalNocturnaExtra1 = minutosAsistenciaNormalesNocturnasPrimerasExtras;
                    uiAsistenciaCalculo.AsistenciaNormalDiurnaExtra2 = minutosAsistenciaNormalesDiurnasPosterioresExtras;
                    uiAsistenciaCalculo.AsistenciaNormalNocturnaExtra2 = minutosAsistenciaNormalesNocturnasPosterioresExtras;

                    //Tardanza Normales
                    uiAsistenciaCalculo.TardanzaNormalTotal = minutosTardanzaNormalesTotales;
                    uiAsistenciaCalculo.TardanzaNormalDiurna = minutosTardanzaNormalesDiurnas;
                    uiAsistenciaCalculo.TardanzaNormalNocturna = minutosTardanzaNormalesNocturnas;

                    //Asistencia Feriados
                    uiAsistenciaCalculo.AsistenciaFeriadoTotal = minutosAsistenciaFeriadosTotales;
                    uiAsistenciaCalculo.AsistenciaFeriadoDiurna = minutosAsistenciaFeriadosDiurnas;
                    uiAsistenciaCalculo.AsistenciaFeriadoNocturna = minutosAsistenciaFeriadosNocturnas;
                    uiAsistenciaCalculo.AsistenciaFeriadoDiurnaExtra1 = minutosAsistenciaFeriadosDiurnasPrimerasExtras;
                    uiAsistenciaCalculo.AsistenciaFeriadoNocturnaExtra1 = minutosAsistenciaFeriadosNocturnasPrimerasExtras;
                    uiAsistenciaCalculo.AsistenciaFeriadoDiurnaExtra2 = minutosAsistenciaFeriadosDiurnasPosterioresExtras;
                    uiAsistenciaCalculo.AsistenciaFeriadoNocturnaExtra2 = minutosAsistenciaFeriadosNocturnasPosterioresExtras;

                    //Tardanza Feriado
                    uiAsistenciaCalculo.TardanzaFeriadoTotal = minutosTardanzaFeriadosTotales;
                    uiAsistenciaCalculo.TardanzaFeriadoDiurna = minutosTardanzaFeriadosDiurnas;
                    uiAsistenciaCalculo.TardanzaFeriadoNocturna = minutosTardanzaFeriadosNocturnas;

                    //Tardanza Inasistencias
                    uiAsistenciaCalculo.InasistenciaTotal = minutosInasistenciasTotales;
                    uiAsistenciaCalculo.InasistenciaNormal = minutosInasistenciasNormales;
                    uiAsistenciaCalculo.InasistenciaFeriado = minutosInasistenciasFeriados;

                    lstUiAsistenciasCalculo.Add(uiAsistenciaCalculo);
                }

                return lstUiAsistenciasCalculo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Listar todos los candidatos activos con sus sueldos
        /// </summary>
        /// <returns></returns>
        public List<BE.UI.CandidatoSueldo> ListarSueldos()
        {
            var lstUiCandidatosSueldos = new List<BE.UI.CandidatoSueldo>();
            try
            {
                var dtCandidatosSueldos = new DA.Recibo().ListarSueldos();

                foreach (DataRow drCandidatoSueldo in dtCandidatosSueldos.Rows)
                {
                    var uiCandidatoSueldo = new BE.UI.CandidatoSueldo();

                    uiCandidatoSueldo.Codigo = drCandidatoSueldo["Codigo"].ToString();
                    uiCandidatoSueldo.Nombres = drCandidatoSueldo["Nombres"].ToString();
                    uiCandidatoSueldo.ApellidoPaterno = drCandidatoSueldo["ApellidoPaterno"].ToString();
                    uiCandidatoSueldo.ApellidoMaterno = drCandidatoSueldo["ApellidoMaterno"].ToString();
                    uiCandidatoSueldo.Sueldo = double.Parse(drCandidatoSueldo["Sueldo"].ToString());
                   
                    lstUiCandidatosSueldos.Add(uiCandidatoSueldo);
                }

                return lstUiCandidatosSueldos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Verifica si existe un calculo de recibos para un periodo especifico
        /// </summary>
        /// <param name="anho">Año del periodo a consultar</param>
        /// <param name="mes">Mes del periodo a consultar</param>
        /// <returns></returns>
        public bool Existe(int anho, int mes)
        {
            try
            {
                var dtRecibos = new DA.Recibo().Listar(anho, mes);
                return dtRecibos.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Registrar los recibos para el periodo indicado
        /// </summary>
        /// <param name="anho">Año en formato yyyy</param>
        /// <param name="mes">Mes en el rango de 1 al 12</param>
        /// <returns></returns>
        public bool Generar(int anho, int mes)
        {
            try
            {
                var lstBeRecibo = new List<BE.Recibo>();

                var daRecibo = new DA.Recibo();

                //Obtener lista detallada de los recibos
                var dtResumenDetalles = daRecibo.Detalle(anho, mes);
                foreach (DataRow item in dtResumenDetalles.Rows)
                {
                    var beRecibo = new BE.Recibo();
                    beRecibo.Anho = int.Parse(item["anho"].ToString());
                    beRecibo.Mes = int.Parse(item["Mes"].ToString());
                    beRecibo.CodigoEmpleado = item["CodigoEmpleado"].ToString();
                    beRecibo.Tipo = item["Tipo"].ToString();
                    beRecibo.Concepto = item["Concepto"].ToString();
                    beRecibo.Fecha = DateTime.Parse(item["Fecha"].ToString());
                    beRecibo.Monto = double.Parse(item["Monto"].ToString());
                    lstBeRecibo.Add(beRecibo);
                }

                //Insertar la lista detallada
                int rowsAffected = daRecibo.Insertar(ref lstBeRecibo);

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Listar el resumen de los recibos de bonos y descuentos 
        /// </summary>
        /// <param name="anho">Año en formato yyyy</param>
        /// <param name="mes">Mes en el rango de 1 al 12</param>
        /// <returns></returns>
        public List<BE.UI.ReciboResumen> Resumen (int anho, int mes)
        {
            var lstUiRecibosResumen = new List<BE.UI.ReciboResumen>();
            try
            {

                var daRecibo = new DA.Recibo();

                DataTable dtResumen = daRecibo.ResumenExistente(anho, mes);
                if (dtResumen.Rows.Count == 0)
                    dtResumen = daRecibo.ResumenCalculado(anho, mes);

                foreach (DataRow item in dtResumen.Rows)
                {
                    var uiReciboResumen = new BE.UI.ReciboResumen();

                    uiReciboResumen.Anho = int.Parse(item["anho"].ToString());
                    uiReciboResumen.Mes = int.Parse(item["Mes"].ToString());

                    using (var lnTrabajador = new LN.Trabajador())
                    {
                        uiReciboResumen.TrabajadorCodigo = item["CodigoEmpleado"].ToString();
                        uiReciboResumen.TrabajadorNombreCompleto = lnTrabajador.ObtenerNombreCompleto(uiReciboResumen.TrabajadorCodigo);
                        uiReciboResumen.TrabajadorTipo = lnTrabajador.ObtenerTipo(uiReciboResumen.TrabajadorCodigo);
                    }

                    uiReciboResumen.TotalSueldo = double.Parse(item["TotalSueldo"].ToString());
                    uiReciboResumen.TotalBonos = double.Parse(item["TotalBonos"].ToString());
                    uiReciboResumen.TotalDescuentos = double.Parse(item["TotalDescuentos"].ToString());
                    lstUiRecibosResumen.Add(uiReciboResumen);
                }

                return lstUiRecibosResumen;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Listar el resumen detallado de los recibos de bonos y descuentos 
        /// </summary>
        /// <param name="anho">Año en formato yyyy</param>
        /// <param name="mes">Mes en el rango de 1 al 12</param>
        /// <param name="codigoEmpleado">Codigo del Empleado y Candidato</param>
        /// <returns></returns>
        public List<BE.UI.Recibo> ResumenDetallado(int anho, int mes, string codigoEmpleado = "")
        {
            var lstUiRecibosResumen = new List<BE.UI.Recibo>();
            try
            {

                var dtResumen = new DA.Recibo().Detalle(anho, mes, codigoEmpleado);

                foreach (DataRow item in dtResumen.Rows)
                {
                    var uiRecibo = new BE.UI.Recibo();

                    uiRecibo.Anho = int.Parse(item["anho"].ToString());
                    uiRecibo.Mes = int.Parse(item["Mes"].ToString());
                    uiRecibo.TrabajadorCodigo = item["CodigoEmpleado"].ToString();
                    uiRecibo.TrabajadorNombreCompleto = new LN.Empleado().ObtenerNombreCompleto(uiRecibo.TrabajadorCodigo);

                    string tipoRecibo = item["Tipo"].ToString();
                    uiRecibo.Tipo = (BE.UI.TipoReciboEnum)Enum.Parse(typeof(BE.UI.TipoReciboEnum), tipoRecibo);

                    uiRecibo.Fecha = DateTime.Parse(item["Fecha"].ToString());
                    uiRecibo.Total = double.Parse(item["Total"].ToString());

                    lstUiRecibosResumen.Add(uiRecibo);
                }

                return lstUiRecibosResumen;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///<summary>
        ///Obtiene los minutos de asistencia por separado por 
        ///Diurno, Nocturno, Extra25% y Extra35%
        ///Asimismo, separados por fecha normal y feriado
        ///</summary>
        private void ObtenerMinutosAsistencia(DateTime fechaHoraNocturnoInicio,
                                            DateTime fechaHoraNocturnoFinal,
                                            DateTime fechaHoraInicio,
                                            DateTime fechaHoraFinal,
                                            out int minutosNormalDiurna,
                                            out int minutosNormalNocturna,
                                            out int minutosNormalDiurnaExtra1,
                                            out int minutosNormalNocturnaExtra1,
                                            out int minutosNormalDiurnaExtra2,
                                            out int minutosNormalNocturnaExtra2,
                                            out int minutosFeriadoDiurna,
                                            out int minutosFeriadoNocturna,
                                            out int minutosFeriadoDiurnaExtra1,
                                            out int minutosFeriadoNocturnaExtra1,
                                            out int minutosFeriadoDiurnaExtra2,
                                            out int minutosFeriadoNocturnaExtra2)
        {

            try
            {
                int minutosLaborales = 480; // 8 horas 
                int minutosComodin = 15;
                int minutosExtras1 = 120; // 2 horas

                int minNorDia = 0;
                int minNorDiaEx1 = 0;
                int minNorDiaEx2 = 0;

                int minNorNoc = 0;
                int minNorNocEx1 = 0;
                int minNorNocEx2 = 0;

                int minFerDia = 0;
                int minFerDiaEx1 = 0;
                int minFerDiaEx2 = 0;

                int minFerNoc = 0;
                int minFerNocEx1 = 0;
                int minFerNocEx2 = 0;

                int minutosTotales = (int)fechaHoraFinal.Subtract(fechaHoraInicio).TotalMinutes;
                DateTime fechaHoraActual = fechaHoraInicio;
                DateTime fechaHoraTermino = fechaHoraFinal;
                int numMinutos = 1;

                while (fechaHoraActual < fechaHoraTermino)
                {

                    bool esFeriado = this.EsFeriado(fechaHoraActual);

                    bool horarioNocturno = false;
                    if (fechaHoraNocturnoInicio <= fechaHoraActual &&
                        fechaHoraNocturnoFinal > fechaHoraActual)
                        horarioNocturno = true;
                    else
                        horarioNocturno = false;

                    if (esFeriado == false) //Asistencia Normal
                    {

                        if (numMinutos > minutosLaborales + minutosComodin) //Extras
                        {
                            if (numMinutos > (minutosLaborales + minutosComodin + minutosExtras1))
                            {
                                if (horarioNocturno == true)
                                    minNorNocEx2++;
                                else
                                    minNorDiaEx2++;
                            }
                            else
                            {
                                if (horarioNocturno == true)
                                    minNorNocEx1++;
                                else
                                    minNorDiaEx1++;
                            }
                        }
                        else if (numMinutos <= minutosLaborales)
                        {
                            if (horarioNocturno == true)
                                minNorNoc++;
                            else
                                minNorDia++;
                        }
                    }
                    else //Asistencia Feriado
                    {

                        if (numMinutos > minutosLaborales + minutosComodin)
                        {
                            if (numMinutos > (minutosLaborales + minutosComodin + minutosExtras1))
                            {
                                if (horarioNocturno == true)
                                    minFerNocEx2++;
                                else
                                    minFerDiaEx2++;
                            }
                            else
                            {
                                if (horarioNocturno == true)
                                    minFerNocEx1++;
                                else
                                    minFerDiaEx1++;
                            }
                        }
                        else if (numMinutos <= minutosLaborales)
                        {
                            if (horarioNocturno == true)
                                minFerNoc++;
                            else
                                minFerDia++;
                        }
                    }

                    fechaHoraActual = fechaHoraInicio.AddMinutes(numMinutos);
                    numMinutos++;
                }

                minutosNormalDiurna = minNorDia;
                minutosNormalDiurnaExtra1 = minNorDiaEx1;
                minutosNormalDiurnaExtra2 = minNorDiaEx2;

                minutosNormalNocturna = minNorNoc;
                minutosNormalNocturnaExtra1 = minNorNocEx1;
                minutosNormalNocturnaExtra2 = minNorNocEx2;

                minutosFeriadoDiurna = minFerDia;
                minutosFeriadoDiurnaExtra1 = minFerDiaEx1;
                minutosFeriadoDiurnaExtra2 = minFerDiaEx2;

                minutosFeriadoNocturna = minFerNoc;
                minutosFeriadoNocturnaExtra1 = minFerNocEx1;
                minutosFeriadoNocturnaExtra2 = minFerNocEx2;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private int ObtenerMinutosNocturno(DateTime fechaHoraInicio,
                                            DateTime fechaHoraFinal,
                                            DateTime fechaHoraNocturnoInicio,
                                            DateTime fechaHoraNocturnoFinal)
        {
            try
            {
                int minutos = 0;

                var range1 = new { start = fechaHoraInicio, end = fechaHoraFinal };
                var range2 = new { start = fechaHoraNocturnoInicio, end = fechaHoraNocturnoFinal };
                var iStart = range1.start < range2.start ? range2.start : range1.start;
                var iEnd = range1.end < range2.end ? range1.end : range2.end;
                var newRange = iStart < iEnd ? new { start = iStart, end = iEnd } : null;

                if (newRange != null)
                {
                    TimeSpan TiempoTardanza = newRange.end.Subtract(newRange.start);
                    minutos = (int)TiempoTardanza.TotalMinutes;
                }

                return minutos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ObtenerMinutosTardanza(DateTime fechaHoraNocturnoInicio,
                                            DateTime fechaHoraNocturnoFinal,
                                            DateTime fechaHoraHorarioInicio,
                                            DateTime fechaHoraAsistenciaInicio,
                                            out int minutosTardanzaNormalDiurnas,
                                            out int minutosTardanzaNormalNocturnas,
                                            out int minutosTardanzaFeriadoDiurnas,
                                            out int minutosTardanzaFeriadoNocturnas)
        {

            try
            {
                int minutosNormalDiurnas = 0;
                int minutosNormalNocturas = 0;
                int minutosFeriadoDiurnas = 0;
                int minutosFeriadoNocturas = 0;

                bool esFeriado = this.EsFeriado(fechaHoraHorarioInicio);

                TimeSpan TiempoTardanza = fechaHoraAsistenciaInicio.Subtract(fechaHoraHorarioInicio);

                if (fechaHoraNocturnoInicio <= fechaHoraHorarioInicio &&
                        fechaHoraNocturnoFinal > fechaHoraHorarioInicio)
                {
                    if (esFeriado)
                        minutosFeriadoNocturas = TiempoTardanza.Minutes;
                    else
                        minutosNormalNocturas = TiempoTardanza.Minutes;
                }
                else
                {
                    if (esFeriado)
                        minutosFeriadoDiurnas = TiempoTardanza.Minutes;
                    else
                        minutosNormalDiurnas = TiempoTardanza.Minutes;
                }

                minutosTardanzaNormalDiurnas = minutosNormalDiurnas > 0 ? minutosNormalDiurnas : 0;
                minutosTardanzaNormalNocturnas = minutosNormalNocturas > 0 ? minutosNormalNocturas : 0;
                minutosTardanzaFeriadoDiurnas = minutosFeriadoDiurnas > 0 ? minutosFeriadoDiurnas : 0;
                minutosTardanzaFeriadoNocturnas = minutosFeriadoNocturas > 0 ? minutosFeriadoNocturas : 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ObtenerMinutosInasistencia(DateTime fechaHoraInicio,
                                            DateTime fechaHoraFinal,
                                            out int minutosInasistenciaNormales,
                                            out int minutosInasistenciaFeriados)
        {

            try
            {
                int minNorDia = 0;
                int minFerDia = 0;

                int minutosTotales = (int)fechaHoraFinal.Subtract(fechaHoraInicio).TotalMinutes;
                DateTime fechaHoraActual = fechaHoraInicio;
                DateTime fechaHoraTermino = fechaHoraFinal.AddMinutes(-15);
                int numMinutos = 1;

                while (fechaHoraActual < fechaHoraTermino)
                {

                    bool esFeriado = this.EsFeriado(fechaHoraActual);

                    if (esFeriado == false) //Inasistencia Normal
                        minNorDia++;
                    else //Inasistencia Feriado
                        minFerDia++;

                    fechaHoraActual = fechaHoraInicio.AddMinutes(numMinutos);
                    numMinutos++;
                }

                minutosInasistenciaNormales = minNorDia;
                minutosInasistenciaFeriados = minFerDia;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool EsFeriado(DateTime fecha)
        {
            bool rpta = false;
            try
            {

                int countRows = this.lstBeFeriados.Where(x => x.Fecha.ToString("yyyyMMdd").Equals(fecha.ToString("yyyyMMdd"))).Count();
                rpta = countRows > 0 ? true : false;

                return rpta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}