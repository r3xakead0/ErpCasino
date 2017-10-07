using BE = ErpCasino.BusinessLibrary.BE;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System;

namespace ErpCasino.BusinessLibrary.DA
{
    public class Bono
    {

        public bool Insertar(ref BE.Bono oBeBono)
        {
            try
            {
                string sp = "SpTbBonoInsertar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                int rowsAffected = 0;
                cnn.Open();

                cmd.Parameters.Add(new SqlParameter("@IDBONO", oBeBono.IdBono));
                cmd.Parameters["@IDBONO"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new SqlParameter("@NOMBRE", oBeBono.Nombre));
                cmd.Parameters.Add(new SqlParameter("@DESCRIPCION", oBeBono.Descripcion));
                cmd.Parameters.Add(new SqlParameter("@ACTIVO", oBeBono.Activo));
                cmd.Parameters.Add(new SqlParameter("@CALCULADO", oBeBono.Calculado));
                cmd.Parameters.Add(new SqlParameter("@MONTO", oBeBono.Monto));

                rowsAffected = cmd.ExecuteNonQuery();
                oBeBono.IdBono = int.Parse(cmd.Parameters["@IDBONO"].Value.ToString());

                return (rowsAffected > 0 ? true : false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Actualizar(BE.Bono oBeBono)
        {
            try
            {
                string sp = "SpTbBonoActualizar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                int rowsAffected = 0;
                cnn.Open();

                cmd.Parameters.Add(new SqlParameter("@IDBONO", oBeBono.IdBono));
                cmd.Parameters.Add(new SqlParameter("@NOMBRE", oBeBono.Nombre));
                cmd.Parameters.Add(new SqlParameter("@DESCRIPCION", oBeBono.Descripcion));
                cmd.Parameters.Add(new SqlParameter("@ACTIVO", oBeBono.Activo));
                cmd.Parameters.Add(new SqlParameter("@CALCULADO", oBeBono.Calculado));
                cmd.Parameters.Add(new SqlParameter("@MONTO", oBeBono.Monto));

                rowsAffected = cmd.ExecuteNonQuery();

                return (rowsAffected > 0 ? true : false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(int idBono)
        {
            try
            {
                string sp = "SpTbBonoEliminar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                int rowsAffected = 0;
                cnn.Open();

                cmd.Parameters.Add(new SqlParameter("@IDBONO", idBono));

                rowsAffected = cmd.ExecuteNonQuery();

                return (rowsAffected > 0 ? true : false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.Bono> Listar()
        {
            var lstBonos = new List<BE.Bono>();
            try
            {
                string sp = "SpTbBonoListar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var beBono = new BE.Bono();

                    beBono.IdBono = int.Parse(reader["IdBono"].ToString());
                    beBono.Nombre = reader["Nombre"].ToString();
                    beBono.Descripcion = reader["Descripcion"] .ToString();
                    beBono.Activo = bool.Parse(reader["Activo"].ToString());
                    beBono.Calculado = bool.Parse(reader["Calculado"].ToString());
                    beBono.Monto = double.Parse(reader["Monto"].ToString());

                    lstBonos.Add(beBono);
                }

                return lstBonos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.Bono Obtener(int idBono)
        {
            BE.Bono beBono = null;
            try
            {
                string sp = "SpTbBonoObtener";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);

                cnn.Open();
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IDBONO", idBono));

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    beBono = new BE.Bono();

                    beBono.IdBono = int.Parse(reader["IdBono"].ToString());
                    beBono.Nombre = reader["Nombre"].ToString();
                    beBono.Descripcion = reader["Descripcion"].ToString();
                    beBono.Activo = bool.Parse(reader["Activo"].ToString());
                    beBono.Calculado = bool.Parse(reader["Calculado"].ToString());
                    beBono.Monto = double.Parse(reader["Monto"].ToString());

                }

                return beBono;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
