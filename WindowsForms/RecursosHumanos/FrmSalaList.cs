using System;
using System.Windows.Forms;
using System.Collections.Generic;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;
using System.Drawing;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmSalaList : Form
    {

        public FrmSalaList()
        {
            InitializeComponent();
        }

        #region Formulario
        private void FrmSalaList_Load(object sender, EventArgs e)
        {
            try
            {

                this.CargarListadoSalas();
                this.FormatoListadoSalas();

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void FrmSalaList_ResizeEnd(object sender, EventArgs e)
        {
            try
            {
                Util.AutoWidthColumn(ref this.dgvSalas, "Nombre");
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                var frmSalaMant = new FrmSalaMant(this);
                frmSalaMant.MdiParent = this.MdiParent;
                frmSalaMant.Show();

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
                if (this.dgvSalas.CurrentRow != null)
                {
                    var uiSala = (BE.UI.Sala)this.dgvSalas.CurrentRow.DataBoundItem;
                    this.Editar(uiSala);
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
                if (this.dgvSalas.CurrentRow != null)
                {

                    if (Util.ConfirmationMessage("¿Desea eliminar la Sala seleccionada?") == false)
                        return;

                    var uiSala = (BE.UI.Sala)this.dgvSalas.CurrentRow.DataBoundItem;

                    bool rpta = new LN.Sala().Eliminar(uiSala.ID);

                    if (rpta == true)
                    {
                        Util.InformationMessage("Se eliminó la Sala seleccionada");
                        this.CargarListadoSalas();
                    }
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        #endregion

        #region Metodos

        private void Editar(BE.UI.Sala uiSala)
        {
            try
            {
                var frmSalaMant = new FrmSalaMant(this);
                frmSalaMant.MdiParent = this.MdiParent;
                frmSalaMant.Show();
                frmSalaMant.Cargar(uiSala);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CargarListadoSalas()
        {
            try
            {
                var lstUiSalas = new LN.Sala().Listar();

                var source = new BindingSource();
                source.DataSource = lstUiSalas;

                this.dgvSalas.DataSource = source;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void FormatoListadoSalas()
        {
            try
            {
                Util.FormatDatagridview(ref this.dgvSalas);

                for (int i = 0; i < this.dgvSalas.Columns.Count; i++)
                    this.dgvSalas.Columns[i].Visible = false;

                this.dgvSalas.Columns["Nombre"].Visible = true;
                this.dgvSalas.Columns["Nombre"].HeaderText = "Nombre";
                this.dgvSalas.Columns["Nombre"].Width = 100;
                this.dgvSalas.Columns["Nombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvSalas.Columns["Departamento"].Visible = true;
                this.dgvSalas.Columns["Departamento"].HeaderText = "Departamento";
                this.dgvSalas.Columns["Departamento"].Width = 100;
                this.dgvSalas.Columns["Departamento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvSalas.Columns["Provincia"].Visible = true;
                this.dgvSalas.Columns["Provincia"].HeaderText = "Provincia";
                this.dgvSalas.Columns["Provincia"].Width = 100;
                this.dgvSalas.Columns["Provincia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvSalas.Columns["Distrito"].Visible = true;
                this.dgvSalas.Columns["Distrito"].HeaderText = "Distrito";
                this.dgvSalas.Columns["Distrito"].Width = 100;
                this.dgvSalas.Columns["Distrito"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvSalas.Columns["Zona"].Visible = true;
                this.dgvSalas.Columns["Zona"].HeaderText = "Zona";
                this.dgvSalas.Columns["Zona"].Width = 100;
                this.dgvSalas.Columns["Zona"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvSalas.Columns["Activo"].Visible = true;
                this.dgvSalas.Columns["Activo"].HeaderText = "Activo";
                this.dgvSalas.Columns["Activo"].Width = 70;
                this.dgvSalas.Columns["Activo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                Util.AutoWidthColumn(ref this.dgvSalas, "Nombre");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion

        
    }
}
