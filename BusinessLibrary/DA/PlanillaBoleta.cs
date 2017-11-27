using BE = ErpCasino.BusinessLibrary.BE;
using System.Data.SqlClient;
using System.Data;
using System;

namespace ErpCasino.BusinessLibrary.DA
{

    public class PlanillaBoleta
    {

        public int Insertar(ref BE.PlanillaBoleta bePlanillaBoleta)
        {
            int rowsAffected = 0;
            try
            {

                string sp = "SpTbPlanillaBoletaInsertar";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IDPLANILLABOLETA", bePlanillaBoleta.IdPlanillaBoleta));
                    cmd.Parameters["@IDPLANILLABOLETA"].Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(new SqlParameter("@IDPLANILLA", bePlanillaBoleta.IdPlanilla));
                    cmd.Parameters.Add(new SqlParameter("@ANHO", bePlanillaBoleta.Anho));
                    cmd.Parameters.Add(new SqlParameter("@MES", bePlanillaBoleta.Mes));
                    cmd.Parameters.Add(new SqlParameter("@MESNOMBRE", bePlanillaBoleta.MesNombre));
                    cmd.Parameters.Add(new SqlParameter("@MESDIAS", bePlanillaBoleta.MesDias));
                    cmd.Parameters.Add(new SqlParameter("@EMPRESANOMBRE", bePlanillaBoleta.EmpresaNombre));
                    cmd.Parameters.Add(new SqlParameter("@EMPRESARUC", bePlanillaBoleta.EmpresaRuc));
                    cmd.Parameters.Add(new SqlParameter("@EMPRESADISTRITO", bePlanillaBoleta.EmpresaDistrito));
                    cmd.Parameters.Add(new SqlParameter("@EMPRESADIRECCION", bePlanillaBoleta.EmpresaDireccion));
                    cmd.Parameters.Add(new SqlParameter("@EMPLEADOCODIGO", bePlanillaBoleta.EmpleadoCodigo));
                    cmd.Parameters.Add(new SqlParameter("@EMPLEADONOMBRES", bePlanillaBoleta.EmpleadoNombres));
                    cmd.Parameters.Add(new SqlParameter("@EMPLEADOAPELLIDOS", bePlanillaBoleta.EmpleadoApellidos));
                    cmd.Parameters.Add(new SqlParameter("@EMPLEADOCARGO", bePlanillaBoleta.EmpleadoCargo));
                    cmd.Parameters.Add(new SqlParameter("@EMPLEADONRODOCUMENTO", bePlanillaBoleta.EmpleadoNroDocumento));
                    cmd.Parameters.Add(new SqlParameter("@EMPLEADOFECHAINGRESO", bePlanillaBoleta.EmpleadoFechaIngreso));

                    if (bePlanillaBoleta.EmpleadoFechaCese == null)
                        cmd.Parameters.Add(new SqlParameter("@EMPLEADOFECHACESE", DBNull.Value));
                    else
                        cmd.Parameters.Add(new SqlParameter("@EMPLEADOFECHACESE", bePlanillaBoleta.EmpleadoFechaCese));

                    if (bePlanillaBoleta.EmpleadoVacacionSalida == null)
                        cmd.Parameters.Add(new SqlParameter("@EMPLEADOVACACIONSALIDA", DBNull.Value));
                    else
                        cmd.Parameters.Add(new SqlParameter("@EMPLEADOVACACIONSALIDA", bePlanillaBoleta.EmpleadoVacacionSalida));

                    if (bePlanillaBoleta.EmpleadoVacacionRetorno == null)
                        cmd.Parameters.Add(new SqlParameter("@EMPLEADOVACACIONRETORNO", DBNull.Value));
                    else
                        cmd.Parameters.Add(new SqlParameter("@EMPLEADOVACACIONRETORNO", bePlanillaBoleta.EmpleadoVacacionRetorno));

                    cmd.Parameters.Add(new SqlParameter("@EMPLEADOESSALUDCODIGO", bePlanillaBoleta.EmpleadoEsSaludCodigo));
                    cmd.Parameters.Add(new SqlParameter("@EMPLEADOSPPCODIGO", bePlanillaBoleta.EmpleadoSppCodigo));
                    cmd.Parameters.Add(new SqlParameter("@EMPLEADOSPPENTIDAD", bePlanillaBoleta.EmpleadoSppEntidad));
                    cmd.Parameters.Add(new SqlParameter("@DIASLABORADOS", bePlanillaBoleta.DiasLaborados));
                    cmd.Parameters.Add(new SqlParameter("@DIASNOLABORADOS", bePlanillaBoleta.DiasNoLaborados));
                    cmd.Parameters.Add(new SqlParameter("@DIASSINGOCEHABER", bePlanillaBoleta.DiasSinGoceHaber));
                    cmd.Parameters.Add(new SqlParameter("@DIASSUBSIDIADO", bePlanillaBoleta.DiasSubsidiado));
                    cmd.Parameters.Add(new SqlParameter("@HORASNORMALES", bePlanillaBoleta.HorasNormales));
                    cmd.Parameters.Add(new SqlParameter("@SUELDO", bePlanillaBoleta.Sueldo));
                    cmd.Parameters.Add(new SqlParameter("@ASIGNACIONFAMILIAR", bePlanillaBoleta.AsignacionFamiliar));
                    cmd.Parameters.Add(new SqlParameter("@BONIFICACIONNOCTURNA", bePlanillaBoleta.BonificacionNocturna));
                    cmd.Parameters.Add(new SqlParameter("@MOVILIDADTRANSLADO", bePlanillaBoleta.MovilidadTranslado));
                    cmd.Parameters.Add(new SqlParameter("@SUBSIDIODESCANSOMEDICO", bePlanillaBoleta.SubsidioDescansoMedico));
                    cmd.Parameters.Add(new SqlParameter("@BONIFICACIONHORASEXTRAS", bePlanillaBoleta.BonificacionHorasExtras));
                    cmd.Parameters.Add(new SqlParameter("@CANTIDADHORASEXTRAS", bePlanillaBoleta.CantidadHorasExtras));
                    cmd.Parameters.Add(new SqlParameter("@CTS", bePlanillaBoleta.Cts));
                    cmd.Parameters.Add(new SqlParameter("@VACACIONES", bePlanillaBoleta.Vacaciones));
                    cmd.Parameters.Add(new SqlParameter("@FERIADODOMINICAL", bePlanillaBoleta.FeriadoDominical));
                    cmd.Parameters.Add(new SqlParameter("@GRATIFICACION", bePlanillaBoleta.Gratificacion));
                    cmd.Parameters.Add(new SqlParameter("@BONIFICACIONGRATIFICACION", bePlanillaBoleta.BonificacionGratificacion));
                    cmd.Parameters.Add(new SqlParameter("@TOTALBRUTO", bePlanillaBoleta.TotalBruto));
                    cmd.Parameters.Add(new SqlParameter("@AFPFONDOMONTO", bePlanillaBoleta.AfpFondoMonto));
                    cmd.Parameters.Add(new SqlParameter("@AFPSEGUROMONTO", bePlanillaBoleta.AfpSeguroMonto));
                    cmd.Parameters.Add(new SqlParameter("@AFPCOMISIONMONTO", bePlanillaBoleta.AfpComisionMonto));
                    cmd.Parameters.Add(new SqlParameter("@IPSSVIDAMONTO", bePlanillaBoleta.IpssVidaMonto));
                    cmd.Parameters.Add(new SqlParameter("@ONPMONTO", bePlanillaBoleta.OnpMonto));
                    cmd.Parameters.Add(new SqlParameter("@RENTAQUINTAMONTO", bePlanillaBoleta.RentaQuintaMonto));
                    cmd.Parameters.Add(new SqlParameter("@INASISTENCIASDIAS", bePlanillaBoleta.InasistenciasDias));
                    cmd.Parameters.Add(new SqlParameter("@INASISTENCIASMONTO", bePlanillaBoleta.InasistenciasMonto));
                    cmd.Parameters.Add(new SqlParameter("@ADELANTOMONTO", bePlanillaBoleta.AdelantoMonto));
                    cmd.Parameters.Add(new SqlParameter("@TARDANZAMINUTOS", bePlanillaBoleta.TardanzaMinutos));
                    cmd.Parameters.Add(new SqlParameter("@TARDANZAMONTO", bePlanillaBoleta.TardanzaMonto));
                    cmd.Parameters.Add(new SqlParameter("@GRATIFICACIONMONTO", bePlanillaBoleta.GratificacionMonto));
                    cmd.Parameters.Add(new SqlParameter("@RETENCIONJUDICIALMONTO", bePlanillaBoleta.RetencionJudicialMonto));
                    cmd.Parameters.Add(new SqlParameter("@SEGUROVIDATRABAJADORMONTO", bePlanillaBoleta.SeguroVidaTrabajadorMonto));
                    cmd.Parameters.Add(new SqlParameter("@IPSSSALUDTRABAJADORMONTO", bePlanillaBoleta.IpssSaludTrabajadorMonto));
                    cmd.Parameters.Add(new SqlParameter("@SEGUROVIDAEMPLEADOMONTO", bePlanillaBoleta.SeguroVidaEmpleadoMonto));
                    cmd.Parameters.Add(new SqlParameter("@IPSSSALUDEMPLEADOMONTO", bePlanillaBoleta.IpssSaludEmpleadoMonto));
                    cmd.Parameters.Add(new SqlParameter("@TOTALDESCUENTOS", bePlanillaBoleta.TotalDescuentos));
                    cmd.Parameters.Add(new SqlParameter("@TOTALAPORTES", bePlanillaBoleta.TotalAportes));
                    cmd.Parameters.Add(new SqlParameter("@TOTALNETO", bePlanillaBoleta.TotalNeto));

                    rowsAffected = cmd.ExecuteNonQuery();
                    bePlanillaBoleta.IdPlanillaBoleta = int.Parse(cmd.Parameters["@IDPLANILLABOLETA"].Value.ToString());

                    cnn.Close();
                }

                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Actualizar(BE.PlanillaBoleta bePlanillaBoleta)
        {
            int rowsAffected = 0;
            try
            {

                string sp = "SpTbPlanillaBoletaActualizar";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IDPLANILLABOLETA", bePlanillaBoleta.IdPlanillaBoleta));
                    cmd.Parameters.Add(new SqlParameter("@IDPLANILLA", bePlanillaBoleta.IdPlanilla));
                    cmd.Parameters.Add(new SqlParameter("@ANHO", bePlanillaBoleta.Anho));
                    cmd.Parameters.Add(new SqlParameter("@MES", bePlanillaBoleta.Mes));
                    cmd.Parameters.Add(new SqlParameter("@MESNOMBRE", bePlanillaBoleta.MesNombre));
                    cmd.Parameters.Add(new SqlParameter("@MESDIAS", bePlanillaBoleta.MesDias));
                    cmd.Parameters.Add(new SqlParameter("@EMPRESANOMBRE", bePlanillaBoleta.EmpresaNombre));
                    cmd.Parameters.Add(new SqlParameter("@EMPRESARUC", bePlanillaBoleta.EmpresaRuc));
                    cmd.Parameters.Add(new SqlParameter("@EMPRESADISTRITO", bePlanillaBoleta.EmpresaDistrito));
                    cmd.Parameters.Add(new SqlParameter("@EMPRESADIRECCION", bePlanillaBoleta.EmpresaDireccion));
                    cmd.Parameters.Add(new SqlParameter("@EMPLEADOCODIGO", bePlanillaBoleta.EmpleadoCodigo));
                    cmd.Parameters.Add(new SqlParameter("@EMPLEADONOMBRES", bePlanillaBoleta.EmpleadoNombres));
                    cmd.Parameters.Add(new SqlParameter("@EMPLEADOAPELLIDOS", bePlanillaBoleta.EmpleadoApellidos));
                    cmd.Parameters.Add(new SqlParameter("@EMPLEADOCARGO", bePlanillaBoleta.EmpleadoCargo));
                    cmd.Parameters.Add(new SqlParameter("@EMPLEADONRODOCUMENTO", bePlanillaBoleta.EmpleadoNroDocumento));
                    cmd.Parameters.Add(new SqlParameter("@EMPLEADOFECHAINGRESO", bePlanillaBoleta.EmpleadoFechaIngreso));

                    if (bePlanillaBoleta.EmpleadoFechaCese == null)
                        cmd.Parameters.Add(new SqlParameter("@EMPLEADOFECHACESE", DBNull.Value));
                    else
                        cmd.Parameters.Add(new SqlParameter("@EMPLEADOFECHACESE", bePlanillaBoleta.EmpleadoFechaCese));

                    if (bePlanillaBoleta.EmpleadoVacacionSalida == null)
                        cmd.Parameters.Add(new SqlParameter("@EMPLEADOVACACIONSALIDA", DBNull.Value));
                    else
                        cmd.Parameters.Add(new SqlParameter("@EMPLEADOVACACIONSALIDA", bePlanillaBoleta.EmpleadoVacacionSalida));

                    if (bePlanillaBoleta.EmpleadoVacacionRetorno == null)
                        cmd.Parameters.Add(new SqlParameter("@EMPLEADOVACACIONRETORNO", DBNull.Value));
                    else
                        cmd.Parameters.Add(new SqlParameter("@EMPLEADOVACACIONRETORNO", bePlanillaBoleta.EmpleadoVacacionRetorno));

                    cmd.Parameters.Add(new SqlParameter("@EMPLEADOESSALUDCODIGO", bePlanillaBoleta.EmpleadoEsSaludCodigo));
                    cmd.Parameters.Add(new SqlParameter("@EMPLEADOSPPCODIGO", bePlanillaBoleta.EmpleadoSppCodigo));
                    cmd.Parameters.Add(new SqlParameter("@EMPLEADOSPPENTIDAD", bePlanillaBoleta.EmpleadoSppEntidad));
                    cmd.Parameters.Add(new SqlParameter("@DIASLABORADOS", bePlanillaBoleta.DiasLaborados));
                    cmd.Parameters.Add(new SqlParameter("@DIASNOLABORADOS", bePlanillaBoleta.DiasNoLaborados));
                    cmd.Parameters.Add(new SqlParameter("@DIASSINGOCEHABER", bePlanillaBoleta.DiasSinGoceHaber));
                    cmd.Parameters.Add(new SqlParameter("@DIASSUBSIDIADO", bePlanillaBoleta.DiasSubsidiado));
                    cmd.Parameters.Add(new SqlParameter("@HORASNORMALES", bePlanillaBoleta.HorasNormales));
                    cmd.Parameters.Add(new SqlParameter("@SUELDO", bePlanillaBoleta.Sueldo));
                    cmd.Parameters.Add(new SqlParameter("@ASIGNACIONFAMILIAR", bePlanillaBoleta.AsignacionFamiliar));
                    cmd.Parameters.Add(new SqlParameter("@BONIFICACIONNOCTURNA", bePlanillaBoleta.BonificacionNocturna));
                    cmd.Parameters.Add(new SqlParameter("@MOVILIDADTRANSLADO", bePlanillaBoleta.MovilidadTranslado));
                    cmd.Parameters.Add(new SqlParameter("@SUBSIDIODESCANSOMEDICO", bePlanillaBoleta.SubsidioDescansoMedico));
                    cmd.Parameters.Add(new SqlParameter("@BONIFICACIONHORASEXTRAS", bePlanillaBoleta.BonificacionHorasExtras));
                    cmd.Parameters.Add(new SqlParameter("@CANTIDADHORASEXTRAS", bePlanillaBoleta.CantidadHorasExtras));
                    cmd.Parameters.Add(new SqlParameter("@CTS", bePlanillaBoleta.Cts));
                    cmd.Parameters.Add(new SqlParameter("@VACACIONES", bePlanillaBoleta.Vacaciones));
                    cmd.Parameters.Add(new SqlParameter("@FERIADODOMINICAL", bePlanillaBoleta.FeriadoDominical));
                    cmd.Parameters.Add(new SqlParameter("@GRATIFICACION", bePlanillaBoleta.Gratificacion));
                    cmd.Parameters.Add(new SqlParameter("@BONIFICACIONGRATIFICACION", bePlanillaBoleta.BonificacionGratificacion));
                    cmd.Parameters.Add(new SqlParameter("@TOTALBRUTO", bePlanillaBoleta.TotalBruto));
                    cmd.Parameters.Add(new SqlParameter("@AFPFONDOMONTO", bePlanillaBoleta.AfpFondoMonto));
                    cmd.Parameters.Add(new SqlParameter("@AFPSEGUROMONTO", bePlanillaBoleta.AfpSeguroMonto));
                    cmd.Parameters.Add(new SqlParameter("@AFPCOMISIONMONTO", bePlanillaBoleta.AfpComisionMonto));
                    cmd.Parameters.Add(new SqlParameter("@IPSSVIDAMONTO", bePlanillaBoleta.IpssVidaMonto));
                    cmd.Parameters.Add(new SqlParameter("@ONPMONTO", bePlanillaBoleta.OnpMonto));
                    cmd.Parameters.Add(new SqlParameter("@RENTAQUINTAMONTO", bePlanillaBoleta.RentaQuintaMonto));
                    cmd.Parameters.Add(new SqlParameter("@INASISTENCIASDIAS", bePlanillaBoleta.InasistenciasDias));
                    cmd.Parameters.Add(new SqlParameter("@INASISTENCIASMONTO", bePlanillaBoleta.InasistenciasMonto));
                    cmd.Parameters.Add(new SqlParameter("@ADELANTOMONTO", bePlanillaBoleta.AdelantoMonto));
                    cmd.Parameters.Add(new SqlParameter("@TARDANZAMINUTOS", bePlanillaBoleta.TardanzaMinutos));
                    cmd.Parameters.Add(new SqlParameter("@TARDANZAMONTO", bePlanillaBoleta.TardanzaMonto));
                    cmd.Parameters.Add(new SqlParameter("@GRATIFICACIONMONTO", bePlanillaBoleta.GratificacionMonto));
                    cmd.Parameters.Add(new SqlParameter("@RETENCIONJUDICIALMONTO", bePlanillaBoleta.RetencionJudicialMonto));
                    cmd.Parameters.Add(new SqlParameter("@SEGUROVIDATRABAJADORMONTO", bePlanillaBoleta.SeguroVidaTrabajadorMonto));
                    cmd.Parameters.Add(new SqlParameter("@IPSSSALUDTRABAJADORMONTO", bePlanillaBoleta.IpssSaludTrabajadorMonto));
                    cmd.Parameters.Add(new SqlParameter("@SEGUROVIDAEMPLEADOMONTO", bePlanillaBoleta.SeguroVidaEmpleadoMonto));
                    cmd.Parameters.Add(new SqlParameter("@IPSSSALUDEMPLEADOMONTO", bePlanillaBoleta.IpssSaludEmpleadoMonto));
                    cmd.Parameters.Add(new SqlParameter("@TOTALDESCUENTOS", bePlanillaBoleta.TotalDescuentos));
                    cmd.Parameters.Add(new SqlParameter("@TOTALAPORTES", bePlanillaBoleta.TotalAportes));
                    cmd.Parameters.Add(new SqlParameter("@TOTALNETO", bePlanillaBoleta.TotalNeto));

                    rowsAffected = cmd.ExecuteNonQuery();

                    cnn.Close();
                }

                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private BE.PlanillaBoleta Cargar(SqlDataReader reader)
        {
            try
            {
                var bePlanillaBoleta = new BE.PlanillaBoleta();

                bePlanillaBoleta.IdPlanillaBoleta = reader["IdPlanillaBoleta"] == DBNull.Value ? 0 : int.Parse(reader["IdPlanillaBoleta"].ToString());
                bePlanillaBoleta.IdPlanilla = reader["IdPlanilla"] == DBNull.Value ? 0 : int.Parse(reader["IdPlanilla"].ToString());
                bePlanillaBoleta.Anho = reader["Anho"] == DBNull.Value ? 0 : int.Parse(reader["Anho"].ToString());
                bePlanillaBoleta.Mes = reader["Mes"] == DBNull.Value ? 0 : int.Parse(reader["Mes"].ToString());
                bePlanillaBoleta.MesNombre = reader["MesNombre"] == DBNull.Value ? "" : reader["MesNombre"].ToString();
                bePlanillaBoleta.MesDias = reader["MesDias"] == DBNull.Value ? 0 : int.Parse(reader["MesDias"].ToString());
                bePlanillaBoleta.EmpresaNombre = reader["EmpresaNombre"] == DBNull.Value ? "" : reader["EmpresaNombre"].ToString();
                bePlanillaBoleta.EmpresaRuc = reader["EmpresaRuc"] == DBNull.Value ? "" : reader["EmpresaRuc"].ToString();
                bePlanillaBoleta.EmpresaDistrito = reader["EmpresaDistrito"] == DBNull.Value ? "" : reader["EmpresaDistrito"].ToString();
                bePlanillaBoleta.EmpresaDireccion = reader["EmpresaDireccion"] == DBNull.Value ? "" : reader["EmpresaDireccion"].ToString();
                bePlanillaBoleta.EmpleadoCodigo = reader["EmpleadoCodigo"] == DBNull.Value ? "" : reader["EmpleadoCodigo"].ToString();
                bePlanillaBoleta.EmpleadoNombres = reader["EmpleadoNombres"] == DBNull.Value ? "" : reader["EmpleadoNombres"].ToString();
                bePlanillaBoleta.EmpleadoApellidos = reader["EmpleadoApellidos"] == DBNull.Value ? "" : reader["EmpleadoApellidos"].ToString();
                bePlanillaBoleta.EmpleadoCargo = reader["EmpleadoCargo"] == DBNull.Value ? "" : reader["EmpleadoCargo"].ToString();
                bePlanillaBoleta.EmpleadoNroDocumento = reader["EmpleadoNroDocumento"] == DBNull.Value ? "" : reader["EmpleadoNroDocumento"].ToString();
                bePlanillaBoleta.EmpleadoFechaIngreso = reader["EmpleadoFechaIngreso"] == DBNull.Value ? DateTime.Now : DateTime.Parse(reader["EmpleadoFechaIngreso"].ToString());
                bePlanillaBoleta.EmpleadoFechaCese = reader["EmpleadoFechaCese"] == DBNull.Value ? null : (DateTime?)DateTime.Parse(reader["EmpleadoFechaCese"].ToString());
                bePlanillaBoleta.EmpleadoVacacionSalida = reader["EmpleadoVacacionSalida"] == DBNull.Value ? null : (DateTime?)DateTime.Parse(reader["EmpleadoVacacionSalida"].ToString());
                bePlanillaBoleta.EmpleadoVacacionRetorno = reader["EmpleadoVacacionRetorno"] == DBNull.Value ? null : (DateTime?)DateTime.Parse(reader["EmpleadoVacacionRetorno"].ToString());
                bePlanillaBoleta.EmpleadoEsSaludCodigo = reader["EmpleadoEsSaludCodigo"] == DBNull.Value ? "" : reader["EmpleadoEsSaludCodigo"].ToString();
                bePlanillaBoleta.EmpleadoSppCodigo = reader["EmpleadoSppCodigo"] == DBNull.Value ? "" : reader["EmpleadoSppCodigo"].ToString();
                bePlanillaBoleta.EmpleadoSppEntidad = reader["EmpleadoSppEntidad"] == DBNull.Value ? "" : reader["EmpleadoSppEntidad"].ToString();
                bePlanillaBoleta.DiasLaborados = reader["DiasLaborados"] == DBNull.Value ? 0 : int.Parse(reader["DiasLaborados"].ToString());
                bePlanillaBoleta.DiasNoLaborados = reader["DiasNoLaborados"] == DBNull.Value ? 0 : int.Parse(reader["DiasNoLaborados"].ToString());
                bePlanillaBoleta.DiasSinGoceHaber = reader["DiasSinGoceHaber"] == DBNull.Value ? 0 : int.Parse(reader["DiasSinGoceHaber"].ToString());
                bePlanillaBoleta.DiasSubsidiado = reader["DiasSubsidiado"] == DBNull.Value ? 0 : int.Parse(reader["DiasSubsidiado"].ToString());
                bePlanillaBoleta.HorasNormales = reader["HorasNormales"] == DBNull.Value ? 0 : int.Parse(reader["HorasNormales"].ToString());
                bePlanillaBoleta.Sueldo = reader["Sueldo"] == DBNull.Value ? 0.0 : double.Parse(reader["Sueldo"].ToString());
                bePlanillaBoleta.AsignacionFamiliar = reader["AsignacionFamiliar"] == DBNull.Value ? 0.0 : double.Parse(reader["AsignacionFamiliar"].ToString());
                bePlanillaBoleta.BonificacionNocturna = reader["BonificacionNocturna"] == DBNull.Value ? 0.0 : double.Parse(reader["BonificacionNocturna"].ToString());
                bePlanillaBoleta.MovilidadTranslado = reader["MovilidadTranslado"] == DBNull.Value ? 0.0 : double.Parse(reader["MovilidadTranslado"].ToString());
                bePlanillaBoleta.SubsidioDescansoMedico = reader["SubsidioDescansoMedico"] == DBNull.Value ? 0.0 : double.Parse(reader["SubsidioDescansoMedico"].ToString());
                bePlanillaBoleta.BonificacionHorasExtras = reader["BonificacionHorasExtras"] == DBNull.Value ? 0.0 : double.Parse(reader["BonificacionHorasExtras"].ToString());
                bePlanillaBoleta.CantidadHorasExtras = reader["CantidadHorasExtras"] == DBNull.Value ? 0 : int.Parse(reader["CantidadHorasExtras"].ToString());
                bePlanillaBoleta.Cts = reader["Cts"] == DBNull.Value ? 0.0 : double.Parse(reader["Cts"].ToString());
                bePlanillaBoleta.Vacaciones = reader["Vacaciones"] == DBNull.Value ? 0.0 : double.Parse(reader["Vacaciones"].ToString());
                bePlanillaBoleta.FeriadoDominical = reader["FeriadoDominical"] == DBNull.Value ? 0.0 : double.Parse(reader["FeriadoDominical"].ToString());
                bePlanillaBoleta.Gratificacion = reader["Gratificacion"] == DBNull.Value ? 0.0 : double.Parse(reader["Gratificacion"].ToString());
                bePlanillaBoleta.BonificacionGratificacion = reader["BonificacionGratificacion"] == DBNull.Value ? 0.0 : double.Parse(reader["BonificacionGratificacion"].ToString());
                bePlanillaBoleta.TotalBruto = reader["TotalBruto"] == DBNull.Value ? 0.0 : double.Parse(reader["TotalBruto"].ToString());
                bePlanillaBoleta.AfpFondoMonto = reader["AfpFondoMonto"] == DBNull.Value ? 0.0 : double.Parse(reader["AfpFondoMonto"].ToString());
                bePlanillaBoleta.AfpSeguroMonto = reader["AfpSeguroMonto"] == DBNull.Value ? 0.0 : double.Parse(reader["AfpSeguroMonto"].ToString());
                bePlanillaBoleta.AfpComisionMonto = reader["AfpComisionMonto"] == DBNull.Value ? 0.0 : double.Parse(reader["AfpComisionMonto"].ToString());
                bePlanillaBoleta.IpssVidaMonto = reader["IpssVidaMonto"] == DBNull.Value ? 0.0 : double.Parse(reader["IpssVidaMonto"].ToString());
                bePlanillaBoleta.OnpMonto = reader["OnpMonto"] == DBNull.Value ? 0.0 : double.Parse(reader["OnpMonto"].ToString());
                bePlanillaBoleta.RentaQuintaMonto = reader["RentaQuintaMonto"] == DBNull.Value ? 0.0 : double.Parse(reader["RentaQuintaMonto"].ToString());
                bePlanillaBoleta.InasistenciasDias = reader["InasistenciasDias"] == DBNull.Value ? 0 : int.Parse(reader["InasistenciasDias"].ToString());
                bePlanillaBoleta.InasistenciasMonto = reader["InasistenciasMonto"] == DBNull.Value ? 0.0 : double.Parse(reader["InasistenciasMonto"].ToString());
                bePlanillaBoleta.AdelantoMonto = reader["AdelantoMonto"] == DBNull.Value ? 0.0 : double.Parse(reader["AdelantoMonto"].ToString());
                bePlanillaBoleta.TardanzaMinutos = reader["TardanzaMinutos"] == DBNull.Value ? 0 : int.Parse(reader["TardanzaMinutos"].ToString());
                bePlanillaBoleta.TardanzaMonto = reader["TardanzaMonto"] == DBNull.Value ? 0.0 : double.Parse(reader["TardanzaMonto"].ToString());
                bePlanillaBoleta.GratificacionMonto = reader["GratificacionMonto"] == DBNull.Value ? 0.0 : double.Parse(reader["GratificacionMonto"].ToString());
                bePlanillaBoleta.RetencionJudicialMonto = reader["RetencionJudicialMonto"] == DBNull.Value ? 0.0 : double.Parse(reader["RetencionJudicialMonto"].ToString());
                bePlanillaBoleta.SeguroVidaTrabajadorMonto = reader["SeguroVidaTrabajadorMonto"] == DBNull.Value ? 0.0 : double.Parse(reader["SeguroVidaTrabajadorMonto"].ToString());
                bePlanillaBoleta.IpssSaludTrabajadorMonto = reader["IpssSaludTrabajadorMonto"] == DBNull.Value ? 0.0 : double.Parse(reader["IpssSaludTrabajadorMonto"].ToString());
                bePlanillaBoleta.SeguroVidaEmpleadoMonto = reader["SeguroVidaEmpleadoMonto"] == DBNull.Value ? 0.0 : double.Parse(reader["SeguroVidaEmpleadoMonto"].ToString());
                bePlanillaBoleta.IpssSaludEmpleadoMonto = reader["IpssSaludEmpleadoMonto"] == DBNull.Value ? 0.0 : double.Parse(reader["IpssSaludEmpleadoMonto"].ToString());
                bePlanillaBoleta.TotalDescuentos = reader["TotalDescuentos"] == DBNull.Value ? 0.0 : double.Parse(reader["TotalDescuentos"].ToString());
                bePlanillaBoleta.TotalAportes = reader["TotalAportes"] == DBNull.Value ? 0.0 : double.Parse(reader["TotalAportes"].ToString());
                bePlanillaBoleta.TotalNeto = reader["TotalNeto"] == DBNull.Value ? 0.0 : double.Parse(reader["TotalNeto"].ToString());

                return bePlanillaBoleta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.PlanillaBoleta Obtener(int idPlanillaBoleta)
        {
            BE.PlanillaBoleta bePlanillaBoleta = null;
            try
            {
                string sp = "SpTbPlanillaBoletaObtener";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IDPLANILLABOLETA", idPlanillaBoleta));

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        bePlanillaBoleta = Cargar(reader);
                    }

                    cnn.Close();
                }

                return bePlanillaBoleta;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtener los datos de la boleta del empleado por el periodo de año y mes
        /// </summary>
        /// <param name="anho">Año de consulta</param>
        /// <param name="mes">Mes de consulta</param>
        /// <param name="codigoEmpleado">Codigo de Empleado de consulta</param>
        /// <returns></returns>
        public BE.PlanillaBoleta Obtener(int anho, int mes, string codigoEmpleado)
        {
            BE.PlanillaBoleta bePlanillaBoleta = null;
            try
            {
                string sp = "SpTbPlanillaBoletaObtener2";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ANHO", anho));
                    cmd.Parameters.Add(new SqlParameter("@MES", mes));
                    cmd.Parameters.Add(new SqlParameter("@CODIGOEMPLEADO", codigoEmpleado));

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        bePlanillaBoleta = Cargar(reader);
                    }

                    cnn.Close();
                }

                return bePlanillaBoleta;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }

}
