using BE = ErpCasino.BusinessLibrary.BE;
using DA = ErpCasino.BusinessLibrary.DA;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System;

namespace ErpCasino.BusinessLibrary.LN
{

    public class Adelanto
    {

        public bool Insertar(ref BE.UI.Adelanto uiAdelanto)
        {
            try
            {
                BE.Adelanto beAdelanto = new BE.Adelanto();
                beAdelanto.CodigoEmpleado = uiAdelanto.CodigoEmpleado;
                beAdelanto.IdBanco = uiAdelanto.IdBanco;
                beAdelanto.Tipo = uiAdelanto.CodigoTipo;
                beAdelanto.Fecha = uiAdelanto.Fecha;
                beAdelanto.Numero = uiAdelanto.Numero;
                beAdelanto.Monto = uiAdelanto.Monto;

                return new DA.Adelanto().Insertar(ref beAdelanto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Actualizar(BE.UI.Adelanto uiAdelanto)
        {
            try
            {
                BE.Adelanto beAdelanto = new BE.Adelanto();
                beAdelanto.IdAdelanto = uiAdelanto.IdAdelanto;
                beAdelanto.CodigoEmpleado = uiAdelanto.CodigoEmpleado;
                beAdelanto.IdBanco = uiAdelanto.IdBanco;
                beAdelanto.Tipo = uiAdelanto.CodigoTipo;
                beAdelanto.Fecha = uiAdelanto.Fecha;
                beAdelanto.Numero = uiAdelanto.Numero;
                beAdelanto.Monto = uiAdelanto.Monto;

                return new DA.Adelanto().Actualizar(beAdelanto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(int idAdelanto)
        {
            try
            {
                return new DA.Adelanto().Eliminar(idAdelanto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public double ObtenerTotalBanco(int anho, int mes, string codigo)
        {
            double total = 0;
            string codigoTipoBanco = "BAN";
            try
            {

                var lstUiAdelantos = this.Listar(anho, mes);

                lstUiAdelantos = lstUiAdelantos.Where(x => x.CodigoTipo == codigoTipoBanco
                && x.CodigoEmpleado.Equals(codigo)).ToList();

                if (lstUiAdelantos != null && lstUiAdelantos.Count > 0)
                    total = lstUiAdelantos.Select(x => x.Monto).Sum();

                return total;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public double ObtenerTotalEfectivo(int anho, int mes, string codigo)
        {
            double total = 0;
            string codigoTipoEfectivo = "EFE";
            try
            {

                var lstUiAdelantos = this.Listar(anho, mes);

                lstUiAdelantos = lstUiAdelantos.Where(x => x.CodigoTipo == codigoTipoEfectivo 
                && x.CodigoEmpleado.Equals(codigo)).ToList();

                if (lstUiAdelantos != null && lstUiAdelantos.Count > 0)
                    total = lstUiAdelantos.Select(x => x.Monto).Sum();

                return total;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.UI.Adelanto> Listar(int anho, int mes)
        {
            try
            {
                List<BE.UI.Adelanto> lstUiAdelantos = new List<BE.UI.Adelanto>();

                List<BE.Adelanto> lstBeAdelantos = new DA.Adelanto().Listar(anho, mes);
                foreach (BE.Adelanto beAdelanto in lstBeAdelantos)
                {
                    var uiAdelanto = new BE.UI.Adelanto();
                    uiAdelanto.IdAdelanto = beAdelanto.IdAdelanto;
                    uiAdelanto.Fecha = beAdelanto.Fecha;
                    uiAdelanto.Numero = beAdelanto.Numero;
                    uiAdelanto.Monto = beAdelanto.Monto;

                    uiAdelanto.CodigoEmpleado = beAdelanto.CodigoEmpleado;
                    uiAdelanto.NombreCompletoEmpleado = new DA.ClsDaTbEmpleado().ObtenerNombreCompleto(beAdelanto.CodigoEmpleado);

                    uiAdelanto.IdBanco = beAdelanto.IdBanco;
                    BE.Banco beBanco = new BE.Banco() { IdBanco = uiAdelanto.IdBanco };
                    if (new DA.Banco().Obtener(ref beBanco) == true)
                    {
                        uiAdelanto.NombreBanco = beBanco.Nombre;
                    }

                    uiAdelanto.CodigoTipo = beAdelanto.Tipo;
                    BE.Record beTipo = new LN.Record().ObtenerTipoAdelanto(uiAdelanto.CodigoTipo);
                    if (beTipo != null)
                    {
                        uiAdelanto.NombreTipo = beTipo.Nombre;
                    }

                    lstUiAdelantos.Add(uiAdelanto);
                }

                return lstUiAdelantos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.UI.Adelanto Obtener(int idAdelanto)
        {
            try
            {
                var beAdelanto = new DA.Adelanto().Obtener(idAdelanto);

                var uiAdelanto = new BE.UI.Adelanto();
                uiAdelanto.IdAdelanto = beAdelanto.IdAdelanto;
                uiAdelanto.Fecha = beAdelanto.Fecha;
                uiAdelanto.Numero = beAdelanto.Numero;
                uiAdelanto.Monto = beAdelanto.Monto;

                uiAdelanto.CodigoEmpleado = beAdelanto.CodigoEmpleado;
                uiAdelanto.NombreCompletoEmpleado = new DA.ClsDaTbEmpleado().ObtenerNombreCompleto(beAdelanto.CodigoEmpleado);

                uiAdelanto.IdBanco = beAdelanto.IdBanco;
                BE.Banco beBanco = new BE.Banco() { IdBanco = uiAdelanto.IdBanco };
                if (new DA.Banco().Obtener(ref beBanco) == true)
                {
                    uiAdelanto.NombreBanco = beBanco.Nombre;
                }

                uiAdelanto.CodigoTipo = beAdelanto.Tipo;
                BE.Record beTipo = new LN.Record().ObtenerTipoAdelanto(uiAdelanto.CodigoTipo);
                if (beTipo != null)
                {
                    uiAdelanto.NombreTipo = beTipo.Nombre;
                }

                return uiAdelanto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}