using System;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;
using System.Linq;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmHorarioAsignarBonos : Form
    {

        public FrmHorarioMensualList frmList = null;

        private List<BE.UI.Horario> lstUiHorarios = null;
        private int idSala = 0;

        public FrmHorarioAsignarBonos()
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

                var sourceRegistros = new BindingSource();
                sourceRegistros.DataSource = this.lstUiHorarios;

                this.dgvHorarioMensual.DataSource = sourceRegistros;
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
            catch (Exception)
            {

                throw;
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

                int idCargo = int.Parse(values[0].ToString());
                string codEmpleado = values[1].ToString();
                DateTime fechaHorario = DateTime.ParseExact(values[2].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                byte numDia = (byte)fechaHorario.DayOfWeek;
                DateTime fechaHoraInicio = DateTime.ParseExact(values[3].ToString(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                DateTime fechaHoraFin = DateTime.ParseExact(values[4].ToString(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                byte horas = (byte)(fechaHoraFin - fechaHoraInicio).TotalHours;
                byte turno = byte.Parse(values[5].ToString());

                #endregion

                var lstBeCargos = new LN.Cargo().ListarCombo();
                var lstTrabajadores = this.ListadoTrabajadores();

                #region Cargar registro
                uiHorario = new BE.UI.Horario();

                uiHorario.IdHorario = 0;
                uiHorario.SalaId = this.idSala;
                uiHorario.Anho = fechaHorario.Year;
                uiHorario.Semana = (byte)Util.GetWeekNumber(fechaHorario);

                uiHorario.FechaHoraInicio = fechaHoraInicio;
                uiHorario.FechaHoraFinal = fechaHoraFin;

                uiHorario.CargoId = idCargo;
                var beCargo = lstBeCargos.SingleOrDefault(x => x.IdCargo == idCargo);
                if (beCargo != null)
                    uiHorario.CargoNombre = beCargo.Nombre;

                uiHorario.Fecha = fechaHorario;

                uiHorario.EmpleadoCodigo = codEmpleado;
                var beTrabajador = lstTrabajadores.SingleOrDefault(x => x.Codigo.Equals(codEmpleado));
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

        private void FrmHorarioAsignarBonos_Load(object sender, EventArgs e)
        {
            try
            {

                //this.CargarSalas();

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

                var rpta = Util.ConfirmationMessage("¿Desea salir del mantenimiento de horario mensual?");

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
                //if (dialog.ShowDialog() == DialogResult.OK)
                //{
                //    this.txtArchivo.Text = dialog.FileName;
                //}
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

                //if (this.cboSala.SelectedIndex == 0)
                //{
                //    this.cboSala.Focus();
                //    throw new Exception("Seleccione una sala");
                //}

                //if (this.txtArchivo.Text.Length == 0)
                //{
                //    this.btnArchivo.Focus();
                //    throw new Exception("Seleccione un archivo de carga");
                //}

                #endregion

                Util.PointerLoad(this);

               
                //this.CargarArchivo(this.txtArchivo.Text);

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
        
    }
}
