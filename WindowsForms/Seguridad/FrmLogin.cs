using System;
using System.Windows.Forms;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;

namespace ErpCasino.WindowsForms.Seguridad
{
    public partial class FrmLogin : Form
    {
        private bool accedio = false;
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                string username = this.txtUsuario.Text.Trim();
                string password = this.txtContrasena.Text.Trim();

                var uiUsuario = new LN.Usuario(0).Validar(username, password);

                if (uiUsuario == null)
                {
                    Util.InformationMessage("Usuario o contraseña incorrectas");
                }
                else
                {
                    var mdi = ((MdiMain)this.MdiParent);
                    mdi.Acceso(uiUsuario);
                    accedio = true;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                this.txtUsuario.Focus();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (accedio == false)
                {
                    Application.Exit();
                }
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
    }
}
