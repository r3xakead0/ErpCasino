using ErpCasino.BusinessLibrary.BE;
using System.Data.SqlClient;
using System.Data;
using System;

namespace ErpCasino.BusinessLibrary.DA
{
    public class Categoria
    {

        public void Cargar(ref BE.Categoria beCategoria, ref DataRow dr)
        {
            try
            {
                beCategoria.IdCategoria = dr["IdCategoria"] == DBNull.Value ? 0 : int.Parse(dr["IdCategoria"].ToString());
                beCategoria.IdTipo = dr["IdTipo"] == DBNull.Value ? 0 : int.Parse(dr["IdTipo"].ToString());
                beCategoria.Codigo = dr["Codigo"] == DBNull.Value ? "" : dr["Codigo"].ToString();
                beCategoria.Nombre = dr["Nombre"] == DBNull.Value ? "" : dr["Nombre"].ToString();
                beCategoria.Activo = dr["Activo"] == DBNull.Value ? false : bool.Parse(dr["Activo"].ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Listar(int IdTipo)
        {
            try
            {
                string sp = "SpTbCategoriaListar";
                DataTable dt = new DataTable();

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter dad = new SqlDataAdapter(cmd);
                    dad.SelectCommand.Parameters.Add(new SqlParameter("@IDTIPO", IdTipo));
                    dad.Fill(dt);
                }
 
                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
 
    }

}
