using ErpCasino.BusinessLibrary.BE;
using System.Data.SqlClient;
using System.Data;
using System;

namespace ErpCasino.BusinessLibrary.DA
{

    public class ClsDaTbPostulanteEstado
    {

        public void Cargar(ref ClsBeTbPostulanteEstado oBeTbPostulanteEstado, DataRow dr)
        {
            try
            {
                oBeTbPostulanteEstado.IdPostulanteEstado = dr["IdPostulanteEstado"] == DBNull.Value ? 0 : int.Parse(dr["IdPostulanteEstado"].ToString());
                oBeTbPostulanteEstado.Nivel = dr["Nivel"] == DBNull.Value ? 0 : int.Parse(dr["Nivel"].ToString());
                oBeTbPostulanteEstado.Nombre = dr["Nombre"] == DBNull.Value ? "" : dr["Nombre"].ToString();
                oBeTbPostulanteEstado.Descripcion = dr["Descripcion"] == DBNull.Value ? "" : dr["Descripcion"].ToString();
                oBeTbPostulanteEstado.Dependencia = dr["Dependencia"] == DBNull.Value ? 0 : int.Parse(dr["Dependencia"].ToString());
                oBeTbPostulanteEstado.Activo = dr["Activo"] == DBNull.Value ? false : bool.Parse(dr["Activo"].ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public DataTable Listar(int? IdPostulante = null, bool Activo = true)
        {
            try
            {
                string sp = "SpTbPostulanteEstadoListar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter dad = new SqlDataAdapter(cmd);
                dad.SelectCommand.Parameters.Add(new SqlParameter("@IDPOSTULANTE", IdPostulante));
                dad.SelectCommand.Parameters.Add(new SqlParameter("@ACTIVO", Activo));

                DataTable dt = new DataTable();
                dad.Fill(dt);

                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Obtener(ref ClsBeTbPostulanteEstado oBeTbPostulanteEstado)
        {

            try
            {
                bool rpta = false;
                string sp = "SpTbPostulanteEstadoObtener";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter dad = new SqlDataAdapter(cmd);
                dad.SelectCommand.Parameters.Add(new SqlParameter("@IDPOSTULANTEESTADO", oBeTbPostulanteEstado.IdPostulanteEstado));

                DataTable dt = new DataTable();
                dad.Fill(dt);

                if ((dt.Rows.Count == 1))
                {
                    DataRow dr = dt.Rows[0];
                    Cargar(ref oBeTbPostulanteEstado, dr);
                    rpta = true;
                }

                return rpta;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
