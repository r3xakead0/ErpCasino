using System;
using System.Windows.Forms;
using BE = ErpCasino.BusinessLibrary.BE;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmAsignarSueldoView : Form
    {

        #region "Patron Singleton"

        private static FrmAsignarSueldoView frmInstance = null;

        public static FrmAsignarSueldoView Instance()
        {

            if (frmInstance == null || frmInstance.IsDisposed == true)
            {
                frmInstance = new FrmAsignarSueldoView();
            }

            frmInstance.BringToFront();

            return frmInstance;
        }

        #endregion

        public FrmAsignarSueldoView()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }

        }

        public void Cargar(BE.UI.SueldoCandidato uiSueldoCandidato)
        {
            try
            {

                if (uiSueldoCandidato != null)
                {

                    this.txtFecha.Text = uiSueldoCandidato.Fecha.ToString("dd/MM/yyyy");
                    this.txtTotal.Text = uiSueldoCandidato.TotalNeto.ToString("N2");

                    this.txtCandidatoCodigo.Text = uiSueldoCandidato.CandidatoCodigo;
                    this.txtCandidatoNombreCompleto.Text = uiSueldoCandidato.CandidatoNombreCompleto;
                    
                    this.txtSueldoBase.Text = uiSueldoCandidato.Sueldo.ToString("N2");
                    this.txtSueldoAsigFam.Text = uiSueldoCandidato.AsignacionFamiliar.ToString("N2");

                    this.txtBonoNocturnoTotal.Text = uiSueldoCandidato.BonoNocturnoTotal.ToString("N2");
                    this.txtBonoNocturnoCantidad.Text = uiSueldoCandidato.BonoNocturnoFormato;
                    this.txtBonoHorasExtrasTotal.Text = uiSueldoCandidato.BonoHorasExtrasTotal.ToString("N2");
                    this.txtBonoHorasExtrasCantidad.Text = uiSueldoCandidato.BonoHorasExtrasFormato;
                    this.txtBonoFeriadoTotal.Text = uiSueldoCandidato.BonoFeriadoTotal.ToString("N2");
                    this.txtBonoFeriadoCantidad.Text = uiSueldoCandidato.BonoFeriadoFormato;

                    this.txtDescuentoTardanzaTotal.Text = uiSueldoCandidato.DescuentoTardanzaTotal.ToString("N2");
                    this.txtDescuentoTardanzaCantidad.Text = uiSueldoCandidato.DescuentoTardanzaFormato;
                    this.txtDescuentoInasistenciaTotal.Text = uiSueldoCandidato.DescuentoInasistenciaTotal.ToString("N2");
                    this.txtDescuentoInasistenciaCantidad.Text = uiSueldoCandidato.DescuentoInasistenciaFormato;

                    this.txtTotalSueldo.Text = uiSueldoCandidato.TotalBase.ToString("N2");
                    this.txtTotalBonos.Text = uiSueldoCandidato.TotalBonos.ToString("N2");
                    this.txtTotalDescuentos.Text = uiSueldoCandidato.TotalDescuentos.ToString("N2");

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void Limpiar()
        {
            try
            {
                this.txtFecha.Clear();
                this.txtCandidatoCodigo.Clear();
                this.txtCandidatoNombreCompleto.Clear();
                this.txtTotal.Text = "0.00";

                this.txtBonoNocturnoTotal.Text = "0.00";
                this.txtBonoNocturnoCantidad.Text = "00:00";
                this.txtBonoHorasExtrasTotal.Text = "0.00";
                this.txtBonoHorasExtrasCantidad.Text = "00:00";
                this.txtBonoFeriadoTotal.Text = "0.00";
                this.txtBonoFeriadoCantidad.Text = "00:00";

                this.txtDescuentoTardanzaTotal.Text = "0.00";
                this.txtDescuentoTardanzaCantidad.Text = "00:00";
                this.txtDescuentoInasistenciaTotal.Text = "0.00";
                this.txtDescuentoInasistenciaCantidad.Text = "00:00";

                this.txtTotalSueldo.Text = "0.00";
                this.txtTotalBonos.Text = "0.00";
                this.txtTotalBonos.Text = "0.00";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Formulario

        private void FrmAsignarSueldoView_Load(object sender, EventArgs e)
        {
            try
            {
                this.Limpiar();
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

                var rpta = Util.ConfirmationMessage($"¿Desea salir del formulario { this.Text }?");

                if (rpta == false)
                    return;

                this.Close();

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        #endregion
        
    }
}
