﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
                    Util.AutoWidthColumn(ref this.dgvObservaciones, "EmpleadoNombreCompleto");
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

                this.CargarEmpleados();

                this.CargarListadoObservaciones();
                this.FormatoListadoObservaciones();

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void dgvObservaciones_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                var col = this.dgvObservaciones.Columns[e.ColumnIndex];
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

                this.dgvObservaciones.Sort(col, dir);
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void dgvObservaciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
                    Util.DatagridviewToCsv(this.dgvObservaciones, sfd.FileName);
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

                this.CargarListadoObservaciones();
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

                this.CargarListadoObservaciones();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }

        }

        #endregion

        #region Metodos

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

                var lstUiObservaciones = new LN.ObservacionEmpleado().Listar(anho, mes);

                var sorted = new SortableBindingList<BE.UI.ObservacionEmpleado>(lstUiObservaciones);

                this.dgvObservaciones.DataSource = sorted;

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
