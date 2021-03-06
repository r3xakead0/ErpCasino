﻿using System;
using System.Windows.Forms;
using BE = ErpCasino.BusinessLibrary.BE;
using ErpCasino.WindowsForms.RecursosHumanos;
using ErpCasino.WindowsForms.Seguridad;
using ErpCasino.WindowsForms.Configuracion;

namespace ErpCasino.WindowsForms
{
    public partial class MdiMain : Form
    {

        public BE.UI.Usuario uiUsuario = null;

        public MdiMain()
        {
            InitializeComponent();
        }

        private void MdiMain_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;

                this.mnuPrincipal.Visible = false;
                this.stsPrincipal.Visible = false;

                var frmLogin = new FrmLogin();
                frmLogin.MdiParent = this;
                frmLogin.StartPosition = FormStartPosition.CenterScreen;
                frmLogin.Show();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
            
        }

        public void Acceso(BE.UI.Usuario uiUsuario)
        {
            try
            {
                this.uiUsuario = uiUsuario;

                this.mnuPrincipal.Visible = true;
                this.stsPrincipal.Visible = true;

                this.stlUsuario.Text = uiUsuario.Nombres;
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void tsmUsuarios_Click(object sender, EventArgs e)
        {
            try
            {
                var frmUsuario = new FrmUsuarioList();
                frmUsuario.MdiParent = this;
                frmUsuario.StartPosition = FormStartPosition.CenterScreen;
                frmUsuario.Show();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }


        #region Planilla

        private void tsmPlanillasMovilidad_Click(object sender, EventArgs e)
        {
            try
            {
                var frmPlanillaMovilidad = FrmPlanillaMovilidadList.Instance();
                frmPlanillaMovilidad.MdiParent = this;
                frmPlanillaMovilidad.StartPosition = FormStartPosition.CenterScreen;
                frmPlanillaMovilidad.Show();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void tsmPlanillasCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                var frmPlanillaCalcular = FrmPlanillaCalcular.Instance();
                frmPlanillaCalcular.MdiParent = this;
                frmPlanillaCalcular.StartPosition = FormStartPosition.CenterScreen;
                frmPlanillaCalcular.Show();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void tsmPlanillasRevisar_Click(object sender, EventArgs e)
        {
            try
            {
                var frmPlanillaRevisar = new FrmPlanillaRevisar();
                frmPlanillaRevisar.MdiParent = this;
                frmPlanillaRevisar.StartPosition = FormStartPosition.CenterScreen;
                frmPlanillaRevisar.Show();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        #endregion

        private void tsmInsistencias_Click(object sender, EventArgs e)
        {
            try
            {
                var frmInasistencia = new FrmInasistenciaList();
                frmInasistencia.MdiParent = this;
                frmInasistencia.StartPosition = FormStartPosition.CenterScreen;
                frmInasistencia.Show();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void tsmPensionesPrivadas_Click(object sender, EventArgs e)
        {
            try
            {
                var frmAfp = new FrmAfpComisionMant();
                frmAfp.MdiParent = this;
                frmAfp.StartPosition = FormStartPosition.CenterScreen;
                frmAfp.Show();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void tsmPostulantesPensiones_Click(object sender, EventArgs e)
        {
            try
            {
                var frmPostulante = FrmPostulanteList.Instance();
                frmPostulante.MdiParent = this;
                frmPostulante.StartPosition = FormStartPosition.CenterScreen;
                frmPostulante.Show();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void tsmPostulantesCandidatos_Click(object sender, EventArgs e)
        {
            try
            {
                var frmCandidato = FrmCandidatoList.Instance();
                frmCandidato.MdiParent = this;
                frmCandidato.StartPosition = FormStartPosition.CenterScreen;
                frmCandidato.Show();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void tsmPostulantesEmpleados_Click(object sender, EventArgs e)
        {
            try
            {
                var frmEmpleado = FrmEmpleadoList.Instance();
                frmEmpleado.MdiParent = this;
                frmEmpleado.StartPosition = FormStartPosition.CenterScreen;
                frmEmpleado.Show();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void tsmTiposBonos_Click(object sender, EventArgs e)
        {
            try
            {
                var frmTipoBono = new FrmTipoBonoMant();
                frmTipoBono.MdiParent = this;
                frmTipoBono.StartPosition = FormStartPosition.CenterScreen;
                frmTipoBono.Show();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void tsmTiposDescuentos_Click(object sender, EventArgs e)
        {
            try
            {
                var frmTipoDescuento = FrmTipoDescuentoMant.Instance();
                frmTipoDescuento.MdiParent = this;
                frmTipoDescuento.StartPosition = FormStartPosition.CenterScreen;
                frmTipoDescuento.Show();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void tsmAdelantos_Click(object sender, EventArgs e)
        {
            try
            {
                var frmAdelanto = FrmAdelantoList.Instance();
                frmAdelanto.MdiParent = this;
                frmAdelanto.StartPosition = FormStartPosition.CenterScreen;
                frmAdelanto.Show();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void tsmPensionesPublicas_Click(object sender, EventArgs e)
        {
            try
            {
                var frmOnp = new FrmOnpComisionMant();
                frmOnp.MdiParent = this;
                frmOnp.StartPosition = FormStartPosition.CenterScreen;
                frmOnp.Show();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void tsmPrestamos_Click(object sender, EventArgs e)
        {
            try
            {
                var frmPrestamo = new FrmPrestamoList();
                frmPrestamo.MdiParent = this;
                frmPrestamo.StartPosition = FormStartPosition.CenterScreen;
                frmPrestamo.Show();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void tsmLiquidaciones_Click(object sender, EventArgs e)
        {
            try
            {
                var frmLiquidacion = new FrmLiquidacionList();
                frmLiquidacion.MdiParent = this;
                frmLiquidacion.StartPosition = FormStartPosition.CenterScreen;
                frmLiquidacion.Show();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void tsmCts_Click(object sender, EventArgs e)
        {
            try
            {
                var frmCts = FrmCtsList.Instance();
                frmCts.MdiParent = this;
                frmCts.StartPosition = FormStartPosition.CenterScreen;
                frmCts.Show();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void tsmGratificaciones_Click(object sender, EventArgs e)
        {
            try
            {
                var frmGratificacion = new FrmGratificacionList();
                frmGratificacion.MdiParent = this;
                frmGratificacion.StartPosition = FormStartPosition.CenterScreen;
                frmGratificacion.Show();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void tsmVacaciones_Click(object sender, EventArgs e)
        {
            try
            {
                var frmVacacion = FrmVacacionList.Instance();
                frmVacacion.MdiParent = this;
                frmVacacion.StartPosition = FormStartPosition.CenterScreen;
                frmVacacion.Show();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void tsmSueldoMinimo_Click(object sender, EventArgs e)
        {
            try
            {
                var frmSueldoMinimo = FrmSueldoMinimoMant.Instance();
                frmSueldoMinimo.MdiParent = this;
                frmSueldoMinimo.StartPosition = FormStartPosition.CenterScreen;
                frmSueldoMinimo.Show();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void tsmFeriados_Click(object sender, EventArgs e)
        {
            try
            {
                var frmFeriado = FrmFeriadoMant.Instance();
                frmFeriado.MdiParent = this;
                frmFeriado.StartPosition = FormStartPosition.CenterScreen;
                frmFeriado.Show();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }
        private void tsmCambiarClave_Click(object sender, EventArgs e)
        {
            try
            {
                var frmCambioClave = new FrmCambioClave();
                frmCambioClave.MdiParent = this;
                frmCambioClave.StartPosition = FormStartPosition.CenterScreen;
                frmCambioClave.Show();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void tsmPerfiles_Click(object sender, EventArgs e)
        {
            try
            {
                var frmPerfilMant = new FrmPerfilMant();
                frmPerfilMant.MdiParent = this;
                frmPerfilMant.StartPosition = FormStartPosition.CenterScreen;
                frmPerfilMant.Show();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void tsmPermisos_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void tsmCargos_Click(object sender, EventArgs e)
        {
            try
            {
                var frmCargo = new FrmCargoMant();
                frmCargo.MdiParent = this;
                frmCargo.StartPosition = FormStartPosition.CenterScreen;
                frmCargo.Show();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void tsmAsistencias_Click(object sender, EventArgs e)
        {
            try
            {
                var frmAsistencia = FrmAsistenciaList.Instance();
                frmAsistencia.MdiParent = this;
                frmAsistencia.StartPosition = FormStartPosition.CenterScreen;
                frmAsistencia.Show();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void tsmHorariosSemanales_Click(object sender, EventArgs e)
        {
            try
            {
                var frmHorario = new FrmHorarioSemanalList();
                frmHorario.MdiParent = this;
                frmHorario.StartPosition = FormStartPosition.CenterScreen;
                frmHorario.Show();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void tsmHorariosMensuales_Click(object sender, EventArgs e)
        {
            try
            {
                var frmHorario = FrmHorarioMensualList.Instance();
                frmHorario.MdiParent = this;
                frmHorario.StartPosition = FormStartPosition.CenterScreen;
                frmHorario.Show();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void tsmTiposObservaciones_Click(object sender, EventArgs e)
        {
            try
            {
                var frmTipoObs = new FrmTipoObservacionMant();
                frmTipoObs.MdiParent = this;
                frmTipoObs.StartPosition = FormStartPosition.CenterScreen;
                frmTipoObs.Show();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void tsmAsignarObservaciones_Click(object sender, EventArgs e)
        {
            try
            {
                var frmObs = FrmAsignarObservacionList.Instance();
                frmObs.MdiParent = this;
                frmObs.StartPosition = FormStartPosition.CenterScreen;
                frmObs.Show();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void tsmAsignarDescuentos_Click(object sender, EventArgs e)
        {
            try
            {
                var frmDescuento = FrmAsignarDescuentoList.Instance();
                frmDescuento.MdiParent = this;
                frmDescuento.StartPosition = FormStartPosition.CenterScreen;
                frmDescuento.Show();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void tsmAsignarSueldos_Click(object sender, EventArgs e)
        {
            try
            {
                var frmSueldo = FrmAsignarSueldoList.Instance();
                frmSueldo.MdiParent = this;
                frmSueldo.StartPosition = FormStartPosition.CenterScreen;
                frmSueldo.Show();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void tsmAsignarBonos_Click(object sender, EventArgs e)
        {
            try
            {
                var frmBono = FrmAsignarBonoList.Instance();
                frmBono.MdiParent = this;
                frmBono.StartPosition = FormStartPosition.CenterScreen;
                frmBono.Show();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void tsmSalasMantenimiento_Click(object sender, EventArgs e)
        {
            try
            {
                var frmSala = new FrmSalaList();
                frmSala.MdiParent = this;
                frmSala.StartPosition = FormStartPosition.CenterScreen;
                frmSala.Show();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void tsmSalasMeta_Click(object sender, EventArgs e)
        {
            try
            {
                var frmSalaMeta = new FrmSalaMetaMant();
                frmSalaMeta.MdiParent = this;
                frmSalaMeta.StartPosition = FormStartPosition.CenterScreen;
                frmSalaMeta.Show();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void tsmColaboradoresCompromisos_Click(object sender, EventArgs e)
        {
            try
            {
                var frmColaboradorComprometido = new FrmColaboradorComprometidoMant();
                frmColaboradorComprometido.MdiParent = this;
                frmColaboradorComprometido.StartPosition = FormStartPosition.CenterScreen;
                frmColaboradorComprometido.Show();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void tsmRecibosCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                var frmReciboCalcular = new FrmReciboRevisar();
                frmReciboCalcular.MdiParent = this;
                frmReciboCalcular.StartPosition = FormStartPosition.CenterScreen;
                frmReciboCalcular.Show();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void tsmConfiguracionEmpresa_Click(object sender, EventArgs e)
        {
            try
            {
                var frmEmpresa = new FrmEmpresaMant();
                frmEmpresa.MdiParent = this;
                frmEmpresa.StartPosition = FormStartPosition.CenterScreen;
                frmEmpresa.Show();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void tsmReporteCumpleanhos_Click(object sender, EventArgs e)
        {
            try
            {
                var frmReporte = FrmReporteCumpleanhos.Instance();
                frmReporte.MdiParent = this;
                frmReporte.StartPosition = FormStartPosition.CenterScreen;
                frmReporte.Show();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void tsmReporteAsistencias_Click(object sender, EventArgs e)
        {
            try
            {
                var frmReporte = FrmReporteAsistencias.Instance();
                frmReporte.MdiParent = this;
                frmReporte.StartPosition = FormStartPosition.CenterScreen;
                frmReporte.Show();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void tsmInformacion_Click(object sender, EventArgs e)
        {
            try
            {
                var frmInformacion = FrmInformacion.Instance();
                frmInformacion.MdiParent = this;
                frmInformacion.StartPosition = FormStartPosition.CenterScreen;
                frmInformacion.Show();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }
    }
}
