using System.Collections.Generic;
using System;

namespace ErpCasino.BusinessLibrary.BE
{

    /// <summary>
    /// Calculo de Planilla
    /// </summary>
    public class Planilla
    {

        public int ID { get; set; }
        public int Anho { get; set; }
        public int Mes { get; set; }
        public int Dias { get; set; }
        public int DiasBase { get; set; }
        public int HorasBase { get; set; }
        public double SueldoMinimo { get; set; }
        public double AsignacionFamiliar { get; set; }
        public double PrimerasDosHorasExtras { get; set; }
        public double PosterioresDosHorasExtras { get; set; }
        public double Onp { get; set; }
        public double EsSalud { get; set; }
        public double Nocturno { get; set; }
        public double Feriado { get; set; }

        public List<PlanillaDetalle> Detalles { get; set; }
        public List<PlanillaAsistencia> Asistencias { get; set; }
    }

    public class PlanillaAsistencia
    {
        public int ID { get; set; }
        public string CodigoEmpleado { get; set; }
        public DateTime Fecha { get; set; }
        public int Semana { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraFinal { get; set; }

        #region Asistencias
        public int MinutosAsistenciaTotal
        {
            get
            {
                return this.MinutosAsistenciaNormalTotal 
                    + this.MinutosAsistenciaFeriadoTotal;
            }
        }

        #region Asistencias Normal

        public int MinutosAsistenciaNormalTotal
        {
            get
            {
                return this.MinutosAsistenciaNormalDiurna + this.MinutosAsistenciaNormalNocturna 
                    + this.MinutosAsistenciaNormalDiurnaExtra1 + this.MinutosAsistenciaNormalNocturnaExtra1
                    + this.MinutosAsistenciaNormalDiurnaExtra2 + this.MinutosAsistenciaNormalNocturnaExtra2;
            }
        }

        public int MinutosAsistenciaNormalDiurna { get; set; }
        public int MinutosAsistenciaNormalNocturna { get; set; }
        public int MinutosAsistenciaNormalDiurnaExtra1 { get; set; }
        public int MinutosAsistenciaNormalNocturnaExtra1 { get; set; }
        public int MinutosAsistenciaNormalDiurnaExtra2 { get; set; }
        public int MinutosAsistenciaNormalNocturnaExtra2 { get; set; }

        #endregion

        #region Asistencias Feriado

        public int MinutosAsistenciaFeriadoTotal
        {
            get
            {
                return this.MinutosAsistenciaFeriadoDiurna + this.MinutosAsistenciaFeriadoNocturna
                    + this.MinutosAsistenciaFeriadoDiurnaExtra1 + this.MinutosAsistenciaFeriadoNocturnaExtra1
                    + this.MinutosAsistenciaFeriadoDiurnaExtra2 + this.MinutosAsistenciaFeriadoNocturnaExtra2;
            }
        }

        public int MinutosAsistenciaFeriadoDiurna { get; set; }
        public int MinutosAsistenciaFeriadoNocturna { get; set; }
        public int MinutosAsistenciaFeriadoDiurnaExtra1 { get; set; }
        public int MinutosAsistenciaFeriadoNocturnaExtra1 { get; set; }
        public int MinutosAsistenciaFeriadoDiurnaExtra2 { get; set; }
        public int MinutosAsistenciaFeriadoNocturnaExtra2 { get; set; }

        #endregion

        #endregion

        #region Tardanzas

        public int MinutosTardanzaTotal
        {
            get
            {
                return this.MinutosTardanzaNormalDiurna 
                    + this.MinutosTardanzaNormalNocturna 
                    + this.MinutosTardanzaFeriadoDiurna 
                    + this.MinutosTardanzaFeriadoNocturna;
            }
        }

        #region Tardanzas Normal

        public int MinutosTardanzaNormalTotal
        {
            get
            {
                return this.MinutosTardanzaNormalDiurna
                    + this.MinutosTardanzaNormalNocturna;
            }
        }

        public int MinutosTardanzaNormalDiurna { get; set; }
        public int MinutosTardanzaNormalNocturna { get; set; }

        #endregion

        #region Tardanzas Feriado

        public int MinutosTardanzaFeriadoTotal
        {
            get
            {
                return this.MinutosTardanzaFeriadoDiurna
                    + this.MinutosTardanzaFeriadoNocturna;
            }
        }

        public int MinutosTardanzaFeriadoDiurna { get; set; }
        public int MinutosTardanzaFeriadoNocturna { get; set; }

        #endregion

        #endregion

        #region Inasistencias

        public int MinutosInasistenciaTotal { get; set; }

        #endregion

    }

