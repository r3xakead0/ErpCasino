using ErpCasino.BusinessLibrary.BE;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace ErpCasino.BusinessLibrary.DA
{

    public class Feriado
    {

        public List<BE.Feriado> Listar(int anho, int mes)
        {
            List<BE.Feriado> lstFeriado = new List<BE.Feriado>();
            try
            {
                string sp = "SpTbFeriadoListar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ANHO", anho));
                cmd.Parameters.Add(new SqlParameter("@MES", mes));

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var beFeriado = new BE.Feriado();
                    beFeriado.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                    beFeriado.Motivo = reader["Motivo"].ToString();
                    beFeriado.Festivo = bool.Parse(reader["Festivo"].ToString());
                    beFeriado.Activo = bool.Parse(reader["Activo"].ToString());

                    lstFeriado.Add(beFeriado);
                }

                return lstFeriado;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.Feriado Obtener(DateTime fecha)
        {
            BE.Feriado beFeriado = null;
            try
            {
                string sp = "SpTbFeriadoObtener";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Fecha", fecha));

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    beFeriado = new BE.Feriado();

                    beFeriado.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                    beFeriado.Motivo = reader["Motivo"].ToString();
                    beFeriado.Festivo = bool.Parse(reader["Festivo"].ToString());
                    beFeriado.Activo = bool.Parse(reader["Activo"].ToString());
                }

                return beFeriado;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
