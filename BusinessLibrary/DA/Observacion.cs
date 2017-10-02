using BE = ErpCasino.BusinessLibrary.BE;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace ErpCasino.BusinessLibrary.DA
{
    public class Observacion
    {

        private int idUsuario = 0;

        public Observacion(int idUsuario)
        {
            this.idUsuario = idUsuario;
        }

        public int Insertar(ref BE.Observacion beObservacion)
        {
            try
            {
                string sp = "SpTbObservacionInsertar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                int rowsAffected = 0;

                cmd.Parameters.Add(new SqlParameter("@IDOBSERVACION", beObservacion.IdObservacion));
                cmd.Parameters["@IDOBSERVACION"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new SqlParameter("@NOMBRE", beObservacion.Nombre));
                cmd.Parameters.Add(new SqlParameter("@DESCRIPCION", beObservacion.Descripcion));
                cmd.Parameters.Add(new SqlParameter("@ACTIVO", beObservacion.Activo));

                rowsAffected = cmd.ExecuteNonQuery();
                beObservacion.IdObservacion = int.Parse(cmd.Parameters["@IDOBSERVACION"].Value.ToString());

                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Actualizar(BE.Observacion beObservacion)
        {
            try
            {
                string sp = "SpTbObservacionActualizar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                int rowsAffected = 0;

                cmd.Parameters.Add(new SqlParameter("@IDOBSERVACION", beObservacion.IdObservacion));
                cmd.Parameters.Add(new SqlParameter("@NOMBRE", beObservacion.Nombre));
                cmd.Parameters.Add(new SqlParameter("@DESCRIPCION", beObservacion.Descripcion));
                cmd.Parameters.Add(new SqlParameter("@ACTIVO", beObservacion.Activo));

                rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Eliminar(int idObservacion)
        {
            try
            {
                string sp = "SpTbObservacionEliminar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                int rowsAffected = 0;
                
                cmd.Parameters.Add(new SqlParameter("@IDOBSERVACION", idObservacion));

                rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.Observacion> Listar()
        {
            var lstBeObservaciones = new List<BE.Observacion>();

            try
            {
                string sp = "SpTbObservacionListar";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var beObservacion = new BE.Observacion();

                        beObservacion.IdObservacion = reader["IdObservacion"] == DBNull.Value ? 0 : int.Parse(reader["IdObservacion"].ToString());
                        beObservacion.Nombre = reader["Nombre"] == DBNull.Value ? "" : reader["Nombre"].ToString();
                        beObservacion.Descripcion = reader["Descripcion"] == DBNull.Value ? "" : reader["Descripcion"].ToString();
                        beObservacion.Activo = reader["Activo"] == DBNull.Value ? false : bool.Parse(reader["Activo"].ToString());

                        lstBeObservaciones.Add(beObservacion);
                    }

                }

                return lstBeObservaciones;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public BE.Observacion Obtener(int idObservacion)
        {
            BE.Observacion beObservacion = null;

            try
            {
                string sp = "SpTbObservacionObtener";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IDOBSERVACION", idObservacion));

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        beObservacion = new BE.Observacion();

                        beObservacion.IdObservacion = reader["IdObservacion"] == DBNull.Value ? 0 : int.Parse(reader["IdObservacion"].ToString());
                        beObservacion.Nombre = reader["Nombre"] == DBNull.Value ? "" : reader["Nombre"].ToString();
                        beObservacion.Descripcion = reader["Descripcion"] == DBNull.Value ? "" : reader["Descripcion"].ToString();
                        beObservacion.Activo = reader["Activo"] == DBNull.Value ? false : bool.Parse(reader["Activo"].ToString());
                        
                    }

                }

                return beObservacion;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }

}
