using BE = ErpCasino.BusinessLibrary.BE;
using DA = ErpCasino.BusinessLibrary.DA;
using System.Collections.Generic;
using System;

namespace ErpCasino.BusinessLibrary.LN
{

    public class Bono
    {

        private BE.UI.Bono BeToUi(BE.Bono beBono)
        {
            try
            {
                var uiBono = new BE.UI.Bono();

                uiBono.Id = beBono.IdBono;
                uiBono.Nombre = beBono.Nombre;
                uiBono.Descripcion = beBono.Descripcion;
                uiBono.Activo = beBono.Activo;
                uiBono.Calculado = beBono.Calculado;
                uiBono.Monto = beBono.Monto;

                return uiBono;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private BE.Bono UiToBe(BE.UI.Bono uiBono)
        {
            try
            {
                var beBono = new BE.Bono();

                beBono.IdBono = uiBono.Id;
                beBono.Nombre = uiBono.Nombre;
                beBono.Descripcion = uiBono.Descripcion;
                beBono.Activo = uiBono.Activo;
                beBono.Calculado = uiBono.Calculado;
                beBono.Monto = uiBono.Monto;

                return beBono;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insertar(ref BE.UI.Bono uiBono)
        {
            try
            {
                var beBono = this.UiToBe(uiBono);

                bool rpta = new DA.Bono().Insertar(ref beBono);
                uiBono = this.BeToUi(beBono);

                return rpta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Actualizar(BE.UI.Bono uiBono)
        {
            try
            {
                var beBono = this.UiToBe(uiBono);
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

        public List<BE.UI.Bono> Listar()
        {
          try
            {
                var lstUiBonos = new List<BE.UI.Bono>();

                var lstBeBonos = new DA.Bono().Listar();
                foreach (BE.Bono beBono in lstBeBonos)
                {
                    BE.UI.Bono uiBono = this.BeToUi(beBono);
                    lstUiBonos.Add(uiBono);
                }

                return lstUiBonos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.UI.Bono Obtener(int idBono)
        {
            try
            {
                var beBono = new DA.Bono().Obtener(idBono);
                var uiBono = this.BeToUi(beBono);
                return uiBono;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}