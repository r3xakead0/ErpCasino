using System;
using System.Windows.Forms;
using System.Drawing;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;
using System.ComponentModel;

namespace ErpCasino.WindowsForms.Seguridad
{
    public partial class FrmUsuarioList : Form
    {
        public FrmUsuarioList()
        {
            InitializeComponent();
        }

        private void FrmUsuarioList_Load(object sender, EventArgs e)
        {
            try
            {
                this.CargarUsuarios();
                this.FormatoUsuarios();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                var frmUsuarioNew = new FrmUsuarioMant();
                frmUsuarioNew.MdiParent = this.MdiParent;
                frmUsuarioNew.Show();
                frmUsuarioNew.frmList = this;
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.dgvUsuarios.CurrentRow != null)
                {
                    var uiUsuario = (BE.UI.Usuario)this.dgvUsuarios.CurrentRow.DataBoundItem;

                    var frmUsuarioEdit = new FrmUsuarioMant(uiUsuario);
                    frmUsuarioEdit.MdiParent = this.MdiParent;
                    frmUsuarioEdit.Show();
                    frmUsuarioEdit.frmList = this;
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvUsuarios.CurrentRow != null)
                {

                    if (Util.ConfirmationMessage("¿Desea eliminar el usuario seleccionado?") == false)
                        return;

                    var uiUsuario = (BE.UI.Usuario)this.dgvUsuarios.CurrentRow.DataBoundItem;

                    if (uiUsuario != null)
                    {
                        int idUsuarioSesion = ((MdiMain)this.MdiParent).uiUsuario.ID;
                        bool rpta = new LN.Usuario(idUsuarioSesion).Eliminar(uiUsuario.ID);
             
                        if (rpta == true)
                        {
                            Util.InformationMessage("Se eliminó el usuario");
                            this.CargarUsuarios();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void dgvUsuarios_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                var col = dgvUsuarios.Columns[e.ColumnIndex];
                ListSortDirection dir;

                switch (col.HeaderCell.SortGlyphDirection)
                {
                    case SortOrder.Ascending:
                        dir = ListSortDirection.Ascending;
                        break;
                    default:
                        dir = ListSortDirection.Descending;
                        break;
                }

                dgvUsuarios.Sort(col, dir);
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        public void CargarUsuarios()
        {
            try
            {
                int idUsuarioSesion = ((MdiMain)this.MdiParent).uiUsuario.ID;

                var lstUiUsuarios = new LN.Usuario(idUsuarioSesion).Listar();

                var sorted = new SortableBindingList<BE.UI.Usuario>(lstUiUsuarios);
                this.dgvUsuarios.DataSource = sorted;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FormatoUsuarios()
        {
            try
            {

                Util.FormatDatagridview(ref this.dgvUsuarios);

                this.dgvUsuarios.Columns["ID"].Visible = false;

                this.dgvUsuarios.Columns["Username"].Visible = true;
                this.dgvUsuarios.Columns["Username"].HeaderText = "Usuario";
                this.dgvUsuarios.Columns["Username"].Width = 100;
                this.dgvUsuarios.Columns["Username"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvUsuarios.Columns["Password"].Visible = false;

                this.dgvUsuarios.Columns["Nombres"].Visible = true;
                this.dgvUsuarios.Columns["Nombres"].HeaderText = "Nombres";
                this.dgvUsuarios.Columns["Nombres"].Width = 100;
                this.dgvUsuarios.Columns["Nombres"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvUsuarios.Columns["Email"].Visible = true;
                this.dgvUsuarios.Columns["Email"].HeaderText = "Email";
                this.dgvUsuarios.Columns["Email"].Width = 200;
                this.dgvUsuarios.Columns["Email"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvUsuarios.Columns["Bloqueado"].Visible = true;
                this.dgvUsuarios.Columns["Bloqueado"].HeaderText = "Bloqueado";
                this.dgvUsuarios.Columns["Bloqueado"].Width = 70;
                this.dgvUsuarios.Columns["Bloqueado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgvUsuarios.Columns["Activo"].Visible = true;
                this.dgvUsuarios.Columns["Activo"].HeaderText = "Activo";
                this.dgvUsuarios.Columns["Activo"].Width = 70;
                this.dgvUsuarios.Columns["Activo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                Util.AutoWidthColumn(ref this.dgvUsuarios, "Nombres");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