    /// <summary>
    /// Detalle del calculo de Planilla con las asistencias y costes resumidos.
    /// Ademas del calculo de Sueldos, Descuentos y Bonificaciones.
    /// </summary>
    public class PlanillaDetalle
    {
        public int ID { get; set; }

        #region Empleado
        public string CodigoEmpleado { get; set; }
        public int IdCargo { get; set; }
        #endregion

        #region Sueldo Base
        public double SueldoBase { get; set; }
        public double AsignacionFamiliar { get; set; }
        #endregion

        public double TotalSueldoBase
        {
            get
            {
                return Math.Round(this.SueldoBase + this.AsignacionFamiliar, 2);
            }
        }

        #region Costos y Descuentos

        #region Costos por Minuto
        public double CostoMinutoNormalDiurno { get; set; }
        public double CostoMinutoNormalDiurnoExtras1 { get; set; }
        public double CostoMinutoNormalDiurnoExtras2 { get; set; }
        public double CostoMinutoNormalNocturno { get; set; }
        public double CostoMinutoNormalNocturnoExtras1 { get; set; }
        public double CostoMinutoNormalNocturnoExtras2 { get; set; }
        public double CostoMinutoFeriadoDiurno { get; set; }
        public double CostoMinutoFeriadoDiurnoExtras1 { get; set; }
        public double CostoMinutoFeriadoDiurnoExtras2 { get; set; }
        public double CostoMinutoFeriadoNocturno { get; set; }
        public double CostoMinutoFeriadoNocturnoExtras1 { get; set; }
        public double CostoMinutoFeriadoNocturnoExtras2 { get; set; }

        #endregion

        #region Descuentos por Minuto
        public double DescuentoMinutoTardanzaNormalDiurno { get; set; }
        public double DescuentoMinutoTardanzaNormalNocturno { get; set; }
        public double DescuentoMinutoTardanzaFeriadoDiurno { get; set; }
        public double DescuentoMinutoTardanzaFeriadoNocturno { get; set; }
        public double DescuentoMinutoDominical { get; set; }
        public double DescuentoMinutoInasistencia { get; set; }
        #endregion

        #endregion

        #region Cantidad (Minutos) y Totales (Costos x Cantidad)

        #region Asistencia Normales por Minuto

        #region Horario Normal Diurno
        public int CantidadMinutosAsistenciaNormalDiurno { get; set; }
        public double TotalMinutoAsistenciaNormalDiurno
        {
            get
            {
                return Math.Round(this.CantidadMinutosAsistenciaNormalDiurno * this.CostoMinutoNormalDiurno, 4);
            }
        }
        #endregion

        #region Horario Normal Nocturno
        public int CantidadMinutosAsistenciaNormalNocturno { get; set; }
        public double TotalMinutoAsistenciaNormalNocturno
        {
            get
            {
                return Math.Round(this.CantidadMinutosAsistenciaNormalNocturno * this.CostoMinutoNormalNocturno, 4);
            }
        }
        #endregion

        #region Horario Extras Menor a 2 horas Diurno
        public int CantidadMinutosAsistenciaNormalDiurnoExtras1 { get; set; }
        public double TotalMinutoAsistenciaNormalDiurnoExtras1
        {
            get
            {
                return Math.Round(this.CantidadMinutosAsistenciaNormalDiurnoExtras1 * this.CostoMinutoNormalDiurnoExtras1, 4);
            }
        }
        #endregion

