using BE = ErpCasino.BusinessLibrary.BE;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;

namespace ErpCasino.BusinessLibrary.DA
{
    public class Horario
    {

        public int Insertar(ref List<BE.Horario> lstBeHorarios)
        {

            SqlConnection cnn = null;
            SqlTransaction tns = null;
            SqlCommand cmd = null;

            try
            {
                int rowsAffected = 0;
                string sp = "SpTbHorarioInsertar";

                cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                cnn.Open();

                for (int i = 0; i < lstBeHorarios.Count; i++)
                {

                    cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IDHORARIO", lstBeHorarios[i].IdHorario));
                    cmd.Parameters["@IDHORARIO"].Direction = ParameterDirection.Output;

                    cmd.Parameters.Add(new SqlParameter("@ANHO", lstBeHorarios[i].Anho));
                    cmd.Parameters.Add(new SqlParameter("@SEMANA", lstBeHorarios[i].Semana));
                    cmd.Parameters.Add(new SqlParameter("@FECHAINICIO", lstBeHorarios[i].FechaInicio));
                    cmd.Parameters.Add(new SqlParameter("@FECHAFINAL", lstBeHorarios[i].FechaFinal));
                    cmd.Parameters.Add(new SqlParameter("@IDSALA", lstBeHorarios[i].IdSala));
                    cmd.Parameters.Add(new SqlParameter("@IDCARGO", lstBeHorarios[i].IdCargo));
                    cmd.Parameters.Add(new SqlParameter("@FECHA", lstBeHorarios[i].Fecha));
                    cmd.Parameters.Add(new SqlParameter("@CODIGO", lstBeHorarios[i].Codigo));
                    cmd.Parameters.Add(new SqlParameter("@DIA", lstBeHorarios[i].Dia));
                    cmd.Parameters.Add(new SqlParameter("@TURNO", lstBeHorarios[i].Turno));
                    cmd.Parameters.Add(new SqlParameter("@HORAINICIO", lstBeHorarios[i].HoraInicio));
                    cmd.Parameters.Add(new SqlParameter("@HORAFINAL", lstBeHorarios[i].HoraFinal));
                    cmd.Parameters.Add(new SqlParameter("@HORAS", lstBeHorarios[i].Horas));

                    rowsAffected += cmd.ExecuteNonQuery();
                    lstBeHorarios[i].IdHorario = int.Parse(cmd.Parameters["@IDHORARIO"].Value.ToString());

                }

                if (tns != null)
                    tns.Commit();

                return rowsAffected;

            }
            catch (Exception ex)
            {
                if (tns != null)
                    tns.Rollback();

                throw ex;
            }
        }

