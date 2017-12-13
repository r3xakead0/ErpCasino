using System;
using System.Windows.Forms;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;

namespace ErpCasino.WindowsForms
{
    public partial class FrmInformacion : Form
    {

        #region "Patron Singleton"

        private static FrmInformacion frmInstance = null;

        public static FrmInformacion Instance()
        {

            if (frmInstance == null || frmInstance.IsDisposed == true)
            {
                frmInstance = new FrmInformacion();
            }

            frmInstance.BringToFront();

            return frmInstance;
        }

        #endregion

        #region Formulario

        public FrmInformacion()
        {
            InitializeComponent();
        }

        private void FrmInformacion_Load(object sender, EventArgs e)
        {
            try
            {
                this.txtSistema.Text = Util.GetTitle();
                this.txtVersion.Text = Util.GetVersion();
                this.lnkConctacto.Text = "Chainiz Software";
                
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void lnkConctacto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                this.lnkConctacto.LinkVisited = true;
                System.Diagnostics.Process.Start("https://www.facebook.com/chainizperu/");
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        #endregion
    }
}
