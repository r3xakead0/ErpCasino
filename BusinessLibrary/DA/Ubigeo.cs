using BE = ErpCasino.BusinessLibrary.BE;
using System.Data.SqlClient;
using System.Data;
using System;

namespace ErpCasino.BusinessLibrary.DA
{

    public class Ubigeo
    {
        public void Cargar(ref BE.Ubigeo beUbigeo, ref DataRow dr)
        {

            try
            {

                beUbigeo.Codigo = dr["Codigo"] == DBNull.Value ? "" : dr["Codigo"].ToString();
                beUbigeo.Departamento = dr["Departamento"] == DBNull.Value ? 0 : int.Parse(dr["Departamento"].ToString());
                beUbigeo.Provincia = dr["Provincia"] == DBNull.Value ? 0 : int.Parse(dr["Provincia"].ToString());
                beUbigeo.Distrito = dr["Distrito"] == DBNull.Value ? 0 : int.Parse(dr["Distrito"].ToString());
                beUbigeo.Nombre = dr["Nombre"] == DBNull.Value ? "" : dr["Nombre"].ToString();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ListarDepartamentos()
        {
            try
            {
                string sp = "SpTbUbigeoListarDepartamentos";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter dad = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                dad.Fill(dt);

                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ListarProvincias(BE.Ubigeo beUbigeo)
        {
            try
            {
                string sp = "SpTbUbigeoListarProvincias";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter dad = new SqlDataAdapter(cmd);
                dad.SelectCommand.Parameters.Add(new SqlParameter("@DEPARTAMENTO", beUbigeo.Departamento));

                DataTable dt = new DataTable();
                dad.Fill(dt);

                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ListarDistritos(BE.Ubigeo beUbigeo)
        {
            try
            {
                string sp = "SpTbUbigeoListarDistritos";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter dad = new SqlDataAdapter(cmd);
                dad.SelectCommand.Parameters.Add(new SqlParameter("@DEPARTAMENTO", beUbigeo.Departamento));
                dad.SelectCommand.Parameters.Add(new SqlParameter("@PROVINCIA", beUbigeo.Provincia));

                DataTable dt = new DataTable();
                dad.Fill(dt);

                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ObtenerDetalle(ref BE.Ubigeo beUbigeo)
        {
            bool flag = false;
            try
            {
                string sp = "SpTbUbigeoObtenerDetalle";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter dad = new SqlDataAdapter(cmd);
                dad.SelectCommand.Parameters.Add(new SqlParameter("@DEPARTAMENTO", beUbigeo.Departamento));
                dad.SelectCommand.Parameters.Add(new SqlParameter("@PROVINCIA", beUbigeo.Provincia));
                dad.SelectCommand.Parameters.Add(new SqlParameter("@DISTRITO", beUbigeo.Distrito));

                DataTable dt = new DataTable();
                dad.Fill(dt);

                if ((dt.Rows.Count == 1))
                {
                    DataRow dr = dt.Rows[0];
                    Cargar(ref beUbigeo, ref dr);
                    flag = true;
                }

                return flag;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Obtener(ref BE.Ubigeo beUbigeo)
        {
            bool flag = false;
            try
            {
                string sp = "SpTbUbigeoObtener";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter dad = new SqlDataAdapter(cmd);
                dad.SelectCommand.Parameters.Add(new SqlParameter("@CODIGO", beUbigeo.Codigo));
                
                DataTable dt = new DataTable();
                dad.Fill(dt);

                if ((dt.Rows.Count == 1))
                {
                    DataRow dr = dt.Rows[0];
                    Cargar(ref beUbigeo, ref dr);
                    flag = true;
                }

                return flag;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}
