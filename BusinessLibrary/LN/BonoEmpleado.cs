using BE = ErpCasino.BusinessLibrary.BE;
using DA = ErpCasino.BusinessLibrary.DA;
using System.Collections.Generic;
using System;

namespace ErpCasino.BusinessLibrary.LN
{

    public class BonoEmpleado
    {

        private BE.UI.BonoEmpleado BeToUi(BE.BonoEmpleado beBonoEmpleado)
        {
            try
            {
                var uiBonoEmpleado = new BE.UI.BonoEmpleado();

                uiBonoEmpleado.ID = beBonoEmpleado.IdBonoEmpleado;
                uiBonoEmpleado.Fecha = beBonoEmpleado.Fecha;
                uiBonoEmpleado.EmpleadoCodigo = beBonoEmpleado.CodigoEmpleado;
                uiBonoEmpleado.EmpleadoNombreCompleto = new LN.Empleado().ObtenerNombreCompleto(beBonoEmpleado.CodigoEmpleado);
                uiBonoEmpleado.BonoID = beBonoEmpleado.Bono.IdBono;
                uiBonoEmpleado.BonoTipo = beBonoEmpleado.Bono.Calculado == true ? "Calculado" : "Manual"; //Manual o Calculado
                uiBonoEmpleado.BonoNombre = beBonoEmpleado.Bono.Nombre;
                uiBonoEmpleado.Motivo = beBonoEmpleado.Motivo;
                uiBonoEmpleado.Monto = beBonoEmpleado.Monto;

                return uiBonoEmpleado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private BE.BonoEmpleado UiToBe(BE.UI.BonoEmpleado uiBonoEmpleado)
        {
            try
            {
                var beBonoEmpleado = new BE.BonoEmpleado();

                beBonoEmpleado.IdBonoEmpleado = uiBonoEmpleado.ID;
                beBonoEmpleado.Fecha = uiBonoEmpleado.Fecha;
                beBonoEmpleado.CodigoEmpleado = uiBonoEmpleado.EmpleadoCodigo;
                beBonoEmpleado.Motivo = uiBonoEmpleado.Motivo;
                beBonoEmpleado.Monto = uiBonoEmpleado.Monto;

                var beBono = new BE.Bono();
                beBono.IdBono = uiBonoEmpleado.BonoID;
                beBono.Nombre = uiBonoEmpleado.BonoNombre;
                beBono.Calculado = uiBonoEmpleado.BonoTipo.Equals("Calculado"); //Manual o Calculado
                beBonoEmpleado.Bono = beBono;

                return beBonoEmpleado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insertar(ref BE.UI.BonoEmpleado uiBonoEmpleado)
        {
            try
            {
                var beBonoEmpleado = this.UiToBe(uiBonoEmpleado);
                int rowsAffected = new DA.BonoEmpleado().Insertar(ref beBonoEmpleado);
                uiBonoEmpleado.ID = beBonoEmpleado.IdBonoEmpleado;
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Actualizar(BE.UI.BonoEmpleado uiBonoEmpleado)
        {
            try
            {
                var beBonoEmpleado = this.UiToBe(uiBonoEmpleado);
                int rowsAffected = new DA.BonoEmpleado().Actualizar(beBonoEmpleado);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(BE.UI.BonoEmpleado uiBonoEmpleado)
        {
            try
            {
                var beBonoEmpleado = this.UiToBe(uiBonoEmpleado);
                int rowsAffected = new DA.BonoEmpleado().Eliminar(beBonoEmpleado.IdBonoEmpleado);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(int idBonoEmpleado)
        {
            try
            {
                int rowsAffected = new DA.BonoEmpleado().Eliminar(idBonoEmpleado);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.UI.BonoEmpleado> Listar(int anho, int mes, string codigoEmpleado)
        {
            try
            {
                var lstUiBonoEmpleados = new List<BE.UI.BonoEmpleado>();

                var lstBeBonoEmpleados = new DA.BonoEmpleado().Listar(anho, mes, codigoEmpleado);
                foreach (BE.BonoEmpleado beBonoEmpleado in lstBeBonoEmpleados)
                {
                    BE.UI.BonoEmpleado uiBonoEmpleado = this.BeToUi(beBonoEmpleado);
                    lstUiBonoEmpleados.Add(uiBonoEmpleado);
                }

                return lstUiBonoEmpleados;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Validar si existe bonos calcululados para el periodo (año y mes) y tipo de bono
        /// </summary>
        /// <param name="anho">Año de consulta en formato yyyy. Ejm: 2017</param>
        /// <param name="mes">Mes de consulta en rango del 1 al 12. Ejm: 1</param>
        /// <param name="idBono">ID del tipo de bono</param>
        /// <returns></returns>
        public bool ExisteCalculo(int anho, int mes, int idBono)
        {
            try
            {
                return new DA.BonoEmpleado().ExisteCalculo(anho, mes, idBono);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}