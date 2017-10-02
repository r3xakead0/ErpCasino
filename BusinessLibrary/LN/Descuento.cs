using BE = ErpCasino.BusinessLibrary.BE;
using DA = ErpCasino.BusinessLibrary.DA;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System;

namespace ErpCasino.BusinessLibrary.LN
{

    public class Descuento
    {

        public bool Insertar(ref BE.Descuento beDescuento)
        {
            try
            {
                return new DA.Descuento().Insertar(ref beDescuento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Actualizar(BE.Descuento beDescuento)
        {
            try
            {
                return new DA.Descuento().Actualizar(beDescuento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(int idDescuento)
        {
            try
            {
                return new DA.Descuento().Eliminar(idDescuento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.Descuento> Listar()
        {
          try
            {
                return new DA.Descuento().Listar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.Descuento Obtener(int idDescuento)
        {
            try
            {
                return new DA.Descuento().Obtener(idDescuento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}