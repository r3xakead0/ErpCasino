using System;
using System.Windows.Forms;
using System.Collections.Generic;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;
using System.ComponentModel;

namespace ErpCasino.WindowsForms.Seguridad
{
    public partial class FrmPerfilMant : Form
    {
        public FrmPerfilMant()
        {
            InitializeComponent();
        }

        private void FrmPerfilMant_Load(object sender, EventArgs e)
        {
            try
            {
                this.CargarPerfiles();
                this.FormatoPerfiles();
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
                if (this.dgvPerfiles.CurrentRow != null)
                {

                    if (Util.ConfirmationMessage("¿Desea eliminar el perfil seleccionado?") == false)
                        return;

                    var bePerfil = (BE.UI.Perfil)this.dgvPerfiles.CurrentRow.DataBoundItem;

                    if (bePerfil != null)
                    {
                        int idUsuarioSesion = ((MdiMain)this.MdiParent).uiUsuario.ID;
                        //bool rpta = new LN.Perfil(idUsuarioSesion).Eliminar(bePerfil.IdPerfil);
             
                        //if (rpta == true)
                        //{
                        //    Util.InformationMessage("Se eliminó el perfil");
                        //    this.CargarPerfiles();
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void dgvPerfiles_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                var col = dgvPerfiles.Columns[e.ColumnIndex];
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

                dgvPerfiles.Sort(col, dir);
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        public void CargarPerfiles()
        {
            try
            {
                int idUsuarioSesion = ((MdiMain)this.MdiParent).uiUsuario.ID;

                //var lstUiPerfiles = new LN.Perfil(idUsuarioSesion).Listar();
                var lstUiPerfiles = new List<BE.UI.Perfil>();
                for (int i = 0; i < 10; i++)
                {
                    lstUiPerfiles.Add(new BE.UI.Perfil());
                }

                var source = new BindingSource();
                source.DataSource = lstUiPerfiles;

                this.dgvPerfiles.DataSource = source;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FormatoPerfiles()
        {
            try
            {

                Util.FormatDatagridview(ref this.dgvPerfiles);
                this.dgvPerfiles.ReadOnly = false;

                this.dgvPerfiles.Columns["ID"].Visible = false;

                this.dgvPerfiles.Columns["Nombre"].Visible = true;
                this.dgvPerfiles.Columns["Nombre"].HeaderText = "Perfil";
                this.dgvPerfiles.Columns["Nombre"].Width = 200;
                this.dgvPerfiles.Columns["Nombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvPerfiles.Columns["Descripcion"].Visible = true;
                this.dgvPerfiles.Columns["Descripcion"].HeaderText = "Descripcion";
                this.dgvPerfiles.Columns["Descripcion"].Width = 200;
                this.dgvPerfiles.Columns["Descripcion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvPerfiles.Columns["Activo"].Visible = true;
                this.dgvPerfiles.Columns["Activo"].HeaderText = "Activo";
                this.dgvPerfiles.Columns["Activo"].Width = 70;
                this.dgvPerfiles.Columns["Activo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                Util.AutoWidthColumn(ref this.dgvPerfiles, "Descripcion");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
