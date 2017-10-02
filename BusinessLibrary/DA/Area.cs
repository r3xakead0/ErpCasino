using BE = ErpCasino.BusinessLibrary.BE;
using System.Data.SqlClient;
using System.Data;
using System;

namespace ErpCasino.BusinessLibrary.DA
{
    public class Area
    {

        public void Cargar(ref BE.Area beArea, ref DataRow dr)
        {
            try
            {
                beArea.IdArea = dr["IdArea"] == DBNull.Value ? 0 : int.Parse(dr["IdArea"].ToString());
                beArea.Nombre = dr["Nombre"] == DBNull.Value ? "" : dr["Nombre"].ToString();
                beArea.Descripcion = dr["Descripcion"] == DBNull.Value ? "" : dr["Descripcion"].ToString();
                beArea.Activo = dr["Activo"] == DBNull.Value ? false : bool.Parse(dr["Activo"].ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Listar(BE.Area beArea)
        {
            try
            {
                string sp = "SpTbAreaListar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter dad = new SqlDataAdapter(cmd);
                dad.SelectCommand.Parameters.Add(new SqlParameter("@ACTIVO", beArea.Activo));

                DataTable dt = new DataTable();
                dad.Fill(dt);

                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Obtener(ref BE.Area beArea)
        {
            try
            {
                string sp = "SpTbAreaObtener";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter dad = new SqlDataAdapter(cmd);
                dad.SelectCommand.Parameters.Add(new SqlParameter("@IDAREA", beArea.IdArea));

                DataTable dt = new DataTable();
                dad.Fill(dt);

                if ((dt.Rows.Count == 1))
                {
                    DataRow dr = dt.Rows[0];
                    Cargar(ref beArea, ref dr);
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