        #region Horario Extras Menor a 2 horas Nocturno
        public int CantidadMinutosAsistenciaNormalNocturnoExtras1 { get; set; }
        public double TotalMinutoAsistenciaNormalNocturnoExtras1
        {
            get
            {
                return Math.Round(this.CantidadMinutosAsistenciaNormalNocturnoExtras1 * this.CostoMinutoNormalNocturnoExtras1, 4);
            }
        }
        #endregion

        #region Horario Extras Mayor a 2 horas Diurno
        public int CantidadMinutosAsistenciaNormalDiurnoExtras2 { get; set; }
        public double TotalMinutoAsistenciaNormalDiurnoExtras2
        {
            get
            {
                return Math.Round(this.CantidadMinutosAsistenciaNormalDiurnoExtras2 * this.CostoMinutoNormalDiurnoExtras2, 4);
            }
        }
        #endregion

        #region Horario Extras Mayor a 2 horas Nocturno
        public int CantidadMinutosAsistenciaNormalNocturnoExtras2 { get; set; }
        public double TotalMinutoAsistenciaNormalNocturnoExtras2
        {
            get
            {
                return Math.Round(this.CantidadMinutosAsistenciaNormalNocturnoExtras2 * this.CostoMinutoNormalNocturnoExtras2, 4);
            }
        }
        #endregion

        public double TotalMinutoAsistenciaNormal
        {
            get
            {
                return Math.Round(this.TotalMinutoAsistenciaNormalDiurno + this.TotalMinutoAsistenciaNormalNocturno + this.TotalMinutoAsistenciaNormalDiurnoExtras1 + this.TotalMinutoAsistenciaNormalNocturnoExtras1 + this.TotalMinutoAsistenciaNormalDiurnoExtras2 + this.TotalMinutoAsistenciaNormalNocturnoExtras2,4);
            }
        }

        #endregion

        #region Tardanza Normales por Minuto

        #region Horario Diurno
        public int CantidadMinutosTardanzaNormalDiurno { get; set; }
        public double TotalMinutoTardanzaNormalDiurno
        {
            get
            {
                return Math.Round(this.CantidadMinutosTardanzaNormalDiurno * this.DescuentoMinutoTardanzaNormalDiurno, 4);
            }
        }
        #endregion

        #region Horario Nocturno
        public int CantidadMinutosTardanzaNormalNocturno { get; set; }
        public double TotalMinutoTardanzaNormalNocturno
        {
            get
            {
                return Math.Round(this.CantidadMinutosTardanzaNormalNocturno * this.DescuentoMinutoTardanzaNormalNocturno, 4);
            }
        }
        #endregion

        public double TotalMinutoTardanzaNormal
        {
            get
            {
                return Math.Round(this.TotalMinutoTardanzaNormalDiurno + this.TotalMinutoTardanzaNormalNocturno, 4);
            }
        }

        #endregion

        #region Asistencia Feriados por Minuto

        #region Horario Feriado Diurno
        public int CantidadMinutosAsistenciaFeriadoDiurno { get; set; }
        public double TotalMinutoAsistenciaFeriadoDiurno
        {
            get
            {
                return Math.Round(this.CantidadMinutosAsistenciaFeriadoDiurno * this.CostoMinutoFeriadoDiurno, 4);
            }
        }
        #endregion

        #region Horario Feriado Nocturno
        public int CantidadMinutosAsistenciaFeriadoNocturno { get; set; }
        public double TotalMinutoAsistenciaFeriadoNocturno
        {
            get
            {
                return Math.Round(this.CantidadMinutosAsistenciaFeriadoNocturno * this.CostoMinutoFeriadoNocturno, 4);
            }
        }
        #endregion

        #region Horario Extras Menor a 2 horas Diurno
        public int CantidadMinutosAsistenciaFeriadoDiurnoExtras1 { get; set; }
        public double TotalMinutoAsistenciaFeriadoDiurnoExtras1
        {
            get
            {
                return Math.Round(this.CantidadMinutosAsistenciaFeriadoDiurnoExtras1 * this.CostoMinutoFeriadoDiurnoExtras1, 4);
            }
        }
        #endregion

