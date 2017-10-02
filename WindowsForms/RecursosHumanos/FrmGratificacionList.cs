using System;
using System.Windows.Forms;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmGratificacionList : Form
    {
        public FrmGratificacionList()
        {
            InitializeComponent();
        }

        #region Formulario
        private void FrmGratificacionList_Load(object sender, EventArgs e)
        {
            try
            {

                this.CargarGratificaciones();
                this.FormatoGratificaciones();
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
                var frmGratificacionMant = new FrmGratificacionMant(this);
                frmGratificacionMant.MdiParent = this.MdiParent;
                frmGratificacionMant.Show();
                frmGratificacionMant.Cargar(null);
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

                if (this.dgvGratificaciones.CurrentRow != null)
                {
                    var beGratificacion = (BE.UI.Gratificacion)this.dgvGratificaciones.CurrentRow.DataBoundItem;

                    var frmGratificacionMant = new FrmGratificacionMant(this);
                    frmGratificacionMant.MdiParent = this.MdiParent;
                    frmGratificacionMant.Show();
                    frmGratificacionMant.Cargar(beGratificacion);
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
                if (this.dgvGratificaciones.CurrentRow != null)
                {

                    if (Util.ConfirmationMessage("¿Desea eliminar la gratificacion seleccionada?") == false)
                        return;

                    var uiGratificacion = (BE.UI.Gratificacion)this.dgvGratificaciones.CurrentRow.DataBoundItem;

                    int idGratificacion = uiGratificacion.Id;
                    bool rpta = new LN.Gratificacion().Eliminar(idGratificacion);

                    if (rpta == true)
                    {
                        Util.InformationMessage("Se eliminó la gratificacion");
                        this.CargarGratificaciones();
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
        
        public void CargarGratificaciones()
        {
            try
            {
                var lstGratificaciones = new LN.Gratificacion().Listar(false);

                var source = new BindingSource();
                source.DataSource = lstGratificaciones;

                this.dgvGratificaciones.DataSource = source;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FormatoGratificaciones()
        {
            try
            {
                Util.FormatDatagridview(ref this.dgvGratificaciones);

                for (int col = 0; col < this.dgvGratificaciones.Columns.Count; col++)
                    this.dgvGratificaciones.Columns[col].Visible = false;

                this.dgvGratificaciones.Columns["Periodo"].Visible = true;
                this.dgvGratificaciones.Columns["Periodo"].HeaderText = "Periodo";
                this.dgvGratificaciones.Columns["Periodo"].Width = 100;
                this.dgvGratificaciones.Columns["Periodo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                
                this.dgvGratificaciones.Columns["EmpleadoNombres"].Visible = true;
                this.dgvGratificaciones.Columns["EmpleadoNombres"].HeaderText = "Empleado";
                this.dgvGratificaciones.Columns["EmpleadoNombres"].Width = 200;
                this.dgvGratificaciones.Columns["EmpleadoNombres"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                
                this.dgvGratificaciones.Columns["GratificacionBruta"].Visible = true;
                this.dgvGratificaciones.Columns["GratificacionBruta"].HeaderText = "Total Bruto";
                this.dgvGratificaciones.Columns["GratificacionBruta"].Width = 100;
                this.dgvGratificaciones.Columns["GratificacionBruta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvGratificaciones.Columns["GratificacionBruta"].DefaultCellStyle.Format = "N2";

                this.dgvGratificaciones.Columns["GratificacionNeta"].Visible = true;
                this.dgvGratificaciones.Columns["GratificacionNeta"].HeaderText = "Total Neto";
                this.dgvGratificaciones.Columns["GratificacionNeta"].Width = 100;
                this.dgvGratificaciones.Columns["GratificacionNeta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvGratificaciones.Columns["GratificacionNeta"].DefaultCellStyle.Format = "N2";

                this.dgvGratificaciones.Columns["GratificacionPago"].Visible = true;
                this.dgvGratificaciones.Columns["GratificacionPago"].HeaderText = "Total a Pagar";
                this.dgvGratificaciones.Columns["GratificacionPago"].Width = 100;
                this.dgvGratificaciones.Columns["GratificacionPago"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvGratificaciones.Columns["GratificacionPago"].DefaultCellStyle.Format = "N2";

                Util.AutoWidthColumn(ref this.dgvGratificaciones, "EmpleadoNombres");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }
}
