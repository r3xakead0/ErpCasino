using System;
using System.Windows.Forms;
using System.Collections.Generic;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmCargoMant : Form
    {

        private List<BE.Cargo> lstBeCargos = new List<BE.Cargo>();

        public FrmCargoMant()
        {
            InitializeComponent();
        }

        #region Formulario
        private void FrmCargoMant_Load(object sender, EventArgs e)
        {
            try
            {

                this.CargarCargos();
                this.FormatoCargos();

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

                
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }
        
        #endregion

        #region Metodos
        
        private void CargarCargos()
        {
            try
            {
                this.lstBeCargos = new LN.Cargo().Listar();

                var source = new BindingSource();
                source.DataSource = lstBeCargos;

                this.dgvCargos.DataSource = source;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FormatoCargos()
        {
            try
            {
                Util.FormatDatagridview(ref this.dgvCargos);
                this.dgvCargos.ReadOnly = false;

                for (int col = 0; col < this.dgvCargos.Columns.Count; col++)
                    this.dgvCargos.Columns[col].Visible = false;

                this.dgvCargos.Columns["Nombre"].Visible = true;
                this.dgvCargos.Columns["Nombre"].HeaderText = "Nombre";
                this.dgvCargos.Columns["Nombre"].Width = 200;
                this.dgvCargos.Columns["Nombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvCargos.Columns["Descripcion"].Visible = true;
                this.dgvCargos.Columns["Descripcion"].HeaderText = "Descripcion";
                this.dgvCargos.Columns["Descripcion"].Width = 200;
                this.dgvCargos.Columns["Descripcion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvCargos.Columns["Activo"].Visible = true;
                this.dgvCargos.Columns["Activo"].HeaderText = "Activo";
                this.dgvCargos.Columns["Activo"].Width = 70;
                this.dgvCargos.Columns["Activo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                Util.AutoWidthColumn(ref this.dgvCargos, "Descripcion");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }
}
