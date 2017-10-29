using BE = ErpCasino.BusinessLibrary.BE;
using DA = ErpCasino.BusinessLibrary.DA;
using System.Collections.Generic;
using System;

namespace ErpCasino.BusinessLibrary.LN
{

    public class Vacacion
    {

        public bool Insertar(ref BE.UI.Vacacion uiVacacion)
        {
            try
            {
                int rowsAffected = 0;
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Actualizar(BE.UI.Vacacion uiVacacion)
        {
            try
            {
                int rowsAffected = 0;
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(int idVacacion)
        {
            try
            {
                int rowsAffected = 0;
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.UI.Vacacion> Listar(int anho, int mes)
        {
            try
            {
                List<BE.UI.Vacacion> lstUiVacacions = new List<BE.UI.Vacacion>();
                return lstUiVacacions;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.UI.Vacacion Obtener(int idVacacion)
        {
            try
            {
                var uiVacacion = new BE.UI.Vacacion();
                
                return uiVacacion;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}