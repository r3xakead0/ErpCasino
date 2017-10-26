using System;

namespace ErpCasino.BusinessLibrary.LN
{

    public class Empresa
    {

        public bool Insertar(ref BE.Empresa beEmpresa)
        {
            try
            {
                int rowsAffected = new DA.Empresa().Insertar(ref beEmpresa);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Actualizar(BE.Empresa beEmpresa)
        {
            try
            {
                int rowsAffected = new DA.Empresa().Actualizar(beEmpresa);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        

        public BE.Empresa Obtener()
        {
            try
            {
                var beEmpresa = new DA.Empresa().Obtener();
                if (beEmpresa != null)
                {
                    var beUbigeo = beEmpresa.Ubigeo;
                    if (new DA.Ubigeo().Obtener(ref beUbigeo))
                        beEmpresa.Ubigeo = beUbigeo;
                }
                return beEmpresa;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}