        #region Horario Extras Menor a 2 horas Nocturno
        public int CantidadMinutosAsistenciaFeriadoNocturnoExtras1 { get; set; }
        public double TotalMinutoAsistenciaFeriadoNocturnoExtras1
        {
            get
            {
                return Math.Round(this.CantidadMinutosAsistenciaFeriadoNocturnoExtras1 * this.CostoMinutoFeriadoNocturnoExtras1, 4);
            }
        }
        #endregion

        #region Horario Extras Mayor a 2 horas Diurno
        public int CantidadMinutosAsistenciaFeriadoDiurnoExtras2 { get; set; }
        public double TotalMinutoAsistenciaFeriadoDiurnoExtras2
        {
            get
            {
                return Math.Round(this.CantidadMinutosAsistenciaFeriadoDiurnoExtras2 * this.CostoMinutoFeriadoDiurnoExtras2, 4);
            }
        }
        #endregion

        #region Horario Extras Mayor a 2 horas Nocturno
        public int CantidadMinutosAsistenciaFeriadoNocturnoExtras2 { get; set; }
        public double TotalMinutoAsistenciaFeriadoNocturnoExtras2
        {
            get
            {
                return Math.Round(this.CantidadMinutosAsistenciaFeriadoNocturnoExtras2 * this.CostoMinutoFeriadoNocturnoExtras2, 4);
            }
        }
        #endregion

        public double TotalMinutoAsistenciaFeriado
        {
            get
            {
                return Math.Round(this.TotalMinutoAsistenciaFeriadoDiurno + this.TotalMinutoAsistenciaFeriadoNocturno + this.TotalMinutoAsistenciaFeriadoDiurnoExtras1 + this.TotalMinutoAsistenciaFeriadoNocturnoExtras1 + this.TotalMinutoAsistenciaFeriadoDiurnoExtras2 + this.TotalMinutoAsistenciaFeriadoNocturnoExtras2, 4);
            }
        }

        #endregion

        #region Tardanza Feriados por Minuto

        #region Horario Diurno
        public int CantidadMinutosTardanzaFeriadoDiurno { get; set; }
        public double TotalMinutoTardanzaFeriadoDiurno
        {
            get
            {
                return Math.Round(this.CantidadMinutosTardanzaFeriadoDiurno * this.DescuentoMinutoTardanzaFeriadoDiurno, 4);
            }
        }
        #endregion

        #region Horario Nocturno
        public int CantidadMinutosTardanzaFeriadoNocturno { get; set; }
        public double TotalMinutoTardanzaFeriadoNocturno
        {
            get
            {
                return Math.Round(this.CantidadMinutosTardanzaFeriadoNocturno * this.DescuentoMinutoTardanzaFeriadoNocturno, 4);
            }
        }
        #endregion

        public double TotalMinutoTardanzaFeriado
        {
            get
            {
                return Math.Round(this.TotalMinutoTardanzaFeriadoDiurno + this.TotalMinutoTardanzaFeriadoNocturno, 4);
            }
        }

        #endregion

        #region Insistencia por Minuto

        public int CantidadMinutosInasistencia { get; set; }

        public double TotalMinutoInasistencia
        {
            get
            {
                return Math.Round(this.CantidadMinutosInasistencia * this.DescuentoMinutoInasistencia, 4);
            }
        }

        #endregion

        #endregion

        #region Bonos Sueldo

        #region Bono Nocturno

        #region Horario Normal
        public int CantidadMinutosBonoNocturnoNormal
        {
            get
            {
                return this.CantidadMinutosAsistenciaNormalNocturno;
            }
        }
        public double TotalMinutoBonoNocturnoNormal
        {
            get
            {
                double cantidadMinutosNormalNocturno = this.CantidadMinutosAsistenciaNormalNocturno;
                double costoDiurno = Math.Round(cantidadMinutosNormalNocturno * this.CostoMinutoNormalDiurno, 4);
                double costoNocturno = this.TotalMinutoAsistenciaNormalNocturno;
                
                return Math.Round(costoNocturno - costoDiurno, 4);
            }
        }
        #endregion

