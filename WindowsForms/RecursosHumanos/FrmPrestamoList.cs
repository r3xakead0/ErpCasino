using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;
using System.Linq;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmPrestamoList : Form
    {
        public FrmPrestamoList()
        {
            InitializeComponent();
        }

        #region Formulario
        private void FrmPrestamoList_Load(object sender, EventArgs e)
        {
            try
            {

                this.CargarAnhos();
                this.CargarMes();

                this.cboAnho.SelectedValue = DateTime.Now.Year.ToString();
                this.cboMes.SelectedValue = DateTime.Now.Month.ToString();

                this.CargarListadoPrestamos();
                this.FormatoListadoPrestamos();

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void FrmPrestamoList_ResizeEnd(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvPrestamos.DataSource != null)
                {
                    Util.AutoWidthColumn(ref this.dgvPrestamos, "NombreCompletoEmpleado");
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void dgvPrestamos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;

                var uiPrestamo = (BE.UI.Prestamo)this.dgvPrestamos.CurrentRow.DataBoundItem;

                this.Editar(uiPrestamo);

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
                this.CargarListadoPrestamos();
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
                var frmPrestamoMant = new FrmPrestamoMant(this);
                frmPrestamoMant.MdiParent = this.MdiParent;
                frmPrestamoMant.Show();
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

                if (this.dgvPrestamos.CurrentRow != null)
                {
                    var uiPrestamo = (BE.UI.Prestamo)this.dgvPrestamos.CurrentRow.DataBoundItem;

                    this.Editar(uiPrestamo);
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
                if (this.dgvPrestamos.CurrentRow != null)
                {

                    if (Util.ConfirmationMessage("¿Desea eliminar al prestamo seleccionado?") == false)
                        return;

                    var uiAdelato = (BE.UI.Prestamo)this.dgvPrestamos.CurrentRow.DataBoundItem;

                    int idPrestamo = uiAdelato.IdPrestamo;
                    bool rpta = new LN.Prestamo().Eliminar(idPrestamo);

                    if (rpta == true)
                    {
                        Util.InformationMessage("Se eliminó el prestamo");
                        this.CargarListadoPrestamos();
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

        private void Editar(BE.UI.Prestamo uiPrestamo)
        {
            try
            {
                var frmPrestamoMant = new FrmPrestamoMant(this);
                frmPrestamoMant.MdiParent = this.MdiParent;
                frmPrestamoMant.Show();
                frmPrestamoMant.Cargar(uiPrestamo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void CargarListadoPrestamos()
        {
            try
            {
                int anho = int.Parse(this.cboAnho.SelectedValue.ToString());
                int mes = int.Parse(this.cboMes.SelectedValue.ToString());

                var lstUiPrestamos = new LN.Prestamo().ListarSinCuotas(anho, mes);

                var source = new BindingSource();
                source.DataSource = lstUiPrestamos;

                this.dgvPrestamos.DataSource = source;

                int nroRegistros = lstUiPrestamos.Count;
                double totalAdelantos = lstUiPrestamos.Sum(x => x.Monto);

                this.txtNroRegistros.Text = nroRegistros.ToString();
                this.txtTotalPrestamos.Text = totalAdelantos.ToString("N2");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FormatoListadoPrestamos()
        {
            try
            {
                Util.FormatDatagridview(ref this.dgvPrestamos);

                for (int col = 0; col < this.dgvPrestamos.Columns.Count; col++)
                    this.dgvPrestamos.Columns[col].Visible = false;

                this.dgvPrestamos.Columns["Fecha"].Visible = true;
                this.dgvPrestamos.Columns["Fecha"].HeaderText = "Fecha";
                this.dgvPrestamos.Columns["Fecha"].Width = 100;
                this.dgvPrestamos.Columns["Fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvPrestamos.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";

                this.dgvPrestamos.Columns["CodigoEmpleado"].Visible = true;
                this.dgvPrestamos.Columns["CodigoEmpleado"].HeaderText = "Codigo";
                this.dgvPrestamos.Columns["CodigoEmpleado"].Width = 100;
                this.dgvPrestamos.Columns["CodigoEmpleado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvPrestamos.Columns["NombreCompletoEmpleado"].Visible = true;
                this.dgvPrestamos.Columns["NombreCompletoEmpleado"].HeaderText = "Empleado";
                this.dgvPrestamos.Columns["NombreCompletoEmpleado"].Width = 100;
                this.dgvPrestamos.Columns["NombreCompletoEmpleado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvPrestamos.Columns["Monto"].Visible = true;
                this.dgvPrestamos.Columns["Monto"].HeaderText = "Monto";
                this.dgvPrestamos.Columns["Monto"].Width = 100;
                this.dgvPrestamos.Columns["Monto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvPrestamos.Columns["Monto"].DefaultCellStyle.Format = "N2";
                
                this.dgvPrestamos.Columns["NumeroCuotas"].Visible = true;
                this.dgvPrestamos.Columns["NumeroCuotas"].HeaderText = "Cuotas";
                this.dgvPrestamos.Columns["NumeroCuotas"].Width = 100;
                this.dgvPrestamos.Columns["NumeroCuotas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                this.dgvPrestamos.Columns["Pagado"].Visible = true;
                this.dgvPrestamos.Columns["Pagado"].HeaderText = "Pagado";
                this.dgvPrestamos.Columns["Pagado"].Width = 50;
                this.dgvPrestamos.Columns["Pagado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                Util.AutoWidthColumn(ref this.dgvPrestamos, "NombreCompletoEmpleado");
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
