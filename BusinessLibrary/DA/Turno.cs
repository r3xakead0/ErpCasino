using BE = ErpCasino.BusinessLibrary.BE;
using System.Data.SqlClient;
using System.Data;
using System;

namespace ErpCasino.BusinessLibrary.DA
{
    public class Turno
    {

        public void Cargar(ref BE.Turno beTurno, ref DataRow dr)
        {
            try
            {
                beTurno.IdTurno = dr["IdTurno"] == DBNull.Value ? 0 : int.Parse(dr["IdTurno"].ToString());
                beTurno.Numero = dr["Numero"] == DBNull.Value ? 0 : int.Parse(dr["Numero"].ToString());
                beTurno.HoraInicial = dr["HoraInicial"] == DBNull.Value ? "00:00:00" : dr["HoraInicial"].ToString();
                beTurno.HoraFinal = dr["HoraFinal"] == DBNull.Value ? "00:00:00" : dr["HoraFinal"].ToString();
                beTurno.Activo = dr["Activo"] == DBNull.Value ? false : bool.Parse(dr["Activo"].ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Insertar(ref BE.Turno beTurno)
        {
            try
            {
                string sp = "SpTbTurnoInsertar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                int rowsAffected = 0;
                cnn.Open();

                cmd.Parameters.Add(new SqlParameter("@IDTURNO", beTurno.IdTurno));
                cmd.Parameters["@IDTURNO"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new SqlParameter("@NUMERO", beTurno.Numero));
                cmd.Parameters.Add(new SqlParameter("@HORAINICIAL", beTurno.HoraInicial));
                cmd.Parameters.Add(new SqlParameter("@HORAFINAL", beTurno.HoraFinal));
                cmd.Parameters.Add(new SqlParameter("@ACTIVO", beTurno.Activo));

                rowsAffected = cmd.ExecuteNonQuery();
                beTurno.IdTurno = int.Parse(cmd.Parameters["@IDTURNO"].Value.ToString());

                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Actualizar(BE.Turno beTurno)
        {
            try
            {
                string sp = "SpTbTurnoActualizar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                int rowsAffected = 0;
                cnn.Open();

                cmd.Parameters.Add(new SqlParameter("@IDTURNO", beTurno.IdTurno));
                cmd.Parameters.Add(new SqlParameter("@NUMERO", beTurno.Numero));
                cmd.Parameters.Add(new SqlParameter("@HORAINICIAL", beTurno.HoraInicial));
                cmd.Parameters.Add(new SqlParameter("@HORAFINAL", beTurno.HoraFinal));
                cmd.Parameters.Add(new SqlParameter("@ACTIVO", beTurno.Activo));

                rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Eliminar(BE.Turno beTurno)
        {
            try
            {
                string sp = "SpTbTurnoEliminar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                int rowsAffected = 0;
                cnn.Open();

                cmd.Parameters.Add(new SqlParameter("@IDTURNO", beTurno.IdTurno));

                rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Listar()
        {
            try
            {
                string sp = "SpTbTurnoListar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

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

        public bool Obtener(ref BE.Turno beTurno)
        {
            bool rpta = false;
            try
            {
                string sp = "SpTbTurnoObtener";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter dad = new SqlDataAdapter(cmd);
                dad.SelectCommand.Parameters.Add(new SqlParameter("@IDTURNO", beTurno.IdTurno));

                DataTable dt = new DataTable();
                dad.Fill(dt);

                if ((dt.Rows.Count == 1))
                {
                    DataRow dr = dt.Rows[0];
                    Cargar(ref beTurno, ref dr);

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