        public bool Insertar(ref BE.Horario beHorario)
        {
            try
            {
                string sp = "SpTbHorarioInsertar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                int rowsAffected = 0;
                cnn.Open();

                cmd.Parameters.Add(new SqlParameter("@IDHORARIO", beHorario.IdHorario));
                cmd.Parameters["@IDHORARIO"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new SqlParameter("@ANHO", beHorario.Anho));
                cmd.Parameters.Add(new SqlParameter("@SEMANA", beHorario.Semana));
                cmd.Parameters.Add(new SqlParameter("@FECHAINICIO", beHorario.FechaInicio));
                cmd.Parameters.Add(new SqlParameter("@FECHAFINAL", beHorario.FechaFinal));
                cmd.Parameters.Add(new SqlParameter("@IDSALA", beHorario.IdSala));
                cmd.Parameters.Add(new SqlParameter("@IDCARGO", beHorario.IdCargo));
                cmd.Parameters.Add(new SqlParameter("@FECHA", beHorario.Fecha));
                cmd.Parameters.Add(new SqlParameter("@CODIGO", beHorario.Codigo));
                cmd.Parameters.Add(new SqlParameter("@DIA", beHorario.Dia));
                cmd.Parameters.Add(new SqlParameter("@TURNO", beHorario.Turno));
                cmd.Parameters.Add(new SqlParameter("@HORAINICIO", beHorario.HoraInicio));
                cmd.Parameters.Add(new SqlParameter("@HORAFINAL", beHorario.HoraFinal));
                cmd.Parameters.Add(new SqlParameter("@HORAS", beHorario.Horas));

                rowsAffected = cmd.ExecuteNonQuery();
                beHorario.IdHorario = int.Parse(cmd.Parameters["@IDHORARIO"].Value.ToString());

                return (rowsAffected > 0);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Actualizar(BE.Horario beHorario)
        {
            try
            {
                string sp = "SpTbHorarioActualizar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                int rowsAffected = 0;
                cnn.Open();

                cmd.Parameters.Add(new SqlParameter("@IDHORARIO", beHorario.IdHorario));
                cmd.Parameters.Add(new SqlParameter("@ANHO", beHorario.Anho));
                cmd.Parameters.Add(new SqlParameter("@SEMANA", beHorario.Semana));
                cmd.Parameters.Add(new SqlParameter("@FECHAINICIO", beHorario.FechaInicio));
                cmd.Parameters.Add(new SqlParameter("@FECHAFINAL", beHorario.FechaFinal));
                cmd.Parameters.Add(new SqlParameter("@IDSALA", beHorario.IdSala));
                cmd.Parameters.Add(new SqlParameter("@IDCARGO", beHorario.IdCargo));
                cmd.Parameters.Add(new SqlParameter("@FECHA", beHorario.Fecha));
                cmd.Parameters.Add(new SqlParameter("@CODIGO", beHorario.Codigo));
                cmd.Parameters.Add(new SqlParameter("@DIA", beHorario.Dia));
                cmd.Parameters.Add(new SqlParameter("@TURNO", beHorario.Turno));
                cmd.Parameters.Add(new SqlParameter("@HORAINICIO", beHorario.HoraInicio));
                cmd.Parameters.Add(new SqlParameter("@HORAFINAL", beHorario.HoraFinal));
                cmd.Parameters.Add(new SqlParameter("@HORAS", beHorario.Horas));

                rowsAffected = cmd.ExecuteNonQuery();
                
                return (rowsAffected > 0);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(int idHorario)
        {
            try
            {
                string sp = "SpTbHorarioEliminar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                int rowsAffected = 0;
                cnn.Open();

                cmd.Parameters.Add(new SqlParameter("@IDHORARIO", idHorario));

                rowsAffected = cmd.ExecuteNonQuery();

                return (rowsAffected > 0);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.HorarioMensual> ListarResumenMensual(int idSala = 0)
        {
            var lstBeHorarioMensual = new List<BE.HorarioMensual>();
            try
            {
                string sp = "SpTbHorarioListarResumenMensual";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (idSala > 0)
                    cmd.Parameters.Add(new SqlParameter("@IDSALA", idSala));

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var beHorarioMensual = new BE.HorarioMensual();

                    beHorarioMensual.Anho = int.Parse(reader["Anho"].ToString());
                    beHorarioMensual.Mes = byte.Parse(reader["Mes"].ToString());
                    beHorarioMensual.SalaId = int.Parse(reader["IdSala"].ToString());
                    beHorarioMensual.SalaNombre = reader["DscSala"].ToString();
                    
                    lstBeHorarioMensual.Add(beHorarioMensual);
                }

                return lstBeHorarioMensual;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.HorarioSemanal> ListarResumenSemanal(int idSala = 0)
        {
            var lstBeHorarioSemanal = new List<BE.HorarioSemanal>();
            try
            {
                string sp = "SpTbHorarioListarResumenSemanal";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (idSala > 0)
                    cmd.Parameters.Add(new SqlParameter("@IDSALA", idSala));

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var beHorarioSemanal = new BE.HorarioSemanal();

                    beHorarioSemanal.Anho = int.Parse(reader["Anho"].ToString());
                    beHorarioSemanal.Semana = byte.Parse(reader["Semana"].ToString());
                    beHorarioSemanal.SalaId = int.Parse(reader["IdSala"].ToString());
                    beHorarioSemanal.SalaNombre = reader["DscSala"].ToString();
                    beHorarioSemanal.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
                    beHorarioSemanal.FechaFinal = DateTime.Parse(reader["FechaFinal"].ToString());

                    lstBeHorarioSemanal.Add(beHorarioSemanal);
                }

                return lstBeHorarioSemanal;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.Horario> ListarSemana(int anho, byte semana, int idSala)
        {
            var lstHorarios = new List<BE.Horario>();
            try
            {
                string sp = "SpTbHorarioListarSemana";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@ANHO", anho));
                cmd.Parameters.Add(new SqlParameter("@SEMANA", semana));
                cmd.Parameters.Add(new SqlParameter("@IDSALA", idSala));

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var beHorario = new BE.Horario();

                    beHorario.IdHorario = int.Parse(reader["IdHorario"].ToString());
                    beHorario.Anho = int.Parse(reader["Anho"].ToString());
                    beHorario.Semana = byte.Parse(reader["Semana"].ToString());
                    beHorario.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
                    beHorario.FechaFinal = DateTime.Parse(reader["FechaFinal"].ToString());
                    beHorario.IdSala = int.Parse(reader["IdSala"].ToString());
                    beHorario.IdCargo = int.Parse(reader["IdCargo"].ToString());
                    beHorario.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                    beHorario.Codigo = reader["Codigo"].ToString();
                    beHorario.Dia = byte.Parse(reader["Dia"].ToString());
                    beHorario.Turno = byte.Parse(reader["Turno"].ToString());
                    beHorario.HoraInicio = TimeSpan.Parse(reader["HoraInicio"].ToString());
                    beHorario.HoraFinal = TimeSpan.Parse(reader["HoraFinal"].ToString());
                    beHorario.Horas = byte.Parse(reader["Horas"].ToString());

                    lstHorarios.Add(beHorario);
                }

                return lstHorarios;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EliminarSemana(int anho, byte semana, int idSala)
        {
            try
            {
                string sp = "SpTbHorarioEliminarSemana";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                int rowsAffected = 0;
                cnn.Open();

                cmd.Parameters.Add(new SqlParameter("@ANHO", anho));
                cmd.Parameters.Add(new SqlParameter("@SEMANA", semana));
                cmd.Parameters.Add(new SqlParameter("@IDSALA", idSala));
                
                rowsAffected = cmd.ExecuteNonQuery();

                return (rowsAffected > 0);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EliminarMes(int anho, byte mes, int idSala)
        {
            try
            {
                string sp = "SpTbHorarioEliminarMes";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@ANHO", anho));
                cmd.Parameters.Add(new SqlParameter("@MES", mes));
                cmd.Parameters.Add(new SqlParameter("@IDSALA", idSala));

                int rowsAffected = 0;
                rowsAffected = cmd.ExecuteNonQuery();

                return (rowsAffected > 0);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}