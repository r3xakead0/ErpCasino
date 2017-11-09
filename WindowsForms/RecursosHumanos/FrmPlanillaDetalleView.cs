using System;
using System.Windows.Forms;
using System.Collections.Generic;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmPlanillaDetalleView : Form
    {

        private int idPlanilla = 0;

        public FrmPlanillaDetalleView(int idPlanilla)
        {
            try
            {
                InitializeComponent();

                this.idPlanilla = idPlanilla;
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }

        }

        private void DetalleAsistencia(string horarioPor)
        {
            try
            {
                string periodo = this.txtPeriodo.Text;
                string[] anhoMes = periodo.Split('/');

                int anho = int.Parse(anhoMes[0].ToString());
                int mes = int.Parse(anhoMes[1].ToString());

                string empleadoCodigo = this.txtEmpleadoCodigo.Text;
                string empleadoNombres = this.txtEmpleadoNombres.Text;

                string calculoPor = this.cboCalculoPor.SelectedValue.ToString();

                var frmAsistencias = new FrmPlanillaDetalleAsistencia(this.idPlanilla, anho, mes, empleadoCodigo, empleadoNombres, horarioPor, calculoPor);
                frmAsistencias.MdiParent = this.MdiParent;
                frmAsistencias.Show();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarCalcular()
        {
            try
            {

                var lstCalculoPor = new List<BE.Record>();

                lstCalculoPor.Add(new BE.Record() { Codigo = "D", Nombre = "Dia" });
                lstCalculoPor.Add(new BE.Record() { Codigo = "H", Nombre = "Hora" });
                lstCalculoPor.Add(new BE.Record() { Codigo = "M", Nombre = "Minuto" });

                this.cboCalculoPor.DataSource = lstCalculoPor;
                this.cboCalculoPor.DisplayMember = "Nombre";
                this.cboCalculoPor.ValueMember = "Codigo";

                this.cboCalculoPor.SelectedValue = "M";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Cargar(BE.UI.PlanillaDetalle beDetalle)
        {
            try
            {

                if (beDetalle != null)
                {
                    
                    this.txtEmpleadoCodigo.Text = beDetalle.EmpleadoCodigo;
                    this.txtEmpleadoNombres.Text = beDetalle.EmpleadoNombre;
                    this.txtPeriodo.Text = beDetalle.Periodo;

                    //TimeSpan span = TimeSpan.FromMinutes(minutos);
                    //span.Tostring("dd:HH:mm");
                    this.txtBonoNocturnoCantidad.Text = beDetalle.BonoNocturnoCantidad.ToString("N2");
                    this.txtBonoNocturno.Text = beDetalle.BonoNocturnoTotal.ToString("N2");
                    this.txtBonoExtrasCantidad.Text = beDetalle.BonoHorasExtrasCantidad.ToString("N2");
                    this.txtBonoExtra.Text = beDetalle.BonoHorasExtrasTotal.ToString("N2");
                    this.txtBonoFeriadosCantidad.Text = beDetalle.BonoFeriadoCantidad.ToString("N2");
                    this.txtBonoFeriado.Text = beDetalle.BonoFeriadoTotal.ToString("N2");

                    this.txtDescuentoInasistenciasCantidad.Text = beDetalle.DescuentoInasistenciaCantidad.ToString("N2");
                    this.txtDescuentoInasistencias.Text = beDetalle.DescuentoInasistenciaTotal.ToString("N2");
                    this.txtDescuentoTardanzasCantidad.Text = beDetalle.DescuentoTardanzaCantidad.ToString("N2");
                    this.txtDescuentoTardanzas.Text = beDetalle.DescuentoTardanzaTotal.ToString("N2");

                    this.txtSueldoBase.Text = beDetalle.Base.ToString("N2");
                    this.txtSueldoAsigFam.Text = beDetalle.AsignacionFamiliar.ToString("N2");

                    this.txtDeduccionRJ.Text = beDetalle.RetencionJudicialTotal.ToString("N2");
                    this.txtDeduccionAdelantos.Text = beDetalle.AdelantoTotal.ToString("N2");
                    this.txtDeduccionPrestamos.Text = beDetalle.PrestamoTotal.ToString("N2");

                    this.txtPensionPrivada.Text = beDetalle.AfpTotal.ToString("N2");
                    this.txtPensionPublica.Text = beDetalle.SnpTotal.ToString("N2");
                    this.txtEssalud.Text = beDetalle.EsSaludTotal.ToString("N2");

                    this.txtSueldoNeto.Text = beDetalle.TotalNeto.ToString("N2");
                    this.txtSueldoPago.Text = beDetalle.TotalPagar.ToString("N2");

                    this.cboCalculoPor.SelectedValue = beDetalle.CalcularPor;

                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }

        }

        private void FrmPlanillaDetalleView_Load(object sender, EventArgs e)
        {
            try
            {
                this.CargarCalcular();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void txtBonoNocturnoCantidad_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.DetalleAsistencia("1");
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void txtBonoExtrasCantidad_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.DetalleAsistencia("2");
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void txtBonoFeriadosCantidad_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.DetalleAsistencia("3");
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void txtDescuentoTardanzasCantidad_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.DetalleAsistencia("3");
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void txtDescuentoInasistenciasCantidad_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.DetalleAsistencia("3");
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }
    }
}
