using System;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;
using System.Linq;
using System.ComponentModel;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmHorarioMensualMant : Form
    {

        #region "Patron Singleton"

        private static FrmHorarioMensualMant frmInstance = null;

        public static FrmHorarioMensualMant Instance()
        {

            if (frmInstance == null || frmInstance.IsDisposed == true)
            {
                frmInstance = new FrmHorarioMensualMant();
            }

            frmInstance.BringToFront();

            return frmInstance;
        }

        #endregion

        public FrmHorarioMensualList frmList = null;

        private List<BE.UI.Horario> lstUiHorarios = null;
        private int idSala = 0;

        public FrmHorarioMensualMant()
        {
            try
            {
                InitializeComponent();

                this.lstUiHorarios = new List<BE.UI.Horario>();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }

        }

        #region Metodos


        private void CargarSalas()
        {
            try
            {

                var lstBeSalas = new LN.Sala().ListaSimple();

                lstBeSalas.Insert(0, new BE.Sala() { IdSala = 0, Nombre = "Seleccione" });

                this.cboSala.DataSource = lstBeSalas;
                this.cboSala.DisplayMember = "Nombre";
                this.cboSala.ValueMember = "IdSala";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarHorarioMensual()
        {
            try
            {

                if (this.lstUiHorarios != null)
                {
                    this.lstUiHorarios = (from uiHorario in this.lstUiHorarios
                                         orderby uiHorario.Fecha, uiHorario.CargoId, uiHorario.Turno 
                                         select uiHorario).ToList();
                }

                //var source = new BindingSource();
                //source.DataSource = this.lstUiHorarios;
                //this.dgvHorarioMensual.DataSource = source;

                var sorted = new SortableBindingList<BE.UI.Horario>(this.lstUiHorarios);
                this.dgvHorarioMensual.DataSource = sorted;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void FormatoHorarioMensual()
        {
            try
            {
                Util.FormatDatagridview(ref this.dgvHorarioMensual);

                for (int i = 0; i < this.dgvHorarioMensual.Columns.Count; i++)
                    this.dgvHorarioMensual.Columns[i].Visible = false;

                this.dgvHorarioMensual.Columns["FechaHoraInicio"].Visible = true;
                this.dgvHorarioMensual.Columns["FechaHoraInicio"].HeaderText = "Fecha Hora Inicial";
                this.dgvHorarioMensual.Columns["FechaHoraInicio"].Width = 120;
                this.dgvHorarioMensual.Columns["FechaHoraInicio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvHorarioMensual.Columns["FechaHoraInicio"].DefaultCellStyle.Format = "dd/MM/yyyy - HH:mm";

                this.dgvHorarioMensual.Columns["FechaHoraFinal"].Visible = true;
                this.dgvHorarioMensual.Columns["FechaHoraFinal"].HeaderText = "Fecha Hora Final";
                this.dgvHorarioMensual.Columns["FechaHoraFinal"].Width = 120;
                this.dgvHorarioMensual.Columns["FechaHoraFinal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvHorarioMensual.Columns["FechaHoraFinal"].DefaultCellStyle.Format = "dd/MM/yyyy - HH:mm";

                this.dgvHorarioMensual.Columns["EmpleadoCodigo"].Visible = true;
                this.dgvHorarioMensual.Columns["EmpleadoCodigo"].HeaderText = "Codigo";
                this.dgvHorarioMensual.Columns["EmpleadoCodigo"].Width = 80;
                this.dgvHorarioMensual.Columns["EmpleadoCodigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvHorarioMensual.Columns["EmpleadoNombreCompleto"].Visible = true;
                this.dgvHorarioMensual.Columns["EmpleadoNombreCompleto"].HeaderText = "Empleado";
                this.dgvHorarioMensual.Columns["EmpleadoNombreCompleto"].Width = 200;
                this.dgvHorarioMensual.Columns["EmpleadoNombreCompleto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvHorarioMensual.Columns["CargoNombre"].Visible = true;
                this.dgvHorarioMensual.Columns["CargoNombre"].HeaderText = "Cargo";
                this.dgvHorarioMensual.Columns["CargoNombre"].Width = 150;
                this.dgvHorarioMensual.Columns["CargoNombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvHorarioMensual.Columns["Fecha"].Visible = true;
                this.dgvHorarioMensual.Columns["Fecha"].Width = 100;
                this.dgvHorarioMensual.Columns["Fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvHorarioMensual.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";

                this.dgvHorarioMensual.Columns["DiaNombre"].Visible = true;
                this.dgvHorarioMensual.Columns["DiaNombre"].HeaderText = "Dia";
                this.dgvHorarioMensual.Columns["DiaNombre"].Width = 70;
                this.dgvHorarioMensual.Columns["DiaNombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgvHorarioMensual.Columns["Turno"].Visible = true;
                this.dgvHorarioMensual.Columns["Turno"].HeaderText = "Turno";
                this.dgvHorarioMensual.Columns["Turno"].Width = 50;
                this.dgvHorarioMensual.Columns["Turno"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgvHorarioMensual.Columns["Horas"].Visible = true;
                this.dgvHorarioMensual.Columns["Horas"].HeaderText = "Horas";
                this.dgvHorarioMensual.Columns["Horas"].Width = 50;
                this.dgvHorarioMensual.Columns["Horas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                Util.AutoWidthColumn(ref this.dgvHorarioMensual, "EmpleadoNombreCompleto");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarArchivo (string rutaArchivo)
        {
            try
            {

                this.lstUiHorarios.Clear();

                using (var fs = File.OpenRead(rutaArchivo))
                using (var reader = new StreamReader(fs))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();

                        BE.UI.Horario uiHorario = this.CSVtoUI(line);

                        this.lstUiHorarios.Add(uiHorario);
                    }
                }

                this.CargarHorarioMensual();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<BE.Record> ListadoTrabajadores()
        {
            try
            {
                var lstEmpleados = new LN.Empleado().Combo();
                var lstCandidatos = new LN.Candidato().Combo();

                lstEmpleados.AddRange(lstCandidatos);

                var lstTrabajadores = lstEmpleados.OrderBy(o => o.Nombre).Distinct().ToList();

                return lstTrabajadores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
   

        private BE.UI.Horario CSVtoUI (string line, char separator = ',')
        {
            try
            {
                BE.UI.Horario uiHorario = null;
              
                #region Obtener datos de la fila

                var values = line.Split(separator);

                string nomCargo = values[0].ToString();
                string codEmpleado = values[1].ToString();
                DateTime fechaHorario = DateTime.ParseExact(values[2].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                byte numDia = (byte)fechaHorario.DayOfWeek;
                DateTime fechaHoraInicio = DateTime.ParseExact(values[3].ToString(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                DateTime fechaHoraFin = DateTime.ParseExact(values[4].ToString(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                byte horas = (byte)(fechaHoraFin - fechaHoraInicio).TotalHours;
                byte turno = byte.Parse(values[5].ToString());

                #endregion

                var lstUiCargos = new LN.Cargo().ListarCombo();
                var lstTrabajadores = this.ListadoTrabajadores();

                #region Cargar registro
                uiHorario = new BE.UI.Horario();

                uiHorario.IdHorario = 0;
                uiHorario.SalaId = this.idSala;
                uiHorario.Anho = fechaHorario.Year;
                uiHorario.Semana = (byte)Util.GetWeekNumber(fechaHorario);

                uiHorario.FechaHoraInicio = fechaHoraInicio;
                uiHorario.FechaHoraFinal = fechaHoraFin;

                var uiCargo = lstUiCargos.FirstOrDefault(x => x.Nombre.Equals(nomCargo));
                if (uiCargo != null)
                {
                    uiHorario.CargoId = uiCargo.Id;
                    uiHorario.CargoNombre = uiCargo.Nombre;
                }

                uiHorario.Fecha = fechaHorario;

                uiHorario.EmpleadoCodigo = codEmpleado;
                var beTrabajador = lstTrabajadores.FirstOrDefault(x => x.Codigo.Equals(codEmpleado));
                if (beTrabajador != null)
                    uiHorario.EmpleadoNombreCompleto = beTrabajador.Nombre;

                uiHorario.DiaNumero = numDia;
                uiHorario.DiaNombre = Util.GetNameOfDay(numDia);

                uiHorario.Turno = turno;
                uiHorario.Horas = horas;

                #endregion

                return uiHorario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        private void FrmHorarioMensualMant_Load(object sender, EventArgs e)
        {
            try
            {

                this.CargarSalas();

                this.CargarHorarioMensual();
                this.FormatoHorarioMensual();
                
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.lstUiHorarios.Count == 0)
                {
                    throw new Exception("No se cargo el horario mensual");
                }

                Util.PointerLoad(this);

                bool rpta = new LN.Horario().Insertar(ref this.lstUiHorarios);

                if (rpta)
                {
                    Util.InformationMessage("Se guardo los datos del horario mensual");
                    this.frmList.CargarListadoHorarioMensual();
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

        private void btnArchivo_Click(object sender, EventArgs e)
        {
            try
            {

                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Archivo CSV (*.csv)|*.csv";
                dialog.InitialDirectory = @"C:\";
                dialog.Title = "Seleccione el archivo de carga";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    this.txtArchivo.Text = dialog.FileName;
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void BtnCargar_Click(object sender, EventArgs e)
        {
            try
            {

                #region Validaciones

                if (this.cboSala.SelectedIndex == 0)
                {
                    this.cboSala.Focus();
                    throw new Exception("Seleccione una sala");
                }

                if (this.txtArchivo.Text.Length == 0)
                {
                    this.btnArchivo.Focus();
                    throw new Exception("Seleccione un archivo de carga");
                }

                #endregion

                Util.PointerLoad(this);

                this.idSala = int.Parse(this.cboSala.SelectedValue.ToString());

                this.CargarArchivo(this.txtArchivo.Text);

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

        private void FrmHorarioMensualMant_ResizeEnd(object sender, EventArgs e)
        {
            try
            {
                Util.AutoWidthColumn(ref this.dgvHorarioMensual, "EmpleadoNombreCompleto");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void dgvHorarioMensual_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                var col = this.dgvHorarioMensual.Columns[e.ColumnIndex];
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

                this.dgvHorarioMensual.Sort(col, dir);
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }
    }
}
