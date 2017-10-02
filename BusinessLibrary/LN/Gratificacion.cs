using BE = ErpCasino.BusinessLibrary.BE;
using DA = ErpCasino.BusinessLibrary.DA;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System;

namespace ErpCasino.BusinessLibrary.LN
{

    public class Gratificacion
    {

        private string NombreMes(int numeroMes)
        {
            string nombreMes = "";

            switch (numeroMes)
            {
                case 1:
                    nombreMes = "Enero";
                    break;
                case 2:
                    nombreMes = "Febrero";
                    break;
                case 3:
                    nombreMes = "Marzo";
                    break;
                case 4:
                    nombreMes = "Abril";
                    break;
                case 5:
                    nombreMes = "Mayo";
                    break;
                case 6:
                    nombreMes = "Junio";
                    break;
                case 7:
                    nombreMes = "Julio";
                    break;
                case 8:
                    nombreMes = "Agosto";
                    break;
                case 9:
                    nombreMes = "Septiembre";
                    break;
                case 10:
                    nombreMes = "Octubre";
                    break;
                case 11:
                    nombreMes = "Noviembre";
                    break;
                default:
                    nombreMes = "Diciembre";
                    break;
            }

            return nombreMes;
        }

        #region Traductor UI a BE
        private BE.Gratificacion GratificacionUiToBe(BE.UI.Gratificacion uiGratificacion)
        {
            var beGratificacion = new BE.Gratificacion();

            beGratificacion.IdGratificacion = uiGratificacion.Id;
            beGratificacion.Periodo = uiGratificacion.Periodo;
            beGratificacion.FechaInicio = uiGratificacion.FechaInicial;
            beGratificacion.FechaFinal = uiGratificacion.FechaFinal;
            beGratificacion.Dias = uiGratificacion.Dias;
            beGratificacion.CodigoEmpleado = uiGratificacion.EmpleadoCodigo;
            beGratificacion.BonoNocturnoPromedio = uiGratificacion.BonoNocturno;
            beGratificacion.BonoHorasExtrasPromedio = uiGratificacion.BonoHorasExtras;
            beGratificacion.SueldoBase = uiGratificacion.SueldoBase;
            beGratificacion.AsignacionFamiliar = uiGratificacion.AsignacionFamiliar;
            beGratificacion.DiasLaborados = uiGratificacion.DiasCalculo;
            beGratificacion.GratificacionBruta = uiGratificacion.GratificacionBruta;
            beGratificacion.BonoExtraordinario = uiGratificacion.GratificacionBono;
            beGratificacion.GratificacionNeta = uiGratificacion.GratificacionNeta;
            beGratificacion.DescuentoRetencionJudicial = uiGratificacion.DescuentoRetencioJudicial;
            beGratificacion.DescuentoImpuesto = uiGratificacion.DescuentoImpuestos;
            beGratificacion.GratificacionPagar = uiGratificacion.GratificacionPago;

            if (uiGratificacion.Detalle != null)
            {
                beGratificacion.Detalle = new List<BE.GratificacionDetalle>();

                foreach (var uiGratificacionDetalle in uiGratificacion.Detalle)
                {
                    var beGratificacionDetalle = this.GratificacionDetalleUiToBe(uiGratificacionDetalle);
                    beGratificacion.Detalle.Add(beGratificacionDetalle);
                }
            }

            return beGratificacion;
        }

        private BE.GratificacionDetalle GratificacionDetalleUiToBe(BE.UI.GratificacionDetalle uiGratificacionDetalle)
        {
            var beGratificacionDetalle = new BE.GratificacionDetalle();

            beGratificacionDetalle.IdGratificacionDetalle = uiGratificacionDetalle.Id;
            beGratificacionDetalle.Anho = uiGratificacionDetalle.Anho;
            beGratificacionDetalle.Mes = uiGratificacionDetalle.MesId;
            beGratificacionDetalle.CodigoEmpleado = uiGratificacionDetalle.EmpleadoCodigo;
            beGratificacionDetalle.BonoNocturno = uiGratificacionDetalle.BonoNocturno;
            beGratificacionDetalle.BonoHorasExtras = uiGratificacionDetalle.BonoHorasExtras;
            beGratificacionDetalle.DiasCalendario = uiGratificacionDetalle.DiasMes;
            beGratificacionDetalle.DiasInasistencia = uiGratificacionDetalle.DiasInasistencias;

            return beGratificacionDetalle;
        }
        #endregion

