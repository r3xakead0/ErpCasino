using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;
using System.Linq;
using System.ComponentModel;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmPlanillaMovilidadList : Form
    {

        #region "Patron Singleton"

        private static FrmPlanillaMovilidadList frmInstance = null;

        public static FrmPlanillaMovilidadList Instance()
        {

            if (frmInstance == null || frmInstance.IsDisposed == true)
            {
                frmInstance = new FrmPlanillaMovilidadList();
            }

            frmInstance.BringToFront();

            return frmInstance;
        }

        #endregion

        public FrmPlanillaMovilidadList()
        {
            InitializeComponent();
        }

        #region Formulario

        private void FrmPlanillaMovilidadList_ResizeEnd(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvMovilidades.DataSource != null)
                {
                    Util.AutoWidthColumn(ref this.dgvMovilidades, "EmpleadoNombreCompleto");
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void FrmPostulanteList_Load(object sender, EventArgs e)
        {
            try
            {

                this.CargarListadoMovilidades();
                this.FormatoListadoMovilidades();

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void dgvMovilidades_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;

                var uiMovilidad = (BE.UI.Movilidad)this.dgvMovilidades.CurrentRow.DataBoundItem;

                this.Editar(uiMovilidad);

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void cboAnhoMes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                this.CargarListadoMovilidades();

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
                var frmMovilidadMant = FrmPlanillaMovilidadMant.Instance();
                frmMovilidadMant.MdiParent = this.MdiParent;
                frmMovilidadMant.Show();

                frmMovilidadMant.frmList = this;
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

                if (this.dgvMovilidades.CurrentRow != null)
                {
                    var uiMovilidad = (BE.UI.Movilidad)this.dgvMovilidades.CurrentRow.DataBoundItem;

                    this.Editar(uiMovilidad);
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
                if (this.dgvMovilidades.CurrentRow != null)
                {

                    if (Util.ConfirmationMessage("¿Desea eliminar al Movilidad seleccionado?") == false)
                        return;

                    var uiAdelato = (BE.UI.Movilidad)this.dgvMovilidades.CurrentRow.DataBoundItem;

                    int idMovilidad = uiAdelato.Id;
                    bool rpta = new LN.Movilidad().Eliminar(idMovilidad);

                    if (rpta == true)
                    {
                        Util.InformationMessage("Se eliminó el Movilidad");
                        this.CargarListadoMovilidades();
                    }
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void dgvMovilidades_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                var col = this.dgvMovilidades.Columns[e.ColumnIndex];
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

                this.dgvMovilidades.Sort(col, dir);
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        #endregion

        #region Metodos

        private void Editar(BE.UI.Movilidad uiMovilidad)
        {
            try
            {
                var frmMovilidadMant = FrmPlanillaMovilidadMant.Instance();
                frmMovilidadMant.MdiParent = this.MdiParent;
                frmMovilidadMant.Show();

                frmMovilidadMant.frmList = this;
                frmMovilidadMant.Cargar(uiMovilidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void CargarListadoMovilidades()
        {
            try
            {

                var lstUiMovilidades = new LN.Movilidad().Listar();

                var sorted = new SortableBindingList<BE.UI.Movilidad>(lstUiMovilidades);
                this.dgvMovilidades.DataSource = sorted;

                int nroRegistros = lstUiMovilidades.Count;
                this.txtNroRegistros.Text = nroRegistros.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FormatoListadoMovilidades()
        {
            try
            {
                Util.FormatDatagridview(ref this.dgvMovilidades);

                for (int col = 0; col < this.dgvMovilidades.Columns.Count; col++)
                    this.dgvMovilidades.Columns[col].Visible = false;

                this.dgvMovilidades.Columns["Anho"].Visible = true;
                this.dgvMovilidades.Columns["Anho"].HeaderText = "Año";
                this.dgvMovilidades.Columns["Anho"].Width = 50;
                this.dgvMovilidades.Columns["Anho"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgvMovilidades.Columns["MesNombre"].Visible = true;
                this.dgvMovilidades.Columns["MesNombre"].HeaderText = "Mes";
                this.dgvMovilidades.Columns["MesNombre"].Width = 50;
                this.dgvMovilidades.Columns["MesNombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgvMovilidades.Columns["EmpleadoCodigo"].Visible = true;
                this.dgvMovilidades.Columns["EmpleadoCodigo"].HeaderText = "Codigo";
                this.dgvMovilidades.Columns["EmpleadoCodigo"].Width = 80;
                this.dgvMovilidades.Columns["EmpleadoCodigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvMovilidades.Columns["EmpleadoNombreCompleto"].Visible = true;
                this.dgvMovilidades.Columns["EmpleadoNombreCompleto"].HeaderText = "Empleado";
                this.dgvMovilidades.Columns["EmpleadoNombreCompleto"].Width = 200;
                this.dgvMovilidades.Columns["EmpleadoNombreCompleto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
               
                this.dgvMovilidades.Columns["Monto"].Visible = true;
                this.dgvMovilidades.Columns["Monto"].HeaderText = "Monto";
                this.dgvMovilidades.Columns["Monto"].Width = 80;
                this.dgvMovilidades.Columns["Monto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvMovilidades.Columns["Monto"].DefaultCellStyle.Format = "N2";

                Util.AutoWidthColumn(ref this.dgvMovilidades, "EmpleadoNombreCompleto");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        #endregion

        
    }
}
