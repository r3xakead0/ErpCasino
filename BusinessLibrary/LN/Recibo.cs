using BE = ErpCasino.BusinessLibrary.BE;
using DA = ErpCasino.BusinessLibrary.DA;
using System.Data;
using System.Collections.Generic;
using System;

namespace ErpCasino.BusinessLibrary.LN
{

    public class Recibo
    {

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
                    uiReciboResumen.EmpleadoCodigo = item["CodigoEmpleado"].ToString();
                    uiReciboResumen.EmpleadoNombreCompleto = new LN.Empleado().ObtenerNombreCompleto(uiReciboResumen.EmpleadoCodigo);
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
        public List<BE.UI.ReciboResumenDetalle> ResumenDetallado(int anho, int mes, string codigoEmpleado = "")
        {
            var lstUiRecibosResumen = new List<BE.UI.ReciboResumenDetalle>();
            try
            {

                var dtResumen = new DA.Recibo().Detalle(anho, mes, codigoEmpleado);

                foreach (DataRow item in dtResumen.Rows)
                {
                    var uiReciboResumen = new BE.UI.ReciboResumenDetalle();
                    uiReciboResumen.Anho = int.Parse(item["anho"].ToString());
                    uiReciboResumen.Mes = int.Parse(item["Mes"].ToString());
                    uiReciboResumen.EmpleadoCodigo = item["CodigoEmpleado"].ToString();
                    uiReciboResumen.EmpleadoNombreCompleto = new LN.Empleado().ObtenerNombreCompleto(uiReciboResumen.EmpleadoCodigo);
                    uiReciboResumen.Tipo = item["Tipo"].ToString();
                    uiReciboResumen.Concepto = item["Concepto"].ToString();
                    uiReciboResumen.Fecha = DateTime.Parse(item["Fecha"].ToString());
                    uiReciboResumen.Monto = double.Parse(item["Monto"].ToString());
                    lstUiRecibosResumen.Add(uiReciboResumen);
                }

                return lstUiRecibosResumen;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}