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
    public partial class FrmHorarioSemanalVista : Form
    {

        public FrmHorarioSemanalVista()
        {
            InitializeComponent();
        }

        #region Formulario
        private void FrmHorarioSemanalVista_Load(object sender, EventArgs e)
        {
            try
            {

                this.CargarHorarioSemanal();
                this.FormatoHorarioSemanal();

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        #endregion


        public void CargarHorarioSemanal()
        {
            try
            {
                var lstHorarios = new LN.Horario().ListarResumenSemanal();

                BindingSource source = new BindingSource();
                source.DataSource = lstHorarios;
                this.dgvHorarioSemanal.DataSource = lstHorarios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FormatoHorarioSemanal()
        {
            try
            {
                Util.FormatDatagridview(ref this.dgvHorarioSemanal);

                for (int col = 0; col < this.dgvHorarioSemanal.Columns.Count; col++)
                    this.dgvHorarioSemanal.Columns[col].Visible = false;

                this.dgvHorarioSemanal.Columns["Anho"].Visible = true;
                this.dgvHorarioSemanal.Columns["Anho"].HeaderText = "Año";
                this.dgvHorarioSemanal.Columns["Anho"].Width = 50;
                this.dgvHorarioSemanal.Columns["Anho"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgvHorarioSemanal.Columns["Semana"].Visible = true;
                this.dgvHorarioSemanal.Columns["Semana"].HeaderText = "Año";
                this.dgvHorarioSemanal.Columns["Semana"].Width = 50;
                this.dgvHorarioSemanal.Columns["Semana"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgvHorarioSemanal.Columns["SalaId"].Visible = false;

                this.dgvHorarioSemanal.Columns["SalaNombre"].Visible = true;
                this.dgvHorarioSemanal.Columns["SalaNombre"].HeaderText = "Sala";
                this.dgvHorarioSemanal.Columns["SalaNombre"].Width = 150;
                this.dgvHorarioSemanal.Columns["SalaNombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgvHorarioSemanal.Columns["FechaInicio"].Visible = true;
                this.dgvHorarioSemanal.Columns["FechaInicio"].HeaderText = "Fecha Inicio";
                this.dgvHorarioSemanal.Columns["FechaInicio"].Width = 120;
                this.dgvHorarioSemanal.Columns["FechaInicio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvHorarioSemanal.Columns["FechaInicio"].DefaultCellStyle.Format = "dd/MM/yyyy";

                this.dgvHorarioSemanal.Columns["FechaFinal"].Visible = true;
                this.dgvHorarioSemanal.Columns["FechaFinal"].HeaderText = "Fecha Final";
                this.dgvHorarioSemanal.Columns["FechaFinal"].Width = 120;
                this.dgvHorarioSemanal.Columns["FechaFinal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvHorarioSemanal.Columns["FechaFinal"].DefaultCellStyle.Format = "dd/MM/yyyy";

                Util.AutoWidthColumn(ref this.dgvHorarioSemanal, "SalaNombre");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