        #region Horario Feriado
        public int CantidadMinutosBonoNocturnoFeriado
        {
            get
            {
                return this.CantidadMinutosAsistenciaFeriadoNocturno;
            }
        }

        public double TotalMinutoBonoNocturnoFeriado
        {
            get
            {
                double cantidadMinutosFeriadoNocturno = this.CantidadMinutosAsistenciaFeriadoNocturno;
                double costoDiurno = Math.Round(cantidadMinutosFeriadoNocturno * this.CostoMinutoFeriadoDiurno, 4);
                double costoNocturno = this.TotalMinutoAsistenciaFeriadoNocturno;

                return Math.Round(costoNocturno - costoDiurno, 4);
            }
        }
        #endregion

        public int CantidadMinutosBonoNocturno
        {
            get
            {
                return this.CantidadMinutosAsistenciaNormalNocturno + this.CantidadMinutosAsistenciaFeriadoNocturno;
            }
        }

        public double TotalMinutoBonoNocturno
        {
            get
            {
                return Math.Round(this.TotalMinutoBonoNocturnoNormal + this.TotalMinutoBonoNocturnoFeriado, 4);
            }
        }
        #endregion

        #region Bono Horas Extras

        #region Horario Normal
        /// <summary>
        /// Cantidad de minutos totales del bono de las primeras 2 horas extras en horario normal
        /// </summary>
        public int CantidadMinutosBonoHorasExtrasNormal1
        {
            get
            {
                return this.CantidadMinutosAsistenciaNormalDiurnoExtras1 + this.CantidadMinutosAsistenciaNormalNocturnoExtras1;
            }
        }

        /// <summary>
        /// Monto total del bono de las primeras 2 horas extras en horario normal
        /// </summary>
        public double TotalMinutoBonoHorasExtrasNormal1
        {
            get
            {
                return Math.Round(this.TotalMinutoAsistenciaNormalDiurnoExtras1 + this.TotalMinutoAsistenciaNormalNocturnoExtras1, 4);
            }
        }

        /// <summary>
        /// Cantidad de minutos totales del bono de las posteriores 2 horas extras en horario normal
        /// </summary>
        public int CantidadMinutosBonoHorasExtrasNormal2
        {
            get
            {
                return this.CantidadMinutosAsistenciaNormalDiurnoExtras2 + this.CantidadMinutosAsistenciaNormalNocturnoExtras2;
            }
        }

        /// <summary>
        /// Monto total del bono de las posteriores 2 horas extras en horario normal
        /// </summary>
        public double TotalMinutoBonoHorasExtrasNormal2
        {
            get
            {
                return Math.Round(this.TotalMinutoAsistenciaNormalDiurnoExtras2 + this.TotalMinutoAsistenciaNormalNocturnoExtras2, 4);
            }
        }
        #endregion

        #region Horario Feriado
        /// <summary>
        /// Cantidad de minutos totales del bono de las primeras 2 horas extras en horario feriado
        /// </summary>
        public int CantidadMinutosBonoHorasExtrasFeriado1
        {
            get
            {
                return this.CantidadMinutosAsistenciaFeriadoDiurnoExtras1 + this.CantidadMinutosAsistenciaFeriadoNocturnoExtras1;
            }
        }

        /// <summary>
        /// Monto total del bono de las primeras 2 horas extras en horario feriado
        /// </summary>
        public double TotalMinutoBonoHorasExtrasFeriado1
        {
            get
            {
                return Math.Round(this.TotalMinutoAsistenciaFeriadoDiurnoExtras1 + this.TotalMinutoAsistenciaFeriadoNocturnoExtras1, 4);
            }
        }

        /// <summary>
        /// Cantidad de minutos totales del bono de las posteriores 2 horas extras en horario feriado
        /// </summary>
        public int CantidadMinutosBonoHorasExtrasFeriado2
        {
            get
            {
                return this.CantidadMinutosAsistenciaFeriadoDiurnoExtras2 + this.CantidadMinutosAsistenciaFeriadoNocturnoExtras2;
            }
        }

