using System;
using System.Windows.Forms;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmCtsList : Form
    {

        #region "Patron Singleton"

        private static FrmCtsList frmInstance = null;

        public static FrmCtsList Instance()
        {

            if (frmInstance == null || frmInstance.IsDisposed == true)
            {
                frmInstance = new FrmCtsList();
            }

            frmInstance.BringToFront();

            return frmInstance;
        }

        #endregion

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
                this.FormatoListadoCts();

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void FrmCtsList_ResizeEnd(object sender, EventArgs e)
        {
            try
            {
                Util.AutoWidthColumn(ref this.dgvCts, "EmpleadoNombreCompleto");
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
                var frmCtsMant = FrmCtsMant.Instance();
                frmCtsMant.MdiParent = this.MdiParent;
                frmCtsMant.Show();

                frmCtsMant.frmList = this;

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

                    var frmCtsMant = FrmCtsMant.Instance();
                    frmCtsMant.MdiParent = this.MdiParent;
                    frmCtsMant.Show();

                    frmCtsMant.frmList = this;
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

                    if (Util.ConfirmationMessage("¿Desea eliminar el registro seleccionado?") == false)
                        return;

                    var uiAdelato = (BE.UI.CTS)this.dgvCts.CurrentRow.DataBoundItem;

                    int idCts = uiAdelato.Id;
                    bool rpta = new LN.CTS().Eliminar(idCts);

                    if (rpta == true)
                    {
                        Util.InformationMessage("Se eliminó el registro seleccionado");
                        this.CargarListadoCts();
                    }
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvCts.CurrentRow != null)
                {

                    var uiCTS = (BE.UI.CTS)this.dgvCts.CurrentRow.DataBoundItem;

                    int anho = uiCTS.Anho;
                    int periodo = uiCTS.PeriodoNumero;
                    string codigoEmpleado = uiCTS.EmpleadoCodigo;

                    var imprimir = FrmImpresion.Instance();
                    imprimir.MdiParent = this.MdiParent;
                    imprimir.Show();
                    imprimir.ImpresionCts(anho, periodo, codigoEmpleado);
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FormatoListadoCts()
        {
            try
            {
                Util.FormatDatagridview(ref this.dgvCts);

                for (int i = 0; i < this.dgvCts.Columns.Count; i++)
                    this.dgvCts.Columns[i].Visible = false;

                this.dgvCts.Columns["Anho"].Visible = true;
                this.dgvCts.Columns["Anho"].HeaderText = "Año";
                this.dgvCts.Columns["Anho"].Width = 50;
                this.dgvCts.Columns["Anho"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgvCts.Columns["PeriodoNombre"].Visible = true;
                this.dgvCts.Columns["PeriodoNombre"].HeaderText = "Periodo";
                this.dgvCts.Columns["PeriodoNombre"].Width = 50;
                this.dgvCts.Columns["PeriodoNombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgvCts.Columns["EmpleadoCodigo"].Visible = true;
                this.dgvCts.Columns["EmpleadoCodigo"].HeaderText = "Codigo";
                this.dgvCts.Columns["EmpleadoCodigo"].Width = 100;
                this.dgvCts.Columns["EmpleadoCodigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvCts.Columns["EmpleadoNombreCompleto"].Visible = true;
                this.dgvCts.Columns["EmpleadoNombreCompleto"].HeaderText = "Nombre Completo";
                this.dgvCts.Columns["EmpleadoNombreCompleto"].Width = 200;
                this.dgvCts.Columns["EmpleadoNombreCompleto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvCts.Columns["ComputableFechaInicial"].Visible = true;
                this.dgvCts.Columns["ComputableFechaInicial"].HeaderText = "Fecha Inicial";
                this.dgvCts.Columns["ComputableFechaInicial"].Width = 100;
                this.dgvCts.Columns["ComputableFechaInicial"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvCts.Columns["ComputableFechaInicial"].DefaultCellStyle.Format = "dd/MM/yyyy";

                this.dgvCts.Columns["ComputableFechaFinal"].Visible = true;
                this.dgvCts.Columns["ComputableFechaFinal"].HeaderText = "Fecha Final";
                this.dgvCts.Columns["ComputableFechaFinal"].Width = 100;
                this.dgvCts.Columns["ComputableFechaFinal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvCts.Columns["ComputableFechaFinal"].DefaultCellStyle.Format = "dd/MM/yyyy";

                this.dgvCts.Columns["ComputableMeses"].Visible = true;
                this.dgvCts.Columns["ComputableMeses"].HeaderText = "Meses";
                this.dgvCts.Columns["ComputableMeses"].Width = 50;
                this.dgvCts.Columns["ComputableMeses"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                this.dgvCts.Columns["ComputableDias"].Visible = true;
                this.dgvCts.Columns["ComputableDias"].HeaderText = "Dias";
                this.dgvCts.Columns["ComputableDias"].Width = 50;
                this.dgvCts.Columns["ComputableDias"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                this.dgvCts.Columns["ComputablePagar"].Visible = true;
                this.dgvCts.Columns["ComputablePagar"].HeaderText = "Total";
                this.dgvCts.Columns["ComputablePagar"].Width = 100;
                this.dgvCts.Columns["ComputablePagar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvCts.Columns["ComputablePagar"].DefaultCellStyle.Format = "N2";

                Util.AutoWidthColumn(ref this.dgvCts, "EmpleadoNombreCompleto");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }
}
