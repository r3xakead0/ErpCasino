using System;
using System.Windows.Forms;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmLiquidacionList : Form
    {
        public FrmLiquidacionList()
        {
            InitializeComponent();
        }

        #region Formulario
        private void FrmPostulanteList_Load(object sender, EventArgs e)
        {
            try
            {

                this.CargarListadoLiquidaciones();

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
                var frmLiquidacionMant = new FrmLiquidacionMant(this);
                frmLiquidacionMant.MdiParent = this.MdiParent;
                frmLiquidacionMant.Show();
                frmLiquidacionMant.Cargar(null);
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

                if (this.dgvLiquidaciones.CurrentRow != null)
                {
                    var beLiquidacion = (BE.UI.Liquidacion)this.dgvLiquidaciones.CurrentRow.DataBoundItem;

                    var frmLiquidacionMant = new FrmLiquidacionMant(this);
                    frmLiquidacionMant.MdiParent = this.MdiParent;
                    frmLiquidacionMant.Show();
                    frmLiquidacionMant.Cargar(beLiquidacion);
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
                if (this.dgvLiquidaciones.CurrentRow != null)
                {

                    if (Util.ConfirmationMessage("¿Desea eliminar la liquidacion seleccionada?") == false)
                        return;

                    var uiLiquidacion = (BE.UI.Liquidacion)this.dgvLiquidaciones.CurrentRow.DataBoundItem;

                    int idLiquidacion = uiLiquidacion.IdLiquidacion;
                    bool rpta = new LN.Liquidacion().Eliminar(idLiquidacion);

                    if (rpta == true)
                    {
                        Util.InformationMessage("Se eliminó la liquidacion");
                        this.CargarListadoLiquidaciones();
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
        
        public void CargarListadoLiquidaciones()
        {
            try
            {

                var source = new BindingSource();
                source.DataSource = new LN.Liquidacion().Listar();

                this.dgvLiquidaciones.DataSource = source;

                this.FormatoListadoLiquidaciones();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FormatoListadoLiquidaciones()
        {
            try
            {
                Util.FormatDatagridview(ref this.dgvLiquidaciones);

                this.dgvLiquidaciones.Columns["IdLiquidacion"].Visible = false;

                this.dgvLiquidaciones.Columns["CeseFecha"].Visible = true;
                this.dgvLiquidaciones.Columns["CeseFecha"].HeaderText = "Fecha";
                this.dgvLiquidaciones.Columns["CeseFecha"].Width = 70;
                this.dgvLiquidaciones.Columns["CeseFecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvLiquidaciones.Columns["CeseFecha"].DefaultCellStyle.Format = "dd/MM/yyyy";

                this.dgvLiquidaciones.Columns["CeseMotivo"].Visible = true;
                this.dgvLiquidaciones.Columns["CeseMotivo"].HeaderText = "Motivo";
                this.dgvLiquidaciones.Columns["CeseMotivo"].Width = 150;
                this.dgvLiquidaciones.Columns["CeseMotivo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvLiquidaciones.Columns["EmpleadoCodigo"].Visible = true;
                this.dgvLiquidaciones.Columns["EmpleadoCodigo"].HeaderText = "Codigo";
                this.dgvLiquidaciones.Columns["EmpleadoCodigo"].Width = 100;
                this.dgvLiquidaciones.Columns["EmpleadoCodigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvLiquidaciones.Columns["EmpleadoNombre"].Visible = true;
                this.dgvLiquidaciones.Columns["EmpleadoNombre"].HeaderText = "Empleado";
                this.dgvLiquidaciones.Columns["EmpleadoNombre"].Width = 200;
                this.dgvLiquidaciones.Columns["EmpleadoNombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                
                Util.AutoWidthColumn(ref this.dgvLiquidaciones, "EmpleadoNombre");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }
}
