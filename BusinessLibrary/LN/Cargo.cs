using ErpCasino.BusinessLibrary.BE;
using ErpCasino.BusinessLibrary.DA;
using System.Data;
using System.Collections.Generic;
using System;
using System.Linq;

namespace ErpCasino.BusinessLibrary.LN
{

    public class Cargo
    {

        private BE.UI.Cargo BeToUi(BE.Cargo beCargo)
        {
            try
            {
                var uiCargo = new BE.UI.Cargo();

                uiCargo.Id = beCargo.IdCargo;
                uiCargo.Nombre = beCargo.Nombre;
                uiCargo.Descripcion = beCargo.Descripcion;
                uiCargo.Activo = beCargo.Activo;
                uiCargo.Bono = beCargo.Bono;

                return uiCargo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private BE.Cargo UiToBe(BE.UI.Cargo uiCargo)
        {
            try
            {
                var beCargo = new BE.Cargo();

                beCargo.IdCargo = uiCargo.Id;
                beCargo.Nombre = uiCargo.Nombre;
                beCargo.Descripcion = uiCargo.Descripcion;
                beCargo.Activo = uiCargo.Activo;
                beCargo.Bono = uiCargo.Bono;

                return beCargo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insertar(ref BE.UI.Cargo uiCargo)
        {
            try
            {
                var beCargo = this.UiToBe(uiCargo);

                bool rpta = new DA.Cargo().Insertar(ref beCargo);
                uiCargo = this.BeToUi(beCargo);

                return rpta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Actualizar(BE.UI.Cargo uiCargo)
        {
            try
            {
                var beCargo = this.UiToBe(uiCargo);
                return new DA.Cargo().Actualizar(beCargo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(int idCargo)
        {
            try
            {
                return new DA.Cargo().Eliminar(idCargo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.UI.Cargo> Listar()
        {
            try
            {
                var lstUiCargos = new List<BE.UI.Cargo>();

                var lstBeCargos = new DA.Cargo().Listar();
                foreach (BE.Cargo beCargo in lstBeCargos)
                {
                    BE.UI.Cargo uiCargo = this.BeToUi(beCargo);
                    lstUiCargos.Add(uiCargo);
                }

                return lstUiCargos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.UI.Cargo Obtener(int idCargo)
        {
            try
            {
                var beCargo = new DA.Cargo().Obtener(idCargo);
                var uiCargo = this.BeToUi(beCargo);
                return uiCargo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.UI.Cargo> ListarCombo()
        {
            try
            {
                var lstUiCargos = this.Listar();
                lstUiCargos = lstUiCargos.Where(x => x.Activo == true).ToList();
                return lstUiCargos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }

}