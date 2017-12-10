using BE = ErpCasino.BusinessLibrary.BE;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace ErpCasino.BusinessLibrary.DA
{
    public class Prestamo
    {
        
        public bool Insertar(ref BE.Prestamo bePrestamo)
        {

            SqlConnection cnn = null;
            SqlTransaction tns = null;

            try
            {

                int rowsAffected = 0;
                string sp = "";

                using (cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();
                    tns = cnn.BeginTransaction();

                    SqlCommand cmd = null;

                    #region Cabecera

                    sp = "SpTbPrestamoInsertar";

                    cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Transaction = tns;

                    cmd.Parameters.Add(new SqlParameter("@IDPRESTAMO", bePrestamo.IdPrestamo));
                    cmd.Parameters["@IDPRESTAMO"].Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(new SqlParameter("@FECHA", bePrestamo.Fecha));
                    cmd.Parameters.Add(new SqlParameter("@CODIGOEMPLEADO", bePrestamo.CodigoEmpleado));
                    cmd.Parameters.Add(new SqlParameter("@MOTIVO", bePrestamo.Motivo));
                    cmd.Parameters.Add(new SqlParameter("@MONTO", bePrestamo.Monto));
                    cmd.Parameters.Add(new SqlParameter("@CUOTAS", bePrestamo.NumeroCuotas));
                    cmd.Parameters.Add(new SqlParameter("@PAGADO", bePrestamo.Pagado));

                    rowsAffected += cmd.ExecuteNonQuery();
                    bePrestamo.IdPrestamo = int.Parse(cmd.Parameters["@IDPRESTAMO"].Value.ToString());

                    #endregion

                    #region Detalles

                    sp = "SpTbPrestamoCuotaInsertar";
                    for (int i = 0; i < bePrestamo.Cuotas.Count; i++)
                    {
                        cmd = new SqlCommand(sp, cnn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Transaction = tns;

                        cmd.Parameters.Add(new SqlParameter("@IDPRESTAMOCUOTA", bePrestamo.Cuotas[i].IdPrestamoCuota));
                        cmd.Parameters["@IDPRESTAMOCUOTA"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@IDPRESTAMO", bePrestamo.IdPrestamo));
                        cmd.Parameters.Add(new SqlParameter("@FECHA", bePrestamo.Cuotas[i].Fecha));
                        cmd.Parameters.Add(new SqlParameter("@MONTO", bePrestamo.Cuotas[i].Importe));
                        cmd.Parameters.Add(new SqlParameter("@PAGADO", bePrestamo.Cuotas[i].Pagado));

                        rowsAffected += cmd.ExecuteNonQuery();
                        bePrestamo.Cuotas[i].IdPrestamoCuota = int.Parse(cmd.Parameters["@IDPRESTAMOCUOTA"].Value.ToString());
                    }

                    #endregion

                    if (tns != null)
                        tns.Commit();

                }

                return (rowsAffected > 0);

            }
            catch (Exception ex)
            {
                if (tns != null)
                    tns.Rollback();

                throw ex;
            }
        }

        public bool Actualizar(BE.Prestamo bePrestamo, 
            List<BE.PrestamoCuota> lstBeCuotasNuevas, 
            List<BE.PrestamoCuota> lstBeCuotasEliminadas)
        {
            SqlConnection cnn = null;
            SqlTransaction tns = null;

            try
            {

                int rowsAffected = 0;
                string sp = "";

                using (cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    tns = cnn.BeginTransaction();

                    SqlCommand cmd = null;

                    #region Cabecera
                    sp = "SpTbPrestamoActualizar";

                    cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Transaction = tns;

                    cmd.Parameters.Add(new SqlParameter("@IDPRESTAMO", bePrestamo.IdPrestamo));
                    cmd.Parameters.Add(new SqlParameter("@FECHA", bePrestamo.Fecha));
                    cmd.Parameters.Add(new SqlParameter("@CODIGOEMPLEADO", bePrestamo.CodigoEmpleado));
                    cmd.Parameters.Add(new SqlParameter("@MOTIVO", bePrestamo.Motivo));
                    cmd.Parameters.Add(new SqlParameter("@MONTO", bePrestamo.Monto));
                    cmd.Parameters.Add(new SqlParameter("@CUOTAS", bePrestamo.NumeroCuotas));
                    cmd.Parameters.Add(new SqlParameter("@PAGADO", bePrestamo.Pagado));

                    rowsAffected += cmd.ExecuteNonQuery();
                    #endregion

                    #region Agregar cuotas

                    sp = "SpTbPrestamoCuotaInsertar";
                    for (int i = 0; i < lstBeCuotasNuevas.Count; i++)
                    {
                        cmd = new SqlCommand(sp, cnn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Transaction = tns;

                        cmd.Parameters.Add(new SqlParameter("@IDPRESTAMOCUOTA", lstBeCuotasNuevas[i].IdPrestamoCuota));
                        cmd.Parameters["@IDPRESTAMOCUOTA"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@IDPRESTAMO", bePrestamo.IdPrestamo));
                        cmd.Parameters.Add(new SqlParameter("@FECHA", lstBeCuotasNuevas[i].Fecha));
                        cmd.Parameters.Add(new SqlParameter("@MONTO", lstBeCuotasNuevas[i].Importe));
                        cmd.Parameters.Add(new SqlParameter("@PAGADO", lstBeCuotasNuevas[i].Pagado));

                        rowsAffected += cmd.ExecuteNonQuery();
                        lstBeCuotasNuevas[i].IdPrestamoCuota = int.Parse(cmd.Parameters["@IDPRESTAMOCUOTA"].Value.ToString());
                    }

                    #endregion

                    #region Eliminar cuotas

                    sp = "SpTbPrestamoCuotaEliminar";
                    for (int i = 0; i < lstBeCuotasEliminadas.Count; i++)
                    {
                        cmd = new SqlCommand(sp, cnn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Transaction = tns;

                        cmd.Parameters.Add(new SqlParameter("@IDPRESTAMOCUOTA", lstBeCuotasEliminadas[i].IdPrestamoCuota));

                        rowsAffected += cmd.ExecuteNonQuery();
                    }

                    #endregion

                    if (tns != null)
                        tns.Commit();
                }

                return (rowsAffected > 0);

            }
            catch (Exception ex)
            {
                if (tns != null)
                    tns.Rollback();

                throw ex;
            }
        }

        /// <summary>
        /// Elimina el prestamo (Cabecera y Detalle)
        /// </summary>
        /// <param name="idPrestamo">Id del prestamo</param>
        /// <returns></returns>
        public bool Eliminar(int idPrestamo)
        {
            try
            {
                string sp = "SpTbPrestamoEliminar";
                int rowsAffected = 0;

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IDPRESTAMO", idPrestamo));

                    rowsAffected = cmd.ExecuteNonQuery();
                }
  
                return (rowsAffected > 0); 

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.Prestamo> Listar(int anho, int mes, bool conCuotas = false)
        {
            var lstPrestamos = new List<BE.Prestamo>();
            try
            {
                string sp = "SpTbPrestamoListar";

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
                        var bePrestamo = new BE.Prestamo();

                        bePrestamo.IdPrestamo = int.Parse(reader["IdPrestamo"].ToString());
                        bePrestamo.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                        bePrestamo.CodigoEmpleado = reader["CodigoEmpleado"].ToString();
                        bePrestamo.Motivo = reader["Motivo"].ToString();
                        bePrestamo.Monto = double.Parse(reader["Monto"].ToString());
                        bePrestamo.NumeroCuotas = int.Parse(reader["Cuotas"].ToString());
                        bePrestamo.Pagado = bool.Parse(reader["Pagado"].ToString());

                        if (conCuotas == true)
                        {
                            bePrestamo.Cuotas = this.ListarCuotas(bePrestamo.IdPrestamo);
                        }

                        lstPrestamos.Add(bePrestamo);
                    }
                }

                return lstPrestamos;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Listar todos los prestamos filtrado empleado que esten pendiente de pago
        /// </summary>
        /// <param name="CodigoEmpleado">Codigo de Empleado</param>
        /// <returns></returns>
        public List<BE.Prestamo> ListarPorEmpleado(string CodigoEmpleado)
        {
            var lstPrestamos = new List<BE.Prestamo>();
            try
            {
                string sp = "SpTbPrestamoListar2";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CodigoEmpleado", CodigoEmpleado));

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var bePrestamo = new BE.Prestamo();

                        bePrestamo.IdPrestamo = int.Parse(reader["IdPrestamo"].ToString());
                        bePrestamo.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                        bePrestamo.CodigoEmpleado = reader["CodigoEmpleado"].ToString();
                        bePrestamo.Motivo = reader["Motivo"].ToString();
                        bePrestamo.Monto = double.Parse(reader["Monto"].ToString());
                        bePrestamo.NumeroCuotas = int.Parse(reader["Cuotas"].ToString());
                        bePrestamo.Pagado = bool.Parse(reader["Pagado"].ToString());
                        bePrestamo.Cuotas = this.ListarCuotas(bePrestamo.IdPrestamo);
     
                        lstPrestamos.Add(bePrestamo);
                    }
                }

                return lstPrestamos;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.Prestamo Obtener(int idPrestamo, bool conCuotas = false)
        {
            BE.Prestamo bePrestamo = null;
            try
            {
                string sp = "SpTbPrestamoObtener";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IDPRESTAMO", idPrestamo));

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {

                        bePrestamo = new BE.Prestamo();

                        bePrestamo.IdPrestamo = int.Parse(reader["IdPrestamo"].ToString());
                        bePrestamo.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                        bePrestamo.CodigoEmpleado = reader["CodigoEmpleado"].ToString();
                        bePrestamo.Motivo = reader["Motivo"].ToString();
                        bePrestamo.Monto = double.Parse(reader["Monto"].ToString());
                        bePrestamo.Pagado = bool.Parse(reader["Pagado"].ToString());
                        bePrestamo.NumeroCuotas = int.Parse(reader["Cuotas"].ToString());

                        if (conCuotas == true)
                        {
                            bePrestamo.Cuotas = this.ListarCuotas(idPrestamo);
                        }
                    }

                }

                return bePrestamo;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Listar cuotas del prestamo
        /// </summary>
        /// <param name="idPrestamo">Id del prestamo</param>
        /// <returns></returns>
        public List<BE.PrestamoCuota> ListarCuotas(int idPrestamo)
        {
            List<BE.PrestamoCuota> lstPrestamoCuota = new List<BE.PrestamoCuota>();
            try
            {
                string sp = "SpTbPrestamoCuotaListar";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IDPRESTAMO", idPrestamo));

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        var bePrestamoCuota = new BE.PrestamoCuota();

                        bePrestamoCuota.IdPrestamoCuota = int.Parse(reader["IdPrestamoCuota"].ToString());
                        bePrestamoCuota.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                        bePrestamoCuota.Importe = double.Parse(reader["Monto"].ToString());
                        bePrestamoCuota.Pagado = bool.Parse(reader["Pagado"].ToString());

                        lstPrestamoCuota.Add(bePrestamoCuota);
                    }
                }

                return lstPrestamoCuota;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.PrestamoCuota> ListarCuotas(int anho, int mes, string codigoEmpleado)
        {
            List<BE.PrestamoCuota> lstPrestamoCuota = new List<BE.PrestamoCuota>();
            try
            {
                string sp = "SpTbPrestamoCuotaListar2";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ANHO", anho));
                    cmd.Parameters.Add(new SqlParameter("@MES", mes));
                    cmd.Parameters.Add(new SqlParameter("@CODIGOEMPLEADO", codigoEmpleado));

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        var bePrestamoCuota = new BE.PrestamoCuota();

                        bePrestamoCuota.IdPrestamoCuota = int.Parse(reader["IdPrestamoCuota"].ToString());
                        bePrestamoCuota.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                        bePrestamoCuota.Importe = double.Parse(reader["Monto"].ToString());
                        bePrestamoCuota.Pagado = bool.Parse(reader["Pagado"].ToString());

                        lstPrestamoCuota.Add(bePrestamoCuota);
                    }
                }

                return lstPrestamoCuota;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}