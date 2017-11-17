using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmReciboCalcular : Form
    {

        private int anho = DateTime.Now.Year;
        private int mes = DateTime.Now.Month;

        public FrmReciboCalcular()
        {
            try
            {
                InitializeComponent();
                
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }

        }

        #region Metodos
        
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

                this.CboAnho.DataSource = lstAnhos;
                this.CboAnho.DisplayMember = "Nombre";
                this.CboAnho.ValueMember = "Codigo";
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

                this.CbxMes.DataSource = lstMes;
                this.CbxMes.DisplayMember = "Nombre";
                this.CbxMes.ValueMember = "Codigo";

                this.CbxMes.SelectedValue = DateTime.Now.Month.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarListadoRecibos(int anho = 0, int mes = 0)
        {
            try
            {
                List<BE.UI.ReciboResumen> lstUiRecibosResumen = null;
                if (anho == 0 || mes == 0)
                {
                    lstUiRecibosResumen = new List<BE.UI.ReciboResumen>();
                    this.txtAnho.Clear();
                    this.txtMes.Clear();
                    this.txtNroRegistros.Text = "0";
                    this.txtTotalBonos.Text = "0.00";
                    this.txtTotalDescuentos.Text = "0.00";
                }
                else
                {
                    lstUiRecibosResumen = new LN.Recibo().Resumen(anho, mes);

                    this.anho = anho;
                    this.mes = mes;

                    this.txtAnho.Text = anho.ToString();
                    this.txtMes.Text = mes.ToString();
                    this.txtNroRegistros.Text = lstUiRecibosResumen.Count.ToString();
                    this.txtTotalBonos.Text = lstUiRecibosResumen.Sum(o => o.TotalBonos).ToString("N2");
                    this.txtTotalDescuentos.Text = lstUiRecibosResumen.Sum(o => o.TotalDescuentos).ToString("N2");
                }

                var sorted = new SortableBindingList<BE.UI.ReciboResumen>(lstUiRecibosResumen);

                this.dgvRecibos.DataSource = sorted;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FormatoListadoRecibos()
        {
            try
            {

                Util.FormatDatagridview(ref this.dgvRecibos);

                for (int i = 0; i < this.dgvRecibos.Columns.Count; i++)
                    this.dgvRecibos.Columns[i].Visible = false;

                this.dgvRecibos.Columns["EmpleadoCodigo"].Visible = true;
                this.dgvRecibos.Columns["EmpleadoCodigo"].HeaderText = "Codigo";
                this.dgvRecibos.Columns["EmpleadoCodigo"].Width = 100;
                this.dgvRecibos.Columns["EmpleadoCodigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvRecibos.Columns["EmpleadoNombreCompleto"].Visible = true;
                this.dgvRecibos.Columns["EmpleadoNombreCompleto"].HeaderText = "Empleado";
                this.dgvRecibos.Columns["EmpleadoNombreCompleto"].Width = 100;
                this.dgvRecibos.Columns["EmpleadoNombreCompleto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvRecibos.Columns["TotalBonos"].Visible = true;
                this.dgvRecibos.Columns["TotalBonos"].HeaderText = "Bono";
                this.dgvRecibos.Columns["TotalBonos"].Width = 100;
                this.dgvRecibos.Columns["TotalBonos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvRecibos.Columns["TotalBonos"].DefaultCellStyle.Format = "N2";

                this.dgvRecibos.Columns["TotalDescuentos"].Visible = true;
                this.dgvRecibos.Columns["TotalDescuentos"].HeaderText = "Descuento";
                this.dgvRecibos.Columns["TotalDescuentos"].Width = 100;
                this.dgvRecibos.Columns["TotalDescuentos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvRecibos.Columns["TotalDescuentos"].DefaultCellStyle.Format = "N2";

                Util.AutoWidthColumn(ref this.dgvRecibos, "EmpleadoNombreCompleto");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        

        #endregion

        #region Formulario

        private void FrmReciboCalcular_Load(object sender, EventArgs e)
        {
            try
            {

                this.CargarAnhos();
                this.CargarMes();

                this.CboAnho.SelectedValue = DateTime.Now.Year.ToString();
                this.CbxMes.SelectedValue = DateTime.Now.Month.ToString();
                
                this.CargarListadoRecibos();
                this.FormatoListadoRecibos();

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void FrmReciboCalcular_ResizeEnd(object sender, EventArgs e)
        {
            try
            {
                Util.AutoWidthColumn(ref this.dgvRecibos, "EmpleadoNombreCompleto");
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
                var rpta = Util.ConfirmationMessage($"¿Desea salir del formulario { this.Text }?");

                if (rpta == false)
                    return;

                this.Close();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {

                Util.PointerLoad(this);

                var lnRecibo = new LN.Recibo();

                if (lnRecibo.Existe(this.anho, this.mes) == true)
                    throw new Exception("Ya se genero los recibos para este periodo");

                if (Util.ConfirmationMessage("¿Desea generar los recibos para este periodo?") == false)
                    return;

                bool rpta = lnRecibo.Generar(this.anho, this.mes);

                if (rpta)
                {
                    Util.InformationMessage("Se generó los recibos correctamente");
                    this.Close();
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                int anho = int.Parse(this.CboAnho.SelectedValue.ToString());
                int mes = int.Parse(this.CbxMes.SelectedValue.ToString());

                this.CargarListadoRecibos(anho, mes);
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvRecibos.CurrentRow != null)
                {
                    var uiReciboResumen = (BE.UI.ReciboResumen)this.dgvRecibos.CurrentRow.DataBoundItem;

                    var frmReciboDetalle = new FrmReciboDetalle();
                    frmReciboDetalle.MdiParent = this.MdiParent;
                    frmReciboDetalle.Show();
                    frmReciboDetalle.Cargar(uiReciboResumen.Anho, uiReciboResumen.Mes, uiReciboResumen.EmpleadoCodigo);
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void dgvRecibos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;

                var uiReciboResumen = (BE.UI.ReciboResumen)this.dgvRecibos.CurrentRow.DataBoundItem;

                var frmReciboDetalle = new FrmReciboDetalle();
                frmReciboDetalle.MdiParent = this.MdiParent;
                frmReciboDetalle.Show();

                frmReciboDetalle.Cargar(uiReciboResumen.Anho, 
                    uiReciboResumen.Mes, 
                    uiReciboResumen.EmpleadoCodigo);
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void btnExportarAsistenciasCsv_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Comma-separated Values (*.csv)|*.csv";
                sfd.FileName = "export.csv";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Util.PointerLoad(this);
                    Util.DatagridviewToCsv(this.dgvRecibos, sfd.FileName);
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

        #endregion

    }
}
