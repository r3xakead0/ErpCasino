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

        private BE.UI.Descuento BeToUi(BE.Descuento beDescuento)
        {
            var uiDescuento = new BE.UI.Descuento();

            uiDescuento.Id = beDescuento.IdDescuento;
            uiDescuento.Nombre = beDescuento.Nombre;
            uiDescuento.Descripcion = beDescuento.Descripcion;
            uiDescuento.Monto = beDescuento.Monto;
            uiDescuento.Calculado = beDescuento.Calculado;
            uiDescuento.Activo = beDescuento.Activo;

            return uiDescuento;
        }

        private BE.Descuento UiToBe(BE.UI.Descuento uiDescuento)
        {
            var beDescuento = new BE.Descuento();

            beDescuento.IdDescuento = uiDescuento.Id;
            beDescuento.Nombre = uiDescuento.Nombre;
            beDescuento.Descripcion = uiDescuento.Descripcion;
            beDescuento.Monto = uiDescuento.Monto;
            beDescuento.Calculado = uiDescuento.Calculado;
            beDescuento.Activo = uiDescuento.Activo;

            return beDescuento;
        }

        public bool Insertar(ref BE.UI.Descuento uiDescuento)
        {
            try
            {
                BE.Descuento beDescuento = this.UiToBe(uiDescuento);

                bool rpta = new DA.Descuento().Insertar(ref beDescuento);
                if (rpta)
                    uiDescuento.Id = beDescuento.IdDescuento;

                return rpta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Actualizar(BE.UI.Descuento uiDescuento)
        {
            try
            {
                BE.Descuento beDescuento = this.UiToBe(uiDescuento);

                return new DA.Descuento().Actualizar(beDescuento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(BE.UI.Descuento uiDescuento)
        {
            try
            {
                return this.Eliminar(uiDescuento.Id);
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

        public List<BE.UI.Descuento> Listar()
        {
          try
            {
                var lstBeDescuentos = new DA.Descuento().Listar();

                var lstUiDescuentos = new List<BE.UI.Descuento>();
                foreach (BE.Descuento beDescuento in lstBeDescuentos)
                {
                    BE.UI.Descuento uiDescuento = this.BeToUi(beDescuento);
                    lstUiDescuentos.Add(uiDescuento);
                }

                return lstUiDescuentos;
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