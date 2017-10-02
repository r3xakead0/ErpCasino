using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmAsignarBonoList : Form
    {
        public FrmAsignarBonoList()
        {
            InitializeComponent();
        }

        #region Formulario

        private void FrmAsignarBonoList_ResizeEnd(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvBonos.DataSource != null)
                {
                    Util.AutoWidthColumn(ref this.dgvBonos, "EmpleadoNombreCompleto");
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void FrmAsignarBonoList_Load(object sender, EventArgs e)
        {
            try
            {

                this.CargarAnhos();
                this.CargarMes();

                this.cboAnho.SelectedValue = DateTime.Now.Year.ToString();
                this.cboMes.SelectedValue = DateTime.Now.Month.ToString();

                this.CargarListadoBonos();
                this.FormatoListadoBonos();

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void dgvBonos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;

                var uiBonoEmpleado = (BE.UI.BonoEmpleado)this.dgvBonos.CurrentRow.DataBoundItem;

                this.Editar(uiBonoEmpleado);

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
                this.CargarListadoBonos();

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
                //var frmBonoMant = new FrmAsignarBonoMant(this);
                //frmBonoMant.MdiParent = this.MdiParent;
                //frmBonoMant.Show();
                
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

                if (this.dgvBonos.CurrentRow != null)
                {
                    var uiBonoEmpleado = (BE.UI.BonoEmpleado)this.dgvBonos.CurrentRow.DataBoundItem;

                    this.Editar(uiBonoEmpleado);
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
                if (this.dgvBonos.CurrentRow != null)
                {

                    if (Util.ConfirmationMessage("¿Desea eliminar el Bono seleccionado?") == false)
                        return;

                    var uiBonoEmpleado = (BE.UI.BonoEmpleado)this.dgvBonos.CurrentRow.DataBoundItem;

                    //int idObservacion = uiBonoEmpleado.ID;
                    //bool rpta = new LN.BonoEmpleado().Eliminar(idObservacion);

                    //if (rpta == true)
                    //{
                    //    Util.InformationMessage("Se eliminó el Bono seleccionado");
                    //    this.CargarListadoBonos();
                    //}
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }


        #endregion

        #region Metodos

        private void Editar(BE.UI.BonoEmpleado uiBonoEmpleado)
        {
            try
            {
                //var frmBonoMant = new FrmAsignarBonoMant(this);
                //frmBonoMant.MdiParent = this.MdiParent;
                //frmBonoMant.Show();
                //frmBonoMant.Cargar(uiBonoEmpleado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void CargarListadoBonos()
        {
            try
            {

                int anho = int.Parse(this.cboAnho.SelectedValue.ToString());
                int mes = int.Parse(this.cboMes.SelectedValue.ToString());

                //var lstUiBonos = new LN.BonoEmpleado().Listar(anho, mes);
                var lstUiBonos = new List<BE.UI.BonoEmpleado>();

                var source = new BindingSource();
                source.DataSource = lstUiBonos;

                this.dgvBonos.DataSource = source;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FormatoListadoBonos()
        {
            try
            {
                Util.FormatDatagridview(ref this.dgvBonos);

                for (int col = 0; col < this.dgvBonos.Columns.Count; col++)
                    this.dgvBonos.Columns[col].Visible = false;

                this.dgvBonos.Columns["Fecha"].Visible = true;
                this.dgvBonos.Columns["Fecha"].HeaderText = "Fecha";
                this.dgvBonos.Columns["Fecha"].Width = 100;
                this.dgvBonos.Columns["Fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvBonos.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";

                this.dgvBonos.Columns["EmpleadoCodigo"].Visible = true;
                this.dgvBonos.Columns["EmpleadoCodigo"].HeaderText = "Codigo";
                this.dgvBonos.Columns["EmpleadoCodigo"].Width = 100;
                this.dgvBonos.Columns["EmpleadoCodigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvBonos.Columns["EmpleadoNombreCompleto"].Visible = true;
                this.dgvBonos.Columns["EmpleadoNombreCompleto"].HeaderText = "Empleado";
                this.dgvBonos.Columns["EmpleadoNombreCompleto"].Width = 200;
                this.dgvBonos.Columns["EmpleadoNombreCompleto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvBonos.Columns["BonoNombre"].Visible = true;
                this.dgvBonos.Columns["BonoNombre"].HeaderText = "Bono";
                this.dgvBonos.Columns["BonoNombre"].Width = 100;
                this.dgvBonos.Columns["BonoNombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgvBonos.Columns["Monto"].Visible = true;
                this.dgvBonos.Columns["Monto"].HeaderText = "Motivo";
                this.dgvBonos.Columns["Monto"].Width = 100;
                this.dgvBonos.Columns["Monto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dgvBonos.Columns["Monto"].DefaultCellStyle.Format = "N2";

                Util.AutoWidthColumn(ref this.dgvBonos, "EmpleadoNombreCompleto");
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
