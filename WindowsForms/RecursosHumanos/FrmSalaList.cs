using System;
using System.Windows.Forms;
using System.Collections.Generic;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;

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

                this.CargarSalas();
                this.FormatoSalas();

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

                
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }
        
        #endregion

        #region Metodos
        
        private void CargarSalas()
        {
            try
            {
                var lstBeSalas = new LN.Sala().Listar();

                var source = new BindingSource();
                source.DataSource = lstBeSalas;

                this.dgvSalas.DataSource = source;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FormatoSalas()
        {
            try
            {
                Util.FormatDatagridview(ref this.dgvSalas);
   
                for (int col = 0; col < this.dgvSalas.Columns.Count; col++)
                    this.dgvSalas.Columns[col].Visible = false;

                this.dgvSalas.Columns["Nombre"].Visible = true;
                this.dgvSalas.Columns["Nombre"].HeaderText = "Nombre";
                this.dgvSalas.Columns["Nombre"].Width = 150;
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
