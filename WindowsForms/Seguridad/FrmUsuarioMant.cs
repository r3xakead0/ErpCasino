using System;
using System.Windows.Forms;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;

namespace ErpCasino.WindowsForms.Seguridad
{
    public partial class FrmUsuarioMant : Form
    {

        public BE.UI.Usuario uiUsuario = null;
        public FrmUsuarioList frmList = null;

        public FrmUsuarioMant()
        {
            try
            {
                InitializeComponent();

                this.uiUsuario = new BE.UI.Usuario();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
            
        }

        public FrmUsuarioMant(BE.UI.Usuario uiUsuario)
        {
            try
            {
                InitializeComponent();

                this.uiUsuario = uiUsuario;

                this.TxtUsuario.Text = this.uiUsuario.Username;
                this.TxtNombre.Text = this.uiUsuario.Nombres;
                this.TxtEmail.Text = this.uiUsuario.Email;

                this.TxtContrasenha.Text = this.uiUsuario.Password;
                this.TxtContrasenha2.Text = this.uiUsuario.Password;

                bool bloqueado = this.uiUsuario.Bloqueado == "Si" ? true : false;
                bool activo = this.uiUsuario.Activo == "Si" ? true : false;
                this.CbxBloqueado.Checked = bloqueado;
                this.CbxActivo.Checked = activo;
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
                if (this.TxtContrasenha.Text.Trim() != this.TxtContrasenha2.Text.Trim())
                {
                    throw new Exception("Contraseña no coincide");
                }

                uiUsuario.Username = this.TxtUsuario.Text.Trim();
                uiUsuario.Password = this.TxtContrasenha.Text.Trim();
                uiUsuario.Nombres = this.TxtNombre.Text.Trim();
                uiUsuario.Email = this.TxtEmail.Text.Trim();
                uiUsuario.Bloqueado = this.CbxBloqueado.Checked ? "Si" : "No";
                uiUsuario.Activo = this.CbxActivo.Checked ? "Si" : "No";

                int idUsuarioSesion = ((MdiMain)this.MdiParent).uiUsuario.ID;
                if (uiUsuario.ID == 0)
                {
                    new LN.Usuario(idUsuarioSesion).Insertar(ref uiUsuario);
                }
                else
                {
                    new LN.Usuario(idUsuarioSesion).Actualizar(uiUsuario);
                }

                this.frmList.CargarUsuarios();

                this.Close();

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
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
