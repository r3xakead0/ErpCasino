using BE = ErpCasino.BusinessLibrary.BE;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace ErpCasino.BusinessLibrary.DA
{
    public class Gratificacion
    {

        public int Insertar(ref BE.Gratificacion beGratificacion)
        {
            SqlTransaction tns = null;
            int rowsAffected = 0;
            try
            {
                string sp = "SpTbGratificacionInsertar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                cnn.Open();

                tns = cnn.BeginTransaction();

                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = tns;

                cmd.Parameters.Add(new SqlParameter("@IDGRATIFICACION", beGratificacion.IdGratificacion));
                cmd.Parameters["@IDGRATIFICACION"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new SqlParameter("@PERIODO", beGratificacion.Periodo));
                cmd.Parameters.Add(new SqlParameter("@FECHAINICIO", beGratificacion.FechaInicio));
                cmd.Parameters.Add(new SqlParameter("@FECHAFINAL", beGratificacion.FechaFinal));
                cmd.Parameters.Add(new SqlParameter("@DIAS", beGratificacion.Dias));
                cmd.Parameters.Add(new SqlParameter("@CODIGOEMPLEADO", beGratificacion.CodigoEmpleado));
                cmd.Parameters.Add(new SqlParameter("@BONONOCTURNOPROMEDIO", beGratificacion.BonoNocturnoPromedio));
                cmd.Parameters.Add(new SqlParameter("@BONOHORASEXTRASPROMEDIO", beGratificacion.BonoHorasExtrasPromedio));
                cmd.Parameters.Add(new SqlParameter("@SUELDOBASE", beGratificacion.SueldoBase));
                cmd.Parameters.Add(new SqlParameter("@ASIGNACIONFAMILIAR", beGratificacion.AsignacionFamiliar));
                cmd.Parameters.Add(new SqlParameter("@DIASLABORADOS", beGratificacion.DiasLaborados));
                cmd.Parameters.Add(new SqlParameter("@GRATIFICACIONBRUTA", beGratificacion.GratificacionBruta));
                cmd.Parameters.Add(new SqlParameter("@BONOEXTRAORDINARIO", beGratificacion.BonoExtraordinario));
                cmd.Parameters.Add(new SqlParameter("@GRATIFICACIONNETA", beGratificacion.GratificacionNeta));
                cmd.Parameters.Add(new SqlParameter("@DESCUENTORETENCIONJUDICIAL", beGratificacion.DescuentoRetencionJudicial));
                cmd.Parameters.Add(new SqlParameter("@DESCUENTOIMPUESTO", beGratificacion.DescuentoImpuesto));
                cmd.Parameters.Add(new SqlParameter("@GRATIFICACIONPAGAR", beGratificacion.GratificacionPagar));

                rowsAffected += cmd.ExecuteNonQuery();
                beGratificacion.IdGratificacion = int.Parse(cmd.Parameters["@IDGRATIFICACION"].Value.ToString());

                foreach (BE.GratificacionDetalle beGratificacionDetalle in beGratificacion.Detalle)
                {

                    sp = "SpTbGratificacionDetalleInsertar";

                    cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Transaction = tns;

                    cmd.Parameters.Add(new SqlParameter("@IDGRATIFICACIONDETALLE", beGratificacionDetalle.IdGratificacionDetalle));
                    cmd.Parameters["@IDGRATIFICACIONDETALLE"].Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(new SqlParameter("@IDGRATIFICACION", beGratificacion.IdGratificacion));
                    cmd.Parameters.Add(new SqlParameter("@ANHO", beGratificacionDetalle.Anho));
                    cmd.Parameters.Add(new SqlParameter("@MES", beGratificacionDetalle.Mes));
                    cmd.Parameters.Add(new SqlParameter("@CODIGOEMPLEADO", beGratificacionDetalle.CodigoEmpleado));
                    cmd.Parameters.Add(new SqlParameter("@BONONOCTURNO", beGratificacionDetalle.BonoNocturno));
                    cmd.Parameters.Add(new SqlParameter("@BONOHORASEXTRAS", beGratificacionDetalle.BonoHorasExtras));
                    cmd.Parameters.Add(new SqlParameter("@DIASCALENDARIO", beGratificacionDetalle.DiasCalendario));
                    cmd.Parameters.Add(new SqlParameter("@DIASINASISTENCIA", beGratificacionDetalle.DiasInasistencia));

                    rowsAffected += cmd.ExecuteNonQuery();
                    beGratificacionDetalle.IdGratificacionDetalle = int.Parse(cmd.Parameters["@IDGRATIFICACIONDETALLE"].Value.ToString());
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

        public int Actualizar(BE.Gratificacion beGratificacion)
        {
            SqlTransaction tns = null;
            int rowsAffected = 0;

            try
            {
                string sp = "SpTbGratificacionActualizar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                cnn.Open();

                tns = cnn.BeginTransaction();

                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = tns;

                cmd.Parameters.Add(new SqlParameter("@IDGRATIFICACION", beGratificacion.IdGratificacion));
                cmd.Parameters.Add(new SqlParameter("@PERIODO", beGratificacion.Periodo));
                cmd.Parameters.Add(new SqlParameter("@FECHAINICIO", beGratificacion.FechaInicio));
                cmd.Parameters.Add(new SqlParameter("@FECHAFINAL", beGratificacion.FechaFinal));
                cmd.Parameters.Add(new SqlParameter("@DIAS", beGratificacion.Dias));
                cmd.Parameters.Add(new SqlParameter("@CODIGOEMPLEADO", beGratificacion.CodigoEmpleado));
                cmd.Parameters.Add(new SqlParameter("@BONONOCTURNOPROMEDIO", beGratificacion.BonoNocturnoPromedio));
                cmd.Parameters.Add(new SqlParameter("@BONOHORASEXTRASPROMEDIO", beGratificacion.BonoHorasExtrasPromedio));
                cmd.Parameters.Add(new SqlParameter("@SUELDOBASE", beGratificacion.SueldoBase));
                cmd.Parameters.Add(new SqlParameter("@ASIGNACIONFAMILIAR", beGratificacion.AsignacionFamiliar));
                cmd.Parameters.Add(new SqlParameter("@DIASLABORADOS", beGratificacion.DiasLaborados));
                cmd.Parameters.Add(new SqlParameter("@GRATIFICACIONBRUTA", beGratificacion.GratificacionBruta));
                cmd.Parameters.Add(new SqlParameter("@BONOEXTRAORDINARIO", beGratificacion.BonoExtraordinario));
                cmd.Parameters.Add(new SqlParameter("@GRATIFICACIONNETA", beGratificacion.GratificacionNeta));
                cmd.Parameters.Add(new SqlParameter("@DESCUENTORETENCIONJUDICIAL", beGratificacion.DescuentoRetencionJudicial));
                cmd.Parameters.Add(new SqlParameter("@DESCUENTOIMPUESTO", beGratificacion.DescuentoImpuesto));
                cmd.Parameters.Add(new SqlParameter("@GRATIFICACIONPAGAR", beGratificacion.GratificacionPagar));

                rowsAffected += cmd.ExecuteNonQuery();

                foreach (BE.GratificacionDetalle beGratificacionDetalle in beGratificacion.Detalle)
                {

                    sp = "SpTbGratificacionDetalleActualizar";

                    cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Transaction = tns;

                    cmd.Parameters.Add(new SqlParameter("@IDGRATIFICACIONDETALLE", beGratificacionDetalle.IdGratificacionDetalle));
                    cmd.Parameters.Add(new SqlParameter("@IDGRATIFICACION", beGratificacion.IdGratificacion));
                    cmd.Parameters.Add(new SqlParameter("@ANHO", beGratificacionDetalle.Anho));
                    cmd.Parameters.Add(new SqlParameter("@MES", beGratificacionDetalle.Mes));
                    cmd.Parameters.Add(new SqlParameter("@CODIGOEMPLEADO", beGratificacionDetalle.CodigoEmpleado));
                    cmd.Parameters.Add(new SqlParameter("@BONONOCTURNO", beGratificacionDetalle.BonoNocturno));
                    cmd.Parameters.Add(new SqlParameter("@BONOHORASEXTRAS", beGratificacionDetalle.BonoHorasExtras));
                    cmd.Parameters.Add(new SqlParameter("@DIASCALENDARIO", beGratificacionDetalle.DiasCalendario));
                    cmd.Parameters.Add(new SqlParameter("@DIASINASISTENCIA", beGratificacionDetalle.DiasInasistencia));

                    rowsAffected += cmd.ExecuteNonQuery();
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

        public int Eliminar(int idGratificacion)
        {
            SqlTransaction tns = null;
            int rowsAffected = 0;

            try
            {
                string sp = "SpTbGratificacionEliminar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                cnn.Open();

                tns = cnn.BeginTransaction();

                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = tns;

                cmd.Parameters.Add(new SqlParameter("@IDGRATIFICACION", idGratificacion));

                rowsAffected += cmd.ExecuteNonQuery();

                var lstBeGratificacionDetalle = this.ListarDetalle(idGratificacion);
                foreach (BE.GratificacionDetalle beGratificacionDetalle in lstBeGratificacionDetalle)
                {
                    sp = "SpTbGratificacionDetalleEliminar";

                    cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Transaction = tns;

                    cmd.Parameters.Add(new SqlParameter("@IDGRATIFICACIONDETALLE", beGratificacionDetalle.IdGratificacionDetalle));

                    rowsAffected += cmd.ExecuteNonQuery();
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

        public List<BE.GratificacionDetalle> ListarDetalle(int idGratificacion)
        {
            try
            {
                var lstBeGratificacionDetalle = new List<BE.GratificacionDetalle>();

                string sp = "SpTbGratificacionDetalleListar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IDGRATIFICACION", idGratificacion));

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var beGratificacionDetalle = new BE.GratificacionDetalle();

                    beGratificacionDetalle.IdGratificacionDetalle = int.Parse(reader["IdGratificacionDetalle"].ToString());
                    beGratificacionDetalle.Anho = int.Parse(reader["Anho"].ToString());
                    beGratificacionDetalle.Mes = int.Parse(reader["Mes"].ToString());
                    beGratificacionDetalle.CodigoEmpleado = reader["CodigoEmpleado"].ToString();
                    beGratificacionDetalle.BonoNocturno = double.Parse(reader["BonoNocturno"].ToString());
                    beGratificacionDetalle.BonoHorasExtras = double.Parse(reader["BonoHorasExtras"].ToString());
                    beGratificacionDetalle.DiasCalendario = int.Parse(reader["DiasCalendario"].ToString());
                    beGratificacionDetalle.DiasInasistencia = int.Parse(reader["DiasInasistencia"].ToString());

                    lstBeGratificacionDetalle.Add(beGratificacionDetalle);
                }

                return lstBeGratificacionDetalle;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.Gratificacion> Listar(bool detalle = false)
        {
            try
            {
                var lstBeGratificacion = new List<BE.Gratificacion>();

                string sp = "SpTbGratificacionListar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var beGratificacion = new BE.Gratificacion();

                    beGratificacion.IdGratificacion = int.Parse(reader["IdGratificacion"].ToString());
                    beGratificacion.Periodo = reader["Periodo"].ToString();
                    beGratificacion.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
                    beGratificacion.FechaFinal = DateTime.Parse(reader["FechaFinal"].ToString());
                    beGratificacion.Dias = int.Parse(reader["Dias"].ToString());
                    beGratificacion.CodigoEmpleado = reader["CodigoEmpleado"].ToString();
                    beGratificacion.BonoNocturnoPromedio = double.Parse(reader["BonoNocturnoPromedio"].ToString());
                    beGratificacion.BonoHorasExtrasPromedio = double.Parse(reader["BonoHorasExtrasPromedio"].ToString());
                    beGratificacion.SueldoBase = double.Parse(reader["SueldoBase"].ToString());
                    beGratificacion.AsignacionFamiliar = double.Parse(reader["AsignacionFamiliar"].ToString());
                    beGratificacion.DiasLaborados = int.Parse(reader["DiasLaborados"].ToString());
                    beGratificacion.GratificacionBruta = double.Parse(reader["GratificacionBruta"].ToString());
                    beGratificacion.BonoExtraordinario = double.Parse(reader["BonoExtraordinario"].ToString());
                    beGratificacion.GratificacionNeta = double.Parse(reader["GratificacionNeta"].ToString());
                    beGratificacion.DescuentoRetencionJudicial = double.Parse(reader["DescuentoRetencionJudicial"].ToString());
                    beGratificacion.DescuentoImpuesto = double.Parse(reader["DescuentoImpuesto"].ToString());
                    beGratificacion.GratificacionPagar = double.Parse(reader["GratificacionPagar"].ToString());

                    if (detalle == true)
                        beGratificacion.Detalle = this.ListarDetalle(beGratificacion.IdGratificacion);

                    lstBeGratificacion.Add(beGratificacion);
                }

                return lstBeGratificacion;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.Gratificacion Obtener(int idGratificacion)
        {
            BE.Gratificacion beGratificacion = null;
            try
            {
                string sp = "SpTbGratificacionObtener";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IDGRATIFICACION", idGratificacion));

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    beGratificacion = new BE.Gratificacion();

                    beGratificacion.IdGratificacion = int.Parse(reader["IdGratificacion"].ToString());
                    beGratificacion.Periodo = reader["Periodo"].ToString();
                    beGratificacion.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
                    beGratificacion.FechaFinal = DateTime.Parse(reader["FechaFinal"].ToString());
                    beGratificacion.Dias = int.Parse(reader["Dias"].ToString());
                    beGratificacion.CodigoEmpleado = reader["CodigoEmpleado"].ToString();
                    beGratificacion.BonoNocturnoPromedio = double.Parse(reader["BonoNocturnoPromedio"].ToString());
                    beGratificacion.BonoHorasExtrasPromedio = double.Parse(reader["BonoHorasExtrasPromedio"].ToString());
                    beGratificacion.SueldoBase = double.Parse(reader["SueldoBase"].ToString());
                    beGratificacion.AsignacionFamiliar = double.Parse(reader["AsignacionFamiliar"].ToString());
                    beGratificacion.DiasLaborados = int.Parse(reader["DiasLaborados"].ToString());
                    beGratificacion.GratificacionBruta = double.Parse(reader["GratificacionBruta"].ToString());
                    beGratificacion.BonoExtraordinario = double.Parse(reader["BonoExtraordinario"].ToString());
                    beGratificacion.GratificacionNeta = double.Parse(reader["GratificacionNeta"].ToString());
                    beGratificacion.DescuentoRetencionJudicial = double.Parse(reader["DescuentoRetencionJudicial"].ToString());
                    beGratificacion.DescuentoImpuesto = double.Parse(reader["DescuentoImpuesto"].ToString());
                    beGratificacion.GratificacionPagar = double.Parse(reader["GratificacionPagar"].ToString());

                    beGratificacion.Detalle = this.ListarDetalle(beGratificacion.IdGratificacion);
                }

                return beGratificacion;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}