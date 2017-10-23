using BE = ErpCasino.BusinessLibrary.BE;
using DA = ErpCasino.BusinessLibrary.DA;
using System.Data;
using System.Collections.Generic;
using System;

namespace ErpCasino.BusinessLibrary.LN
{

    public class Sala
    {
        public bool Insertar(ref BE.Sala oBeTbSala)
        {
            try
            {
                var daSala = new DA.Sala();

                int rowsAffected = daSala.Insertar(ref oBeTbSala);

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Actualizar(BE.Sala oBeTbSala)
        {
            try
            {
                var daSala = new DA.Sala();

                int rowsAffected = daSala.Actualizar(oBeTbSala);

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(int idSala)
        {
            try
            {
                int rowsAffected = new DA.Sala().Eliminar(idSala);

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Lista solo los codigos y nombres de salas
        /// </summary>
        /// <returns></returns>
        public List<BE.Sala> ListaSimple()
        {
            try
            {
                var lstBeSalas = new DA.Sala().Listar();

                return lstBeSalas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Lista detallada de las salas 
        /// </summary>
        /// <returns></returns>
        public List<BE.UI.Sala> Listar()
        {

            List<BE.UI.Sala> lstUiSalas = new List<BE.UI.Sala>();

            try
            {

                var lstBeSalas = new DA.Sala().Listar();

                foreach (BE.Sala beSala in lstBeSalas)
                {

                    var lnUbigeo = new LN.Ubigeo();
                    var beDepartamento = lnUbigeo.ObtenerDepartamento(beSala.Ubigeo.Departamento);
                    var beProvincia = lnUbigeo.ObtenerProvincia(beSala.Ubigeo.Departamento, beSala.Ubigeo.Provincia);
                    var beDistrito = lnUbigeo.ObtenerDistrito(beSala.Ubigeo.Departamento, beSala.Ubigeo.Provincia,beSala.Ubigeo.Distrito);

                    var uiSala = new BE.UI.Sala();
                    uiSala.ID = beSala.IdSala;
                    uiSala.Nombre = beSala.Nombre;
                    uiSala.Departamento = beDepartamento != null ? beDepartamento.Nombre : "";
                    uiSala.Provincia = beProvincia != null ? beProvincia.Nombre : "";
                    uiSala.Distrito = beDistrito != null ? beDistrito.Nombre : "";
                    uiSala.Zona = beSala.Zona;
                    uiSala.Direccion = beSala.Direccion;
                    uiSala.Referencia = beSala.Referencia;
                    uiSala.Activo = beSala.Activo == true ? "Si" : "No";

                    lstUiSalas.Add(uiSala);
                }

                return lstUiSalas;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.Sala Obtener(int idSala)
        {
            try
            {
                var beSala = new BE.Sala() { IdSala = idSala };

                bool exists = new DA.Sala().Obtener(ref beSala);
                if (exists == true)
                {
                    var beUbigeo = new BE.Ubigeo() { Codigo = beSala.Ubigeo.Codigo };
                    exists = new DA.Ubigeo().Obtener(ref beUbigeo);
                    if (exists == true)
                        beSala.Ubigeo = beUbigeo;
                }
                else
                    beSala = null;

                return beSala;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 

    }

}