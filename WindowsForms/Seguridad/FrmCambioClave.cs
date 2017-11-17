using System;
using System.Windows.Forms;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;

namespace ErpCasino.WindowsForms.Seguridad
{
    public partial class FrmCambioClave : Form
    {

        public FrmCambioClave()
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

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {

                #region Validaciones

                if (this.txtClaveActual.Text.Trim().Length == 0)
                {
                    this.txtClaveActual.Focus();
                    throw new Exception("Ingrese la clave actual");
                }

                if (this.txtClaveNueva.Text.Trim().Length == 0)
                {
                    this.txtClaveNueva.Focus();
                    throw new Exception("Ingrese la nueva clave");
                }

                if (this.txtClaveRepetir.Text.Trim().Length == 0)
                {
                    this.txtClaveRepetir.Focus();
                    throw new Exception("Ingrese repetivamente la nueva clave");
                }

                if (this.txtClaveNueva.Text.Trim() != this.txtClaveRepetir.Text.Trim())
                {
                    this.txtClaveNueva.Focus();
                    throw new Exception("La nueva clave no coincide");
                }

                #endregion

                string claveActual = this.txtClaveActual.Text;
                string claveNueva = this.txtClaveNueva.Text;
                string claveRepetida = this.txtClaveRepetir.Text;

                int idUsuarioSesion = ((MdiMain)this.MdiParent).uiUsuario.ID;

                var uiUsuario = ((MdiMain)this.MdiParent).uiUsuario;
                uiUsuario.Password = claveNueva;

                var lnUsuario = new LN.Usuario(idUsuarioSesion);
                var beUsuario = lnUsuario.Validar(uiUsuario.Username, uiUsuario.Password);
                if (beUsuario == null)
                {
                    this.txtClaveActual.Focus();
                    throw new Exception("La clave actual es incorrecta");
                }

                bool rpta = lnUsuario.Actualizar(uiUsuario);
                if (rpta == true)
                {
                    Util.InformationMessage("Se cambio la clave del usuario");
                    this.Close();
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
