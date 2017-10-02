using BE = ErpCasino.BusinessLibrary.BE;
using DA = ErpCasino.BusinessLibrary.DA;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System;

namespace ErpCasino.BusinessLibrary.LN
{

    public class OnpComision
    {

        private string MesNombre(int mesNumero)
        {
            string nameMonth = "";

            switch (mesNumero)
            {
                case 1:
                    nameMonth = "Enero";
                    break;
                case 2:
                    nameMonth = "Febrero";
                    break;
                case 3:
                    nameMonth = "Marzo";
                    break;
                case 4:
                    nameMonth = "Abril";
                    break;
                case 5:
                    nameMonth = "Mayo";
                    break;
                case 6:
                    nameMonth = "Junio";
                    break;
                case 7:
                    nameMonth = "Julio";
                    break;
                case 8:
                    nameMonth = "Agosto";
                    break;
                case 9:
                    nameMonth = "Septiembre";
                    break;
                case 10:
                    nameMonth = "Octubre";
                    break;
                case 11:
                    nameMonth = "Noviembre";
                    break;
                default:
                    nameMonth = "Diciembre";
                    break;
            }

            return nameMonth;
        }

        private BE.UI.OnpComision BEtoUI(BE.OnpComision BeOnpComision)
        {
            var UiOnpComision = new BE.UI.OnpComision();
            UiOnpComision.IdOnpComision = BeOnpComision.IdOnpComision;
            UiOnpComision.Anho = BeOnpComision.Anho;
            UiOnpComision.MesNumero = BeOnpComision.Mes;
            UiOnpComision.MesNombre = this.MesNombre(BeOnpComision.Mes);
            UiOnpComision.AportePorcentual = BeOnpComision.PorcentajeAporte;
            return UiOnpComision;
        }

        private BE.OnpComision UItoBE(BE.UI.OnpComision UiOnpComision)
        {
            var BeOnpComision = new BE.OnpComision();
            BeOnpComision.IdOnpComision = UiOnpComision.IdOnpComision;
            BeOnpComision.Anho = UiOnpComision.Anho;
            BeOnpComision.Mes = UiOnpComision.MesNumero;
            BeOnpComision.PorcentajeAporte = UiOnpComision.AportePorcentual;
            return BeOnpComision;
        }

        public bool Insertar(ref BE.UI.OnpComision uiOnpComision)
        {
            try
            {
                var beOnpComision = this.UItoBE(uiOnpComision);
                return new DA.OnpComision().Insertar(ref beOnpComision);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

      
        public bool Eliminar(int idOnpComision)
        {
            try
            {
                return new DA.OnpComision().Eliminar(idOnpComision);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.UI.OnpComision> Listar()
        {
          try
            {
                List<BE.OnpComision> lstBeOnpComision = new DA.OnpComision().Listar();

                var lstUiOnpComision = new List<BE.UI.OnpComision>();
                foreach (var beOnpComision in lstBeOnpComision)
                {
                    BE.UI.OnpComision uiOnpComision = this.BEtoUI(beOnpComision);
                    lstUiOnpComision.Add(uiOnpComision);
                }
                return lstUiOnpComision;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.UI.OnpComision Obtener(int anho, int mes)
        {
            try
            {
                BE.OnpComision beOnpComision = new DA.OnpComision().Obtener(anho, mes);
                if (beOnpComision != null)
                {
                    return this.BEtoUI(beOnpComision);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}