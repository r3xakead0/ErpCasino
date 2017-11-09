using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;
using System.Linq;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmIndicadores : Form
    {

        #region "Patron Singleton"

        private static FrmIndicadores frmInstance = null;

        public static FrmIndicadores Instance()
        {

            if (frmInstance == null || frmInstance.IsDisposed == true)
            {
                frmInstance = new FrmIndicadores();
            }

            frmInstance.BringToFront();

            return frmInstance;
        }

        #endregion

        public FrmIndicadores()
        {
            InitializeComponent();
        }

        #region Formulario

        private void FrmPostulanteList_Load(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }
        #endregion

        #region Metodos
        

        #endregion
        
    }
}
