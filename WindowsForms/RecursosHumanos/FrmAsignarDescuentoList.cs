﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmAsignarDescuentoList : Form
    {
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

                this.CargarListadoDescuentos();
                this.FormatoListadoDescuentos();

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
                var frmDescuentoMant = new FrmAsignarDescuentoMant(this);
                frmDescuentoMant.MdiParent = this.MdiParent;
                frmDescuentoMant.Show();
                
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


        #endregion

        #region Metodos

        private void Editar(BE.UI.DescuentoEmpleado uiDescuentoEmpleado)
        {
            try
            {
                var frmDescuentoMant = new FrmAsignarDescuentoMant(this);
                frmDescuentoMant.MdiParent = this.MdiParent;
                frmDescuentoMant.Show();
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

                var source = new BindingSource();
                source.DataSource = lstUiDescuentos;

                this.dgvDescuentos.DataSource = source;

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
                this.dgvDescuentos.Columns["DescuentoNombre"].Width = 100;
                this.dgvDescuentos.Columns["DescuentoNombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgvDescuentos.Columns["Monto"].Visible = true;
                this.dgvDescuentos.Columns["Monto"].HeaderText = "Motivo";
                this.dgvDescuentos.Columns["Monto"].Width = 100;
                this.dgvDescuentos.Columns["Monto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dgvDescuentos.Columns["Monto"].DefaultCellStyle.Format = "N2";

                Util.AutoWidthColumn(ref this.dgvDescuentos, "EmpleadoNombreCompleto");
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