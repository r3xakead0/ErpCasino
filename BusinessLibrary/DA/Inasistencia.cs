using BE = ErpCasino.BusinessLibrary.BE;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;

namespace ErpCasino.BusinessLibrary.DA
{
    public class Inasistencia
    {

        public bool Insertar(ref BE.Inasistencia BeInasistencia)
        {
            try
            {
                string sp = "SpTbInasistenciaInsertar";
                int rowsAffected = 0;

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IDINASISTENCIA", BeInasistencia.IdInasistencia));
                    cmd.Parameters["@IDINASISTENCIA"].Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(new SqlParameter("@CODIGO", BeInasistencia.Codigo));
                    cmd.Parameters.Add(new SqlParameter("@FECHAREGISTRO", BeInasistencia.Fecha));
                    cmd.Parameters.Add(new SqlParameter("@FECHAHORAENTRADA", BeInasistencia.FechaHoraEntrada));
                    cmd.Parameters.Add(new SqlParameter("@FECHAHORASALIDA", BeInasistencia.FechaHoraSalida));
                    cmd.Parameters.Add(new SqlParameter("@IDUSUARIOCREADOR", BeInasistencia.IdUsuarioCreador));
                    cmd.Parameters.Add(new SqlParameter("@FECHACREACION", DateTime.Now));
                    cmd.Parameters.Add(new SqlParameter("@TIPO", BeInasistencia.Tipo));
                    cmd.Parameters.Add(new SqlParameter("@ASUNTO", BeInasistencia.Asunto));
                    cmd.Parameters.Add(new SqlParameter("@DETALLE", BeInasistencia.Detalle));
                    cmd.Parameters.Add(new SqlParameter("@CITT", BeInasistencia.Certificado));

                    rowsAffected = cmd.ExecuteNonQuery();
                    BeInasistencia.IdInasistencia = int.Parse(cmd.Parameters["@IDINASISTENCIA"].Value.ToString());

                }

                return (rowsAffected > 0);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Actualizar(BE.Inasistencia BeInasistencia)
        {
            try
            {
                string sp = "SpTbInasistenciaActualizar";
                int rowsAffected = 0;

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IDINASISTENCIA", BeInasistencia.IdInasistencia));
                    cmd.Parameters.Add(new SqlParameter("@CODIGO", BeInasistencia.Codigo));
                    cmd.Parameters.Add(new SqlParameter("@FECHAREGISTRO", BeInasistencia.Fecha));
                    cmd.Parameters.Add(new SqlParameter("@FECHAHORAENTRADA", BeInasistencia.FechaHoraEntrada));
                    cmd.Parameters.Add(new SqlParameter("@FECHAHORASALIDA", BeInasistencia.FechaHoraSalida));
                    cmd.Parameters.Add(new SqlParameter("@IDUSUARIOMODIFICADOR", BeInasistencia.IdUsuarioModificador));
                    cmd.Parameters.Add(new SqlParameter("@FECHAMODIFICACION", DateTime.Now));
                    cmd.Parameters.Add(new SqlParameter("@TIPO", BeInasistencia.Tipo));
                    cmd.Parameters.Add(new SqlParameter("@ASUNTO", BeInasistencia.Asunto));
                    cmd.Parameters.Add(new SqlParameter("@DETALLE", BeInasistencia.Detalle));
                    cmd.Parameters.Add(new SqlParameter("@CITT", BeInasistencia.Certificado));

                    rowsAffected = cmd.ExecuteNonQuery();
                }

                return (rowsAffected > 0);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        public DataTable Listar(int anho, int mes, int idSala)
        {
            try
            {
                string sp = "SpListarInasistencias";
                DataTable dt = new DataTable();

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ANHO", anho));
                    cmd.Parameters.Add(new SqlParameter("@MES", mes));
                    if (idSala > 0)
                        cmd.Parameters.Add(new SqlParameter("@IDSALA", idSala));
                    else
                        cmd.Parameters.Add(new SqlParameter("@IDSALA", DBNull.Value));

                    SqlDataAdapter dad = new SqlDataAdapter(cmd);                    
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