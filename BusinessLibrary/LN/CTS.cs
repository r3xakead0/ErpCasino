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

        public bool Insertar(ref BE.UI.CTS uiCTS)
        {
            try
            {
                BE.CTS beCTS = new BE.CTS();
                beCTS.CodigoEmpleado = uiCTS.EmpleadoCodigo;
                beCTS.FechaDeposito = uiCTS.FechaDeposito;
                beCTS.FechaPeriodoInicial = uiCTS.FechaPeriodoInicial;
                beCTS.FechaPeriodoFinal = uiCTS.FechaPeriodoFinal;
                beCTS.Monto = uiCTS.Monto;

                return new DA.CTS().Insertar(ref beCTS);
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
                BE.CTS beCTS = new BE.CTS();
                beCTS.IdCts = uiCTS.IdCts;
                beCTS.CodigoEmpleado = uiCTS.EmpleadoCodigo;
                beCTS.FechaDeposito = uiCTS.FechaDeposito;
                beCTS.FechaPeriodoInicial = uiCTS.FechaPeriodoInicial;
                beCTS.FechaPeriodoFinal = uiCTS.FechaPeriodoFinal;
                beCTS.Monto = uiCTS.Monto;

                return new DA.CTS().Actualizar(beCTS);
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
                return new DA.CTS().Eliminar(idCTS);
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
                    var uiCTS = new BE.UI.CTS();

                    uiCTS.IdCts = beCTS.IdCts;
                    uiCTS.FechaDeposito = beCTS.FechaDeposito;
                    uiCTS.FechaPeriodoInicial = beCTS.FechaPeriodoInicial;
                    uiCTS.FechaPeriodoFinal = beCTS.FechaPeriodoFinal;
                    uiCTS.Monto = beCTS.Monto;
                    uiCTS.EmpleadoCodigo = beCTS.CodigoEmpleado;
                    uiCTS.EmpleadoNombre = new DA.ClsDaTbEmpleado().ObtenerNombreCompleto(beCTS.CodigoEmpleado);

                    lstUiCTS.Add(uiCTS);
                }

                return lstUiCTS.OrderBy(x => x.FechaDeposito).ToList();
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

                var uiCTS = new BE.UI.CTS();

                uiCTS.IdCts = beCTS.IdCts;
                uiCTS.FechaDeposito = beCTS.FechaDeposito;
                uiCTS.FechaPeriodoInicial = beCTS.FechaPeriodoInicial;
                uiCTS.FechaPeriodoFinal = beCTS.FechaPeriodoFinal;
                uiCTS.Monto = beCTS.Monto;
                uiCTS.EmpleadoCodigo = beCTS.CodigoEmpleado;
                uiCTS.EmpleadoNombre = new DA.ClsDaTbEmpleado().ObtenerNombreCompleto(beCTS.CodigoEmpleado);

                return uiCTS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}