using BE = ErpCasino.BusinessLibrary.BE;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace ErpCasino.BusinessLibrary.DA
{
    public class ObservacionEmpleado
    {

        public int Insertar(ref BE.ObservacionEmpleado beObservacionEmpleado)
        {
            try
            {
                string sp = "SpTbObservacionEmpleadoInsertar";
                int rowsAffected = 0;

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IDOBSERVACIONEMPLEADO", beObservacionEmpleado.IdObservacionEmpleado));
                    cmd.Parameters["@IDOBSERVACIONEMPLEADO"].Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(new SqlParameter("@FECHA", beObservacionEmpleado.Fecha));
                    cmd.Parameters.Add(new SqlParameter("@IDSALA", beObservacionEmpleado.Sala.IdSala));
                    cmd.Parameters.Add(new SqlParameter("@CODIGOEMPLEADO", beObservacionEmpleado.CodigoEmpleado));
                    cmd.Parameters.Add(new SqlParameter("@IDOBSERVACION", beObservacionEmpleado.Observacion.IdObservacion));
                    cmd.Parameters.Add(new SqlParameter("@DESCRIPCION", beObservacionEmpleado.Descripcion));

                    rowsAffected = cmd.ExecuteNonQuery();
                    beObservacionEmpleado.IdObservacionEmpleado = int.Parse(cmd.Parameters["@IDOBSERVACIONEMPLEADO"].Value.ToString());

                    cnn.Close();
                }

                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Actualizar(BE.ObservacionEmpleado beObservacionEmpleado)
        {
            try
            {
                string sp = "SpTbObservacionEmpleadoActualizar";
                int rowsAffected = 0;

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IDOBSERVACIONEMPLEADO", beObservacionEmpleado.IdObservacionEmpleado));
                    cmd.Parameters.Add(new SqlParameter("@FECHA", beObservacionEmpleado.Fecha));
                    cmd.Parameters.Add(new SqlParameter("@IDSALA", beObservacionEmpleado.Sala.IdSala));
                    cmd.Parameters.Add(new SqlParameter("@CODIGOEMPLEADO", beObservacionEmpleado.CodigoEmpleado));
                    cmd.Parameters.Add(new SqlParameter("@IDOBSERVACION", beObservacionEmpleado.Observacion.IdObservacion));
                    cmd.Parameters.Add(new SqlParameter("@DESCRIPCION", beObservacionEmpleado.Descripcion));

                    rowsAffected = cmd.ExecuteNonQuery();

                    cnn.Close();
                }
    
                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Eliminar(int idObservacionEmpleado)
        {
            try
            {
                string sp = "SpTbObservacionEmpleadoEliminar";
                int rowsAffected = 0;

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IDOBSERVACIONEMPLEADO", idObservacionEmpleado));

                    rowsAffected = cmd.ExecuteNonQuery();

                    cnn.Close();
                }

                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.ObservacionEmpleado> Listar(int anho, int mes)
        {
            var lstBeObservaciones = new List<BE.ObservacionEmpleado>();

            try
            {
                string sp = "SpTbObservacionEmpleadoListar";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ANHO", anho));
                    cmd.Parameters.Add(new SqlParameter("@MES", mes));

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var beObservacionEmpleado = new BE.ObservacionEmpleado();

                        beObservacionEmpleado.IdObservacionEmpleado = reader["IdObservacionEmpleado"] == DBNull.Value ? 0 : int.Parse(reader["IdObservacionEmpleado"].ToString());
                        beObservacionEmpleado.Fecha = reader["Fecha"] == DBNull.Value ? DateTime.Now : DateTime.Parse(reader["Fecha"].ToString());
                        beObservacionEmpleado.CodigoEmpleado = reader["CodigoEmpleado"] == DBNull.Value ? "" : reader["CodigoEmpleado"].ToString();
                        beObservacionEmpleado.Descripcion = reader["Descripcion"] == DBNull.Value ? "" : reader["Descripcion"].ToString();

                        if (reader["IdSala"] != DBNull.Value)
                        {
                            var beSala = new BE.Sala();
                            beSala.IdSala = int.Parse(reader["IdSala"].ToString());

                            if (new DA.Sala().Obtener(ref beSala) == true)
                                beObservacionEmpleado.Sala = beSala;

                            beSala = null;
                        }

                        if (reader["IdObservacion"] != DBNull.Value)
                        {
                            int idUsuario = 0;
                            int idObservacion = int.Parse(reader["IdObservacion"].ToString());

                            var beObservacion = new DA.Observacion(idUsuario).Obtener(idObservacion);
                            if (beObservacion != null)
                                beObservacionEmpleado.Observacion = beObservacion;

                            beObservacion = null;   
                        }

                        lstBeObservaciones.Add(beObservacionEmpleado);
                    }

                    cnn.Close();
                }

                return lstBeObservaciones;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        
    }

}
