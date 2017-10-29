using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmFeriadoMant : Form
    {

        #region "Patron Singleton"

        private static FrmFeriadoMant frmInstance = null;

        public static FrmFeriadoMant Instance()
        {

            if (frmInstance == null || frmInstance.IsDisposed == true)
            {
                frmInstance = new FrmFeriadoMant();
            }

            frmInstance.BringToFront();

            return frmInstance;
        }

        #endregion

        public FrmFeriadoMant()
        {
            InitializeComponent();
        }

        #region Formulario
        private void FrmFeriadoMant_Load(object sender, EventArgs e)
        {
            try
            {

                int  anhoActual = DateTime.Now.Year;

                this.CargarAnhos();
                this.cboAnho.SelectedValue = anhoActual.ToString();

                this.CargarFeriados(anhoActual);
                this.FormatoFeriados();

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

                if (this.dgvFeriados.CurrentRow != null)
                {

                    if (Util.ConfirmationMessage("¿Desea eliminar el registro seleccionado?") == false)
                        return;

                    var uiFeriado = (BE.UI.Feriado)this.dgvFeriados.CurrentRow.DataBoundItem;

                    bool rpta = new LN.Feriado().Eliminar(uiFeriado.Fecha);

                    if (rpta == true)
                    {                  
                        int anho = int.Parse(this.cboAnho.SelectedValue.ToString());
                        this.CargarFeriados(anho);

                        Util.InformationMessage("Se eliminó el registro seleccionado");
                    }
                }

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void FrmFeriadoMant_ResizeEnd(object sender, EventArgs e)
        {
            try
            {
                Util.AutoWidthColumn(ref this.dgvFeriados, "Motivo");
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void cboAnho_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                int anho = int.Parse(this.cboAnho.SelectedValue.ToString());
                this.CargarFeriados(anho);
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        #endregion

        #region Metodos

        private void CargarAnhos()
        {
            try
            {
                int anhoInicio = 2017;
                int anhoFinal = DateTime.Now.Year + 5;

                var lstAnhos = new List<BE.Record>();
                for (int i = anhoInicio; i < anhoFinal; i++)
                {
                    lstAnhos.Add(new BE.Record() { Codigo = i.ToString(), Nombre = i.ToString() });
                }

                this.cboAnho.DataSource = lstAnhos;
                this.cboAnho.DisplayMember = "Nombre";
                this.cboAnho.ValueMember = "Codigo";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarFeriados(int anho)
        {
            try
            {
                
                var lstUiFeriados = new LN.Feriado().ListarAnho(anho);

                var source = new BindingSource();
                source.DataSource = lstUiFeriados;

                this.dgvFeriados.DataSource = source;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FormatoFeriados()
        {
            try
            {
                Util.FormatDatagridview(ref this.dgvFeriados);

                for (int col = 0; col < this.dgvFeriados.Columns.Count; col++)
                    this.dgvFeriados.Columns[col].Visible = false;

                this.dgvFeriados.Columns["Fecha"].Visible = true;
                this.dgvFeriados.Columns["Fecha"].HeaderText = "Fecha";
                this.dgvFeriados.Columns["Fecha"].Width = 100;
                this.dgvFeriados.Columns["Fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvFeriados.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";

                this.dgvFeriados.Columns["Motivo"].Visible = true;
                this.dgvFeriados.Columns["Motivo"].HeaderText = "Motivo";
                this.dgvFeriados.Columns["Motivo"].Width = 200;
                this.dgvFeriados.Columns["Motivo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvFeriados.Columns["Festivo"].Visible = true;
                this.dgvFeriados.Columns["Festivo"].HeaderText = "Festivo";
                this.dgvFeriados.Columns["Festivo"].Width = 50;
                this.dgvFeriados.Columns["Festivo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgvFeriados.Columns["Activo"].Visible = true;
                this.dgvFeriados.Columns["Activo"].HeaderText = "Activo";
                this.dgvFeriados.Columns["Activo"].Width = 50;
                this.dgvFeriados.Columns["Activo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                Util.AutoWidthColumn(ref this.dgvFeriados, "Motivo");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }
}
