using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmAsignarDescuentoList : Form
    {

        #region "Patron Singleton"

        private static FrmAsignarDescuentoList frmInstance = null;

        public static FrmAsignarDescuentoList Instance()
        {

            if (frmInstance == null || frmInstance.IsDisposed == true)
            {
                frmInstance = new FrmAsignarDescuentoList();
            }

            frmInstance.BringToFront();

            return frmInstance;
        }

        #endregion

        public FrmAsignarDescuentoList()
        {
            InitializeComponent();
        }

        #region Formulario

        private void FrmAsignarDescuentoList_ResizeEnd(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvDescuentos.DataSource != null)
                {
                    Util.AutoWidthColumn(ref this.dgvDescuentos, "EmpleadoNombreCompleto");
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void FrmAsignarDescuentoList_Load(object sender, EventArgs e)
        {
            try
            {

                this.CargarAnhos();
                this.CargarMes();

                this.cboAnho.SelectedValue = DateTime.Now.Year.ToString();
                this.cboMes.SelectedValue = DateTime.Now.Month.ToString();

                this.CargarEmpleados();

                this.CargarListadoDescuentos();
                this.FormatoListadoDescuentos();

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void dgvDescuentos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                var col = this.dgvDescuentos.Columns[e.ColumnIndex];
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

                this.dgvDescuentos.Sort(col, dir);
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void dgvDescuentos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;

                var uiDescuentoEmpleado = (BE.UI.DescuentoEmpleado)this.dgvDescuentos.CurrentRow.DataBoundItem;

                this.Editar(uiDescuentoEmpleado);

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
                this.CargarListadoDescuentos();

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
                var frmDescuentoMant = FrmAsignarDescuentoMant.Instance();
                frmDescuentoMant.MdiParent = this.MdiParent;
                frmDescuentoMant.Show();
                frmDescuentoMant.frmList = this;
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

                if (this.dgvDescuentos.CurrentRow != null)
                {
                    var uiDescuentoEmpleado = (BE.UI.DescuentoEmpleado)this.dgvDescuentos.CurrentRow.DataBoundItem;

                    this.Editar(uiDescuentoEmpleado);
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
                if (this.dgvDescuentos.CurrentRow != null)
                {

                    if (Util.ConfirmationMessage("¿Desea eliminar el descuento seleccionado?") == false)
                        return;

                    var uiDescuentoEmpleado = (BE.UI.DescuentoEmpleado)this.dgvDescuentos.CurrentRow.DataBoundItem;

                    int idObservacion = uiDescuentoEmpleado.ID;
                    bool rpta = new LN.DescuentoEmpleado().Eliminar(idObservacion);

                    if (rpta == true)
                    {
                        Util.InformationMessage("Se eliminó el descuento seleccionado");
                        this.CargarListadoDescuentos();
                    }
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Comma-separated Values (*.csv)|*.csv";
                sfd.FileName = "export.csv";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Util.PointerLoad(this);
                    Util.DatagridviewToCsv(this.dgvDescuentos, sfd.FileName);
                    Util.InformationMessage("Se exporto correctamente el archivo CSV");
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
            finally
            {
                Util.PointerReady(this);
            }
        }

        private void cboEmpleado_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (this.cboEmpleado.SelectedIndex > 0)
                {
                    string codigoEmpleado = this.cboEmpleado.SelectedValue.ToString().Trim();
                    this.txtEmpleadoCodigo.Text = codigoEmpleado;
                }
                else
                {
                    this.txtEmpleadoCodigo.Clear();
                }

                this.CargarListadoDescuentos();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }

        }

        private void txtEmpleadoCodigo_Leave(object sender, EventArgs e)
        {
            try
            {
                string codigoEmpleado = this.txtEmpleadoCodigo.Text.Trim();

                var lst = (List<BE.Record>)this.cboEmpleado.DataSource;

                if (lst.Where(x => x.Codigo == codigoEmpleado).Count() > 0)
                {
                    this.txtEmpleadoCodigo.Text = codigoEmpleado;
                    this.cboEmpleado.SelectedValue = codigoEmpleado;
                }
                else
                {
                    this.txtEmpleadoCodigo.Clear();
                    this.cboEmpleado.SelectedIndex = 0;
                }

                this.CargarListadoDescuentos();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }

        }

        #endregion

        #region Metodos

        private void Editar(BE.UI.DescuentoEmpleado uiDescuentoEmpleado)
        {
            try
            {
                var frmDescuentoMant = FrmAsignarDescuentoMant.Instance();
                frmDescuentoMant.MdiParent = this.MdiParent;
                frmDescuentoMant.Show();
                frmDescuentoMant.frmList = this;
                frmDescuentoMant.Cargar(uiDescuentoEmpleado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void CargarListadoDescuentos()
        {
            try
            {

                int anho = int.Parse(this.cboAnho.SelectedValue.ToString());
                int mes = int.Parse(this.cboMes.SelectedValue.ToString());

                var lstUiDescuentos = new LN.DescuentoEmpleado().Listar(anho, mes);
                var cntDescuentos = lstUiDescuentos.Count;
                var sumDescuentos = lstUiDescuentos.Sum(x => x.Monto);

                var sorted = new SortableBindingList<BE.UI.DescuentoEmpleado>(lstUiDescuentos);

                this.dgvDescuentos.DataSource = sorted;
                this.txtNroRegistros.Text = cntDescuentos.ToString();
                this.txtTotal.Text = sumDescuentos.ToString("N2");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FormatoListadoDescuentos()
        {
            try
            {
                Util.FormatDatagridview(ref this.dgvDescuentos);

                for (int col = 0; col < this.dgvDescuentos.Columns.Count; col++)
                    this.dgvDescuentos.Columns[col].Visible = false;

                this.dgvDescuentos.Columns["Fecha"].Visible = true;
                this.dgvDescuentos.Columns["Fecha"].HeaderText = "Fecha";
                this.dgvDescuentos.Columns["Fecha"].Width = 100;
                this.dgvDescuentos.Columns["Fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvDescuentos.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";

                this.dgvDescuentos.Columns["EmpleadoCodigo"].Visible = true;
                this.dgvDescuentos.Columns["EmpleadoCodigo"].HeaderText = "Codigo";
                this.dgvDescuentos.Columns["EmpleadoCodigo"].Width = 100;
                this.dgvDescuentos.Columns["EmpleadoCodigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvDescuentos.Columns["EmpleadoNombreCompleto"].Visible = true;
                this.dgvDescuentos.Columns["EmpleadoNombreCompleto"].HeaderText = "Empleado";
                this.dgvDescuentos.Columns["EmpleadoNombreCompleto"].Width = 200;
                this.dgvDescuentos.Columns["EmpleadoNombreCompleto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvDescuentos.Columns["DescuentoNombre"].Visible = true;
                this.dgvDescuentos.Columns["DescuentoNombre"].HeaderText = "Descuento";
                this.dgvDescuentos.Columns["DescuentoNombre"].Width = 200;
                this.dgvDescuentos.Columns["DescuentoNombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvDescuentos.Columns["Monto"].Visible = true;
                this.dgvDescuentos.Columns["Monto"].HeaderText = "Monto";
                this.dgvDescuentos.Columns["Monto"].Width = 100;
                this.dgvDescuentos.Columns["Monto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                this.dgvDescuentos.Columns["Monto"].DefaultCellStyle.Format = "N2";

                Util.AutoWidthColumn(ref this.dgvDescuentos, "EmpleadoNombreCompleto");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarEmpleados()
        {
            var lstEmpleados = new LN.Empleado().Combo();
            var lstCandidatos = new LN.Candidato().Combo();
            lstEmpleados.AddRange(lstCandidatos);
            var lstTrabajador = lstEmpleados.OrderBy(o => o.Codigo).Distinct().ToList();

            lstTrabajador.Insert(0, new BE.Record() { Codigo = "", Nombre = "Seleccione" });

            this.cboEmpleado.DataSource = lstTrabajador;
            this.cboEmpleado.DisplayMember = "Nombre";
            this.cboEmpleado.ValueMember = "Codigo";
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
