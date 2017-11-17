using BE = ErpCasino.BusinessLibrary.BE;
using DA = ErpCasino.BusinessLibrary.DA;
using System.Collections.Generic;
using System;

namespace ErpCasino.BusinessLibrary.LN
{

    public class Observacion
    {

        private int idUsuario = 0;

        public Observacion(int idUsuario)
        {
            this.idUsuario = idUsuario;
        }

        private BE.UI.Observacion BeToUI(BE.Observacion beObservacion)
        {
            try
            {
                var uiObservacion = new BE.UI.Observacion();

                uiObservacion.Id = beObservacion.IdObservacion;
                uiObservacion.Nombre = beObservacion.Nombre;
                uiObservacion.Descripcion = beObservacion.Descripcion;
                uiObservacion.Activo = beObservacion.Activo ? BE.UI.ActivoEnum.Si : BE.UI.ActivoEnum.No;

                return uiObservacion;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private BE.Observacion UiToBe(BE.UI.Observacion uiObservacion)
        {
            try
            {
                var beObservacion = new BE.Observacion();

                beObservacion.IdObservacion = uiObservacion.Id;
                beObservacion.Nombre = uiObservacion.Nombre;
                beObservacion.Descripcion = uiObservacion.Descripcion;
                beObservacion.Activo = uiObservacion.Activo.Equals(BE.UI.ActivoEnum.Si) ? true : false;

                return beObservacion;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insertar(ref BE.UI.Observacion uiObservacion)
        {
            try
            {
                var beObservacion = this.UiToBe(uiObservacion);
                int rowsAffected = new DA.Observacion(idUsuario).Insertar(ref beObservacion);
                uiObservacion.Id = beObservacion.IdObservacion;
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Actualizar(BE.UI.Observacion uiObservacion)
        {
            try
            {
                var beObservacion = this.UiToBe(uiObservacion);
                int rowsAffected = new DA.Observacion(idUsuario).Actualizar(beObservacion);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(BE.UI.Observacion uiObservacion)
        {
            try
            {
                var beObservacion = this.UiToBe(uiObservacion);
                int rowsAffected = new DA.Observacion(idUsuario).Eliminar(beObservacion.IdObservacion);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(int idObservacion)
        {
            try
            {
                int rowsAffected = new DA.Observacion(idUsuario).Eliminar(idObservacion);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.UI.Observacion> Listar()
        {
            try
            {
                var lstUiObservaciones = new List<BE.UI.Observacion>();

                var lstBeObservaciones = new DA.Observacion(idUsuario).Listar();
                foreach (BE.Observacion beObservacion in lstBeObservaciones)
                {
                    BE.UI.Observacion uiObservacion = this.BeToUI(beObservacion);
                    lstUiObservaciones.Add(uiObservacion);
                }

                return lstUiObservaciones;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.UI.Observacion Obtener(int idObservacion)
        {
            try
            {
                var beObservacion = new DA.Observacion(idUsuario).Obtener(idObservacion);

                BE.UI.Observacion uiObservacion = this.BeToUI(beObservacion);
                
                return uiObservacion;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}