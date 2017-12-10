using System;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmInasistenciaList : Form
    {
        public FrmInasistenciaList()
        {
            InitializeComponent();
        }

        #region Formulario
        private void FrmInasistenciaList_Load(object sender, EventArgs e)
        {
            try
            {

                this.CargarAnhos();
                this.CargarMes();
                this.CargarSalas();

                this.cboAnho.SelectedValue = DateTime.Now.Year.ToString();
                this.cboMes.SelectedValue = DateTime.Now.Month.ToString();

                this.CargarListadoInasistencias();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void FrmInasistenciaList_ResizeEnd(object sender, EventArgs e)
        {
            try
            {
                Util.AutoWidthColumn(ref this.dgvInasistencias, "EmpleadoNombreCompleto");
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
                    Util.DatagridviewToCsv(this.dgvInasistencias, sfd.FileName);
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

        private void CboAnhoMesSala_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (this.cboAnho.Items.Count == 0 || this.cboMes.Items.Count == 0)
                    return;

                int anho = int.Parse(this.cboAnho.SelectedValue.ToString());
                int mes = int.Parse(this.cboMes.SelectedValue.ToString());
                int sala = int.Parse(this.cboSala.SelectedValue.ToString());

                this.CargarListadoInasistencias(anho, mes, sala);
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void btnClasificar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Clasificar();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void dgvInasistencias_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.Clasificar();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        #endregion

        private void Clasificar()
        {
            try
            {

                if (this.dgvInasistencias.CurrentRow != null)
                {
                    var uiInasistencia = (BE.UI.Inasistencia)this.dgvInasistencias.CurrentRow.DataBoundItem;
                 
                    var frmInasistencia = new FrmInasistenciaMant(this);
                    frmInasistencia.MdiParent = this.MdiParent;
                    frmInasistencia.Show();

                    frmInasistencia.Cargar(uiInasistencia);
                }
            
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

                this.cboAnho.SelectedValue = DateTime.Now.Year.ToString();
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

                this.cboMes.SelectedValue = DateTime.Now.Month.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CargarListadoInasistencias()
        {
            try
            {
                int anho = int.Parse(this.cboAnho.SelectedValue.ToString());
                int mes = int.Parse(this.cboMes.SelectedValue.ToString());
                int sala = int.Parse(this.cboSala.SelectedValue.ToString());

                this.CargarListadoInasistencias(anho, mes, sala);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void CargarListadoInasistencias(int anho, int mes, int idSala)
        {
            try
            {
                var lstUiInasistencias = new LN.Inasistencia().Listar(anho, mes, idSala);

                var sorted = new SortableBindingList<BE.UI.Inasistencia>(lstUiInasistencias);
               
                this.dgvInasistencias.DataSource = sorted;

                this.FormatoListadoInasistencias();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FormatoListadoInasistencias()
        {
            try
            {
                Util.FormatDatagridview(ref this.dgvInasistencias);

                this.dgvInasistencias.Columns["Id"].Visible = false;
                this.dgvInasistencias.Columns["Anho"].Visible = false;
                this.dgvInasistencias.Columns["MesId"].Visible = false;
                this.dgvInasistencias.Columns["MesNombre"].Visible = false;
                this.dgvInasistencias.Columns["Semana"].Visible = false;

                this.dgvInasistencias.Columns["SalaId"].Visible = false;

                this.dgvInasistencias.Columns["SalaNombre"].Visible = true;
                this.dgvInasistencias.Columns["SalaNombre"].HeaderText = "Sala";
                this.dgvInasistencias.Columns["SalaNombre"].Width = 100;
                this.dgvInasistencias.Columns["SalaNombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgvInasistencias.Columns["CargoId"].Visible = false;

                this.dgvInasistencias.Columns["CargoNombre"].Visible = true;
                this.dgvInasistencias.Columns["CargoNombre"].HeaderText = "Cargo";
                this.dgvInasistencias.Columns["CargoNombre"].Width = 100;
                this.dgvInasistencias.Columns["CargoNombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgvInasistencias.Columns["EmpleadoCodigo"].Visible = false;

                this.dgvInasistencias.Columns["EmpleadoNombreCompleto"].Visible = true;
                this.dgvInasistencias.Columns["EmpleadoNombreCompleto"].HeaderText = "Empleado";
                this.dgvInasistencias.Columns["EmpleadoNombreCompleto"].Width = 150;
                this.dgvInasistencias.Columns["EmpleadoNombreCompleto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgvInasistencias.Columns["Fecha"].Visible = true;
                this.dgvInasistencias.Columns["Fecha"].HeaderText = "Fecha";
                this.dgvInasistencias.Columns["Fecha"].Width = 80;
                this.dgvInasistencias.Columns["Fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvInasistencias.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";

                this.dgvInasistencias.Columns["DiaNumero"].Visible = false;

                this.dgvInasistencias.Columns["DiaNombre"].Visible = true;
                this.dgvInasistencias.Columns["DiaNombre"].HeaderText = "Dia";
                this.dgvInasistencias.Columns["DiaNombre"].Width = 70;
                this.dgvInasistencias.Columns["DiaNombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgvInasistencias.Columns["Turno"].Visible = true;
                this.dgvInasistencias.Columns["Turno"].HeaderText = "Turno";
                this.dgvInasistencias.Columns["Turno"].Width = 40;
                this.dgvInasistencias.Columns["Turno"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgvInasistencias.Columns["FechaHoraInicio"].Visible = true;
                this.dgvInasistencias.Columns["FechaHoraInicio"].HeaderText = "Fecha Hora Inicio";
                this.dgvInasistencias.Columns["FechaHoraInicio"].Width = 120;
                this.dgvInasistencias.Columns["FechaHoraInicio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvInasistencias.Columns["FechaHoraInicio"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

                this.dgvInasistencias.Columns["FechaHoraFinal"].Visible = true;
                this.dgvInasistencias.Columns["FechaHoraFinal"].HeaderText = "Fecha Hora Final";
                this.dgvInasistencias.Columns["FechaHoraFinal"].Width = 120;
                this.dgvInasistencias.Columns["FechaHoraFinal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvInasistencias.Columns["FechaHoraFinal"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

                this.dgvInasistencias.Columns["Horas"].Visible = true;
                this.dgvInasistencias.Columns["Horas"].HeaderText = "Horas";
                this.dgvInasistencias.Columns["Horas"].Width = 40;
                this.dgvInasistencias.Columns["Horas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgvInasistencias.Columns["TipoCodigo"].Visible = false;

                this.dgvInasistencias.Columns["TipoNombre"].Visible = true;
                this.dgvInasistencias.Columns["TipoNombre"].HeaderText = "Tipo";
                this.dgvInasistencias.Columns["TipoNombre"].Width = 100;
                this.dgvInasistencias.Columns["TipoNombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgvInasistencias.Columns["Asunto"].Visible = false;
                this.dgvInasistencias.Columns["Detalle"].Visible = false;
                this.dgvInasistencias.Columns["Certificado"].Visible = false;

                Util.AutoWidthColumn(ref this.dgvInasistencias, "EmpleadoNombreCompleto");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
