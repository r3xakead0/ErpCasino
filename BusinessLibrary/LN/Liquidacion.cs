using BE = ErpCasino.BusinessLibrary.BE;
using DA = ErpCasino.BusinessLibrary.DA;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System;

namespace ErpCasino.BusinessLibrary.LN
{

    public class Liquidacion
    {

        public bool Insertar(ref BE.UI.Liquidacion uiLiquidacion)
        {
            try
            {
                bool rpta = false;

                //BE.Liquidacion beLiquidacion = new BE.Liquidacion();
                //beLiquidacion.CodigoEmpleado = uiLiquidacion.CodigoEmpleado;
                //beLiquidacion.IdBanco = uiLiquidacion.IdBanco;
                //beLiquidacion.Tipo = uiLiquidacion.CodigoTipo;
                //beLiquidacion.Fecha = uiLiquidacion.Fecha;
                //beLiquidacion.Numero = uiLiquidacion.Numero;
                //beLiquidacion.Monto = uiLiquidacion.Monto;

                //rpta = new DA.Liquidacion().Insertar(ref beLiquidacion);

                return rpta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Actualizar(BE.UI.Liquidacion uiLiquidacion)
        {
            try
            {
                bool rpta = false;

                //BE.Liquidacion beLiquidacion = new BE.Liquidacion();
                //beLiquidacion.IdLiquidacion = uiLiquidacion.IdLiquidacion;
                //beLiquidacion.CodigoEmpleado = uiLiquidacion.CodigoEmpleado;
                //beLiquidacion.IdBanco = uiLiquidacion.IdBanco;
                //beLiquidacion.Tipo = uiLiquidacion.CodigoTipo;
                //beLiquidacion.Fecha = uiLiquidacion.Fecha;
                //beLiquidacion.Numero = uiLiquidacion.Numero;
                //beLiquidacion.Monto = uiLiquidacion.Monto;

                //rpta = new DA.Liquidacion().Actualizar(beLiquidacion);

                return rpta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(int idLiquidacion)
        {
            try
            {
                bool rpta = false;
                //rpta = new DA.Liquidacion().Eliminar(idLiquidacion);
                return rpta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.UI.Liquidacion> Listar()
        {
          try
            {
                List<BE.UI.Liquidacion> lstUiLiquidaciones = new List<BE.UI.Liquidacion>();

                //List<BE.Liquidacion> lstBeLiquidacions = new DA.Liquidacion().Listar();
                //foreach (BE.Liquidacion beLiquidacion in lstBeLiquidacions)
                //{
                //    var uiLiquidacion = new BE.UI.Liquidacion();
                //    uiLiquidacion.IdLiquidacion = beLiquidacion.IdLiquidacion;
                //    uiLiquidacion.Fecha = beLiquidacion.Fecha;
                //    uiLiquidacion.Numero = beLiquidacion.Numero;
                //    uiLiquidacion.Monto = beLiquidacion.Monto;

                //    uiLiquidacion.CodigoEmpleado = beLiquidacion.CodigoEmpleado;
                //    uiLiquidacion.NombreCompletoEmpleado = new DA.ClsDaTbEmpleado().ObtenerNombreCompleto(beLiquidacion.CodigoEmpleado);

                //    uiLiquidacion.IdBanco = beLiquidacion.IdBanco;
                //    BE.Banco beBanco = new BE.Banco() { IdBanco = uiLiquidacion.IdBanco };
                //    if(new DA.Banco().Obtener(ref beBanco) == true)
                //    {
                //        uiLiquidacion.NombreBanco = beBanco.Nombre;
                //    }

                //    uiLiquidacion.CodigoTipo = beLiquidacion.Tipo;
                //    BE.Record beTipo = new LN.Record().ObtenerTipoLiquidacion(uiLiquidacion.CodigoTipo);
                //    if (beTipo != null)
                //    {
                //        uiLiquidacion.NombreTipo = beTipo.Nombre;
                //    }

                //    lstUiLiquidaciones.Add(uiLiquidacion);
                //}

                return lstUiLiquidaciones;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.UI.Liquidacion Obtener(int idLiquidacion)
        {
            try
            {
                //var beLiquidacion = new DA.Liquidacion().Obtener(idLiquidacion);

                var uiLiquidacion = new BE.UI.Liquidacion();
                //uiLiquidacion.IdLiquidacion = beLiquidacion.IdLiquidacion;
                //uiLiquidacion.Fecha = beLiquidacion.Fecha;
                //uiLiquidacion.Numero = beLiquidacion.Numero;
                //uiLiquidacion.Monto = beLiquidacion.Monto;

                //uiLiquidacion.CodigoEmpleado = beLiquidacion.CodigoEmpleado;
                //uiLiquidacion.NombreCompletoEmpleado = new DA.ClsDaTbEmpleado().ObtenerNombreCompleto(beLiquidacion.CodigoEmpleado);

                //uiLiquidacion.IdBanco = beLiquidacion.IdBanco;
                //BE.Banco beBanco = new BE.Banco() { IdBanco = uiLiquidacion.IdBanco };
                //if (new DA.Banco().Obtener(ref beBanco) == true)
                //{
                //    uiLiquidacion.NombreBanco = beBanco.Nombre;
                //}

                //uiLiquidacion.CodigoTipo = beLiquidacion.Tipo;
                //BE.Record beTipo = new LN.Record().ObtenerTipoLiquidacion(uiLiquidacion.CodigoTipo);
                //if (beTipo != null)
                //{
                //    uiLiquidacion.NombreTipo = beTipo.Nombre;
                //}

                return uiLiquidacion;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}