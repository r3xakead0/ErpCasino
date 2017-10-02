using System;
using System.Windows.Forms;
using System.Drawing;
using System.Globalization;
using System.Collections.Generic;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;
using System.ComponentModel;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmAsistenciaList : Form
    {

        private int anchoInicial = 0;

        public FrmAsistenciaList()
        {
            InitializeComponent();
        }

        #region Formulario
        private void FrmAsistenciaList_Load(object sender, EventArgs e)
        {
            try
            {
                this.CargarAnhos();
                this.CargarMes();

                int anho = DateTime.Now.Year;
                int mes = DateTime.Now.Month;

                this.CargarAsistencias(anho, mes);
                this.FormatoAsistencias();

                this.anchoInicial = this.Width;
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
                var frmAsistenciaNew = new FrmAsistenciaMant();
                frmAsistenciaNew.MdiParent = this.MdiParent;
                frmAsistenciaNew.Show();
                frmAsistenciaNew.Cargar(null);
                frmAsistenciaNew.frmList = this;
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
                if (this.dgvAsistencias.CurrentRow != null)
                {
                    if (Util.ConfirmationMessage("¿Desea eliminar la asistencia de la fecha seleccionada?") == false)
                        return;

                    var uiAsistenciaResumen = (BE.UI.AsistenciaResumen)this.dgvAsistencias.CurrentRow.DataBoundItem;
                    DateTime fecha = uiAsistenciaResumen.Fecha;

                    bool rpta = new LN.Asistencia().EliminarResumen(fecha);

                    if (rpta)
                    {
                        Util.ConfirmationMessage("Se elimino la asistencia de la fecha seleccionada");

                        int anho = int.Parse(this.cboAnho.SelectedValue.ToString());
                        int mes = int.Parse(this.cboMes.SelectedValue.ToString());

                        this.CargarAsistencias(anho, mes);
                    }
                }
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

                if (this.dgvAsistencias.CurrentRow != null)
                {

                    var uiAsistenciaResumen = (BE.UI.AsistenciaResumen)this.dgvAsistencias.CurrentRow.DataBoundItem;
                    DateTime fecha = uiAsistenciaResumen.Fecha;

                    List<BE.UI.Asistencia> lstUiAsistencias = new LN.Asistencia().Listar(fecha);

                    var frmAsistenciaEdit = new FrmAsistenciaMant();
                    frmAsistenciaEdit.MdiParent = this.MdiParent;
                    frmAsistenciaEdit.Show();

                    frmAsistenciaEdit.Cargar(lstUiAsistencias);
                    frmAsistenciaEdit.frmList = this;
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void dgvAsistencias_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                var col = dgvAsistencias.Columns[e.ColumnIndex];
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

                this.dgvAsistencias.Sort(col, dir);
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

        public void CargarAsistencias(int anho, int mes)
        {
            try
            {

                var lstUiAsistenciaResumen = new LN.Asistencia().ListarResumen(anho, mes);

                var sorted = new SortableBindingList<BE.UI.AsistenciaResumen>(lstUiAsistenciaResumen);

                this.dgvAsistencias.DataSource = sorted;

                this.cboAnho.SelectedValue = anho.ToString();
                this.cboMes.SelectedValue = mes.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FormatoAsistencias()
        {
            try
            {
                Util.FormatDatagridview(ref this.dgvAsistencias);

                for (int col = 0; col < this.dgvAsistencias.Columns.Count; col++)
                    this.dgvAsistencias.Columns[col].Visible = false;

                this.dgvAsistencias.Columns["Fecha"].Visible = true;
                this.dgvAsistencias.Columns["Fecha"].HeaderText = "Fecha";
                this.dgvAsistencias.Columns["Fecha"].Width = 150;
                this.dgvAsistencias.Columns["Fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvAsistencias.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";

                this.dgvAsistencias.Columns["Cantidad"].Visible = true;
                this.dgvAsistencias.Columns["Cantidad"].HeaderText = "Cantidad";
                this.dgvAsistencias.Columns["Cantidad"].Width = 80;
                this.dgvAsistencias.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                Util.AutoWidthColumn(ref this.dgvAsistencias, "Fecha");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion

        private void cboAnhoMes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (this.cboAnho.Items.Count == 0 || this.cboMes.Items.Count == 0)
                    return;

                int anho = int.Parse(this.cboAnho.SelectedValue.ToString());
                int mes = int.Parse(this.cboMes.SelectedValue.ToString());

                this.CargarAsistencias(anho, mes);
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void FrmAsistenciaList_ResizeEnd(object sender, EventArgs e)
        {
            try
            {
                if (this.Width < this.anchoInicial)
                    this.Width = this.anchoInicial;

                Util.AutoWidthColumn(ref this.dgvAsistencias, "Fecha");
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

    }
}
