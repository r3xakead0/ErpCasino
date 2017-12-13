using BE = ErpCasino.BusinessLibrary.BE;
using DA = ErpCasino.BusinessLibrary.DA;
using System.Data;
using System.Collections.Generic;
using System;

namespace ErpCasino.BusinessLibrary.LN
{

    public class Trabajador : IDisposable  
    {
        
        /// <summary>
        /// Obtener el tipo de trabajador (Candidato o Empleado) mediante su codigo
        /// </summary>
        /// <param name="codigoTrabajador">Codigo unico de trabajador</param>
        /// <returns></returns>
        public BE.UI.TipoTrabajadorEnum ObtenerTipo(string codigoTrabajador)
        {
            try
            {
                return new DA.Trabajador().ObtenerTipo(codigoTrabajador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtener el nombre completo ("Apellidos Paterno Materno, Nombres") mediante su codigo
        /// </summary>
        /// <param name="codigoTrabajador">Codigo unico de trabajador</param>
        /// <param name="activo">Opcional: Solo trabajador activo</param>
        /// <returns></returns>
        public string ObtenerNombreCompleto(string codigoTrabajador, bool? activo = null)
        {
            try
            {
                return new DA.Trabajador().ObtenerNombreCompleto(codigoTrabajador, activo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Validar si existe el codigo de trabajador
        /// </summary>
        /// <param name="codigoTrabajador">Codigo unico de trabajador</param>
        /// <param name="id">Opcional: Id de Empleado o Candidato</param>
        /// <returns></returns>
        public bool ValidarCodigo(string codigoTrabajador, int id = 0)
        {
            bool rpta = false;
            try
            {
                rpta = new DA.ClsDaTbCandidato().ValidarCodigo(id, codigoTrabajador);

                if (rpta == false)
                    rpta = new DA.ClsDaTbEmpleado().ValidarCodigo(id, codigoTrabajador);

                return rpta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Dispose
        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Free other state (managed objects).
                }
                // Free your own state (unmanaged objects).
                // Set large fields to null.
                disposed = true;
            }
        }

        #endregion
    }

}