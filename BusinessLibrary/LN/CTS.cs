using BE = ErpCasino.BusinessLibrary.BE;
using DA = ErpCasino.BusinessLibrary.DA;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System;

namespace ErpCasino.BusinessLibrary.LN
{

    public class CTS
    {

        private BE.CTS UiToBe (BE.UI.CTS uiCTS)
        {
            var beCTS = new BE.CTS();

            beCTS.IdCts = uiCTS.Id;
            beCTS.Anho = uiCTS.Anho;
            beCTS.Periodo = uiCTS.PeriodoNumero;
            beCTS.PeriodoFechaInicial = uiCTS.PeriodoFechaInicial;
            beCTS.PeriodoFechaFinal = uiCTS.PeriodoFechaFinal;
            beCTS.EmpleadoCodigo = uiCTS.EmpleadoCodigo;
            beCTS.EmpleadoFechaIngreso = uiCTS.EmpleadoFechaIngreso;
            beCTS.EmpleadoSueldo = uiCTS.EmpleadoSueldo;
            beCTS.EmpleadoAsigFam = uiCTS.EmpleadoAsignacionFamiliar;
            beCTS.TotalBonificacion = uiCTS.TotalBonificacion;
            beCTS.TotalHorasExtras = uiCTS.TotalHorasExtras;
            beCTS.TotalGratificacion = uiCTS.TotalGratificacion;
            beCTS.PromedioBonificacion = uiCTS.PromedioBonificacion;
            beCTS.PromedioHorasExtras = uiCTS.PromedioHorasExtras;
            beCTS.PromedioGratificacion = uiCTS.PromedioGratificacion;
            beCTS.ComputableTotal = uiCTS.ComputableTotal;
            beCTS.ComputableFechaInicial = uiCTS.ComputableFechaInicial;
            beCTS.ComputableFechaFinal = uiCTS.ComputableFechaFinal;
            beCTS.ComputableMeses = uiCTS.ComputableMeses;
            beCTS.ComputableDias = uiCTS.ComputableDias;
            beCTS.ComputablePagar = uiCTS.ComputablePagar;
            beCTS.Banco = new LN.Banco().Obtener(uiCTS.BancoId);
            beCTS.Cuenta = uiCTS.BancoCuenta;
            beCTS.DepositoFecha = uiCTS.DepositoFecha;
            beCTS.DepositoMonto = uiCTS.DepositoMonto;
            beCTS.DepositoOperacion = uiCTS.DepositoOperacion;

            return beCTS;
        }

        private BE.UI.CTS BeToUi(BE.CTS beCTS)
        {
            var uiCTS = new BE.UI.CTS();

            uiCTS.Id = beCTS.IdCts;
            uiCTS.Anho = beCTS.Anho;
            uiCTS.PeriodoNumero = beCTS.Periodo;

            switch (beCTS.Periodo)
            {
                case 1:
                    uiCTS.PeriodoNombre = "Mayo - Octubre";
                    break;
                case 2:
                    uiCTS.PeriodoNombre = "Noviembre - Abril";
                    break;
                default:
                    uiCTS.PeriodoNombre = "";
                    break;
            }

            uiCTS.PeriodoFechaInicial = beCTS.PeriodoFechaInicial;
            uiCTS.PeriodoFechaFinal = beCTS.PeriodoFechaFinal;
            uiCTS.EmpleadoCodigo = beCTS.EmpleadoCodigo;
            uiCTS.EmpleadoNombreCompleto = new LN.Empleado().ObtenerNombreCompleto(beCTS.EmpleadoCodigo);
            uiCTS.EmpleadoFechaIngreso = beCTS.EmpleadoFechaIngreso;
            uiCTS.EmpleadoSueldo = beCTS.EmpleadoSueldo;
            uiCTS.EmpleadoAsignacionFamiliar = beCTS.EmpleadoAsigFam;
            uiCTS.TotalBonificacion = beCTS.TotalBonificacion;
            uiCTS.TotalHorasExtras = beCTS.TotalHorasExtras;
            uiCTS.TotalGratificacion = beCTS.TotalGratificacion;
            uiCTS.PromedioBonificacion = beCTS.PromedioBonificacion;
            uiCTS.PromedioHorasExtras = beCTS.PromedioHorasExtras;
            uiCTS.PromedioGratificacion = beCTS.PromedioGratificacion;
            uiCTS.ComputableTotal = beCTS.ComputableTotal;
            uiCTS.ComputableFechaInicial = beCTS.ComputableFechaInicial;
            uiCTS.ComputableFechaFinal = beCTS.ComputableFechaFinal;
            uiCTS.ComputableMeses = beCTS.ComputableMeses;
            uiCTS.ComputableDias = beCTS.ComputableDias;
            uiCTS.ComputablePagar = beCTS.ComputablePagar;

            if (beCTS.Banco != null)
            {
                uiCTS.BancoId = beCTS.Banco.IdBanco;
                uiCTS.BancoNombre = beCTS.Banco.Nombre;
            }

            uiCTS.BancoCuenta = beCTS.Cuenta;
            uiCTS.DepositoFecha = beCTS.DepositoFecha;
            uiCTS.DepositoMonto = beCTS.DepositoMonto;
            uiCTS.DepositoOperacion = beCTS.DepositoOperacion;

            return uiCTS;
        }

        public bool Insertar(ref BE.UI.CTS uiCTS)
        {
            try
            {

                var beCTS = this.UiToBe(uiCTS);
                
                int rowsAffected = new DA.CTS().Insertar(ref beCTS);
                if (rowsAffected > 0)
                    uiCTS.Id = beCTS.IdCts;

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Actualizar(BE.UI.CTS uiCTS)
        {
            try
            {
                var beCTS = this.UiToBe(uiCTS);

                int rowsAffected = new DA.CTS().Actualizar(beCTS);

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(int idCTS)
        {
            try
            {
                int rowsAffected = new DA.CTS().Eliminar(idCTS);

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.UI.CTS> Listar()
        {
          try
            {
                List<BE.UI.CTS> lstUiCTS = new List<BE.UI.CTS>();

                List<BE.CTS> lstBeCTSs = new DA.CTS().Listar();
                foreach (BE.CTS beCTS in lstBeCTSs)
                {
                    var uiCTS = this.BeToUi(beCTS);
                    lstUiCTS.Add(uiCTS);
                }

                return lstUiCTS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.UI.CTS Obtener(int idCTS)
        {
            try
            {
                var beCTS = new DA.CTS().Obtener(idCTS);

                var uiCTS = this.BeToUi(beCTS);

                return uiCTS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}