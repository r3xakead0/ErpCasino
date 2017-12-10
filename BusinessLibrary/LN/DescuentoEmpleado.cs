using BE = ErpCasino.BusinessLibrary.BE;
using DA = ErpCasino.BusinessLibrary.DA;
using System.Collections.Generic;
using System;

namespace ErpCasino.BusinessLibrary.LN
{

    public class DescuentoEmpleado
    {

        private BE.UI.DescuentoEmpleado BeToUI(BE.DescuentoEmpleado beDescuentoEmpleado)
        {
            try
            {
                var uiDescuentoEmpleado = new BE.UI.DescuentoEmpleado();

                uiDescuentoEmpleado.ID = beDescuentoEmpleado.IdDescuentoEmpleado;
                uiDescuentoEmpleado.Fecha = beDescuentoEmpleado.Fecha;
                uiDescuentoEmpleado.EmpleadoCodigo = beDescuentoEmpleado.CodigoEmpleado;
                uiDescuentoEmpleado.EmpleadoNombreCompleto = new LN.Empleado().ObtenerNombreCompleto(beDescuentoEmpleado.CodigoEmpleado);
                uiDescuentoEmpleado.DescuentoID = beDescuentoEmpleado.Descuento.IdDescuento;
                uiDescuentoEmpleado.DescuentoNombre = beDescuentoEmpleado.Descuento.Nombre;
                uiDescuentoEmpleado.Motivo = beDescuentoEmpleado.Motivo;
                uiDescuentoEmpleado.Monto = beDescuentoEmpleado.Monto;

                return uiDescuentoEmpleado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private BE.DescuentoEmpleado UiToBe(BE.UI.DescuentoEmpleado uiDescuentoEmpleado)
        {
            try
            {
                var beDescuentoEmpleado = new BE.DescuentoEmpleado();

                beDescuentoEmpleado.IdDescuentoEmpleado = uiDescuentoEmpleado.ID;
                beDescuentoEmpleado.Fecha = uiDescuentoEmpleado.Fecha;
                beDescuentoEmpleado.CodigoEmpleado = uiDescuentoEmpleado.EmpleadoCodigo;
                beDescuentoEmpleado.Motivo = uiDescuentoEmpleado.Motivo;
                beDescuentoEmpleado.Monto = uiDescuentoEmpleado.Monto;

                var beDescuento = new BE.Descuento();
                beDescuento.IdDescuento = uiDescuentoEmpleado.DescuentoID;
                beDescuento.Nombre = uiDescuentoEmpleado.DescuentoNombre;
                beDescuentoEmpleado.Descuento = beDescuento;

                return beDescuentoEmpleado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insertar(ref BE.UI.DescuentoEmpleado uiDescuentoEmpleado)
        {
            try
            {
                var beDescuentoEmpleado = this.UiToBe(uiDescuentoEmpleado);
                int rowsAffected = new DA.DescuentoEmpleado().Insertar(ref beDescuentoEmpleado);
                uiDescuentoEmpleado.ID = beDescuentoEmpleado.IdDescuentoEmpleado;
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Actualizar(BE.UI.DescuentoEmpleado uiDescuentoEmpleado)
        {
            try
            {
                var beDescuentoEmpleado = this.UiToBe(uiDescuentoEmpleado);
                int rowsAffected = new DA.DescuentoEmpleado().Actualizar(beDescuentoEmpleado);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(BE.UI.DescuentoEmpleado uiDescuentoEmpleado)
        {
            try
            {
                var beDescuentoEmpleado = this.UiToBe(uiDescuentoEmpleado);
                int rowsAffected = new DA.DescuentoEmpleado().Eliminar(beDescuentoEmpleado.IdDescuentoEmpleado);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(int idDescuentoEmpleado)
        {
            try
            {
                int rowsAffected = new DA.DescuentoEmpleado().Eliminar(idDescuentoEmpleado);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.UI.DescuentoEmpleado> Listar(int anho, int mes)
        {
            try
            {
                var lstUiDescuentoEmpleados = new List<BE.UI.DescuentoEmpleado>();

                var lstBeDescuentoEmpleados = new DA.DescuentoEmpleado().Listar(anho, mes);
                foreach (BE.DescuentoEmpleado beDescuentoEmpleado in lstBeDescuentoEmpleados)
                {
                    BE.UI.DescuentoEmpleado uiDescuentoEmpleado = this.BeToUI(beDescuentoEmpleado);
                    lstUiDescuentoEmpleados.Add(uiDescuentoEmpleado);
                }

                return lstUiDescuentoEmpleados;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Validar si existe descuentos calculados para el periodo (año y mes) y tipo de bono
        /// </summary>
        /// <param name="anho">Año de consulta en formato yyyy. Ejm: 2017</param>
        /// <param name="mes">Mes de consulta en rango del 1 al 12. Ejm: 1</param>
        /// <param name="descuentoId">ID del tipo de descuento</param>
        /// <returns></returns>
        public bool ExisteCalculo(int anho, int mes, int descuentoId)
        {
            try
            {
                return new DA.DescuentoEmpleado().ExisteCalculo(anho, mes, descuentoId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}