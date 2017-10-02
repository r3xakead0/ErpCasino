using ErpCasino.BusinessLibrary.BE;
using System.Data.SqlClient;
using System.Data;
using System;

namespace ErpCasino.BusinessLibrary.DA
{
    public class ClsDaTbPlantillaHorario
    {

        public void Cargar(ref ClsBeTbPlantillaHorario oBeTbHorarioPlantilla, DataRow dr)
        {
            try
            {
                oBeTbHorarioPlantilla.IdPlantillaHorario = dr["IdPlantillaHorario"] == DBNull.Value ? 0 : int.Parse(dr["IdPlantillaHorario"].ToString());
                oBeTbHorarioPlantilla.Dia = dr["Dia"] == DBNull.Value ? 0 : int.Parse(dr["Dia"].ToString());
                oBeTbHorarioPlantilla.Turno = dr["Turno"] == DBNull.Value ? 0 : int.Parse(dr["Turno"].ToString());
                oBeTbHorarioPlantilla.HoraInicio = dr["HoraInicio"] == DBNull.Value ?  "00:00": dr["HoraInicio"].ToString();
                oBeTbHorarioPlantilla.HoraFin = dr["HoraFin"] == DBNull.Value ? "00:00" : dr["HoraFin"].ToString();
                oBeTbHorarioPlantilla.Horas = dr["Horas"] == DBNull.Value ? 0 : int.Parse(dr["Horas"].ToString());
                
                if (dr["IdSala"] != DBNull.Value)
                {
                    oBeTbHorarioPlantilla.Sala = new BE.Sala()
                    {
                        IdSala = int.Parse(dr["IdSala"].ToString())
                    };
                }

                if (dr["IdCargo"] != DBNull.Value)
                {
                    oBeTbHorarioPlantilla.Cargo = new BE.Cargo()
                    {
                        IdCargo = int.Parse(dr["IdCargo"].ToString())
                    };
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Listar(ClsBeTbPlantillaHorario oBeTbHorarioPlantilla)
        {
            try
            {
                string sp = "SpTbPlantillaHorarioListar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter dad = new SqlDataAdapter(cmd);
                dad.SelectCommand.Parameters.Add(new SqlParameter("@IdSala", oBeTbHorarioPlantilla.Sala.IdSala));
                dad.SelectCommand.Parameters.Add(new SqlParameter("@IdCargo", oBeTbHorarioPlantilla.Cargo.IdCargo));

                DataTable dt = new DataTable();
                dad.Fill(dt);

                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insertar(ref ClsBeTbPlantillaHorario oBeTbPlantillaHorario)
        {
            bool flag = false;

            try
            {
                string sp = "SpTbPlantillaHorarioInsertar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                int rowsAffected = 0;
                cnn.Open();

                cmd.Parameters.Add(new SqlParameter("@IDPLANTILLAHORARIO", oBeTbPlantillaHorario.IdPlantillaHorario));
                cmd.Parameters["@IDPLANTILLAHORARIO"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new SqlParameter("@IDSALA", oBeTbPlantillaHorario.Sala.IdSala));
                cmd.Parameters.Add(new SqlParameter("@IDCARGO", oBeTbPlantillaHorario.Cargo.IdCargo));
                cmd.Parameters.Add(new SqlParameter("@DIA", oBeTbPlantillaHorario.Dia));
                cmd.Parameters.Add(new SqlParameter("@TURNO", oBeTbPlantillaHorario.Turno));
                cmd.Parameters.Add(new SqlParameter("@HORAINICIO", oBeTbPlantillaHorario.HoraInicio));
                cmd.Parameters.Add(new SqlParameter("@HORAFIN", oBeTbPlantillaHorario.HoraFin));
                cmd.Parameters.Add(new SqlParameter("@HORAS", oBeTbPlantillaHorario.Horas));

                rowsAffected = cmd.ExecuteNonQuery();
                oBeTbPlantillaHorario.IdPlantillaHorario = int.Parse(cmd.Parameters["@IDPLANTILLAHORARIO"].Value.ToString());

                flag = (rowsAffected == 0 ? false : true);
                return flag;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(ClsBeTbPlantillaHorario oBeTbPlantillaHorario)
        {
            bool flag = false;

            try
            {
                string sp = "SpTbPlantillaHorarioEliminar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                int rowsAffected = 0;
                cnn.Open();

                cmd.Parameters.Add(new SqlParameter("@IDPLANTILLAHORARIO", oBeTbPlantillaHorario.IdPlantillaHorario));

                rowsAffected = cmd.ExecuteNonQuery();

                flag = (rowsAffected == 0 ? false : true);
                return flag;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}