using BE = ErpCasino.BusinessLibrary.BE;
using DA = ErpCasino.BusinessLibrary.DA;
using System.Collections.Generic;
using System;

namespace ErpCasino.BusinessLibrary.LN
{

    public class ObservacionEmpleado
    {

        private int idUsuario = 0;

        private BE.UI.ObservacionEmpleado BeToUI(BE.ObservacionEmpleado beObservacionEmpleado)
        {
            try
            {
                var uiObservacionEmpleado = new BE.UI.ObservacionEmpleado();

                uiObservacionEmpleado.ID = beObservacionEmpleado.IdObservacionEmpleado;
                uiObservacionEmpleado.Fecha = beObservacionEmpleado.Fecha;
                uiObservacionEmpleado.SalaID = beObservacionEmpleado.Sala.IdSala;
                uiObservacionEmpleado.SalaNombre = beObservacionEmpleado.Sala.Nombre;
                uiObservacionEmpleado.EmpleadoCodigo = beObservacionEmpleado.CodigoEmpleado;
                uiObservacionEmpleado.EmpleadoNombreCompleto = new LN.Empleado().ObtenerNombreCompleto(beObservacionEmpleado.CodigoEmpleado);
                uiObservacionEmpleado.ObservacionID = beObservacionEmpleado.Observacion.IdObservacion;
                uiObservacionEmpleado.ObservacionNombre = beObservacionEmpleado.Observacion.Nombre;
                uiObservacionEmpleado.ObservacionDescripcion = beObservacionEmpleado.Descripcion;

                return uiObservacionEmpleado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private BE.ObservacionEmpleado UiToBe(BE.UI.ObservacionEmpleado uiObservacionEmpleado)
        {
            try
            {
                var beObservacionEmpleado = new BE.ObservacionEmpleado();

                beObservacionEmpleado.IdObservacionEmpleado = uiObservacionEmpleado.ID;
                beObservacionEmpleado.Fecha = uiObservacionEmpleado.Fecha;
                beObservacionEmpleado.CodigoEmpleado = uiObservacionEmpleado.EmpleadoCodigo;
                beObservacionEmpleado.Descripcion = uiObservacionEmpleado.ObservacionDescripcion;

                var beSala = new BE.Sala();
                beSala.IdSala = uiObservacionEmpleado.SalaID;
                beSala.Nombre = uiObservacionEmpleado.SalaNombre;
                beObservacionEmpleado.Sala = beSala;

                var beObservacion = new BE.Observacion();
                beObservacion.IdObservacion = uiObservacionEmpleado.ObservacionID;
                beObservacion.Nombre = uiObservacionEmpleado.ObservacionNombre;
                beObservacionEmpleado.Observacion = beObservacion;

                return beObservacionEmpleado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insertar(ref BE.UI.ObservacionEmpleado uiObservacionEmpleado)
        {
            try
            {
                var beObservacionEmpleado = this.UiToBe(uiObservacionEmpleado);
                int rowsAffected = new DA.ObservacionEmpleado().Insertar(ref beObservacionEmpleado);
                uiObservacionEmpleado.ID = beObservacionEmpleado.IdObservacionEmpleado;
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Actualizar(BE.UI.ObservacionEmpleado uiObservacionEmpleado)
        {
            try
            {
                var beObservacionEmpleado = this.UiToBe(uiObservacionEmpleado);
                int rowsAffected = new DA.ObservacionEmpleado().Actualizar(beObservacionEmpleado);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(BE.UI.ObservacionEmpleado uiObservacionEmpleado)
        {
            try
            {
                var beObservacionEmpleado = this.UiToBe(uiObservacionEmpleado);
                int rowsAffected = new DA.ObservacionEmpleado().Eliminar(beObservacionEmpleado.IdObservacionEmpleado);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(int idObservacionEmpleado)
        {
            try
            {
                int rowsAffected = new DA.ObservacionEmpleado().Eliminar(idObservacionEmpleado);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.UI.ObservacionEmpleado> Listar(int anho, int mes)
        {
            try
            {
                var lstUiObservacionEmpleadoes = new List<BE.UI.ObservacionEmpleado>();

                var lstBeObservacionEmpleadoes = new DA.ObservacionEmpleado().Listar(anho, mes);
                foreach (BE.ObservacionEmpleado beObservacionEmpleado in lstBeObservacionEmpleadoes)
                {
                    BE.UI.ObservacionEmpleado uiObservacionEmpleado = this.BeToUI(beObservacionEmpleado);
                    lstUiObservacionEmpleadoes.Add(uiObservacionEmpleado);
                }

                return lstUiObservacionEmpleadoes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        

    }

}