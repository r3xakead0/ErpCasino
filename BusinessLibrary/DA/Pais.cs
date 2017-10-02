using BE = ErpCasino.BusinessLibrary.BE;
using System.Data.SqlClient;
using System.Data;
using System;

namespace ErpCasino.BusinessLibrary.DA
{

    public class Pais
    {

        public void Cargar(ref BE.Pais bePais, ref DataRow dr)
        {
            try
            {
                bePais.Codigo = dr["CodPais"] == DBNull.Value ? "" : dr["CodPais"].ToString();
                bePais.Nombre = dr["Nombre"] == DBNull.Value ? "" : dr["Nombre"].ToString();
                bePais.Name = dr["Name"] == DBNull.Value ? "" : dr["Name"].ToString();
                bePais.Nom = dr["Nom"] == DBNull.Value ? "" : dr["Nom"].ToString();
                bePais.Iso2 = dr["Iso2"] == DBNull.Value ? "" : dr["Iso2"].ToString();
                bePais.PhoneCode = dr["PhoneCode"] == DBNull.Value ? "" : dr["PhoneCode"].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Listar()
        {
            try
            {
                string sp = "SpTbPaisListar";

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

        public bool Obtener(ref BE.Pais bePais)
        {
            try
            {
                string sp = "SpTbPaisObtener";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter dad = new SqlDataAdapter(cmd);
                dad.SelectCommand.Parameters.Add(new SqlParameter("@CODPAIS", bePais.Codigo));

                DataTable dt = new DataTable();
                dad.Fill(dt);

                if ((dt.Rows.Count == 1))
                {
                    DataRow dr = dt.Rows[0];
                    Cargar(ref bePais, ref dr);
                }
                else
                {
                    throw new Exception("No se pudo obtener el registro");
                }

                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}