        #region Traductor BE a UI
        private BE.UI.Gratificacion GratificacionBeToUi(BE.Gratificacion beGratificacion)
        {
            var uiGratificacion = new BE.UI.Gratificacion();

            uiGratificacion.Id = beGratificacion.IdGratificacion;
            uiGratificacion.Periodo = beGratificacion.Periodo;
            uiGratificacion.FechaInicial = beGratificacion.FechaInicio;
            uiGratificacion.FechaFinal = beGratificacion.FechaFinal;
            uiGratificacion.Dias = beGratificacion.Dias;
            uiGratificacion.EmpleadoCodigo = beGratificacion.CodigoEmpleado;
            uiGratificacion.EmpleadoNombres = new LN.Empleado().ObtenerNombreCompleto(beGratificacion.CodigoEmpleado);
            uiGratificacion.BonoNocturno = beGratificacion.BonoNocturnoPromedio;
            uiGratificacion.BonoHorasExtras = beGratificacion.BonoHorasExtrasPromedio;
            uiGratificacion.SueldoBase = beGratificacion.SueldoBase;
            uiGratificacion.AsignacionFamiliar = beGratificacion.AsignacionFamiliar;
            uiGratificacion.DiasCalculo = beGratificacion.DiasLaborados;
            uiGratificacion.GratificacionBruta = beGratificacion.GratificacionBruta;
            uiGratificacion.GratificacionBono = beGratificacion.BonoExtraordinario;
            uiGratificacion.GratificacionNeta = beGratificacion.GratificacionNeta;
            uiGratificacion.DescuentoRetencioJudicial = beGratificacion.DescuentoRetencionJudicial;
            uiGratificacion.DescuentoImpuestos = beGratificacion.DescuentoImpuesto;
            uiGratificacion.GratificacionPago = beGratificacion.GratificacionPagar;

            if (beGratificacion.Detalle != null)
            {
                uiGratificacion.Detalle = new List<BE.UI.GratificacionDetalle>();

                foreach (var beGratificacionDetalle in beGratificacion.Detalle)
                {
                    var uiGratificacionDetalle = this.GratificacionDetalleBeToUi(beGratificacionDetalle);
                    uiGratificacion.Detalle.Add(uiGratificacionDetalle);
                }
            }

            return uiGratificacion;
        }

        private BE.UI.GratificacionDetalle GratificacionDetalleBeToUi(BE.GratificacionDetalle beGratificacionDetalle)
        {
            var uiGratificacionDetalle = new BE.UI.GratificacionDetalle();

            uiGratificacionDetalle.Id = beGratificacionDetalle.IdGratificacionDetalle;
            uiGratificacionDetalle.Anho = beGratificacionDetalle.Anho;
            uiGratificacionDetalle.MesId = beGratificacionDetalle.Mes;
            uiGratificacionDetalle.MesNombre = this.NombreMes(beGratificacionDetalle.Mes);
            uiGratificacionDetalle.EmpleadoCodigo = beGratificacionDetalle.CodigoEmpleado;
            uiGratificacionDetalle.BonoNocturno = beGratificacionDetalle.BonoNocturno;
            uiGratificacionDetalle.BonoHorasExtras = beGratificacionDetalle.BonoHorasExtras;
            uiGratificacionDetalle.DiasMes = beGratificacionDetalle.DiasCalendario;
            uiGratificacionDetalle.DiasInasistencias = beGratificacionDetalle.DiasInasistencia;
            uiGratificacionDetalle.DiasCalculo = uiGratificacionDetalle.DiasMes - uiGratificacionDetalle.DiasInasistencias;

            return uiGratificacionDetalle;
        }
        #endregion

        public bool Insertar(ref BE.UI.Gratificacion uiGratificacion)
        {
            try
            {
                var beGratificacion = this.GratificacionUiToBe(uiGratificacion);
                var rpta = new DA.Gratificacion().Insertar(ref beGratificacion);
                return (rpta > 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Actualizar(BE.UI.Gratificacion uiGratificacion)
        {
            try
            {
                var beGratificacion = this.GratificacionUiToBe(uiGratificacion);
                var rpta = new DA.Gratificacion().Actualizar(beGratificacion);
                return (rpta > 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(int idGratificacion)
        {
            try
            {
                var rpta = new DA.Gratificacion().Eliminar(idGratificacion);
                return (rpta > 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.UI.Gratificacion> Listar(bool detalle = false)
        {
          try
            {
                List<BE.UI.Gratificacion> lstUiGratificaciones = new List<BE.UI.Gratificacion>();

                List<BE.Gratificacion> lstBeGratificaciones = new DA.Gratificacion().Listar(detalle);
                foreach (BE.Gratificacion beGratificacion in lstBeGratificaciones)
                {
                    var uiGratificacion = this.GratificacionBeToUi(beGratificacion);
                    uiGratificacion.EmpleadoNombres = new LN.Empleado().ObtenerNombreCompleto(uiGratificacion.EmpleadoCodigo);
                    lstUiGratificaciones.Add(uiGratificacion);
                }

                return lstUiGratificaciones;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.UI.Gratificacion Obtener(int idGratificacion)
        {
            try
            {
                var beGratificacion = new DA.Gratificacion().Obtener(idGratificacion);
                var uiGratificacion = this.GratificacionBeToUi(beGratificacion);
                return uiGratificacion;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}