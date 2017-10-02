using System;
using System.Windows.Forms;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmSueldoMinimoMant : Form
    {
        public FrmSueldoMinimoMant()
        {
            InitializeComponent();
        }

        #region Formulario
        private void FrmSueldoMinimoMant_Load(object sender, EventArgs e)
        {
            try
            {

                this.CargarSueldosMinimos();
                this.FormatoSueldosMinimos();

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

        private void btnCancelar_Click(object sender, EventArgs e)
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
        
        private void CargarSueldosMinimos()
        {
            try
            {
                var lstSueldosMinimos = new LN.SueldoMinimo().Listar();

                var source = new BindingSource();
                source.DataSource = lstSueldosMinimos;

                this.dgvSueldosMinimos.DataSource = source;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FormatoSueldosMinimos()
        {
            try
            {
                Util.FormatDatagridview(ref this.dgvSueldosMinimos);
   
                for (int col = 0; col < this.dgvSueldosMinimos.Columns.Count; col++)
                    this.dgvSueldosMinimos.Columns[col].Visible = false;

                this.dgvSueldosMinimos.Columns["FechaInicio"].Visible = true;
                this.dgvSueldosMinimos.Columns["FechaInicio"].HeaderText = "Fecha Inicio";
                this.dgvSueldosMinimos.Columns["FechaInicio"].Width = 100;
                this.dgvSueldosMinimos.Columns["FechaInicio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvSueldosMinimos.Columns["FechaInicio"].DefaultCellStyle.Format = "dd/MM/yyyy";

                this.dgvSueldosMinimos.Columns["Monto"].Visible = true;
                this.dgvSueldosMinimos.Columns["Monto"].HeaderText = "Monto";
                this.dgvSueldosMinimos.Columns["Monto"].Width = 100;
                this.dgvSueldosMinimos.Columns["Monto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvSueldosMinimos.Columns["Monto"].DefaultCellStyle.Format = "N2";

                this.dgvSueldosMinimos.Columns["Activo"].Visible = true;
                this.dgvSueldosMinimos.Columns["Activo"].HeaderText = "Activo";
                this.dgvSueldosMinimos.Columns["Activo"].Width = 100;
                this.dgvSueldosMinimos.Columns["Activo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                Util.AutoWidthColumn(ref this.dgvSueldosMinimos, "FechaInicio");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }
}
