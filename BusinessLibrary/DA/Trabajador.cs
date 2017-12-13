using System;

using System.Data.SqlClient;
using System.Data;
using ErpCasino.BusinessLibrary.BE.UI;

namespace ErpCasino.BusinessLibrary.DA
{
    public class Trabajador
    {

        internal string ObtenerNombreCompleto(string codigoTrabajador, bool? activo = null)
        {
            string nombreCompleto = "";

            try
            {
                string sp = "SpTrabajadorObtenerNombreCompleto";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter dad = new SqlDataAdapter(cmd);
                    cmd.Parameters.Add(new SqlParameter("@CODIGO", codigoTrabajador));
                    if (activo != null)
                        cmd.Parameters.Add(new SqlParameter("@ACTIVO", activo));

                    nombreCompleto = cmd.ExecuteScalar().ToString();

                    cnn.Close();
                }

                return nombreCompleto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal TipoTrabajadorEnum ObtenerTipo(string codigoTrabajador)
        {
            try
            {
                string tipo = "Ninguno";

                string sp = "SpTrabajadorObtenerTipo";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter dad = new SqlDataAdapter(cmd);
                    cmd.Parameters.Add(new SqlParameter("@CODIGO", codigoTrabajador));

                    tipo = cmd.ExecuteScalar().ToString();

                    cnn.Close();
                }

                switch (tipo)
                {
                    case "Candidato":
                        return TipoTrabajadorEnum.Candidato;
                    case "Empleado":
                        return TipoTrabajadorEnum.Empleado;
                    default:
                        return TipoTrabajadorEnum.Ninguno;
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}