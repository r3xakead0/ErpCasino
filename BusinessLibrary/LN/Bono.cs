using BE = ErpCasino.BusinessLibrary.BE;
using DA = ErpCasino.BusinessLibrary.DA;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System;

namespace ErpCasino.BusinessLibrary.LN
{

    public class Bono
    {

        public bool Insertar(ref BE.Bono beBono)
        {
            try
            {
                return new DA.Bono().Insertar(ref beBono);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Actualizar(BE.Bono beBono)
        {
            try
            {
                return new DA.Bono().Actualizar(beBono);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(int idBono)
        {
            try
            {
                return new DA.Bono().Eliminar(idBono);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.Bono> Listar()
        {
          try
            {
                return new DA.Bono().Listar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.Bono Obtener(int idBono)
        {
            try
            {
                return new DA.Bono().Obtener(idBono);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}