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
    public partial class FrmHorarioMensualList : Form
    {

        #region "Patron Singleton"

        private static FrmHorarioMensualList frmInstance = null;

        public static FrmHorarioMensualList Instance()
        {

            if (frmInstance == null || frmInstance.IsDisposed == true)
            {
                frmInstance = new FrmHorarioMensualList();
            }

            frmInstance.BringToFront();

            return frmInstance;
        }

        #endregion

        public FrmHorarioMensualList()
        {
            InitializeComponent();
        }

        #region Formulario
        private void FrmHorarioMensualList_Load(object sender, EventArgs e)
        {
            try
            {
                this.CargarSalas();

                this.CargarListadoHorarioMensual();
                this.FormatoListadoHorarioMensual();
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
                var frmHorarioNew = FrmHorarioMensualMant.Instance();
                frmHorarioNew.MdiParent = this.MdiParent;
                frmHorarioNew.Show();
                frmHorarioNew.frmList = this;
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
                if (this.dgvHorariosMensuales.CurrentRow != null)
                {

                    if (Util.ConfirmationMessage("¿Desea eliminar al Horario mensual seleccionado?") == false)
                        return;

                    var uiHorarioMensual = (BE.UI.HorarioMensual)this.dgvHorariosMensuales.CurrentRow.DataBoundItem;

                    new LN.Horario().EliminarMes(uiHorarioMensual);

                    this.CargarListadoHorarioMensual();
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }
        #endregion


        public void CargarListadoHorarioMensual(int idSala = 0)
        {
            try
            {
                var lstHorarios = new LN.Horario().ListarResumenMensual(idSala);

                var source = new BindingSource();
                source.DataSource = lstHorarios;

                this.dgvHorariosMensuales.DataSource = lstHorarios;

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

        private void FormatoListadoHorarioMensual()
        {
            try
            {
                Util.FormatDatagridview(ref this.dgvHorariosMensuales);

                for (int i = 0; i < this.dgvHorariosMensuales.Columns.Count; i++)
                    this.dgvHorariosMensuales.Columns[i].Visible = false;

                this.dgvHorariosMensuales.Columns["Anho"].Visible = true;
                this.dgvHorariosMensuales.Columns["Anho"].HeaderText = "Año";
                this.dgvHorariosMensuales.Columns["Anho"].Width = 50;
                this.dgvHorariosMensuales.Columns["Anho"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgvHorariosMensuales.Columns["MesNombre"].Visible = true;
                this.dgvHorariosMensuales.Columns["MesNombre"].HeaderText = "Mes";
                this.dgvHorariosMensuales.Columns["MesNombre"].Width = 100;
                this.dgvHorariosMensuales.Columns["MesNombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgvHorariosMensuales.Columns["SalaNombre"].Visible = true;
                this.dgvHorariosMensuales.Columns["SalaNombre"].HeaderText = "Sala";
                this.dgvHorariosMensuales.Columns["SalaNombre"].Width = 150;
                this.dgvHorariosMensuales.Columns["SalaNombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                Util.AutoWidthColumn(ref this.dgvHorariosMensuales, "SalaNombre");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FrmHorarioMensualList_ResizeEnd(object sender, EventArgs e)
        {
            try
            {

                Util.AutoWidthColumn(ref this.dgvHorariosMensuales, "SalaNombre");
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

                this.CargarListadoHorarioMensual(idSala);
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

    }
}
