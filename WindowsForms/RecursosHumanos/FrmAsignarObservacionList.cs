using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmAsignarObservacionList : Form
    {

        #region "Patron Singleton"

        private static FrmAsignarObservacionList frmInstance = null;

        public static FrmAsignarObservacionList Instance()
        {

            if (frmInstance == null || frmInstance.IsDisposed == true)
            {
                frmInstance = new FrmAsignarObservacionList();
            }

            frmInstance.BringToFront();

            return frmInstance;
        }

        #endregion

        public FrmAsignarObservacionList()
        {
            InitializeComponent();
        }

        #region Formulario

        private void FrmAsignarObservacionList_ResizeEnd(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvObservaciones.DataSource != null)
                {
                    Util.AutoWidthColumn(ref this.dgvObservaciones, "NombreCompletoEmpleado");
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void FrmAsignarObservacionList_Load(object sender, EventArgs e)
        {
            try
            {

                this.CargarAnhos();
                this.CargarMes();

                this.cboAnho.SelectedValue = DateTime.Now.Year.ToString();
                this.cboMes.SelectedValue = DateTime.Now.Month.ToString();

                this.CargarListadoObservaciones();
                this.FormatoListadoObservaciones();

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void dgvAdelantos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;

                var uiObservacionEmpleado = (BE.UI.ObservacionEmpleado)this.dgvObservaciones.CurrentRow.DataBoundItem;

                this.Editar(uiObservacionEmpleado);

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
                this.CargarListadoObservaciones();

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
                var frmObservacionEmpleadoMant = FrmAsignarObservacionMant.Instance();
                frmObservacionEmpleadoMant.MdiParent = this.MdiParent;
                frmObservacionEmpleadoMant.Show();
                frmObservacionEmpleadoMant.frmList = this;

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

                if (this.dgvObservaciones.CurrentRow != null)
                {
                    var uiObservacionEmpleado = (BE.UI.ObservacionEmpleado)this.dgvObservaciones.CurrentRow.DataBoundItem;

                    this.Editar(uiObservacionEmpleado);
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
                if (this.dgvObservaciones.CurrentRow != null)
                {

                    if (Util.ConfirmationMessage("¿Desea eliminar la observación seleccionada?") == false)
                        return;

                    var uiObservacionEmpleado = (BE.UI.ObservacionEmpleado)this.dgvObservaciones.CurrentRow.DataBoundItem;

                    int idObservacion = uiObservacionEmpleado.ID;
                    bool rpta = new LN.ObservacionEmpleado().Eliminar(idObservacion);

                    if (rpta == true)
                    {
                        Util.InformationMessage("Se eliminó la observación seleccionada");
                        this.CargarListadoObservaciones();
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

        private void Editar(BE.UI.ObservacionEmpleado uiObservacionEmpleado)
        {
            try
            {
                var frmObservacionEmpleadoMant = FrmAsignarObservacionMant.Instance();
                frmObservacionEmpleadoMant.MdiParent = this.MdiParent;
                frmObservacionEmpleadoMant.Show();

                frmObservacionEmpleadoMant.frmList = this;
                frmObservacionEmpleadoMant.Cargar(uiObservacionEmpleado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void CargarListadoObservaciones()
        {
            try
            {

                int anho = int.Parse(this.cboAnho.SelectedValue.ToString());
                int mes = int.Parse(this.cboMes.SelectedValue.ToString());

                var lstAdelantos = new LN.ObservacionEmpleado().Listar(anho, mes);

                var source = new BindingSource();
                source.DataSource = lstAdelantos;

                this.dgvObservaciones.DataSource = source;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FormatoListadoObservaciones()
        {
            try
            {
                Util.FormatDatagridview(ref this.dgvObservaciones);

                for (int col = 0; col < this.dgvObservaciones.Columns.Count; col++)
                    this.dgvObservaciones.Columns[col].Visible = false;

                this.dgvObservaciones.Columns["Fecha"].Visible = true;
                this.dgvObservaciones.Columns["Fecha"].HeaderText = "Fecha";
                this.dgvObservaciones.Columns["Fecha"].Width = 100;
                this.dgvObservaciones.Columns["Fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvObservaciones.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";

                this.dgvObservaciones.Columns["EmpleadoCodigo"].Visible = true;
                this.dgvObservaciones.Columns["EmpleadoCodigo"].HeaderText = "Codigo";
                this.dgvObservaciones.Columns["EmpleadoCodigo"].Width = 100;
                this.dgvObservaciones.Columns["EmpleadoCodigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvObservaciones.Columns["EmpleadoNombreCompleto"].Visible = true;
                this.dgvObservaciones.Columns["EmpleadoNombreCompleto"].HeaderText = "Empleado";
                this.dgvObservaciones.Columns["EmpleadoNombreCompleto"].Width = 200;
                this.dgvObservaciones.Columns["EmpleadoNombreCompleto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvObservaciones.Columns["SalaNombre"].Visible = true;
                this.dgvObservaciones.Columns["SalaNombre"].HeaderText = "Sala";
                this.dgvObservaciones.Columns["SalaNombre"].Width = 100;
                this.dgvObservaciones.Columns["SalaNombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgvObservaciones.Columns["ObservacionNombre"].Visible = true;
                this.dgvObservaciones.Columns["ObservacionNombre"].HeaderText = "Observacion";
                this.dgvObservaciones.Columns["ObservacionNombre"].Width = 300;
                this.dgvObservaciones.Columns["ObservacionNombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                
                Util.AutoWidthColumn(ref this.dgvObservaciones, "EmpleadoNombreCompleto");
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
