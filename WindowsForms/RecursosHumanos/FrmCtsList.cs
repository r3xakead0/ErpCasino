using System;
using System.Windows.Forms;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmCtsList : Form
    {
        public FrmCtsList()
        {
            InitializeComponent();
        }

        #region Formulario
        private void FrmCtsList_Load(object sender, EventArgs e)
        {
            try
            {

                this.CargarListadoCts();

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
                var frmCtsMant = new FrmCtsMant(this);
                frmCtsMant.MdiParent = this.MdiParent;
                frmCtsMant.Show();
                frmCtsMant.Cargar(null);
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

                if (this.dgvCts.CurrentRow != null)
                {
                    var beCts = (BE.UI.CTS)this.dgvCts.CurrentRow.DataBoundItem;

                    var frmCtsMant = new FrmCtsMant(this);
                    frmCtsMant.MdiParent = this.MdiParent;
                    frmCtsMant.Show();
                    frmCtsMant.Cargar(beCts);
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
                if (this.dgvCts.CurrentRow != null)
                {

                    if (Util.ConfirmationMessage("¿Desea eliminar al adelanto seleccionado?") == false)
                        return;

                    var uiAdelato = (BE.UI.CTS)this.dgvCts.CurrentRow.DataBoundItem;

                    int idCts = uiAdelato.IdCts;
                    bool rpta = new LN.CTS().Eliminar(idCts);

                    if (rpta == true)
                    {
                        Util.InformationMessage("Se eliminó el adelanto");
                        this.CargarListadoCts();
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
        
        public void CargarListadoCts()
        {
            try
            {
                var lstCts = new LN.CTS().Listar();

                var source = new BindingSource();
                source.DataSource = lstCts;

                this.dgvCts.DataSource = source;

                this.FormatoListadoCtss();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FormatoListadoCtss()
        {
            try
            {
                Util.FormatDatagridview(ref this.dgvCts);

                this.dgvCts.Columns["IdCts"].Visible = false;

                this.dgvCts.Columns["FechaDeposito"].Visible = true;
                this.dgvCts.Columns["FechaDeposito"].HeaderText = "Fecha";
                this.dgvCts.Columns["FechaDeposito"].Width = 100;
                this.dgvCts.Columns["FechaDeposito"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvCts.Columns["FechaDeposito"].DefaultCellStyle.Format = "dd/MM/yyyy";

                this.dgvCts.Columns["EmpleadoCodigo"].Visible = true;
                this.dgvCts.Columns["EmpleadoCodigo"].HeaderText = "Codigo";
                this.dgvCts.Columns["EmpleadoCodigo"].Width = 100;
                this.dgvCts.Columns["EmpleadoCodigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvCts.Columns["EmpleadoNombre"].Visible = true;
                this.dgvCts.Columns["EmpleadoNombre"].HeaderText = "Nombre";
                this.dgvCts.Columns["EmpleadoNombre"].Width = 200;
                this.dgvCts.Columns["EmpleadoNombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvCts.Columns["Monto"].Visible = true;
                this.dgvCts.Columns["Monto"].HeaderText = "Monto";
                this.dgvCts.Columns["Monto"].Width = 100;
                this.dgvCts.Columns["Monto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvCts.Columns["Monto"].DefaultCellStyle.Format = "N2";

                this.dgvCts.Columns["FechaPeriodoInicial"].Visible = true;
                this.dgvCts.Columns["FechaPeriodoInicial"].HeaderText = "Inicio Periodo";
                this.dgvCts.Columns["FechaPeriodoInicial"].Width = 100;
                this.dgvCts.Columns["FechaPeriodoInicial"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvCts.Columns["FechaPeriodoInicial"].DefaultCellStyle.Format = "dd/MM/yyyy";

                this.dgvCts.Columns["FechaPeriodoFinal"].Visible = true;
                this.dgvCts.Columns["FechaPeriodoFinal"].HeaderText = "Final Periodo";
                this.dgvCts.Columns["FechaPeriodoFinal"].Width = 100;
                this.dgvCts.Columns["FechaPeriodoFinal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvCts.Columns["FechaPeriodoFinal"].DefaultCellStyle.Format = "dd/MM/yyyy";

                Util.AutoWidthColumn(ref this.dgvCts, "EmpleadoNombre");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }
}
