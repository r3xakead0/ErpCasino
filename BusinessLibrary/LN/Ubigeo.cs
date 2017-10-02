using BE = ErpCasino.BusinessLibrary.BE;
using DA = ErpCasino.BusinessLibrary.DA;
using System.Data;
using System.Collections.Generic;
using System;

namespace ErpCasino.BusinessLibrary.LN
{

    public class Ubigeo
    {

        public List<BE.Record> ListarDepartamentos()
        {

            List<BE.Record> lst = new List<BE.Record>();

            try
            {

                var daUbigeo = new DA.Ubigeo();

                DataTable dt = daUbigeo.ListarDepartamentos();

                foreach (DataRow dr in dt.Rows)
                {
                    var beRecord = new BE.Record()
                    {
                        Codigo = dr["Departamento"].ToString(),
                        Nombre = dr["Nombre"].ToString()
                    };

                    lst.Add(beRecord);
                }

                return lst;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.Record> ListarProvincias(int departamento)
        {

            List<BE.Record> lst = new List<BE.Record>();

            try
            {

                var daUbigeo = new DA.Ubigeo();

                DataTable dt = daUbigeo.ListarProvincias(new BE.Ubigeo() { Departamento = departamento });

                foreach (DataRow dr in dt.Rows)
                {
                    var beRecord = new BE.Record()
                    {
                        Codigo = dr["Provincia"].ToString(),
                        Nombre = dr["Nombre"].ToString()
                    };

                    lst.Add(beRecord);
                }

                return lst;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.Record> ListarDistritos(int departamento, int provincia)
        {

            List<BE.Record> lst = new List<BE.Record>();

            try
            {

                var daUbigeo = new DA.Ubigeo();

                DataTable dt = daUbigeo.ListarDistritos(new BE.Ubigeo() { Departamento = departamento, Provincia = provincia });

                foreach (DataRow dr in dt.Rows)
                {
                    var beRecord = new BE.Record()
                    {
                        Codigo = dr["Distrito"].ToString(),
                        Nombre = dr["Nombre"].ToString()
                    };

                    lst.Add(beRecord);
                }

                return lst;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Obtener(ref BE.Ubigeo oBeTbUbigeo)
        {
            bool exists = false;
            try
            {

                if (oBeTbUbigeo.Codigo == null || oBeTbUbigeo.Codigo == "")
                {
                    exists = new DA.Ubigeo().ObtenerDetalle(ref oBeTbUbigeo);
                }
                else
                {
                    exists = new DA.Ubigeo().Obtener(ref oBeTbUbigeo);
                }

                return exists;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.Ubigeo ObtenerDepartamento(int idDepartamento)
        {
            BE.Ubigeo beUbigeo = null;
            try
            {
                beUbigeo = new BE.Ubigeo();
                beUbigeo.Departamento = idDepartamento;
                beUbigeo.Provincia = 0;
                beUbigeo.Distrito = 0;

                if (new DA.Ubigeo().ObtenerDetalle(ref beUbigeo) == false)
                    beUbigeo = null;

                return beUbigeo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.Ubigeo ObtenerProvincia(int idDepartamento, int idProvincia)
        {
            BE.Ubigeo beUbigeo = null;
            try
            {
                beUbigeo = new BE.Ubigeo();
                beUbigeo.Departamento = idDepartamento;
                beUbigeo.Provincia = idProvincia;
                beUbigeo.Distrito = 0;

                if (new DA.Ubigeo().ObtenerDetalle(ref beUbigeo) == false)
                    beUbigeo = null;

                return beUbigeo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.Ubigeo ObtenerDistrito(int idDepartamento, int idProvincia, int idDistrito)
        {
            BE.Ubigeo beUbigeo = null;
            try
            {
                beUbigeo = new BE.Ubigeo();
                beUbigeo.Departamento = idDepartamento;
                beUbigeo.Provincia = idProvincia;
                beUbigeo.Distrito = idDistrito;

                if (new DA.Ubigeo().ObtenerDetalle(ref beUbigeo) == false)
                    beUbigeo = null;

                return beUbigeo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }

}