        /// <summary>
        /// Monto total del bono de las posteriores 2 horas extras en horario feriado
        /// </summary>
        public double TotalMinutoBonoHorasExtrasFeriado2
        {
            get
            {
                return Math.Round(this.TotalMinutoAsistenciaFeriadoDiurnoExtras2 + this.TotalMinutoAsistenciaFeriadoNocturnoExtras2, 4);
            }
        }
        #endregion

        public int CantidadMinutosBonoHorasExtras
        {
            get
            {
                return this.CantidadMinutosBonoHorasExtrasNormal1 + this.CantidadMinutosBonoHorasExtrasNormal2 + CantidadMinutosBonoHorasExtrasFeriado1 + CantidadMinutosBonoHorasExtrasFeriado2;
            }
        }

        public double TotalMinutoBonoHorasExtras
        {
            get
            {
                return Math.Round(this.TotalMinutoBonoHorasExtrasNormal1 + this.TotalMinutoBonoHorasExtrasNormal2 + this.TotalMinutoBonoHorasExtrasFeriado1 + this.TotalMinutoBonoHorasExtrasFeriado2, 4);
            }
        }

        #endregion

        #region Bono Feriado

        #region Horario Diurno
        public int CantidadMinutosBonoFeriadoDiurno
        {
            get
            {
                return this.CantidadMinutosAsistenciaFeriadoDiurno;
            }
        }

        public double TotalMinutoBonoFeriadoDiurno
        {
            get
            {
                return Math.Round(this.CantidadMinutosAsistenciaFeriadoDiurno * this.CostoMinutoFeriadoDiurno, 4);
            }
        }
        #endregion

        #region Horario Nocturno
        public int CantidadMinutosBonoFeriadoNocturno
        {
            get
            {
                return this.CantidadMinutosAsistenciaFeriadoNocturno;
            }
        }

        public double TotalMinutoBonoFeriadoNocturno
        {
            get
            {
                return Math.Round(this.CantidadMinutosAsistenciaFeriadoNocturno * this.CostoMinutoFeriadoNocturno, 4);
            }
        }
        #endregion

        public int CantidadMinutosBonoFeriado
        {
            get
            {
                return this.CantidadMinutosAsistenciaFeriadoDiurno + this.CantidadMinutosAsistenciaFeriadoNocturno;
            }
        }

        public double TotalMinutoBonoFeriado
        {
            get
            {
                return Math.Round(this.TotalMinutoBonoFeriadoDiurno + this.TotalMinutoBonoFeriadoNocturno, 4);
            }
        }

        #endregion

        public double TotalBono
        {
            get
            {
                return Math.Round(this.TotalMinutoBonoNocturno 
                    + this.TotalMinutoBonoHorasExtras 
                    + this.TotalMinutoBonoFeriado, 4);
            }
        }

        #endregion

        #region Descuentos Sueldo

        #region Tardanzas

        #region Horario Normal

        public int CantidadMinutosDescuentoTardanzaNormal
        {
            get
            {
                return this.CantidadMinutosTardanzaNormalDiurno + this.CantidadMinutosTardanzaNormalNocturno;
            }
        }

        public double TotalMinutoDescuentoTardanzaNormal
        {
            get
            {
                return this.TotalMinutoTardanzaNormal;
            }
        }

        #endregion

        #region Horario Feriado

        public int CantidadMinutosDescuentoTardanzaFeriado
        {
            get
            {
                return this.CantidadMinutosTardanzaFeriadoDiurno + this.CantidadMinutosTardanzaFeriadoNocturno;
            }
        }

        public double TotalMinutoDescuentoTardanzaFeriado
        {
            get
            {
                return this.TotalMinutoTardanzaFeriado;
            }
        }

        #endregion

