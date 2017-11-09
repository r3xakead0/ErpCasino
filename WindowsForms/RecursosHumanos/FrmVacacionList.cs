using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;
using System.Linq;
using System.ComponentModel;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmVacacionList : Form
    {

        #region "Patron Singleton"

        private static FrmVacacionList frmInstance = null;

        public static FrmVacacionList Instance()
        {

            if (frmInstance == null || frmInstance.IsDisposed == true)
            {
                frmInstance = new FrmVacacionList();
            }

            frmInstance.BringToFront();

            return frmInstance;
        }

        #endregion

        public FrmVacacionList()
        {
            InitializeComponent();
        }

        #region Formulario

        private void FrmVacacionList_ResizeEnd(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvVacaciones.DataSource != null)
                {
                    Util.AutoWidthColumn(ref this.dgvVacaciones, "EmpleadoNombreCompleto");
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

                this.CargarAnhos();
                this.CargarMes();

                this.cboAnho.SelectedValue = DateTime.Now.Year.ToString();
                this.cboMes.SelectedValue = DateTime.Now.Month.ToString();

                this.CargarListadoVacaciones();
                this.FormatoListadoVacaciones();

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void dgvVacaciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;

                var uiVacacion = (BE.UI.Vacacion)this.dgvVacaciones.CurrentRow.DataBoundItem;

                

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
                this.CargarListadoVacaciones();

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
                var frmVacacionMant = FrmVacacionMant.Instance();
                frmVacacionMant.MdiParent = this.MdiParent;
                frmVacacionMant.Show();

                frmVacacionMant.frmList = this;
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvVacaciones.CurrentRow != null)
                {
                    var uiVacacion = (BE.UI.Vacacion)this.dgvVacaciones.CurrentRow.DataBoundItem;

                    var frmVacacionVer = FrmVacacionVer.Instance();
                    frmVacacionVer.MdiParent = this.MdiParent;
                    frmVacacionVer.Show();

                    frmVacacionVer.frmList = this;
                    frmVacacionVer.Cargar(uiVacacion);
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
                if (this.dgvVacaciones.CurrentRow != null)
                {

                    if (Util.ConfirmationMessage("¿Desea eliminar el Calculo de Vacaciones seleccionado?") == false)
                        return;

                    var uiVacacion = (BE.UI.Vacacion)this.dgvVacaciones.CurrentRow.DataBoundItem;

                    int idVacacion = uiVacacion.Id;
                    bool rpta = new LN.Vacacion().Eliminar(idVacacion);

                    if (rpta == true)
                    {
                        Util.InformationMessage("Se eliminó el Calculo de Vacaciones");
                        this.CargarListadoVacaciones();
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
                if (this.dgvVacaciones.CurrentRow != null)
                {

                    if (Util.ConfirmationMessage("¿Desea imprimir el Calculo de Vacaciones seleccionado?") == false)
                        return;

                    var uiVacacion = (BE.UI.Vacacion)this.dgvVacaciones.CurrentRow.DataBoundItem;

                    var frmPlanillaVista = new FrmImpresion();
                    frmPlanillaVista.MdiParent = this.MdiParent;
                    frmPlanillaVista.Show();
                    frmPlanillaVista.ImpresionVacacion(uiVacacion.EmpleadoCodigo);

                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void dgvVacaciones_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                var col = this.dgvVacaciones.Columns[e.ColumnIndex];
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

                this.dgvVacaciones.Sort(col, dir);
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        #endregion

        #region Metodos
        
        public void CargarListadoVacaciones()
        {
            try
            {

                int anho = int.Parse(this.cboAnho.SelectedValue.ToString());
                int mes = int.Parse(this.cboMes.SelectedValue.ToString());

                var lstUiVacaciones = new LN.Vacacion().Listar(anho, mes);

                var sorted = new SortableBindingList<BE.UI.Vacacion>(lstUiVacaciones);
                this.dgvVacaciones.DataSource = sorted;

                int nroRegistros = lstUiVacaciones.Count;
                double total = lstUiVacaciones.Sum(x => x.TotalNeto);

                this.txtNroRegistros.Text = nroRegistros.ToString();
                this.txtTotal.Text = total.ToString("N2");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FormatoListadoVacaciones()
        {
            try
            {
                Util.FormatDatagridview(ref this.dgvVacaciones);

                for (int col = 0; col < this.dgvVacaciones.Columns.Count; col++)
                    this.dgvVacaciones.Columns[col].Visible = false;

                this.dgvVacaciones.Columns["EmpleadoCodigo"].Visible = true;
                this.dgvVacaciones.Columns["EmpleadoCodigo"].HeaderText = "Codigo";
                this.dgvVacaciones.Columns["EmpleadoCodigo"].Width = 80;
                this.dgvVacaciones.Columns["EmpleadoCodigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvVacaciones.Columns["EmpleadoNombreCompleto"].Visible = true;
                this.dgvVacaciones.Columns["EmpleadoNombreCompleto"].HeaderText = "Empleado";
                this.dgvVacaciones.Columns["EmpleadoNombreCompleto"].Width = 200;
                this.dgvVacaciones.Columns["EmpleadoNombreCompleto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvVacaciones.Columns["VacacionFechaInicial"].Visible = true;
                this.dgvVacaciones.Columns["VacacionFechaInicial"].HeaderText = "Fecha Inicial";
                this.dgvVacaciones.Columns["VacacionFechaInicial"].Width = 100;
                this.dgvVacaciones.Columns["VacacionFechaInicial"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvVacaciones.Columns["VacacionFechaInicial"].DefaultCellStyle.Format = "dd/MM/yyyy";

                this.dgvVacaciones.Columns["VacacionFechaFinal"].Visible = true;
                this.dgvVacaciones.Columns["VacacionFechaFinal"].HeaderText = "Fecha Final";
                this.dgvVacaciones.Columns["VacacionFechaFinal"].Width = 100;
                this.dgvVacaciones.Columns["VacacionFechaFinal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dgvVacaciones.Columns["VacacionFechaFinal"].DefaultCellStyle.Format = "dd/MM/yyyy";

                this.dgvVacaciones.Columns["VacacionDias"].Visible = true;
                this.dgvVacaciones.Columns["VacacionDias"].HeaderText = "Dias";
                this.dgvVacaciones.Columns["VacacionDias"].Width = 80;
                this.dgvVacaciones.Columns["VacacionDias"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvVacaciones.Columns["TotalNeto"].Visible = true;
                this.dgvVacaciones.Columns["TotalNeto"].HeaderText = "Total";
                this.dgvVacaciones.Columns["TotalNeto"].Width = 80;
                this.dgvVacaciones.Columns["TotalNeto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvVacaciones.Columns["TotalNeto"].DefaultCellStyle.Format = "N2";

                Util.AutoWidthColumn(ref this.dgvVacaciones, "EmpleadoNombreCompleto");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

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

        private void CargarMes()
        {
            try
            {

                var lstMes = new List<BE.Record>();

                lstMes.Add(new BE.Record() { Codigo = "1", Nombre = "Enero" });
                lstMes.Add(new BE.Record() { Codigo = "2", Nombre = "Febrero" });
                lstMes.Add(new BE.Record() { Codigo = "3", Nombre = "Marzo" });
                lstMes.Add(new BE.Record() { Codigo = "4", Nombre = "Abril" });
                lstMes.Add(new BE.Record() { Codigo = "5", Nombre = "Mayo" });
                lstMes.Add(new BE.Record() { Codigo = "6", Nombre = "Junio" });
                lstMes.Add(new BE.Record() { Codigo = "7", Nombre = "Julio" });
                lstMes.Add(new BE.Record() { Codigo = "8", Nombre = "Agosto" });
                lstMes.Add(new BE.Record() { Codigo = "9", Nombre = "Setiembre" });
                lstMes.Add(new BE.Record() { Codigo = "10", Nombre = "Octubre" });
                lstMes.Add(new BE.Record() { Codigo = "11", Nombre = "Noviembre" });
                lstMes.Add(new BE.Record() { Codigo = "12", Nombre = "Diciembre" });

                this.cboMes.DataSource = lstMes;
                this.cboMes.DisplayMember = "Nombre";
                this.cboMes.ValueMember = "Codigo";
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion

    }
}
