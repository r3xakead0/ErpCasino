using BE = ErpCasino.BusinessLibrary.BE;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System;

namespace ErpCasino.BusinessLibrary.DA
{
    public class Asistencia
    {

        public void Cargar(ref BE.Asistencia oBeTbArea, ref DataRow dr)
        {
            try
            {
                oBeTbArea.IdAsistencia = dr["IdAsistencia"] == DBNull.Value ? 0 : int.Parse(dr["IdAsistencia"].ToString());
                oBeTbArea.Codigo = dr["Codigo"] == DBNull.Value ? "" : dr["Codigo"].ToString();
                oBeTbArea.FechaHoraEntrada = dr["FechaHoraEntrada"] == DBNull.Value ? DateTime.Now : DateTime.Parse(dr["FechaHoraEntrada"].ToString());
                oBeTbArea.FechaHoraSalida = dr["FechaHoraSalida"] == DBNull.Value ? DateTime.Now : DateTime.Parse(dr["FechaHoraSalida"].ToString());
                oBeTbArea.Origen = dr["Origen"] == DBNull.Value ? "M" : dr["Origen"].ToString();
                oBeTbArea.FechaRegistro = dr["FechaRegistro"] == DBNull.Value ? DateTime.Now : DateTime.Parse(dr["FechaRegistro"].ToString());
                oBeTbArea.Turno = dr["Turno"] == DBNull.Value ? 0 : int.Parse(dr["Turno"].ToString());
                oBeTbArea.IdUsuarioCreador = dr["IdUsuarioCreador"] == DBNull.Value ? 0 : int.Parse(dr["IdUsuarioCreador"].ToString());
                oBeTbArea.FechaCreacion = dr["FechaCreacion"] == DBNull.Value ? DateTime.Now : DateTime.Parse(dr["FechaCreacion"].ToString());
                oBeTbArea.IdUsuarioModificador = dr["IdUsuarioModificador"] == DBNull.Value ? 0 : int.Parse(dr["IdUsuarioModificador"].ToString());
                oBeTbArea.FechaModificacion = dr["FechaModificacion"] == DBNull.Value ? null : (DateTime?)DateTime.Parse(dr["FechaModificacion"].ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Insertar(ref BE.Asistencia beAsistencia)
        {
            try
            {
                string sp = "SpTbAsistenciaInsertar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                int rowsAffected = 0;
                cnn.Open();

                cmd.Parameters.Add(new SqlParameter("@IDASISTENCIA", beAsistencia.IdAsistencia));
                cmd.Parameters["@IDASISTENCIA"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new SqlParameter("@CODIGO", beAsistencia.Codigo));
                cmd.Parameters.Add(new SqlParameter("@FECHAHORAENTRADA", beAsistencia.FechaHoraEntrada));
                cmd.Parameters.Add(new SqlParameter("@FECHAHORASALIDA", beAsistencia.FechaHoraSalida));
                cmd.Parameters.Add(new SqlParameter("@ORIGEN", beAsistencia.Origen));
                cmd.Parameters.Add(new SqlParameter("@FECHAREGISTRO", beAsistencia.FechaRegistro));
                cmd.Parameters.Add(new SqlParameter("@TURNO", beAsistencia.Turno));
                cmd.Parameters.Add(new SqlParameter("@IDUSUARIOCREADOR", beAsistencia.IdUsuarioCreador));

                rowsAffected = cmd.ExecuteNonQuery();
                beAsistencia.IdAsistencia = int.Parse(cmd.Parameters["@IDASISTENCIA"].Value.ToString());

                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Eliminar(int idAsistencia)
        {
            try
            {
                string sp = "SpTbAsistenciaEliminar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                int rowsAffected = 0;
                cnn.Open();

                cmd.Parameters.Add(new SqlParameter("@IDASISTENCIA", idAsistencia));

                rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Listar(DateTime fecha)
        {
            try
            {
                string sp = "SpTbAsistenciaListar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@FECHAREGISTRO", fecha));

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

        public int EliminarResumen(DateTime fecha)
        {
            try
            {
                string sp = "SpTbAsistenciaResumenEliminar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@FECHA", fecha));

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ListarResumen(int anho, int mes)
        {
            try
            {
                string sp = "SpTbAsistenciaResumenListar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ANHO", anho));
                cmd.Parameters.Add(new SqlParameter("@MES", mes));

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


        public bool Obtener(ref BE.Asistencia beAsistencia)
        {
            bool flag = false;
            try
            {
                string sp = "SpTbAsistenciaObtener";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter dad = new SqlDataAdapter(cmd);
                dad.SelectCommand.Parameters.Add(new SqlParameter("@IDASISTENCIA", beAsistencia.IdAsistencia));

                DataTable dt = new DataTable();
                dad.Fill(dt);

                if ((dt.Rows.Count == 1))
                {
                    DataRow dr = dt.Rows[0];
                    Cargar(ref beAsistencia, ref dr);
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
