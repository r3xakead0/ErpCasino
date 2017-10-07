using BE = ErpCasino.BusinessLibrary.BE;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace ErpCasino.BusinessLibrary.DA
{
    public class BonoEmpleado
    {

        public int Insertar(ref BE.BonoEmpleado beBonoEmpleado)
        {
            try
            {
                string sp = "SpTbBonoEmpleadoInsertar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                int rowsAffected = 0;

                cmd.Parameters.Add(new SqlParameter("@IDBONOEMPLEADO", beBonoEmpleado.IdBonoEmpleado));
                cmd.Parameters["@IDBONOEMPLEADO"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new SqlParameter("@FECHA", beBonoEmpleado.Fecha));
                cmd.Parameters.Add(new SqlParameter("@CODIGOEMPLEADO", beBonoEmpleado.CodigoEmpleado));
                cmd.Parameters.Add(new SqlParameter("@IDBONO", beBonoEmpleado.Bono.IdBono));
                cmd.Parameters.Add(new SqlParameter("@MOTIVO", beBonoEmpleado.Motivo));
                cmd.Parameters.Add(new SqlParameter("@MONTO", beBonoEmpleado.Monto));

                rowsAffected = cmd.ExecuteNonQuery();
                beBonoEmpleado.IdBonoEmpleado = int.Parse(cmd.Parameters["@IDBONOEMPLEADO"].Value.ToString());

                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Actualizar(BE.BonoEmpleado beBonoEmpleado)
        {
            try
            {
                string sp = "SpTbBonoEmpleadoActualizar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                int rowsAffected = 0;

                cmd.Parameters.Add(new SqlParameter("@IDBONOEMPLEADO", beBonoEmpleado.IdBonoEmpleado));
                cmd.Parameters.Add(new SqlParameter("@FECHA", beBonoEmpleado.Fecha));
                cmd.Parameters.Add(new SqlParameter("@CODIGOEMPLEADO", beBonoEmpleado.CodigoEmpleado));
                cmd.Parameters.Add(new SqlParameter("@IDBONO", beBonoEmpleado.Bono.IdBono));
                cmd.Parameters.Add(new SqlParameter("@MOTIVO", beBonoEmpleado.Motivo));
                cmd.Parameters.Add(new SqlParameter("@MONTO", beBonoEmpleado.Monto));

                rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Eliminar(int idBonoEmpleado)
        {
            try
            {
                string sp = "SpTbBonoEmpleadoEliminar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                int rowsAffected = 0;

                cmd.Parameters.Add(new SqlParameter("@IDBONOEMPLEADO", idBonoEmpleado));

                rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.BonoEmpleado> Listar(int anho, int mes)
        {
            var lstBeObservaciones = new List<BE.BonoEmpleado>();

            try
            {
                string sp = "SpTbBonoEmpleadoListar";

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
                        var beBonoEmpleado = new BE.BonoEmpleado();

                        beBonoEmpleado.IdBonoEmpleado = reader["IdBonoEmpleado"] == DBNull.Value ? 0 : int.Parse(reader["IdBonoEmpleado"].ToString());
                        beBonoEmpleado.Fecha = reader["Fecha"] == DBNull.Value ? DateTime.Now : DateTime.Parse(reader["Fecha"].ToString());
                        beBonoEmpleado.CodigoEmpleado = reader["CodigoEmpleado"] == DBNull.Value ? "" : reader["CodigoEmpleado"].ToString();
                        beBonoEmpleado.Motivo = reader["Motivo"] == DBNull.Value ? "" : reader["Motivo"].ToString();
                        beBonoEmpleado.Monto = reader["Monto"] == DBNull.Value ? 0.0 : double.Parse(reader["Monto"].ToString());

                        if (reader["idBono"] != DBNull.Value)
                        {
                            int idBono = int.Parse(reader["idBono"].ToString());

                            var beBono = new DA.Bono().Obtener(idBono);
                            if (beBono != null)
                                beBonoEmpleado.Bono = beBono;

                            beBono = null;   
                        }

                        lstBeObservaciones.Add(beBonoEmpleado);
                    }

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
