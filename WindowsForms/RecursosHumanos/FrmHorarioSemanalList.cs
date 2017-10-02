using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;

using System.Data;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmHorarioSemanalList : Form
    {

        public FrmHorarioSemanalList()
        {
            InitializeComponent();
        }

        #region Formulario
        private void FrmHorarioSemanalList_Load(object sender, EventArgs e)
        {
            try
            {

                this.CargarSalas();
                this.CargarListadoHorarios();
                
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
                var frmHorarioNew = new FrmHorarioSemanalMant(this);
                frmHorarioNew.MdiParent = this.MdiParent;
                frmHorarioNew.Show();
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

                if (this.dgvHorarios.CurrentRow != null)
                {

                    var frmHorarioEdit = new FrmHorarioSemanalMant(this);
                    frmHorarioEdit.MdiParent = this.MdiParent;
                    frmHorarioEdit.Show();

                    var uiHorarioSemanal = (BE.UI.HorarioSemanal)this.dgvHorarios.CurrentRow.DataBoundItem;

                    frmHorarioEdit.cboAnho.SelectedValue = uiHorarioSemanal.Anho.ToString();
                    frmHorarioEdit.cboSemana.SelectedValue = uiHorarioSemanal.Semana.ToString();
                    frmHorarioEdit.cboSala.SelectedValue = uiHorarioSemanal.SalaId;
                    frmHorarioEdit.CargarRangoFechas(uiHorarioSemanal.Anho, uiHorarioSemanal.Semana);

                    frmHorarioEdit.Cargar(uiHorarioSemanal);

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
                if (this.dgvHorarios.CurrentRow != null)
                {

                    if (Util.ConfirmationMessage("¿Desea eliminar al Horario seleccionado?") == false)
                        return;

                    var uiHorarioSemanal = (BE.UI.HorarioSemanal)this.dgvHorarios.CurrentRow.DataBoundItem;

                    new LN.Horario().EliminarMes(uiHorarioSemanal);

                    this.CargarListadoHorarios();
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }
        #endregion


        public void CargarListadoHorarios(int idSala = 0)
        {
            try
            {
                var lstHorarios = new LN.Horario().ListarResumenSemanal(idSala);

                BindingSource source = new BindingSource();
                source.DataSource = lstHorarios;
                this.dgvHorarios.DataSource = lstHorarios;

                this.FormatoListadoHorarios();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarSalas()
        {
            var lstSalas = new LN.Sala().ListaSimple();

            lstSalas.Insert(0, new BE.Sala() { IdSala = 0, Nombre = "Todas" });

            this.cboSala.DataSource = lstSalas;
            this.cboSala.DisplayMember = "Nombre";
            this.cboSala.ValueMember = "IdSala";
        }

        private void FormatoListadoHorarios()
        {
            try
            {
                Util.FormatDatagridview(ref this.dgvHorarios);

                this.dgvHorarios.Columns["Anho"].Visible = true;
                this.dgvHorarios.Columns["Anho"].HeaderText = "Año";
                this.dgvHorarios.Columns["Anho"].Width = 50;
                this.dgvHorarios.Columns["Anho"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgvHorarios.Columns["Semana"].Visible = true;
                this.dgvHorarios.Columns["Semana"].HeaderText = "Semana";
                this.dgvHorarios.Columns["Semana"].Width = 50;
                this.dgvHorarios.Columns["Semana"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgvHorarios.Columns["SalaId"].Visible = false;

                this.dgvHorarios.Columns["SalaNombre"].Visible = true;
                this.dgvHorarios.Columns["SalaNombre"].HeaderText = "Sala";
                this.dgvHorarios.Columns["SalaNombre"].Width = 150;
                this.dgvHorarios.Columns["SalaNombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgvHorarios.Columns["FechaInicio"].Visible = true;
                this.dgvHorarios.Columns["FechaInicio"].HeaderText = "Fecha Inicio";
                this.dgvHorarios.Columns["FechaInicio"].Width = 80;
                this.dgvHorarios.Columns["FechaInicio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvHorarios.Columns["FechaInicio"].DefaultCellStyle.Format = "dd/MM/yyyy";

                this.dgvHorarios.Columns["FechaFinal"].Visible = true;
                this.dgvHorarios.Columns["FechaFinal"].HeaderText = "Fecha Final";
                this.dgvHorarios.Columns["FechaFinal"].Width = 80;
                this.dgvHorarios.Columns["FechaFinal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvHorarios.Columns["FechaFinal"].DefaultCellStyle.Format = "dd/MM/yyyy";

                Util.AutoWidthColumn(ref this.dgvHorarios, "SalaNombre");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FrmHorarioSemanalList_ResizeEnd(object sender, EventArgs e)
        {
            try
            {

                Util.AutoWidthColumn(ref this.dgvHorarios, "SalaNombre");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void cboSala_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                int idSala = int.Parse(this.cboSala.SelectedValue.ToString());
                this.CargarListadoHorarios(idSala);
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void dgvHorarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.RowIndex < 0)
                    return;

                var uiHorarioSemanal = (BE.UI.HorarioSemanal)this.dgvHorarios.Rows[e.RowIndex].DataBoundItem;

                var frmHorarioEdit = new FrmHorarioSemanalMant(this);
                frmHorarioEdit.MdiParent = this.MdiParent;
                frmHorarioEdit.Show();

                frmHorarioEdit.cboAnho.SelectedValue = uiHorarioSemanal.Anho.ToString();
                frmHorarioEdit.cboSemana.SelectedValue = uiHorarioSemanal.Semana.ToString();
                frmHorarioEdit.cboSala.SelectedValue = uiHorarioSemanal.SalaId;
                frmHorarioEdit.CargarRangoFechas(uiHorarioSemanal.Anho, uiHorarioSemanal.Semana);

                frmHorarioEdit.Cargar(uiHorarioSemanal);

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }
    }
}