        public int CantidadMinutosDescuentoTardanza
        {
            get
            {
                return this.CantidadMinutosDescuentoTardanzaNormal + this.CantidadMinutosDescuentoTardanzaFeriado;
            }
        }

        public double TotalMinutoDescuentoTardanza
        {
            get
            {
                return Math.Round(this.TotalMinutoDescuentoTardanzaNormal + this.TotalMinutoDescuentoTardanzaFeriado, 4);
            }
        }

        #endregion

        #region Inasistencias

        public int CantidadMinutosDescuentoInasistencia
        {
            get
            {
                return this.CantidadMinutosInasistencia;
            }
        }

        public double TotalDescuentoInasistencia
        {
            get
            {
                return this.TotalMinutoInasistencia;
            }
        }

        #endregion

        public double TotalDescuento
        {
            get
            {
                return Math.Round(this.TotalMinutoDescuentoTardanza + this.TotalDescuentoInasistencia, 4);
            }
        }

        #endregion

        #region Subsidio por Descanso Medico

        public double TotalSubsidio { get; set; } = 0.0;

        #endregion

        #region Movilidad por Translado

        public double TotalMovilidad { get; set; } = 0.0;

        #endregion

        public double TotalSueldoBruto
        {
            get
            {
                double totalBruto = 0.0;

                totalBruto += this.TotalSueldoBase;
                totalBruto += this.TotalBono - this.TotalDescuento;
                totalBruto += this.TotalSubsidio + this.TotalMovilidad;

                return Math.Round(totalBruto);
            }
        }

        #region Pensiones

        #region SNP
        public bool Snp { get; set; }
        private double snpTotal;
        public double SnpTotal
        {
            get
            {
                return (Snp == true ? snpTotal : 0.0);
            }
            set
            {
                snpTotal = value;
            }
        }
        #endregion

        #region AFP
        public Afp Afp { get; set; }
        public string AfpTipo { get; set; }
        public double AfpAporteObligatorio { get; set; }
        public double AfpAporteVoluntario { get; set; }
        public double AfpSeguro { get; set; }
        public double AfpComision { get; set; }
        public double AfpTotal
        {
            get
            {
                double afpTotal = this.AfpAporteObligatorio + this.AfpAporteVoluntario + this.AfpSeguro + this.AfpComision;
                return (Snp == false ? afpTotal : 0.0);
            }
        }
        #endregion
    
        public double PensionTotal
        {
            get
            {
                return this.SnpTotal + this.AfpTotal;
            }
        }

        #endregion

        #region Impuestos
        public double ImpuestoTotal { get; set; }
        #endregion

        public double TotalSueldoNeto
        {
            get
            {
                return Math.Round(this.TotalSueldoBruto - this.PensionTotal - this.ImpuestoTotal, 2);
            }
        }

        #region Retencion Judicial
        public double RetencionJudicialPorcentual { get; set; }
        public double RetencionJudicialNominal { get; set; }
        public double RetencionJudicialTotal
        {
            get
            {
                double total = this.RetencionJudicialNominal;
                if (this.RetencionJudicialPorcentual > 0.0)
                {
                    double factor = this.RetencionJudicialPorcentual / 100;
                    double pension = this.PensionTotal;
                    double sueldo = this.TotalSueldoBruto;
                    total = (sueldo - pension) * factor;
                }
                return total;
            }
        }
        #endregion

        #region Adelanto
        public double AdelantoEfectivo { get; set; }
        public double AdelantoBanco { get; set; }
        public double AdelantoTotal
        {
            get
            {
                return this.AdelantoEfectivo + this.AdelantoBanco;
            }
        }
        #endregion

        #region Prestamo
        public double PrestamoTotal { get; set; }
        #endregion

        public double TotalDeduccion
        {
            get
            {
                return Math.Round(this.RetencionJudicialTotal + this.AdelantoTotal + this.PrestamoTotal, 2);
            }
        }


        public double TotaPago
        {
            get
            {
                return Math.Round(this.TotalSueldoNeto - this.TotalDeduccion, 2);
            }
        }

        
        public double EsSaludTotal { get; set; }
    }

}
